﻿using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DeltaBot
{
    public class Program
    {
        static void Main(string[] args)
       => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task StartAsync()
        {
            

            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, "Mzg4MDgwMDgzODA3NjMzNDA4.DQn2KA.88B53zhX3nb-LJDnhUlWS2f6FrE");

            await _client.StartAsync();

            _handler = new CommandHandler(_client); 

            await Task.Delay(-1);
        }
    }
}