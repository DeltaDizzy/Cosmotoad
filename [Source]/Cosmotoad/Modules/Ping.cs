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
            int pingtime = Context.Client.Latency;
            string ping = pingtime.ToString();
            await Context.Channel.SendMessageAsync("My ping is " + ping + " ms. :ping_pong:");
        }
    }
}
