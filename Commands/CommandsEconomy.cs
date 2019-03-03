using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DOG.Entity;

namespace DOG.Commands
{
    public class CommandsEconomy : ModuleBase<SocketCommandContext>
    {
        //🐕🐶🐩🐾🍖🍗🐺💩
        private List<string> _emojiString = new List<string>
        {
            "🐕",
            "🐶",
            "🐩",
            "🐾",
            "🍖",
            "🍗",
            "🐺",
            "💩"
        };

        [Command("dailies")]
        [Summary("Grants you your daily bones. \n*Usage:* \\*dailies")]
        [Alias("DailyBonus")]
        public async Task DailyBonusCommand()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var userId = Context.User.Id.ToString();
            var user = D_O_G.Instance.Context.Users.First(us => us.discord_id == userId);

            if (user.last_received_daily == null || user.last_received_daily.Value.AddDays(1) < DateTime.Now)
            {
                var bones = rnd.Next(1, 1001);
                user.bones += bones;
                user.trainer_experience += 50;
                user.last_received_daily = DateTime.Now;

                await ReplyAsync($"Congratulations on your daily bonus of {bones} bones! You now have {user.bones} bones. You have also gained 50 experience!");
            }
            else
            {
                await ReplyAsync($"Error - you can receive your daily bonus in {(user.last_received_daily.Value.AddDays(1) - DateTime.Now).Hours} hours.");
            }

            D_O_G.Instance.Context.SaveChanges();
        }

        [Command("coinflip")]
        [Summary("Lets you flip a coin for bones. \n*Usage:* \\*coinflip <heads/tails> <bones to bet>")]
        [Alias("flipcoin")]
        public async Task CoinFlipCommand(string headsOrTails, int bonesToBet)
        {
            if (bonesToBet < 1)
            {
                await ReplyAsync("Error - bet must be more than 0.");
                return;
            }

            //heads 0, tails 1
            var resultOfFlip = new Random(Guid.NewGuid().GetHashCode()).Next(0,2);
            var userId = Context.User.Id.ToString();
            var user = D_O_G.Instance.Context.Users.First(us => us.discord_id == userId);

            if (user.bones < bonesToBet)
            {
                await ReplyAsync("Error - you do not have enough bones to bet.");
                return;
            }

            if (headsOrTails.ToLower() == "heads" && resultOfFlip == 0 || headsOrTails.ToLower() == "tails" && resultOfFlip == 1)
            {

                user.bones += bonesToBet;
                user.trainer_experience += 10;
                await ReplyAsync($"Congratulations! You won {bonesToBet} bones!! You now have {user.bones}. You have also gained 10 experience!");
            }
            else
            {
                user.bones -= bonesToBet;
                await ReplyAsync($"Unfortunately, you lost {bonesToBet} bones. Better luck next time! You now have {user.bones}.");
            }

            D_O_G.Instance.Context.SaveChanges();
        }

        [Command("slots")]
        [Summary("Lets you flip a coin for bones. \n*Usage:* \\*slots <bones to bet>")]
        public async Task SlotsCommand(int bonesToBet)
        {
            if (bonesToBet < 1)
            {
                await ReplyAsync("Error - bet must be more than 0.");
                return;
            }

            var userId = Context.User.Id.ToString();
            var user = D_O_G.Instance.Context.Users.First(us => us.discord_id == userId);

            if (user.bones < bonesToBet)
            {
                await ReplyAsync("Error - you do not have enough bones to bet.");
                return;
            }

            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var origMsg = await ReplyAsync($"*SLOTS*\nBid amount: {bonesToBet}");


            for (int i = 5; i > 0; i--)
            {
                var editStr = "";
                for (int j = 0; j < i; j++)
                {
                    editStr += _emojiString[rnd.Next(_emojiString.Count)];
                }

                await origMsg.ModifyAsync(msg => msg.Content = $"*SLOTS*\nBid amount: {bonesToBet}\n{editStr}");
                await Task.Delay(2500);
            }


        }
    }
}