using System;

namespace ToshinouBot.Services
{
    class RandomService
    {
        private Random rnd = new Random();

        public int getRandomInt(int start, int end) {
            return rnd.Next(start, end + 1);
        }
    }
}
