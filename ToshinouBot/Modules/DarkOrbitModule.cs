using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToshinouBot.Enums;
using ToshinouBot.Services;

namespace ToshinouBot.Modules
{
    public class DarkOrbitModule : ModuleBase<SocketCommandContext>
    {
        readonly DarkOrbitService darkOrbitService;

        public DarkOrbitModule(DarkOrbitService darkOrbitService)
        {
            this.darkOrbitService = darkOrbitService;
        }

        [Command("checkUpdate", RunMode=RunMode.Async)]
        public async Task CheckUpdate()
        {
            var updated = await this.darkOrbitService.CheckUpdateAsync();
            if (updated) {
                IMessageChannel channel = Context.Client.GetChannel((ulong)Toshinou.GeneralNews) as IMessageChannel;
                await channel.SendMessageAsync("@everyone Darkorbit pushed a new update. Bot is offline!");
                await this.ReplyAsync("A new game version has been released! Fucking cyka blyat bugpoint");
                await Context.Client.SetGameAsync("Offline");
            }
            else {
                await this.ReplyAsync("The game version is the same.");
            }
                
            
        }
    }
}
