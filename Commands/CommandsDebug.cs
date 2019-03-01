using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DOG.Entity;
using DOG.Gen;

namespace DOG.Commands
{
    public class CommandsDebug : ModuleBase<SocketCommandContext>
    {
        [Command("DebugDog")]
        public async Task GetDog(int dogs = 1, int dogPower = 0, bool isWild = false)
        {
            for (int i = 0; i < dogs; i++)
            {
                var dog = D_O_G.Instance.DogGen.GenerateDog(dogPower, 100);
                

                await ReplyAsync(null, false, Utility.GenerateEmbedDog(dog, null, isWild));
            }
        }


    }
}