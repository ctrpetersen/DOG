﻿using System;
using System.Collections.Generic;

namespace DOG
{
    public partial class Dog
    {
        public Dog()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public int? Experience { get; set; }
        public DateTime? LastTrained { get; set; }
        public DateTime? DateGotten { get; set; }
        public int? Enchantment { get; set; }
        public int? Class { get; set; }
        public int? Health { get; set; }
        public int? AtkPower { get; set; }
        public int? Defense { get; set; }
        public int? Prayer { get; set; }
        public int? Will { get; set; }
        public int? Intelligence { get; set; }
        public string ImagePath { get; set; }
        public string Origin { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public override string ToString()
        {
            return $"OwnerId: {OwnerId}, Name: {Name}, Experience: {Experience}, " +
                   $"LastTrained: {LastTrained}, DateGotten: {DateGotten}, " +
                   $"Enchantment: {Enchantment}, Class: {Class}, Health: {Health}, " +
                   $"AtkPower: {AtkPower}, Defense: {Defense}, Prayer: {Prayer}, Will: {Will}, " +
                   $"Intelligence: {Intelligence}, ImagePath: {ImagePath}, Origin: {Origin}, Owner: {Owner}";
        }
    }
}