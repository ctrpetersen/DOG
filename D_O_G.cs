﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using DOG.Entity;
using DOG.Gen;
using Microsoft.Extensions.DependencyInjection;

namespace DOG
{
    public class D_O_G
    {
        //https://discordapp.com/oauth2/authorize?client_id=550055710038425610&permissions=378944&scope=bot

        public static D_O_G Instance => _instance ?? (_instance = new D_O_G());
        private static D_O_G _instance;

        private D_O_G()
        {
            _token = File.ReadAllText("token.txt");

            var rnd = new Random(Guid.NewGuid().GetHashCode());

/*            var dg = new DogGen();

            Console.WriteLine("GENERATING WITH 10 POWER");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(dg.GenerateDog(10, 0));
            }

            Console.WriteLine("\n\nGENERATING WITH 50 POWER");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(dg.GenerateDog(50, 0));
            }

            Console.WriteLine("\n\nGENERATING WITH 100 POWER");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(dg.GenerateDog(100, 0));
            }*/
        }

        public DiscordSocketClient Client;
        public DOGContext Context = new DOGContext();
        public CommandService CommandService;
        public DogGen DogGen = new DogGen();
        public Dictionary<ulong, TaskCompletionSource<ulong>> DogsUpForCapture = new Dictionary<ulong, TaskCompletionSource<ulong>>();

        private IServiceProvider _services;
        private readonly string _token;

        public async Task StartAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Debug,
                MessageCacheSize = 500
            });

            CommandService = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(CommandService)
                .BuildServiceProvider();

            await InstallCommandsAsync();
            await Client.LoginAsync(TokenType.Bot, _token);
            await Client.StartAsync();

            Client.JoinedGuild += JoinedGuild;
            Client.ReactionAdded += Client_ReactionAdded;
            Client.ReactionRemoved += ClientOnReactionRemoved;

            Client.Ready += () =>
            {
                Utility.SetPlaying("Woof!", Client);
                Utility.Log(new LogMessage(LogSeverity.Info, "Squid", $"Logged in as {Client.CurrentUser.Username}#{Client.CurrentUser.Discriminator}." +
                                                              $"\nServing {Client.Guilds.Count} guilds with a total of {Client.Guilds.Sum(guild => guild.Users.Count)} online users."));
                return Task.CompletedTask;
            };

            await Task.Delay(-1);
        }

        private Task ClientOnReactionRemoved(Cacheable<IUserMessage, ulong> msg, ISocketMessageChannel channel, SocketReaction reaction)
        {
            throw new NotImplementedException();
        }

        private Task Client_ReactionAdded(Cacheable<IUserMessage, ulong> msg, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (DogsUpForCapture.ContainsKey(msg.Id) && !reaction.Channel.GetUserAsync(reaction.UserId).Result.IsBot)
            {
                DogsUpForCapture[msg.Id].TrySetResult(reaction.UserId);
            }

            return Task.CompletedTask;
        }

        private Task JoinedGuild(SocketGuild guild)
        {
            Utility.Log(new LogMessage(LogSeverity.Info, "DOG",
                $"Joined new guild {guild.Name} with {guild.Users.Count}"));

            return Task.CompletedTask;
        }

        public async Task InstallCommandsAsync()
        {
            Client.MessageReceived += HandleCommandAsync;
            await CommandService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            if (!(messageParam is SocketUserMessage message)) return;
            if (message.Author.IsBot) return;

            var argPos = 0;
            if (!(message.HasCharPrefix('*', ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;
            var context = new SocketCommandContext(Client, message);

            var result = await CommandService.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }
    }
}