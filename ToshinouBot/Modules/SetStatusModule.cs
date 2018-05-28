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
            string status = param.ToLower();
            if (status == "offline") {
                await Context.Client.SetGameAsync("Offline");
                await this.ReplyAsync("Set status to: **Offline!**");
            } else if (status == "online") {
                await Context.Client.SetGameAsync("Online");
                await this.ReplyAsync("Set status to: **Online!**");
            } else {
                await this.ReplyAsync("Error: Invalid parameter; \nAccepts: Offline, Online");
            }
            
        }
    }
}
