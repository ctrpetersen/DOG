using System;
using System.Collections.Generic;
using DOG.Entity;

namespace DOG.Gen
{
    internal class NameGen
    {
        private readonly List<string> _dogPrefixes = new List<string>
        {
            "Emperor",
            "Caesar",
            "Tsar",
            "King of Kings",
            "High King",
            "Queen",
            "Prince",
            "Caliph",
            "Archduke",
            "Grand Duke",
            "Grand Prince",
            "Duke",
            "Prince",
            "Marquess",
            "Landgrave",
            "Count",
            "Viscount",
            "Baron",
            "Baronet",
            "Dominus",
            "Knight",
            "Laird",
            "Esquire",
            "Gentleman",
            "Duchess"
        };

        private readonly List<string> _dogNames = new List<string>
        {
            "Woof",
            "Bork",
            "Bones",
            "Fido",
            "Bella",
            "Beauty",
            "Tail",
            "Paws",
            "Star",
            "Woofer",
            "Borker",
            "Pupper",
            "Puppo",
            "Longboye",
            "Ace",
            "Apollo",
            "Bailey",
            "Bandit",
            "Baxter",
            "Bear",
            "Beau",
            "Benji",
            "Benny",
            "Bentley",
            "Blue",
            "Bo",
            "Boomer",
            "Brady",
            "Brody",
            "Bruno",
            "Brutus",
            "Bubba",
            "Buddy",
            "Buster",
            "Cash",
            "Champ",
            "Chance",
            "Charlie",
            "Chase",
            "Chester",
            "Chico",
            "Coco",
            "Cody",
            "Cooper",
            "Copper",
            "Dexter",
            "Diesel",
            "Duke",
            "Elvis",
            "Finn",
            "Frankie",
            "George",
            "Gizmo",
            "Gunner",
            "Gus",
            "Hank",
            "Harley",
            "Henry",
            "Hunter",
            "Jack",
            "Jackson",
            "Jake",
            "Jasper",
            "Jax",
            "Joey",
            "Kobe",
            "Leo",
            "Loki",
            "Louie",
            "Lucky",
            "Luke",
            "Mac",
            "Marley",
            "Max",
            "Mickey",
            "Milo",
            "Moose",
            "Murphy",
            "Oliver",
            "Ollie",
            "Oreo",
            "Oscar",
            "Otis",
            "Peanut",
            "Prince",
            "Rex",
            "Riley",
            "Rocco",
            "Rocky",
            "Romeo",
            "Roscoe",
            "Rudy",
            "Rufus",
            "Rusty",
            "Sam",
            "Sammy",
            "Samson",
            "Scooter",
            "Scout",
            "Shadow",
            "Simba",
            "Sparky",
            "Spike",
            "Tank",
            "Teddy",
            "Thor",
            "Toby",
            "Tucker",
            "Tyson",
            "Vader",
            "Winston",
            "Yoda",
            "Zeus",
            "Ziggy",
            "Abby",
            "Allie",
            "Angel",
            "Annie",
            "Athena",
            "Baby",
            "Bailey",
            "Bella",
            "Belle",
            "Bonnie",
            "Brandy",
            "Cali",
            "Callie",
            "Casey",
            "Charlie",
            "Chloe",
            "Cleo",
            "Coco",
            "Cocoa",
            "Cookie",
            "Daisy",
            "Dakota",
            "Dixie",
            "Ella",
            "Ellie",
            "Emma",
            "Gigi",
            "Ginger",
            "Grace",
            "Gracie",
            "Hannah",
            "Harley",
            "Hazel",
            "Heidi",
            "Holly",
            "Honey",
            "Izzy",
            "Jasmine",
            "Josie",
            "Katie",
            "Kona",
            "Lacey",
            "Lady",
            "Layla",
            "Lexi",
            "Lexie",
            "Lilly",
            "Lily",
            "Lola",
            "Lucky",
            "Lucy",
            "Lulu",
            "Luna",
            "Macy",
            "Maddie",
            "Madison",
            "Maggie",
            "Marley",
            "Maya",
            "Mia",
            "Millie",
            "Mimi",
            "Minnie",
            "Missy",
            "Misty",
            "Mocha",
            "Molly",
            "Nala",
            "Nikki",
            "Olive",
            "Peanut",
            "Pebbles",
            "Penny",
            "Pepper",
            "Phoebe",
            "Piper",
            "Princess",
            "Riley",
            "Rosie",
            "Roxie",
            "Roxy",
            "Ruby",
            "Sadie",
            "Sally",
            "Sandy",
            "Sasha",
            "Sassy",
            "Scout",
            "Shadow",
            "Shelby",
            "Sierra",
            "Sophie",
            "Stella",
            "Sugar",
            "Sydney",
            "Trixie",
            "Willow",
            "Winnie",
            "Zoe",
            "Zoey"
        };

