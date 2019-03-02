using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DOG.Entity;

namespace DOG.Utility
{
    public static class Utility
    {
        public static Task Log(LogMessage logmsg)
        {
            switch (logmsg.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now} [{logmsg.Severity,8}] {logmsg.Source}: {logmsg.Message} {logmsg.Exception}");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public static async void SetPlaying(string message, DiscordSocketClient client, ActivityType activityType = ActivityType.Playing)
        {
            await client.SetGameAsync($"{message} | {client.Guilds.Count} guilds, {client.Guilds.Sum(guild => guild.Users.Count) - 1} users", null, activityType);
        }

        public static Embed GenerateEmbedDog(Dog dog = null, string message = null, string catchName = null, string catchValue = null, ulong ownerId = 0)
        {
            var eb = new EmbedBuilder();
            eb.WithAuthor(D_O_G.Instance.Client.CurrentUser);
            eb.WithColor(Color.DarkBlue);
            
            if (dog != null)
            {
                eb.AddField($"***{dog.name}***", (DogClasses)dog.dog_class);

                eb.AddField($"⚔            🛡            ❤", $"```{dog.atk_power.ToString().PadRight(7) + dog.defense.ToString().PadRight(8) + dog.health}```");
                eb.AddField($"🔮            🔰            🙏", $"```{dog.intelligence.ToString().PadRight(7) + dog.will.ToString().PadRight(8) + dog.prayer}```");

                eb.WithImageUrl(dog.image_path);
                eb.WithCurrentTimestamp();
                eb.WithFooter(dog.experience + " experience");

                switch ((DogClasses)dog.dog_class)
                {
                    case DogClasses.Assassin:
                        eb.WithThumbnailUrl("https://i.imgur.com/Fs1Hzf5.png");
                        break;
                    case DogClasses.Champion:
                        eb.WithThumbnailUrl("https://i.imgur.com/TqjvWHJ.png");
                        break;
                    case DogClasses.Elementalist:
                        eb.WithThumbnailUrl("https://i.imgur.com/XeqOcHE.png");
                        break;
                    case DogClasses.Guardian:
                        eb.WithThumbnailUrl("https://i.imgur.com/CVyhxuC.png");
                        break;
                    case DogClasses.Paladin:
                        eb.WithThumbnailUrl("https://i.imgur.com/RF1IfGj.png");
                        break;
                    case DogClasses.Warlock:
                        eb.WithThumbnailUrl("https://i.imgur.com/S3dfkP5.png");
                        break;
                }

                if (catchName != null)
                {
                    eb.AddField(catchName, catchValue);
                }

                if (ownerId != 0)
                {
                    var owner = D_O_G.Instance.Client.GetUser(ownerId);
                    eb.WithFooter($"{dog.experience} experience • Owner: {owner.Username}#{owner.Discriminator}");
                }
            }
            else
            {
                var rnd = new Random(Guid.NewGuid().GetHashCode());
                eb.WithImageUrl("https://random.dog/" + D_O_G.Instance.DogGen.DogPictures[rnd.Next(D_O_G.Instance.DogGen.DogPictures.Count)]);
            }

            return eb.Build();
        }
    }
}