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
                var eb = new EmbedBuilder();
                eb.WithAuthor(D_O_G.Instance.Client.CurrentUser);
                eb.ImageUrl = dog.ImagePath;
                eb.AddField("Dog",
                    $"**{dog.Name}**\n{(DogClasses) dog.Class}\nAtk: {dog.AtkPower}\nDef:{dog.Defense}\nHp:{dog.Health}" +
                    $"\nInt:{dog.Intelligence}\nWill:{dog.Will}\nPrayer:{dog.Prayer}");

                await ReplyAsync(null, false, eb.Build());
            }
        }


    }
}