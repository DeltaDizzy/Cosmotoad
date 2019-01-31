using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Discord;
using Discord.Commands;
using Discord.webSocket;

namespace Cosmotoad.Services
{
    public class LogService
    {
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly ILoggerFactory _logFac;
        private readonly ILogger _discLog;
        private readonly ILogger _cmdLog;
        
        public LogService(DiscordSocketClient discord, CommandService commands, ILoggerFactory logFactory)
        {
            _discord = discord;
            _commands = commands;
            
            _logFac = ConfigureLogging(logFactory);
            _discLog = _logFac.CreateLogger("discord");
            _cmdLog = _logFac.CreateLogger("commands");
            
            _discord.Log += LogDiscord;
            _commands.Log += LogCommand;
        }
        
        private ILoggerFactory ConfigureLogging(ILoggerFactory fac)
        {
            fac.AddConsole();
            return fac;
        }
        
        private Task LogDiscord(LogMessage msg)
        {
            _discLog.Log(
                LogLevelFromSeverity(msg.Severity),
                0,
                msg,
                msg.Exception,
                (_1, _2) => msg.ToString(prependTimestamp: false));
            return Task.CompletedTask;
        }
        
        private Task LogCommand(LogMessage msg)
        {
            if(msg.Exception is CommandException cex)
            {
                var _ = cex.Context.Channel.SendMessageAsync($"Error: {cex.Message}");
            }
            
            _cmdLog.Log(
                LogLevelFromSeverity(msg.Severity),
                0,
                msg,
                msg.Exception,
                (_1, _2) => msg.ToString(prependTimestamp: false));
            return Task.CompletedTask;
        }
        
        private static LogLevelFromSeverity(LogSeverity sev)
            => (LogLevel)(Math.Abs((int)sev - 5));
    }
}
