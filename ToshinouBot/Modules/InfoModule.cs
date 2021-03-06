﻿using System.Threading.Tasks;
using Discord.Commands;

namespace ToshinouBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
    [Command("info")]
    public Task Info()
        => ReplyAsync(
            $"Hello, I am a bot called **{Context.Client.CurrentUser.Username}** written in Discord.Net v.1.0.2!\n");
    }
}