        private readonly List<string> _dogSuffixDefense = new List<string>
        {
            "Tank",
            "Iron Giant",
            "Armoured",
            "Heavy"
        };

        private readonly List<string> _dogSuffixHealth = new List<string>
        {
            "Meatsack",
            "Bloodgiant",
            "Thick",
            "Big-boned",
            "Healthy",
            "Robust"
        };

        private readonly List<string> _dogSuffixInt = new List<string>
        {
            "Smart",
            "Big-brained",
            "Wise",
            "Mage"
        };

        private readonly List<string> _dogSuffixWill = new List<string>
        {
            "Steel-willed",
            "Iron-willed"
        };

        private readonly List<string> _dogSuffixPrayer = new List<string>
        {
            "Wise",
            "Priest",
            "Cultist",
            "Priestess",
        };

        private readonly List<string> _dogSuffixAtk = new List<string>
        {
            "Barbarian",
            "Bloodshedder",
            "Angry",
            "Ruthless"
        };

        private readonly List<string> _dogSuffixUseless = new List<string>
        {
            "Useless",
            "Incompetent",
            "Waste of Meat",
            "Idiot"
        };

        private readonly List<string> _dogSuffixGodlike = new List<string>
        {
            "Destroyer of Worlds",
            "Eater of Souls",
            "Ancient One",
            "Forsaken",
            "Exiled One"
        };

        private const int GodlikeMin = 180;
        private const int UselessMax = 15;
        private const double GodlikeScale = 1.2;
        private const int GodlikeFlatIncrease = 15;
        private const double ChanceOfGodlike = 0.04;

        internal string GenerateDogName(ref Dog dog)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var name = "";

            var prefixChance =
                (float) (dog.Prayer + dog.AtkPower + dog.Defense + dog.Health + dog.Intelligence + dog.Will) / 6 *
                0.01F;
            prefixChance = prefixChance * (prefixChance - 0.7F);


            foreach (var t in _dogPrefixes)
                if (rnd.NextDouble() < prefixChance)
                {
                    name += t + " ";
                    break;
                }

            name += _dogNames[rnd.Next(0, _dogNames.Count)];


            if (rnd.NextDouble() < ChanceOfGodlike)
            {
                name += " the " + _dogSuffixGodlike[rnd.Next(0, _dogSuffixGodlike.Count)];

                dog.AtkPower = (int) ((dog.AtkPower + GodlikeFlatIncrease) * GodlikeScale);
                dog.Defense = (int) ((dog.Defense + GodlikeFlatIncrease) * GodlikeScale);
                dog.Health = (int) ((dog.Health + GodlikeFlatIncrease) * GodlikeScale);
                dog.Intelligence = (int) ((dog.Intelligence + GodlikeFlatIncrease) * GodlikeScale);
                dog.Will = (int) ((dog.Will + GodlikeFlatIncrease) * GodlikeScale);
                dog.Prayer = (int) ((dog.Prayer + GodlikeFlatIncrease) * GodlikeScale);

                Console.WriteLine("\n!!!GODLIKE!!!\n");
            }

            else if (dog.AtkPower < UselessMax &&
                     dog.Defense < UselessMax &&
                     dog.Health < UselessMax &&
                     dog.Intelligence < UselessMax &&
                     dog.Will < UselessMax &&
                     dog.Prayer < UselessMax)
            {
                name += " the " + _dogSuffixUseless[rnd.Next(0, _dogSuffixUseless.Count)];
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