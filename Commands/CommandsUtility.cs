using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
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
            "Lists all dogs you currently have, along with their id for release / selling, or just a single one.\n*Usage:*\\*dogs <param> (id, all, browse)")]
        [Alias("viewdogs")]
        public async Task ViewDogsCommand(string commandParam)
        {
            if (int.TryParse(commandParam, out int parsed))
            {
                //must be int, so ID
                var dogExists = D_O_G.Instance.Context.Dogs.Any(d => d.id == parsed);
                if (dogExists)
                {
                    var dog = D_O_G.Instance.Context.Dogs.First(d => d.id == parsed);
                    await ReplyAsync(null, false, Utility.Utility.GenerateEmbedDog(dog, null, null, null, Context.User.Id));
                }
                else
                {
                    await ReplyAsync($"Could not find dog with id {parsed}. Execute command without any parameters to view a list of all your dogs with their given IDs.");
                }
            }
            else
            {
                //must be param, so browse or all
            }

        }

    }
}