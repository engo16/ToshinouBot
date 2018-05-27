using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace ToshinouBot.Modules
{
    public class GithubModule : ModuleBase<SocketCommandContext>
    {
        [Command("github")]
        public async Task Github(string branch = "")
        {
            var embed = new Discord.EmbedBuilder();
            string Branch = branch.ToLower();
            embed.WithTitle("Github");

            if (Branch == "master") {
                embed.AddInlineField("Master", "https://github.com/Gagong/Toshinou-Revamped/tree/master");
            } else if (Branch == "beta") {
                embed.AddInlineField("Beta", "https://github.com/Gagong/Toshinou-Revamped/tree/beta");
            } else {
                embed.AddInlineField("Master (Recommended)", "https://github.com/Gagong/Toshinou-Revamped/tree/master");
                embed.AddInlineField("Beta", "https://github.com/Gagong/Toshinou-Revamped/tree/beta");
            }
            embed.Color = Color.Green;

            await ReplyAsync("", false, embed);
        }
    }
}
