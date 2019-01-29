﻿using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DeltaBot
{
    class Program
    {
        string tokenpath = AppDomain.CurrentDomain.BaseDirectory + "tokenbeta.txt";
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        private CommandHandler _handler; 
        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += MessageRecieved;
            string token = "";
            if (File.Exists(tokenpath))
            {
                token = File.ReadAllText(tokenpath);
            }
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            _handler = new CommandHandler(client);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

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
