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


        public override string ToString()
        {
            return $"Id: {Id}, DiscordId: {DiscordId}, TrainerExperience: {TrainerExperience}, Bones: {Bones}, Dogs: {Dogs}";
        }
    }
}