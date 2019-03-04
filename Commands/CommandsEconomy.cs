using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DOG.Entity;

namespace DOG.Commands
{
    public class CommandsEconomy : ModuleBase<SocketCommandContext>
    {
        //🐕🐶🐩🐾🍖🍗🐺💩
        private List<string> _emojisList = new List<string>
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

            //D_O_G.Instance.Context.SaveChanges();
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
                await ReplyAsync($"**🎲Congratulations!🎲** You won {bonesToBet} bones! \nResult: **{(resultOfFlip == 0 ? "Heads" : "Tails")}**\nTotal: **{user.bones}** bones.\nYou have also gained 10 experience!");
            }
            else
            {
                user.bones -= bonesToBet;
                await ReplyAsync($"Unfortunately, you lost {bonesToBet} bones.\nResult: **{(resultOfFlip == 0 ? "Heads" : "Tails")}**\nTotal: **{user.bones}** bones.");
            }
        }

        private const double ThreeWin = 1.5;
        private const double FourWin = 2.0;
        private const double FiveWin = 4.0;

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
            var origMsg = await ReplyAsync($"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones");

            var slotRolls = new List<string>
            {
                _emojisList[rnd.Next(_emojisList.Count)],
                _emojisList[rnd.Next(_emojisList.Count)],
                _emojisList[rnd.Next(_emojisList.Count)],
                _emojisList[rnd.Next(_emojisList.Count)],
                _emojisList[rnd.Next(_emojisList.Count)]
            };

            for (int i = 1; i < 5; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    slotRolls[j] = _emojisList[rnd.Next(_emojisList.Count)];
                }
                await origMsg.ModifyAsync(msg => msg.Content = $"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones\n{string.Join(string.Empty, slotRolls.ToArray())}");
                await Task.Delay(1500);
            }

            var slotCount = slotRolls.GroupBy(r => r).ToDictionary(g => g.Key, g => g.Count());

            if (slotCount.Any(s => s.Value == 3))
            {
                user.bones += (int)(bonesToBet * ThreeWin);
                await origMsg.ModifyAsync(msg => msg.Content = $"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones\n{string.Join(string.Empty, slotRolls.ToArray())}" +
                                                               $"\nCongratulations, you won **{bonesToBet * ThreeWin}** bones!\n**Total:{user.bones}** bones.");
            }

            else if (slotCount.Any(s => s.Value == 4))
            {
                user.bones += (int)(bonesToBet * FourWin);
                await origMsg.ModifyAsync(msg => msg.Content = $"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones\n{string.Join(string.Empty, slotRolls.ToArray())}" +
                                                               $"\nCongratulations, you won **{bonesToBet * FourWin}** bones!\n**Total:{user.bones}** bones.");
            }

            else if (slotCount.Any(s => s.Value == 5))
            {
                user.bones += (int)(bonesToBet * FiveWin);
                await origMsg.ModifyAsync(msg => msg.Content = $"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones\n{string.Join(string.Empty, slotRolls.ToArray())}" +
                                                               $"\n!!JACKPOT!!\nCongratulations, you won **{bonesToBet * FiveWin}** bones!\n**Total:{user.bones}** bones.");
            }

            else
            {
                user.bones -= bonesToBet;
                await origMsg.ModifyAsync(msg => msg.Content = $"**🎲SLOTS🎲**\nBid amount: **{bonesToBet}** bones\n{string.Join(string.Empty, slotRolls.ToArray())}" +
                                                               $"\nSorry, you lost **{bonesToBet}** bones.\nTotal: **{user.bones}** bones.");
            }

        }
    }
}