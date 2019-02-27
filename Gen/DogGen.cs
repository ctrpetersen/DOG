using System;
using System.Runtime.Hosting;
using DOG.Entity;

namespace DOG.Gen
{
    public class DogGen
    {
        internal Dog GenerateDog(int power, int experience)
        {
            var dog = new Dog();
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            var tierSRoll = (90, 100);
            var tier1Roll = (80, 89);
            var tier2Roll = (70, 79);
            var tier3Roll = (60, 69);
            var tier4Roll = (50, 59);
            var tier5Roll = (40, 49);
            var tier6Roll = (30, 39);
            var tier7Roll = (20, 29);
            var tier8Roll = (10, 19);
            var tier9Roll = (0, 9);

            if (power <= 20)
            {
                
            }



            return null;
        }
    }
}