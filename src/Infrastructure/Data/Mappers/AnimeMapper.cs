using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CrunchyAppBackend.Core.Entities;
using System.Collections.Generic;

namespace CrunchyAppBackend.Infrastructure.Data.Mappers
{
    public class AnimeMapper : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .IsUnicode(false)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            builder.HasData(new List<Anime>
            {
                new Anime{ Id = 1, CategoryId = 1, Title = "My Hero Academia", Description = "Izuku has dreamt of being a hero all his life—a lofty goal for anyone, but especially challenging for a kid with no superpowers. That’s right, in a world where eighty percent of the population has some kind of super-powered “quirk,” Izuku was unlucky enough to be born completely normal. But that’s not enough to stop him from enrolling in one of the world’s most prestigious hero academies.", Episodes = 88, IsComplete = false, ImageUrl = "https://i2.wp.com/lacomikeria.com/wp-content/uploads/2020/04/c5c213f074e0325713cce87b281fc78e8b978b95r1-722-1024v2_uhq.jpg?resize=600%2C400&ssl=1" },
                new Anime{ Id = 2, CategoryId = 5, Title = "My Little Monster", Description = "Impassive girl meets trouble maker in a brand new love story! After Mizutani Shizuku, a girl whose sole interest is studying, is asked to deliver some handouts to Yoshida Haru, a boy who hasn\'t come to school after spilling blood on the first day, she finds herself the target of his affection. This is a story about a boy and a girl who struggle with love and friendship. Opening yourself up to other people forces you to be honest with yourself.", Episodes = 13, IsComplete = true, ImageUrl = "https://i.pinimg.com/originals/a0/92/54/a09254f34a19bcbd85d99caffb6a3ee4.png" },
                new Anime{ Id = 3, CategoryId = 4, Title = "Bungou Stray Dogs", Description = "Kicked out of his orphanage and on the verge of starving to death, Nakajima Atsushi meets some strange men. One of them, Dazai Osamu, is a suicidal man attempting to drown himself in broad daylight. The other, bespectacled Kunikida Doppo, nervously stands by flipping through a notepad. Both are members of the  \"Armed Detective Agency \" said to solve incidents that even the military and police won\'t touch. Atsushi ends up accompanying them on a mission to eliminate a man-eating tiger that\'s been terrorizing the population...", Episodes = 37, IsComplete = true, ImageUrl = "https://obs.line-scdn.net/0hMBCFH-r4Em1-PzqfLettOkRpEQJNUwFuGglDcy5RTFkHB1E_FlBfWFI-GVtSDFUzEApZAls8CVwAWlUyRl9f/w644" }     
            });
        }
    }
}