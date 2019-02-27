using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;

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
    }
}