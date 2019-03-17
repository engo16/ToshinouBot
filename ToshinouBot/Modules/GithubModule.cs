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
            branch = branch.ToLower();
            //embed.WithTitle("Github");

            switch (branch)
            {
                case "master":
                    embed.AddInlineField("Master", "https://github.com/Gagong/Toshinou-Revamped/tree/master");
                    break;
                case "beta":
                    embed.AddInlineField("Beta", "https://github.com/Gagong/Toshinou-Revamped/tree/beta").WithFooter("WARNING: This is not a stable build, recommended to use Master");
                    break;
                default:
                    embed.AddInlineField("Master (Recommended)", "https://github.com/Gagong/Toshinou-Revamped/tree/master");
                    embed.AddInlineField("Beta", "https://github.com/Gagong/Toshinou-Revamped/tree/beta");
                    break;
            }

            embed.Color = Color.Green;
            embed.WithAuthor("Smart Toshinou | Github", "", ""); // Name, IconURL, URL(???)
            await ReplyAsync("", false, embed);
        }
    }
}
