/*
    Cosmotoad is a Discord bot built in C# using Discord.NET v2.0.1.
    It is based on DiscordBotBase by foxbot.
    Terras Ignotas is licensed MIT by KSP-DDR c.2017-2019
    Turbindrive is licensed MIT by DeltaDizzy and Mrcarrot1 c.2019
    Ramses System Overhaul is copyrighted by NickRoss120 c.2018-2019, All Rights Reserved
*/﻿

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DeltaBot
{
    class Program
    {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter.GetResult();
        
        private DiscrdSocketClient _client;
        private IConfiguration _config;
        
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _config = BuildConfig();
            
            var services = ConfigureServices();
            services.GetRequiredService<LogService>();
            await services.GetRequiedService<CommandHandlingService>().InitializeAsync(services);
            
            await _client.LoginAsync(TokenType.Bot _config["token"]);
            await _client.StartAsync();
            
            await Task.Delay(-1);
        }
        
        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                //Base Services
                .AddSingleton(_client)
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                //Logging
                .AddLogging()
                .AddSingleton<LogService>()
                //Config
                .AddSingleton(_config)
                //Add additional services here
                .BuildServiceProvider();
        }
        
        private IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.cosnet")
                .Build();
        }
    }
}
