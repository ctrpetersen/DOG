using System;
using System.Collections.Generic;

namespace DOG
{
    public partial class Users
    {
        public Users()
        {
            Dogs = new HashSet<Dogs>();
        }

        public int Id { get; set; }
        public long DiscordId { get; set; }
        public int TrainerExperience { get; set; }
        public int Bones { get; set; }

        public virtual ICollection<Dogs> Dogs { get; set; }
    }
}