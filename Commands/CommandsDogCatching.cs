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

                    var message = await ReplyAsync(null, false, Utility.GenerateEmbedDog(dog, null, true));
                    await message.AddReactionAsync(new Emoji("🐕"));

                    var tcs = new TaskCompletionSource<ulong>();
                    D_O_G.Instance.DogsUpForCapture.Add(message.Id, tcs);
                    await Task.WhenAny(tcs.Task, Task.Delay(5000));

                    if (tcs.Task.IsCompleted)
                    {
                        await message.ModifyAsync(msg =>
                            msg.Embed = Utility.GenerateEmbedDog(dog, null, true, true, Context.Client.GetUser(tcs.Task.Result).Username));
                    }
                    else
                    {
                        Console.WriteLine("Timed out");
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