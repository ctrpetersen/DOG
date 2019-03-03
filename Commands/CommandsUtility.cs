using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DOG.Entity;
using DOG.Gen;

namespace DOG.Commands
{
    public class CommandsUtility : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        [Summary("Lists all available commands, or just one. \n*Usage:* \\*help / \\*help <command name>")]
        [Alias("commands", "command")]
        public async Task HelpCommand(string commandParam = null)
        {
            string reply = "";
            if (commandParam != null)
            {
                foreach (var command in D_O_G.Instance.CommandService.Commands)
                {
                    if (commandParam.ToLower() == command.Name.ToLower() || command.Aliases.Contains(commandParam.ToLower()))
                    {
                        var aliases = string.Join(", ", command.Aliases).Replace($"{command.Name}, ", "");
                        reply = $"\n__**{command.Name}**__ \n*({aliases})* \n{command.Summary}\n";
                        break;
                    }
                    reply = $"No command named {commandParam} found.";
                }
            }
            else
            {
                foreach (var command in D_O_G.Instance.CommandService.Commands)
                {
                    var aliases = string.Join(", ", command.Aliases).Replace($"{command.Name}, ", "");

                    reply += $"\n__**{command.Name}**__ \n*({aliases})* \n{command.Summary}\n";
                }
            }

            await ReplyAsync($"{reply}");
        }

        [Command("dogs")]
        [Summary(
            "Lists all dogs you currently have, along with their id for release / selling, or just a single one. Sends a DM with the <all> option.\n*Usage:*\\*dogs <param> (id, all)")]
        [Alias("viewdogs")]
        public async Task ViewDogsCommand(string commandParam)
        {
            if (int.TryParse(commandParam, out int parsed))
            {
                var dogExists = D_O_G.Instance.Context.Dogs.Any(d => d.id == parsed);
                if (dogExists)
                {
                    var dog = D_O_G.Instance.Context.Dogs.First(d => d.id == parsed);
                    await ReplyAsync(null, false, Utility.Utility.GenerateEmbedDog(dog, null, null, null, Context.User.Id));
                }
                else
                {
                    await ReplyAsync($"Could not find dog with id: {parsed}. \n*Usage:*\\*dogs <param> (id, all, browse)");
                }
            }
            else
            {
                //must be param, so browse or all
                if (commandParam == "all")
                {
                    //generate list of all dogs, try DM user
                    var userId = Context.User.Id.ToString();
                    if (D_O_G.Instance.Context.Users.First(u => u.discord_id == userId).Dogs.Any())
                    {
                        //await Context.User.SendMessageAsync("All your dogs:");
                        var eb = new EmbedBuilder();
                        eb.WithAuthor(D_O_G.Instance.Client.CurrentUser);
                        eb.WithColor(Color.DarkBlue);
                        eb.WithCurrentTimestamp();

                        foreach (var dog in D_O_G.Instance.Context.Users.First(u => u.discord_id == userId).Dogs)
                        {
                            eb.AddField($"***{dog.name}*** • ({dog.id})", (DogClasses) dog.dog_class + "\n" + dog.image_path);

                            eb.AddField($"⚔            🛡            ❤",
                                $"```{dog.atk_power.ToString().PadRight(7) + dog.defense.ToString().PadRight(8) + dog.health}```");
                            eb.AddField($"🔮            🔰            🙏",
                                $"```{dog.intelligence.ToString().PadRight(7) + dog.will.ToString().PadRight(8) + dog.prayer}```");

                            eb.AddField("Experience", dog.experience);
                        }

                        await Context.User.SendMessageAsync(null, false, eb.Build());
                    }
                    else
                    {
                        await ReplyAsync("You do not have any dogs.");
                    }
                }
                else if (commandParam == "browse")
                {

                }
            }
        }

        [Command("profile")]
        [Summary("View your profile. \n*Usage:* \\*profile")]
        [Alias("viewprofile", "myprofile")]
        public async Task ViewProfileCommand()
        {
            var userId = Context.User.Id.ToString();
            var user = D_O_G.Instance.Context.Users.First(us => us.discord_id == userId);

            var eb = new EmbedBuilder();
            eb.WithColor(Color.DarkBlue);
            eb.WithAuthor(D_O_G.Instance.Client.CurrentUser);
            eb.WithCurrentTimestamp();
            eb.WithThumbnailUrl(Context.User.GetAvatarUrl());

            eb.AddField("Trainer experience", user.trainer_experience);
            eb.AddField("Bones", user.bones);
            eb.AddField("Dogs", user.Dogs.Count);
            await ReplyAsync(null, false, eb.Build());
        }

    }
}