using System;
using System.Collections.Generic;
using DOG.Entity;

namespace DOG.Gen
{
    internal class NameGen
    {
        private List<string> _dogPrefixes = new List<string>
        {
            "Sir",
            "Lord",
            "Count"
        };

        private List<string> _dogNames = new List<string>
        {
            "Woof",
            "Bork",
            "Bones",
            "Fido",
            "Bella",
            "Beauty"
        };

        private List<string> _dogSuffixDefense = new List<string>
        {
            "Tank",
            "Iron Giant",
            "Armoured",
            "Heavy"
        };

        private List<string> _dogSuffixHealth = new List<string>
        {
            "Meatsack",
            "Bloodgiant",
            "Thick",
            "Big-boned"
        };

        private List<string> _dogSuffixInt = new List<string>
        {
            "Smart",
            "Big-brained",
            "Wise"
        };

        private List<string> _dogSuffixWill = new List<string>
        {
            "Wise",
            "Ancient One",
            "Steel-willed"
        };

        private List<string> _dogSuffixAtk = new List<string>
        {
            "Barbarian",
            "Bloodshedder",
            "Angry",
            "Ruthless"
        };

        private List<string> _dogSuffixUseless = new List<string>
        {
            "Useless",
            "Incompetent",
            "Waste of Meat"
        };

        internal string GenerateDogName(Dog dog)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var name = "";

            if (rnd.Next(0, 100) < 20)
            {
                name += _dogPrefixes[rnd.Next(0, _dogPrefixes.Count)] + " ";
            }

            name += _dogNames[rnd.Next(0, _dogNames.Count)];

            if (dog.AtkPower < 15 && dog.Defense < 15 && dog.Health < 15 && dog.Intelligence < 15 && dog.Will < 15)
            {
                name += " the " + _dogSuffixUseless[rnd.Next(0, _dogSuffixUseless.Count)];
            }

            else if (dog.AtkPower >= dog.Defense && 
                dog.AtkPower >= dog.Health && 
                dog.AtkPower >= dog.Intelligence &&
                dog.AtkPower >= dog.Will)
            {
                name += " the " + _dogSuffixAtk[rnd.Next(0, _dogSuffixAtk.Count)];
            }
            
            else if (dog.Defense >= dog.AtkPower && 
                     dog.Defense >= dog.Health && 
                     dog.Defense >= dog.Intelligence &&
                     dog.Defense >= dog.Will)
            {
                name += " the " + _dogSuffixDefense[rnd.Next(0, _dogSuffixDefense.Count)];
            }

            else if (dog.Health >= dog.AtkPower && 
                     dog.Health >= dog.Defense && 
                     dog.Health >= dog.Intelligence &&
                     dog.Health >= dog.Will)
            {
                name += " the " + _dogSuffixHealth[rnd.Next(0, _dogSuffixHealth.Count)];
            }

            else if (dog.Intelligence >= dog.AtkPower && 
                     dog.Intelligence >= dog.Health && 
                     dog.Intelligence >= dog.Defense &&
                     dog.Intelligence >= dog.Will)
            {
                name += " the " + _dogSuffixInt[rnd.Next(0, _dogSuffixInt.Count)];
            }

            else if (dog.Will >= dog.AtkPower && 
                     dog.Will >= dog.Health && 
                     dog.Will >= dog.Intelligence &&
                     dog.Will >= dog.Defense)
            {
                name += " the " + _dogSuffixWill[rnd.Next(0, _dogSuffixWill.Count)];
            }

            return name;
        }
    }
}