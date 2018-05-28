using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace ToshinouBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            var embed = new Discord.EmbedBuilder();
            embed.AddField("!help", "Will display list of commands!");
            embed.AddField("!info", "Will display Smart Toshinou info!");
            embed.AddField("!checkUpdate", "Will display the status of the bot!");
            embed.AddField("!github", "Will link the Github!");
            embed.AddField("!github master", "Stable Toshinou version!");
            embed.AddField("!github beta", "Beta Toshinou version!");
            embed.AddField("!roll <amount>", "Will roll a number between 1 and <amount>!");
            embed.Color = Color.Green;
            embed.WithAuthor("Smart Toshinou | Help", "", ""); // Name, IconURL, URL(???)
            await ReplyAsync("", false, embed);
        }
    }
}
