using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using DOG.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace DOG.Gen
{
    public class DogGen
    {
        private const float NextTierAddition = 0.0005F;
        private const float StatPenaltyScaling = 1.1F;
        private NameGen _ng = new NameGen();
        //private string[] dogPictures = Directory.GetFiles("D:\\Dev\\DOG\\dogs", "*.jpg", SearchOption.AllDirectories);
        private JArray _dogPictures = JArray.Parse(File.ReadAllText("D:\\Dev\\DOG\\Gen\\dogs.json"));
        

        private List<Tuple<int,int>> _rolls = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(90, 101),
            new Tuple<int, int>(80, 90),
            new Tuple<int, int>(70, 80),
            new Tuple<int, int>(60, 70),
            new Tuple<int, int>(50, 60),
            new Tuple<int, int>(40, 50),
            new Tuple<int, int>(30, 40),
            new Tuple<int, int>(20, 30),
            new Tuple<int, int>(10, 20),
            new Tuple<int, int>(0, 9)
        };

        private int _rollStat(float chance)
        {
            var _rnd = new Random(Guid.NewGuid().GetHashCode());
            chance = chance * (chance - 0.08F);


            foreach (var t in _rolls)
            {
                if (_rnd.NextDouble() < chance)
                {
                    return _rnd.Next(t.Item1, t.Item2);
                }
                else
                {
                    chance += NextTierAddition;
                }
                
                
            }

            return _rnd.Next(_rolls[9].Item1, _rolls[9].Item2);
        }

        internal Dog GenerateDog(int power, int experience)
        {
            var _rnd = new Random(Guid.NewGuid().GetHashCode());
            var dog = new Dog();
            
            var remainingChance = (power * 0.01F);
            var randomRoll = _rnd.Next(0, 6);

            switch (randomRoll)
            {
                case 0:
                    dog.Class = (int)DogClasses.Guardian;

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
                    dog.Class = (int)DogClasses.Champion;

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
                    dog.Class = (int)DogClasses.Paladin;

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
                    dog.Class = (int)DogClasses.Assassin;

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
                    dog.Class = (int)DogClasses.Warlock;

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
                    dog.Class = (int)DogClasses.Elementalist;

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
            
            var classBonus = DogClass.GetClassBonus((DogClasses)dog.Class);
            dog.Prayer = Math.Min(200, Math.Max(0, (int) (dog.Prayer * classBonus.PrayerScaling)));
            dog.AtkPower = Math.Min(200, Math.Max(0, (int) (dog.AtkPower * classBonus.AtkPowerScaling)));
            dog.Defense = Math.Min(200, Math.Max(0, (int) (dog.Defense * classBonus.DefenseScaling)));
            dog.Health = Math.Min(200, Math.Max(0, (int) (dog.Health * classBonus.HealthScaling)));
            dog.Intelligence = Math.Min(200, Math.Max(0, (int) (dog.Intelligence * classBonus.IntelligenceScaling)));
            dog.Will = Math.Min(200, Math.Max(0, (int) (dog.Will * classBonus.WillScaling)));

            dog.Name = _ng.GenerateDogName(ref dog);
            dog.Experience = experience;


            dog.ImagePath = "https://random.dog/" + _dogPictures[_rnd.Next(_dogPictures.Count)];


            return dog;
        }
    }
}