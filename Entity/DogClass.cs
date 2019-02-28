using System;

namespace DOG.Entity
{
    internal enum DogClasses
    {
        Guardian = 0, //def+hp+atk
        Champion = 1, //hp+atk+def
        Paladin = 2, //prayer+will+int
        Assassin = 3, //atk+will+prayer
        Warlock = 4, //will+def+health
        Elementalist = 5 //int+will+health
    }

    internal enum DogClassSpecialEffect
    {
        GuardianEffect = 0,
        ChampionEffect = 1,
        PaladinEffect = 2,
        AssassinEffect = 3,
        WarlockEffect = 4,
        ElementalistEffect = 5
    }

    internal struct DogClassBonuses
    {
        internal float HealthScaling;
        internal float AtkPowerScaling;
        internal float DefenseScaling;
        internal float PrayerScaling;
        internal float WillScaling;
        internal float IntelligenceScaling;
        internal DogClassSpecialEffect SpecialEffect;
    }

    internal static class DogClass
    {
        internal static DogClassBonuses GetClassBonus(DogClasses dogClass)
        {
            var classBonus = new DogClassBonuses();

            switch (dogClass)
            {
                case DogClasses.Guardian:
                    classBonus.DefenseScaling = 1.2F;
                    classBonus.HealthScaling = 1.2F;
                    classBonus.AtkPowerScaling = 1.0F;

                    classBonus.PrayerScaling = 0.9F;
                    classBonus.WillScaling = 0.9F;
                    classBonus.IntelligenceScaling = 0.8F;
                    break;

                case DogClasses.Champion:
                    classBonus.DefenseScaling = 1.1F;
                    classBonus.HealthScaling = 1.3F;
                    classBonus.AtkPowerScaling = 1.1F;

                    classBonus.PrayerScaling = 0.7F;
                    classBonus.WillScaling = 0.8F;
                    classBonus.IntelligenceScaling = 0.6F;
                    break;

                case DogClasses.Paladin:
                    classBonus.DefenseScaling = 1.1F;
                    classBonus.HealthScaling = 1.1F;
                    classBonus.AtkPowerScaling = 0.7F;

                    classBonus.PrayerScaling = 1.4F;
                    classBonus.WillScaling = 1.1F;
                    classBonus.IntelligenceScaling = 0.4F;
                    break;

                case DogClasses.Assassin:
                    classBonus.DefenseScaling = 0.4F;
                    classBonus.HealthScaling = 0.5F;
                    classBonus.AtkPowerScaling = 2.1F;

                    classBonus.PrayerScaling = 0.5F;
                    classBonus.WillScaling = 0.5F;
                    classBonus.IntelligenceScaling = 0.4F;
                    break;

                case DogClasses.Warlock:
                    classBonus.DefenseScaling = 1.3F;
                    classBonus.HealthScaling = 1.3F;
                    classBonus.AtkPowerScaling = 0.6F;

                    classBonus.PrayerScaling = 0.1F;
                    classBonus.WillScaling = 1.3F;
                    classBonus.IntelligenceScaling = 1.4F;
                    break;

                case DogClasses.Elementalist:
                    classBonus.DefenseScaling = 0.8F;
                    classBonus.HealthScaling = 1F;
                    classBonus.AtkPowerScaling = 0.5F;

                    classBonus.PrayerScaling = 1F;
                    classBonus.WillScaling = 1.5F;
                    classBonus.IntelligenceScaling = 2.0F;
                    break;
            }

            return classBonus;


        }
    }

    

    
}