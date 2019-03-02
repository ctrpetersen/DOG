using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using DOG.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
// ReSharper disable PossibleInvalidOperationException

namespace DOG.Gen
{
    public class DogGen
    {
        private const float NextTierAddition = 0.0005F;
        private const float StatPenaltyScaling = 1.1F;
        private NameGen _ng = new NameGen();
        //private string[] dogPictures = Directory.GetFiles("D:\\Dev\\DOG\\dogs", "*.jpg", SearchOption.AllDirectories);
        public JArray DogPictures = JArray.Parse(File.ReadAllText("D:\\Dev\\DOG\\Gen\\dogs.json"));
        

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

        public Dog GenerateDog(int power, int experience)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var dog = new Dog();
            
            var remainingChance = (power * 0.01F);
            var randomRoll = rnd.Next(0, 6);

            switch (randomRoll)
            {
                case 0:
                    dog.dog_class = (int)DogClasses.Guardian;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.atk_power = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.intelligence = _rollStat(remainingChance);
                    break;
                case 1:
                    dog.dog_class = (int)DogClasses.Champion;

                    dog.health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.atk_power = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.intelligence = _rollStat(remainingChance);
                    break;
                case 2:
                    dog.dog_class = (int)DogClasses.Paladin;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.atk_power = _rollStat(remainingChance);
                    break;
                case 3:
                    dog.dog_class = (int)DogClasses.Assassin;

                    dog.atk_power = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.health = _rollStat(remainingChance);
                    break;
                case 4:
                    dog.dog_class = (int)DogClasses.Warlock;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.atk_power = _rollStat(remainingChance);
                    break;
                case 5:
                    dog.dog_class = (int)DogClasses.Elementalist;

                    dog.intelligence = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.will = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.health = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.prayer = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.defense = _rollStat(remainingChance);
                    remainingChance = remainingChance / StatPenaltyScaling;

                    dog.atk_power = _rollStat(remainingChance);
                    break;
            }
            
            var classBonus = DogClass.GetClassBonus((DogClasses)dog.dog_class);
            dog.prayer = Math.Min(200, Math.Max(0, (int) (dog.prayer * classBonus.PrayerScaling)));
            dog.atk_power = Math.Min(200, Math.Max(0, (int) (dog.atk_power * classBonus.AtkPowerScaling)));
            dog.defense = Math.Min(200, Math.Max(0, (int) (dog.defense * classBonus.DefenseScaling)));
            dog.health = Math.Min(200, Math.Max(0, (int) (dog.health * classBonus.HealthScaling)));
            dog.intelligence = Math.Min(200, Math.Max(0, (int) (dog.intelligence * classBonus.IntelligenceScaling)));
            dog.will = Math.Min(200, Math.Max(0, (int) (dog.will * classBonus.WillScaling)));

            dog.name = _ng.GenerateDogName(ref dog);
            dog.experience = experience;


            dog.image_path = "https://random.dog/" + DogPictures[rnd.Next(DogPictures.Count)];


            return dog;
        }
    }
}