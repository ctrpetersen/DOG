using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DOG
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
    }
}