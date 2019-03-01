using System;
using System.Collections.Generic;

namespace DOG
{
    public partial class Item
    {
        public int Id { get; set; }
        public int? Slot { get; set; }
        public int? DogId { get; set; }
        public int? AtkPower { get; set; }
        public int? Defense { get; set; }
        public int? Will { get; set; }
        public int? Intelligence { get; set; }
        public int? SpecialEffect { get; set; }
        public string Name { get; set; }

        public virtual Dog Dog { get; set; }
    }
}