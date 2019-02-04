using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmotoad.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            var embed = new EmbedBuilder();
            embed.WithColor(Color.Blue);
            embed.WithTitle("**Commands:**");
            embed.AddField($"{Program.Prefix}help", "Shows a list of commands", false);
            embed.AddField($"{Program.Prefix}ping", "Displays the Bot's latency", false);
            embed.AddField($"{Program.Prefix}test", "Makes sure the bot is working", false);
            embed.AddField($"{Program.Prefix}warn <user> <reason>", "Warns a user if they have broken a rule.", false);
            embed.AddField($"{Program.Prefix}kick <user> <reason>", "Kicks a user.", false);
            embed.AddField($"{Program.Prefix}projects" "Displays projects by KSP-DDR", false);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
