using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmotoad.Modules
{
    public class TestModule : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        public async Task Test()
        {
            await Context.Channel.SendMessageAsync("I'm alive so far!");
        }
    }
}
