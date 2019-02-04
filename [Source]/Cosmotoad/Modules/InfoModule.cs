using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Cosmotoad.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("Info")]
        public async Task Info()
        {
            var eb = new EmbedBuilder();
            eb.WithColor(Color.Blue);
            eb.WithTitle("**Other Projects by KSP-DDR:**");
            eb.AddField("Terras Ignotas", "[A WIP interstellar planet](https://forum.kerbalspaceprogram.com/index.php?/topic/179652-wip13x-15x-terras-ignotas-v011-open-alpha-bohr/)", false);
            //eb.AddField("Turbindrive", "A point-to-point jump drive with no beacons required!", false);
            eb.AddField("Asterios Explorations", "Stockalike Soviet Probes", false);
            eb.AddField("Ramses System Overhaul", "It makes the planet egyptian:tm:", false);
            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
