using System;
using System.Collections.Generic;

namespace DOG.Entity
{
    public partial class User
    {
        public User()
        {
            Dogs = new HashSet<Dog>();
        }

        public int Id { get; set; }
        public string DiscordId { get; set; }
        public int? TrainerExperience { get; set; }
        public int? Bones { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}