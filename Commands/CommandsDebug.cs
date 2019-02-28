using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DOG.Gen;

namespace DOG.Commands
{
    public class CommandsDebug : ModuleBase<SocketCommandContext>
    {
        [Command("DebugDog")]
        public async Task GetDog(string commandParam = null)
        {
            var dog = D_O_G.Instance.DogGen.GenerateDog(100, 0);

            var eb = new EmbedBuilder();
            eb.WithAuthor(D_O_G.Instance.Client.CurrentUser);

            eb.ImageUrl = dog.ImagePath;

            await ReplyAsync(dog.Name, false, eb.Build());
        }


    }
}