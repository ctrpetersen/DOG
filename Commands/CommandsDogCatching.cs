using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace DOG.Commands
{
    public class CommandsDogCatching : ModuleBase<SocketCommandContext>
    {
        [Command("dog")]
        [Summary("Finds a random dog for you, which has a chance of being catchable!")]
        public async Task FindDog()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            if (rnd.NextDouble() < 0.5)
            {
                //initiate catching
                var power = Math.Min(rnd.Next(0, 101), rnd.Next(0, 101));
                var dog = D_O_G.Instance.DogGen.GenerateDog(power, rnd.Next(0, 1001));
                await ReplyAsync(null, false, Utility.GenerateEmbedDog(dog,null,true));
            }
            else
            {
                await ReplyAsync(null, false, Utility.GenerateEmbedDog());
            }


        }
    }
}