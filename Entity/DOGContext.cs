using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DOG.Entity
{
    public partial class DOGContext : DbContext
    {
        public DOGContext()
        {
        }

        public DOGContext(DbContextOptions<DOGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(File.ReadAllText("conn.txt"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AtkPower).HasColumnName("atk_power");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.DateGotten)
                    .HasColumnName("date_gotten")
                    .HasColumnType("datetime");

                entity.Property(e => e.Defense).HasColumnName("defense");

                entity.Property(e => e.Enchantment).HasColumnName("enchantment");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Health).HasColumnName("health");

                entity.Property(e => e.ImagePath)
                    .HasColumnName("image_path")
                    .HasMaxLength(100);

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.LastTrained)
                    .HasColumnName("last_trained")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Origin)
                    .HasColumnName("origin")
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Prayer).HasColumnName("prayer");

                entity.Property(e => e.Will).HasColumnName("will");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Dogs)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Dogs_Users");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AtkPower).HasColumnName("atk_power");

                entity.Property(e => e.Defense).HasColumnName("defense");

                entity.Property(e => e.DogId).HasColumnName("dog_id");

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Slot).HasColumnName("slot");

                entity.Property(e => e.SpecialEffect).HasColumnName("special_effect");

                entity.Property(e => e.Will).HasColumnName("will");

                entity.HasOne(d => d.Dog)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.DogId)
                    .HasConstraintName("FK_Items_Dogs");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bones).HasColumnName("bones");

                entity.Property(e => e.DiscordId)
                    .IsRequired()
                    .HasColumnName("discord_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrainerExperience).HasColumnName("trainer_experience");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}