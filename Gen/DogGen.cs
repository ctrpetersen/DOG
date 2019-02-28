using System;
using System.Collections.Generic;
using DOG.Entity;

namespace DOG.Gen
{
    public class DogGen
    {
        private const float NextTierAddition = 0.0005F;
        private const float StatPenaltyScaling = 1.1F;
        private NameGen _ng = new NameGen();

        private List<Tuple<int,int>> _rolls = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(90, 101),
            new Tuple<int, int>(80, 89),
            new Tuple<int, int>(70, 79),
            new Tuple<int, int>(60, 69),
            new Tuple<int, int>(50, 59),
            new Tuple<int, int>(40, 49),
            new Tuple<int, int>(30, 39),
            new Tuple<int, int>(20, 29),
            new Tuple<int, int>(10, 19),
            new Tuple<int, int>(0, 9)
        };

        private int _rollStat(float chance)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            chance = chance * (chance - 0.08F);


            foreach (var t in _rolls)
            {
                if (rnd.NextDouble() < chance)
                {
                    return rnd.Next(t.Item1, t.Item2);
                }
                else
                {
                    chance += NextTierAddition;
                }
            }

            return rnd.Next(_rolls[9].Item1, _rolls[9].Item2);
        }

        internal Dog GenerateDog(int power, int experience)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var dog = new Dog();
            
            var remainingChance = (power * 0.01F);
            var randomRoll = rnd.Next(0, 6);

            switch (randomRoll)
            {
                case 0:
                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.AtkPower = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Intelligence = _rollStat(remainingChance);
                    break;
                case 1:
                    dog.Health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.AtkPower = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Intelligence = _rollStat(remainingChance);
                    break;
                case 2:
                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.AtkPower = _rollStat(remainingChance);
                    break;
                case 3:
                    dog.AtkPower = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Health = _rollStat(remainingChance);
                    break;
                case 4:
                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.AtkPower = _rollStat(remainingChance);
                    break;
                case 5:
                    dog.Intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.Defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.AtkPower = _rollStat(remainingChance);
                    break;
            }

            dog.Name = _ng.GenerateDogName(dog);

            return dog;
        }
    }
}