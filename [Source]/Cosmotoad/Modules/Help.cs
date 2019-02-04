using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            var embed = new EmbedBuilder();
            embed.WithColor(Color.Blue);
            embed.WithTitle("**Commands:**");
            embed.AddField("&help", "Shows a list of commands", false);
            embed.AddField("&ping", "Displays the Bot's latency", false);
            embed.AddField("&test", "Makes sure the bot is working", false);
            embed.AddField("&warn <user> <reason>", "Warns a user if they have broken a rule.", false);
            embed.AddField("&kick <user> <reason>", "Kicks a user.", false);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
