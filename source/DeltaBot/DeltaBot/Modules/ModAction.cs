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
    public class ModAction : ModuleBase<SocketCommandContext>
    {
        string _reason;

        [Command("Warn")]
        [RequireUserPermission(GuildPermission.ManageGuild)]
        public async Task Warn(IGuildUser user, string reason)
        {
            _reason = String.Format($"You have been warned for the following reason: {reason}");
            await UserExtensions.SendMessageAsync(user, _reason);
            await Context.Channel.SendMessageAsync($":white_check_mark: **{user}** has been warned!");
        }

        [Command("Kick")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task Kick(IGuildUser user, [Remainder]string reason)
        {
            await user.KickAsync(reason);
            //_reason = String.Format($"You have been kicked for the following reason: '{reason}'");
            //await UserExtensions.SendMessageAsync(user, _reason);
            await Context.Channel.SendMessageAsync($":white_check_mark: **{user}** has been Kicked!");
        }

        [Command("Ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task Ban(IGuildUser user, [Remainder]string reason, int banMins = 1)
        {
            await user.Guild.AddBanAsync(user, banMins);
            //_reason = String.Format($"You have been banned for the following reason: '{reason}'");
            //await UserExtensions.SendMessageAsync(user, _reason);
            await Context.Channel.SendMessageAsync($":white_check_mark: **{user}** has been Banned!");
        }
    }
}
