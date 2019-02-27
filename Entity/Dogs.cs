using System;
using System.Collections.Generic;

namespace DOG
{
    public partial class Dogs
    {
        public Dogs()
        {
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public DateTime LastTrained { get; set; }
        public DateTime DateGotten { get; set; }
        public int Health { get; set; }
        public int AtkPower { get; set; }
        public int Defense { get; set; }
        public int Will { get; set; }
        public int Intelligence { get; set; }
        public string ImagePath { get; set; }
        public string Origin { get; set; }

        public virtual Users Owner { get; set; }
        public virtual ICollection<Items> Items { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, OwnerId: {OwnerId}, Name: {Name}, Experience: {Experience}, LastTrained: {LastTrained}, DateGotten: {DateGotten}, Health: {Health}, AtkPower: {AtkPower}, Defense: {Defense}, Will: {Will}, Intelligence: {Intelligence}, ImagePath: {ImagePath}, Origin: {Origin}, Owner: {Owner}, Items: {Items}";
        }
    }
}