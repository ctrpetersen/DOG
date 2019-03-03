using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using DOG.Entity;

namespace DOG.Commands
{
    public class CommandsEconomy : ModuleBase<SocketCommandContext>
    {
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
                user.trainer_experience += 15;
                user.last_received_daily = DateTime.Now;

                await ReplyAsync($"Congratulations on your daily bonus of {bones} bones!");
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

            if (headsOrTails.ToLower() == "heads")
            {
                if (resultOfFlip == 0)
                {
                    user.bones += bonesToBet;
                    await ReplyAsync($"Congratulations, you won {bonesToBet} bones!!");
                }
                else
                {
                    user.bones -= bonesToBet;
                    await ReplyAsync($"Unfortunately, you lost {bonesToBet} bones. Better luck next time!");
                }
            }

            if (headsOrTails.ToLower() == "tails")
            {
                if (resultOfFlip == 1)
                {
                    user.bones += bonesToBet;
                    await ReplyAsync($"Congratulations, you won {bonesToBet} bones!!");
                }
                else
                {
                    user.bones -= bonesToBet;
                    await ReplyAsync($"Unfortunately, you lost {bonesToBet} bones. Better luck next time!");
                }
            }

            D_O_G.Instance.Context.SaveChanges();
        }
    }
}