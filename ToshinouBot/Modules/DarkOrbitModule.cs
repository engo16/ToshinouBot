using Discord.Commands;
using Discord;
using System.Threading.Tasks;
using ToshinouBot.Enums;
using ToshinouBot.Services;

namespace ToshinouBot.Modules
{
    public class DarkOrbitModule : ModuleBase<SocketCommandContext>
    {
        private readonly DarkOrbitService darkOrbitService;

        public DarkOrbitModule(DarkOrbitService darkOrbitService)
        {
            this.darkOrbitService = darkOrbitService;
        }

        [Command("checkUpdate", RunMode=RunMode.Async)]
        public async Task CheckUpdate()
        {
            var updated = await this.darkOrbitService.CheckUpdateAsync();
            if (!updated)
            {
                await this.ReplyAsync("Bot Status: **Online!**");
                return;
            }

            if (Context.Client.GetChannel((ulong)Toshinou.GeneralNews) is IMessageChannel channel)
                await channel.SendMessageAsync("@everyone Darkorbit pushed a new update. Bot is **Offline**!");

            await this.ReplyAsync("Please be patient while the Developers are working on the update!");
            await Context.Client.SetGameAsync("Offline");
        }
    }
}
