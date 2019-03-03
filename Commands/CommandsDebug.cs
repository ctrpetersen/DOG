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
        public async Task GetDog(int dogs = 1, int dogPower = 0)
        {
            for (int i = 0; i < dogs; i++)
            {
                var dog = D_O_G.Instance.DogGen.GenerateDog(dogPower, 100);
                

                await ReplyAsync(null, false, Utility.Utility.GenerateEmbedDog(dog));
            }
        }

        [Command("debugBones")]
        public async Task GetDog(int bones)
        {
            var userId = Context.User.Id.ToString();
            var user = D_O_G.Instance.Context.Users.First(us => us.discord_id == userId);
            user.bones += bones;
            D_O_G.Instance.Context.SaveChanges();
            await ReplyAsync($"{bones} has been added.");
        }


    }
}