using System;
using System.Collections.Generic;
using DOG.Entity;

namespace DOG.Gen
{
    internal class NameGen
    {
        private List<string> _dogPrefixes = new List<string>
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

        private List<string> _dogNames = new List<string>
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

        private List<string> _dogSuffixDefense = new List<string>
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

        private List<string> _dogSuffixHealth = new List<string>
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

        private List<string> _dogSuffixInt = new List<string>
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

        private List<string> _dogSuffixWill = new List<string>
        {
            "Steel-willed",
            "Iron-willed"
            "Gene King",
            "Scarred",
            "Unhinged"
            "Number one Social Worker",
            "Suicide Hotline host",
            "Happy",
            "Jaded",
            "Ocean Hound",
            "Soulful",
            "Empath Silk"
        };

        private List<string> _dogSuffixPrayer = new List<string>
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
            "Bulwark of Dogs"
        };

        private List<string> _dogSuffixAtk = new List<string>
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
            "Genocider",
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

        private List<string> _dogSuffixUseless = new List<string>
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
            "Incel",
            "Hopelessly stupid",
            "Hopeless",
            "Diseased",
            "One-hundred years old wrinkled puppy",
            "Manchild",
            "Vagan's Avatar",
            "Caustically autistic",
            "Critically Failing",
            "Hollowed Internal Structure",
            "Seriously bad at everything",
            "Subscribed to the Euthanasia list",
            "PETA defender",
            "Self-righteous",
            "bacteria that won't be a thing to become",
            "Brainless"
        };

        private List<string> _dogSuffixGodlike = new List<string>
        {
            "Destroyer of Worlds",
            "Eater of Souls",
            "Ancient One",
            "Forsaken",
            "Exiled One",
            "Divine Divinity"
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

        private const int GodlikeMin = 85;
        private const int UselessMax = 15;

        internal string GenerateDogName(Dog dog)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var name = "";

            var prefixChance = (float)(dog.Prayer + dog.AtkPower + dog.Defense + dog.Health + dog.Intelligence + dog.Will) / 6 * 0.01F;
            prefixChance = prefixChance * (prefixChance - 0.7F);
            

            foreach (var t in _dogPrefixes)
            {
                if (rnd.NextDouble() < prefixChance)
                {
                    name += t + " ";
                    break;
                }
            }

            name += _dogNames[rnd.Next(0, _dogNames.Count)];

            if (dog.AtkPower < UselessMax && 
                dog.Defense < UselessMax && 
                dog.Health < UselessMax && 
                dog.Intelligence < UselessMax && 
                dog.Will < UselessMax &&
                dog.Prayer < UselessMax)
            {
                name += " the " + _dogSuffixUseless[rnd.Next(0, _dogSuffixUseless.Count)];
            }

            else if (dog.AtkPower > GodlikeMin && 
                     dog.Defense > GodlikeMin && 
                     dog.Health > GodlikeMin && 
                     dog.Intelligence > GodlikeMin &&
                     dog.Will > GodlikeMin && 
                     dog.Prayer > GodlikeMin)
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
