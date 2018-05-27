using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace ToshinouBot.Modules
{
    public class GithubModule : ModuleBase<SocketCommandContext>
    {
        [Command("github")]
        public async Task Github()
        {
            var embed = new Discord.EmbedBuilder();
            embed.WithTitle("Github");
            embed.AddInlineField("Master (Recommended)", "https://github.com/Gagong/Toshinou-Revamped/tree/master");
            embed.AddInlineField("Beta", "https://github.com/Gagong/Toshinou-Revamped/tree/beta");
            embed.Color = Color.Green;

            await ReplyAsync("", false, embed);
        }
        
    }
}
