using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using System.Linq;
using ToshinouBot.Services;
using System.Threading;
using ToshinouBot.Enums;

namespace ToshinouBot.Controllers
{
    class MainHandler
    {
        private readonly DarkOrbitService darkOrbitService;
        private Timer updateTimer;

        public DiscordSocketClient Client;

        public MainHandler(DiscordSocketClient Discord, DarkOrbitService darkOrbitService) {
            Discord.Ready += OnReadyUpdateBrahDuh;
            Discord.GuildMemberUpdated += OnBrahDuhUpdated;
            Client = Discord;

            this.darkOrbitService = darkOrbitService;
            this.updateTimer = new Timer(async (state) =>
            {
                var updated = await this.darkOrbitService.CheckUpdateAsync();
                if (!updated) return; // if not updated -> do nothing

                await this.SendMessage("@everyone Darkorbit pushed a new update. Bot is **Offline!**\nPlease be patient while the Developers are working on the update!", Toshinou.GeneralNews);
                await Client.SetGameAsync("Offline");
            }, null, 5000, 1000 * 60 * 5); // Checks every 5 mins

            var thread = new Thread(async () =>
            {
                await this.HandleInput();
            });
            thread.Start();
        }

        private async Task SendMessage(string message, Toshinou channel)
        {
            if(this.Client.GetChannel((ulong)channel) is IMessageChannel txtChannel)
                await txtChannel.SendMessageAsync(message);
        }

        private async Task<string> GetConsoleInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }

        private async Task HandleInput()
        {
            var message = await this.GetConsoleInputAsync();
            await this.SendMessage(message, Toshinou.GeneralEn);
            await this.HandleInput();
        }

        private async Task OnReadyUpdateBrahDuh() {
            SocketGuild guild = Client.GetGuild(434604419255107586);
            SocketRole role = guild.GetRole(435902767358410762);
            SocketGuildUser user = guild.GetUser(427905551763111950);

            if (!user.Roles.Contains(role)) {
                Console.WriteLine("Updated BruhDuh");
                await user.AddRoleAsync(role);
            }
        }

        private async Task OnBrahDuhUpdated(SocketGuildUser before, SocketGuildUser after)
        {
            if (after.Id == 427905551763111950)
            {
                SocketGuild guild = Client.GetGuild(434604419255107586);
                SocketRole role = guild.GetRole(435902767358410762);

                if (!after.Roles.Contains(role))
                {
                    Console.WriteLine("Updated BruhDuh");
                    await after.AddRoleAsync(role);
                }
            }
        }
    }
}
