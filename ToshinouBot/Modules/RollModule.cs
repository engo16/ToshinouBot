using System.Threading.Tasks;
using Discord.Commands;
using ToshinouBot.Services;

namespace ToshinouBot.Modules
{
    public class RollModule : ModuleBase<SocketCommandContext>
    {
        readonly RandomService Random;

        private RollModule(RandomService randomService)
        {
            this.Random = randomService;
        }

        [Command("Roll")]
        public async Task Roll(int param)
        {
            if (param < 1) {
                await this.ReplyAsync("Error: Number must be positive");
            }
            else {
                await this.ReplyAsync(Random.getRandomInt(1, param).ToString());
            }
            
        }
    }
}
