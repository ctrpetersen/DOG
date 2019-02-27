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
        public long DiscordId { get; set; }
        public int TrainerExperience { get; set; }
        public int Bones { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, DiscordId: {DiscordId}, TrainerExperience: {TrainerExperience}, Bones: {Bones}, Dogs: {Dogs}";
        }
    }
}