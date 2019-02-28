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
            "Steel-willed",
            "Iron-willed"
        };

        private List<string> _dogSuffixPrayer = new List<string>
        {
            "Wise",
            "Priest"
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

        private List<string> _dogSuffixGodlike = new List<string>
        {
            "Destroyer of Worlds",
            "Eater of Souls",
            "Ancient One",
            "Forsaken"
        };

        internal string GenerateDogName(Dog dog)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var name = "";
            var godlikeMin = 85;
            var uselessMax = 15;

            if (rnd.Next(0, 100) < 20)
            {
                name += _dogPrefixes[rnd.Next(0, _dogPrefixes.Count)] + " ";
            }

            name += _dogNames[rnd.Next(0, _dogNames.Count)];

            if (dog.AtkPower < uselessMax && 
                dog.Defense < uselessMax && 
                dog.Health < uselessMax && 
                dog.Intelligence < uselessMax && 
                dog.Will < uselessMax &&
                dog.Prayer < uselessMax)
            {
                name += " the " + _dogSuffixUseless[rnd.Next(0, _dogSuffixUseless.Count)];
            }

            else if (dog.AtkPower > godlikeMin && 
                     dog.Defense > godlikeMin && 
                     dog.Health > godlikeMin && 
                     dog.Intelligence > godlikeMin &&
                     dog.Will > godlikeMin && 
                     dog.Prayer > godlikeMin)
            {
                name += " the " + _dogSuffixGodlike[rnd.Next(0, _dogSuffixGodlike.Count)];
            }

            else if (dog.AtkPower >= dog.Defense &&
                     dog.AtkPower >= dog.Health &&
                     dog.AtkPower >= dog.Intelligence &&
                     dog.AtkPower >= dog.Will &&
                     dog.AtkPower >= dog.Prayer)
            {
                name += " the " + _dogSuffixAtk[rnd.Next(0, _dogSuffixAtk.Count)];
            }

            else if (dog.Defense >= dog.AtkPower &&
                     dog.Defense >= dog.Health &&
                     dog.Defense >= dog.Intelligence &&
                     dog.Defense >= dog.Will &&
                     dog.Defense >= dog.Prayer)
            {
                name += " the " + _dogSuffixDefense[rnd.Next(0, _dogSuffixDefense.Count)];
            }

            else if (dog.Health >= dog.AtkPower &&
                     dog.Health >= dog.Defense &&
                     dog.Health >= dog.Intelligence &&
                     dog.Health >= dog.Will &&
                     dog.Health >= dog.Prayer)
            {
                name += " the " + _dogSuffixHealth[rnd.Next(0, _dogSuffixHealth.Count)];
            }

            else if (dog.Intelligence >= dog.AtkPower &&
                     dog.Intelligence >= dog.Health &&
                     dog.Intelligence >= dog.Defense &&
                     dog.Intelligence >= dog.Will &&
                     dog.Intelligence >= dog.Prayer)
            {
                name += " the " + _dogSuffixInt[rnd.Next(0, _dogSuffixInt.Count)];
            }

            else if (dog.Will >= dog.AtkPower &&
                     dog.Will >= dog.Health &&
                     dog.Will >= dog.Intelligence &&
                     dog.Will >= dog.Defense &&
                     dog.Will >= dog.Prayer)
            {
                name += " the " + _dogSuffixWill[rnd.Next(0, _dogSuffixWill.Count)];
            }

            else if (dog.Prayer >= dog.AtkPower &&
                     dog.Prayer >= dog.Health &&
                     dog.Prayer >= dog.Intelligence &&
                     dog.Prayer >= dog.Defense &&
                     dog.Prayer >= dog.Will)
            {
                name += " the " + _dogSuffixPrayer[rnd.Next(0, _dogSuffixPrayer.Count)];
            }



            return name;
        }
    }
}