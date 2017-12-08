using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        public async Task TestCommand()
        {
            await Context.Channel.SendMessageAsync("Success!");
        }

        [Command("Help")]
        public async Task HelpCommand()
        {
            await Context.Channel.SendMessageAsync("The Commands are `&test`(displays message if bot is working), `&testname(displatys your username), and `&testrole`(displays your role).");
        }

        [Command("Name")]
        public async Task UserNameCommand(IGuildUser user)
        {
            await Context.Channel.SendMessageAsync(user.ToString());
        }

        [Command("Role")]
        public Task UserRoleCommand(SocketGuildUser User= null)
        {
            User = User ?? Context.User as SocketGuildUser;
            var role = User.Guild.Roles.FirstOrDefault();
            return ReplyAsync($"{User.Mention} Role is {role.Mention}");
        }

    }
}
