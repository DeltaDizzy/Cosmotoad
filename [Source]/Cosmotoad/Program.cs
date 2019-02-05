using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmotoad
{
    class Program
    {
        private readonly DiscordShardedClient _client;
        private CommandService _service = new CommandService();
        private readonly IServiceCollection _map = new ServiceCollection();
        string tokenpath = AppDomain.CurrentDomain.BaseDirectory + "tokenbeta.tok";
        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }


        private Program()
        {
            _client = new DiscordShardedClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 50
            });
        }
        public async Task MainAsync()
        {
            _client.Log += Logger;
            await CommandStart();
            string token = "";
            if (File.Exists(tokenpath))
            {
                token = File.ReadAllText(tokenpath);
            }
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            await Task.Delay(-1);

        }

        IServiceProvider _services;

        private async Task CommandStart()
        {
            _services = _map.BuildServiceProvider();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null)
            {
                return;
            }

            var context = new ShardedCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasCharPrefix('&', ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        //TODO: Write one of these yourselves
        private static Task Logger(LogMessage message)
        {
            var cc = Console.ForegroundColor;
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message}");
            Console.ForegroundColor = cc;

            // If you get an error saying 'CompletedTask' doesn't exist,
            // your project is targeting .NET 4.5.2 or lower. You'll need
            // to adjust your project's target framework to 4.6 or higher
            // (instructions for this are easily Googled).
            // If you *need* to run on .NET 4.5 for compat/other reasons,
            // the alternative is to 'return Task.Delay(0);' instead.
            return Task.CompletedTask;
        }
    }
}
