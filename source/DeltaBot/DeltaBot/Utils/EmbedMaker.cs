using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DeltaBot.Utils
{
    public class EmbedHelper
    {
        public void Factory(Color color, string title, List<EmbedField> fields)
        {
            var embed = new EmbedBuilder();
            embed.WithColor(color
            embed.WithTitle("**Commands:**");
            embed.AddField("&help", "Shows a list of commands", false);
            embed.AddField("&ping", "Displays the Bot's latency", false);
            embed.AddField("&test", "Makes sure the bot is working", false);
            embed.AddField("&warn <user> <reason>", "Warns a user if they have broken a rule.", false);
            embed.AddField("&kick <user> <reason>", "Kicks a user.", false);
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
