using System;
using System.Threading.Tasks;
using Discord;
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

            if (rnd.NextDouble() < 0.9)
            {
                var captureDog = Task.Run(async () =>
                {
                    //initiate catching
                    var power = Math.Min(rnd.Next(0, 101), rnd.Next(0, 101));
                    var dog = D_O_G.Instance.DogGen.GenerateDog(power, rnd.Next(0, 1001));

                    var message = await ReplyAsync(null, false, Utility.GenerateEmbedDog(dog, null, "**This dog is able to be catched!**", "React to this message to catch it!"));
                    await message.AddReactionAsync(new Emoji("🐕"));

                    var tcs = new TaskCompletionSource<ulong>();
                    D_O_G.Instance.DogsUpForCapture.Add(message.Id, tcs);
                    await Task.WhenAny(tcs.Task, Task.Delay(2500));

                    if (tcs.Task.IsCompleted)
                    {
                        await message.ModifyAsync(msg =>
                            msg.Embed = Utility.GenerateEmbedDog(dog, null, "**This dog has been catched!**", $"Catched by {Context.Client.GetUser(tcs.Task.Result).Username}!"));
                    }
                    else
                    {
                        await message.ModifyAsync(msg =>
                            msg.Embed = Utility.GenerateEmbedDog(dog, null, "**No one catched the dog!**", "It has now disappeared into the woods, forever lost."));
                    }

                    D_O_G.Instance.DogsUpForCapture.Remove(message.Id);

                });

            }
            else
            {
                await ReplyAsync(null, false, Utility.GenerateEmbedDog());
            }


        }
    }
}