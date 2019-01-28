using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DeltaBot
{
    class DeltaBot
    {
        string filePath = File.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        bool LogExists;
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
        
        private Task VerifyLogFile()
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath + "\DeltaBot.log");
                Console.WriteLine(Log("Log File Created"));
                LogExists = true;
            }
        }
        private Task Log(LogMessage msg)
        {
            TextWriter lw = new StreamWriter(filePath + "DeltaBot.log", true);
            Console.WriteLine(msg.ToString());
            msg.toString().LogWrite(filePath);
            return Task.CompletedTask;
        }
        private async Task MessageRecieved(SocketMessage message)
        {
            
        }
        
        public static LogWrite(this string value, string fileName)
        {
            File.WriteAllText(fileName, value);
        }
    }
}
