using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DeltaBot
{
    class DeltaBot
    {
        public static void Main(string[] args)
            => new DeltaBot().MainAsync().GetAwaiter().GetResult();
        private CommandHandler _handler; 
        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += MessageRecieved;
            string token = "";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            _handler = new CommandHandler(client);

            await Task.Delay(-1);

        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageRecieved(SocketMessage message)
        {
            
        }
    }
}
