using System;
using System.Collections.Generic;
using DOG.Entity;
// ReSharper disable PossibleInvalidOperationException

namespace DOG.Gen
{
    public class NameGen
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
            "Duchess",
            "Praetor",
            "General",
            "Master",
            "Cherubim",
            "Wolf-King"
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
            "Argus",
            "Bailey",
            "Bandit",
            "Baxter",
            "Bear",
            "Beau",
            "Benji",
            "Benny",
            "Bentley",
            "Bits",
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
            "Joe",
            "Joey",
            "Kobe",
            "Leo",
            "Loki",
            "Louie",
            "Lucky",
            "Luke",
            "Mac",
            "Marley",
            "Mars",
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
            "Rogan",
            "Rosie",
            "Roxie",
            "Roxy",
            "Ruby",
            "Sadie",
            "Sally",
            "Samson",
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
            "Zoey",
            "ZoomZoom"
        };

        private readonly List<string> _dogSuffixDefense = new List<string>
        {
            "Tank",
            "Iron Giant",
            "Armoured",
            "Heavy",
            "Heavy-Duty",
            "Absolute Unit",
            "Metal Gear",
            "Jaeger",
            "Colossus",
            "Minotaur",
            "Gauntlet",
            "Vanguard",
            "Iron Strider",
            "Paragon",
            "Agememnon",
            "Guardian",
            "Juggernaut",
            "Sentinel",
            "Dreadnought",
            "Titan",
            "Golem",
            "Steel Machine",
            "Basalt-Infused",
            "Galena-Infused",
            "Iron-Infused"
        };

        private readonly List<string> _dogSuffixHealth = new List<string>
        {
            "Meatsack",
            "Bloodgiant",
            "Thick",
            "Big-boned",
            "Healthy",
            "Robust",
            "Milk-Drinker",
            "Hannibal",
            "Quartz-infused",
            "Emerald-infused",
            "Lion",
            "Peanut Choker",
            "Yoga practicioner",
            "Endurance Hunter",
            "Fit",
            "Shining Sun",
            "Vegetarian",
            "Carnivore",
            "Moss Artifician",
            "Fungi Afficionado",
            "Guacamole Expert"
        };

        private readonly List<string> _dogSuffixInt = new List<string>
        {
            "Smart",
            "Big-brained",
            "Mage",
            "Wise",
            "Enlightened",
            "Nerd",
            "Creator",
            "Inventor",
            "Well-travelled",
            "Lapis-Infused",
            "Crow-like",
            "Raven-like",
            "Agency Director",
            "Shaman",
            "Sage",
            "Philosopher",
            "Scientist",
            "Doggist",
            "Engineer"
        };

        private readonly List<string> _dogSuffixWill = new List<string>
        {
            "Steel-willed",
            "Iron-willed",
            "Gene King",
            "Scarred",
            "Unhinged",
            "Number one Social Worker",
            "Happy",
            "Jaded",
            "Ocean Hound",
            "Soulful",
            "Empath Silk"
        };

        private readonly List<string> _dogSuffixPrayer = new List<string>
        {
            "Priest",
            "Pastor",
            "Divine",
            "Head of the Church",
            "Crucifix-bearer",
            "Cult leader",
            "Soulrester",
            "Just",
            "Righteous",
            "Inquisitor",
            "Devout",
            "Pious",
            "Religious",
            "Agnostic",
            "Sacred",
            "Saint",
            "Moral Saint",
            "Sanctified",
            "Holy",
            "Apostle",
            "Scripture Writer",
            "Angel",
            "Bishop",
            "Messenger",
            "Pariah of sins",
            "Virtuous",
            "Templar",
            "Soldier of Faith",
            "Dog of Purity",
            "Saver",
            "Trinitarian Conceptor",
            "Worshipped",
            "Slayer of sinners",
            "Vice-free",
            "Ascended",
            "Speaker to Eternium",
            "Sight Giver",
            "Paws of Heaven",
            "Will of the Gods",
            "Wandering PawJew",
            "Realized utopistic dog",
            "Beacon of Hope",
            "Light",
            "Stream of Dreams",
            "Dream-Maker",
            "Nightmare-Slayer",
            "Bulwark of Humanity",
            "Bulwark of Dogs",
            "Last Bulwark of Hope",
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
            "Ruthless",
            "Pyrite-infused",
            "Incinerator",
            "Savage",
            "Overly Aggressive",
            "Hollow",
            "Shade of Hate",
            "Avatar of Hate",
            "Wrathful",
            "Hateful",
            "Heart-piercer",
            "Organ-stealer",
            "Cannibal",
            "Berserker",
            "Ender",
            "Whale Killer",
            "Mass Murderer",
            "Bloody Gladiator",
            "Champion of Blood",
            "Crimson",
            "Demonic",
            "Sixteen-Pawed",
            "Heavy Weaponry Master",
            "Horse Decapitator",
            "Volcano",
            "Fiery",
            "Maker of widows",
            "Hungry Hyena",
            "Restless",
            "Dervish"
        };

        private readonly List<string> _dogSuffixUseless = new List<string>
        {
            "Useless",
            "Incompetent",
            "Waste of Meat",
            "Salt-infused",
            "Vegan",
            "Yellow Vest",
            "Piece of trash",
            "Abortion that should-have-been",
            "Chihuahua",
            "Hopelessly stupid",
            "Hopeless",
            "Diseased",
            "One-hundred years old wrinkled puppy",
            "Manchild",
            "Vagan's Avatar",
            "Critically Failing",
            "Hollowed public Structure",
            "Seriously bad at everything",
            "PETA defender",
            "Self-righteous",
            "bacteria that won't be a thing to become",
            "Brainless",
            "Idiot"
        };

        private readonly List<string> _dogSuffixGodlike = new List<string>
        {
            "Destroyer of Worlds",
            "Eater of Souls",
            "Ancient One",
            "Forsaken",
            "Exiled One",
            "Divine Divinity",
            "Herald of the Apocalypse",
            "Harbinger",
            "Demi-God",
            "Center of Gravity",
            "Unmaker",
            "Black Hole",
            "Ossuary",
            "Infinite Catacomb",
            "Cremator",
            "Dominator from the Seven Hells",
            "Cerberus",
            "Celestial",
            "Absolute",
            "Omnipotent",
            "Omniscient",
            "Second Sun",
            "Time Manipulator",
            "Eternal",
            "Seraphim",
            "Bulwark of the Universe",
            "Salvation"
        };

        private const int GodlikeMin = 180;
        private const int UselessMax = 15;
        private const double GodlikeScale = 1.2;
        private const int GodlikeFlatIncrease = 15;
        private const double ChanceOfGodlike = 0.04;

        public string GenerateDogName(ref Dog dog)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var name = "";

            var prefixChance =
                (float) (dog.prayer + dog.atk_power + dog.defense + dog.health + dog.intelligence + dog.will) / 6 *
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

                dog.atk_power = (int) ((dog.atk_power + GodlikeFlatIncrease) * GodlikeScale);
                dog.defense = (int) ((dog.defense + GodlikeFlatIncrease) * GodlikeScale);
                dog.health = (int) ((dog.health + GodlikeFlatIncrease) * GodlikeScale);
                dog.intelligence = (int) ((dog.intelligence + GodlikeFlatIncrease) * GodlikeScale);
                dog.will = (int) ((dog.will + GodlikeFlatIncrease) * GodlikeScale);
                dog.prayer = (int) ((dog.prayer + GodlikeFlatIncrease) * GodlikeScale);

                Console.WriteLine("\n!!!GODLIKE!!!\n");
            }

            else if (dog.atk_power < UselessMax &&
                     dog.defense < UselessMax &&
                     dog.health < UselessMax &&
                     dog.intelligence < UselessMax &&
                     dog.will < UselessMax &&
                     dog.prayer < UselessMax)
            {
                name += " the " + _dogSuffixUseless[rnd.Next(0, _dogSuffixUseless.Count)];
            }

            else if (dog.atk_power >= dog.defense &&
                     dog.atk_power >= dog.health &&
                     dog.atk_power >= dog.intelligence &&
                     dog.atk_power >= dog.will &&
                     dog.atk_power >= dog.prayer)
            {
                name += " the " + _dogSuffixAtk[rnd.Next(0, _dogSuffixAtk.Count)];
            }

            else if (dog.defense >= dog.atk_power &&
                     dog.defense >= dog.health &&
                     dog.defense >= dog.intelligence &&
                     dog.defense >= dog.will &&
                     dog.defense >= dog.prayer)
            {
                name += " the " + _dogSuffixDefense[rnd.Next(0, _dogSuffixDefense.Count)];
            }

            else if (dog.health >= dog.atk_power &&
                     dog.health >= dog.defense &&
                     dog.health >= dog.intelligence &&
                     dog.health >= dog.will &&
                     dog.health >= dog.prayer)
            {
                name += " the " + _dogSuffixHealth[rnd.Next(0, _dogSuffixHealth.Count)];
            }

            else if (dog.intelligence >= dog.atk_power &&
                     dog.intelligence >= dog.health &&
                     dog.intelligence >= dog.defense &&
                     dog.intelligence >= dog.will &&
                     dog.intelligence >= dog.prayer)
            {
                name += " the " + _dogSuffixInt[rnd.Next(0, _dogSuffixInt.Count)];
            }

            else if (dog.will >= dog.atk_power &&
                     dog.will >= dog.health &&
                     dog.will >= dog.intelligence &&
                     dog.will >= dog.defense &&
                     dog.will >= dog.prayer)
            {
                name += " the " + _dogSuffixWill[rnd.Next(0, _dogSuffixWill.Count)];
            }

            else if (dog.prayer >= dog.atk_power &&
                     dog.prayer >= dog.health &&
                     dog.prayer >= dog.intelligence &&
                     dog.prayer >= dog.defense &&
                     dog.prayer >= dog.will)
            {
                name += " the " + _dogSuffixPrayer[rnd.Next(0, _dogSuffixPrayer.Count)];
            }


            return name;
        }
    }
}
