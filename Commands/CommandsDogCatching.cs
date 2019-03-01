﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DOG.Entity;

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
                var power = Math.Min(rnd.Next(0, 101), rnd.Next(0, 101));
                var dog = D_O_G.Instance.DogGen.GenerateDog(power, rnd.Next(0, 1001));
                ReleaseDog(rnd, 2500, dog);
            }
            else
            {
                await ReplyAsync(null, false, Utility.GenerateEmbedDog());
            }
        }

        private void ReleaseDog(Random rnd, int escapeTime, Dog dog)
        {
            var captureDog = Task.Run(async () =>
            {
                var message = await ReplyAsync(null, false, Utility.GenerateEmbedDog(dog, null, "**This dog is able to be catched!**", "React to this message to catch it!"));
                await message.AddReactionAsync(new Emoji("🐕"));

                var tcs = new TaskCompletionSource<ulong>();
                D_O_G.Instance.DogsUpForCapture.Add(message.Id, tcs);
                await Task.WhenAny(tcs.Task, Task.Delay(escapeTime));

                if (tcs.Task.IsCompleted)
                {
                    var catcher = Context.Client.GetUser(tcs.Task.Result);
                    await message.ModifyAsync(msg =>
                        msg.Embed = Utility.GenerateEmbedDog(dog, null, "**This dog has been catched!**", $"Catched by {catcher.Username}!"));

                    User user;
                    if (!D_O_G.Instance.Context.Users.Any(u => u.DiscordId == catcher.Id.ToString()))
                    {
                        //add new user to db
                        var newUser = new User
                        {
                            Bones = 0,
                            DiscordId = catcher.Id.ToString(),
                            TrainerExperience = 0
                        };
                        await D_O_G.Instance.Context.Users.AddAsync(newUser);
                        await D_O_G.Instance.Context.SaveChangesAsync();
                        user = newUser;
                        Console.WriteLine($"added {newUser} to db");
                    }
                    else
                    {
                        user = D_O_G.Instance.Context.Users.First(u => u.DiscordId == catcher.Id.ToString());
                    }

                    dog.OwnerId = user.DiscordId;
                    user.Dogs.Add(dog);
                    await D_O_G.Instance.Context.Dogs.AddAsync(dog);
                    await D_O_G.Instance.Context.SaveChangesAsync();

                    //save dog to user

                }
                else
                {
                    await message.ModifyAsync(msg =>
                        msg.Embed = Utility.GenerateEmbedDog(dog, null, "**No one catched the dog!**", "It has now escaped into the woods, forever lost."));
                }
            });
        }
    }
}