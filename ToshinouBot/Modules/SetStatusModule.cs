using System.Threading.Tasks;
using Discord.Commands;

namespace ToshinouBot.Modules
{
    public class SetStatusModule : ModuleBase<SocketCommandContext>
    {
        [Command("setStatus")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task SetStatus(string param)
        {
            var status = param.ToLower();
            switch (status)
            {
                case "offline":
                    await Context.Client.SetGameAsync("Offline");
                    await this.ReplyAsync("Set status to: **Offline!**");
                    break;
                case "online":
                    await Context.Client.SetGameAsync("Online");
                    await this.ReplyAsync("Set status to: **Online!**");
                    break;
                default:
                    await this.ReplyAsync("Error: Invalid parameter; \nAccepts: Offline, Online");
                    break;
            }
        }
    }
}
