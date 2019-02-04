using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmotoad.Modules
{
    public class PingModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            string ping = Context.Client.Latency.ToString();
            var eb = new EmbedBuilder();
            eb.WithTitle("Latency");
            eb.WithColor(Color.Orange);
            ed.AddField("", $"My ping is {ping} ms. :ping_pong:")
            await Context.Channel.SendMessageAsync("My ping is " + ping + " ms. :ping_pong:");
        }
    }
}
