using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CrunchyAppBackend.Core.Entities;
using System.Collections.Generic;

namespace CrunchyAppBackend.Infrastructure.Data.Mappers
{
    public class MangaMapper : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
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

            builder.HasData(new List<Manga>
            {
                new Manga { Id = 1, CategoryId = 1, Title = "Attack on Titan", Author = "Hajime Isayama", Description = "A century ago, the grotesque giants known as Titans appeared and consumed all but a few thousand humans. The survivors took refuge behind giant walls. Today, the threat of the Titans is a distant memory, and a boy named Eren yearns to explore the world beyond Wall Maria. But what began as a childish dream will become an all-too-real nightmare when the Titans return and humanity is once again on the brink of extinction", Chapters = 129, IsComplete = false, ImageUrl = "https://i1.wp.com/lacomikeria.com/wp-content/uploads/2020/06/Attack-on-Titan-manga.jpg?resize=600%2C400&ssl=1" },
                new Manga { Id = 2, CategoryId = 5, Title = "Lovely Complex", Author = "Aya Nakahara", Description = "Love is unusual for Koizumi Risa and Ootani Atsushi, who are both striving to find their ideal partner in high school—172 cm tall Koizumi is much taller than the average girl, and Ootani is much shorter than the average guy at 156 cm. To add to their plights, their crushes fall in love with each other, leaving Koizumi and Ootani comically flustered and heartbroken. To make matters worse, they\'re even labeled as a comedy duo by their homeroom teacher due to their personalities and the stark difference in their heights, and their classmates even think of their arguments as sketches.", Chapters = 66, IsComplete = false, ImageUrl = "https://uploads.spiritfanfiction.com/fanfics/historias/202001/because-there-is-you-18417494-260120201649.png" },
                new Manga { Id = 3, CategoryId = 4, Title = "Goodnight, Punpun", Author = "Inio Asano", Description = "A coming-of-age drama story, it follows the life of a child named Onodera Punpun, from his elementary school years to his early 20s, as he copes with his dysfunctional family, love life, friends, life goals and hyperactive mind, while occasionally focusing on the lives and struggles of his schoolmates and family. Punpun and the members of his family are normal humans, but are depicted to the reader in the forms of birds. The manga explores themes such as depression, love, social isolation, sex, death, and family.", Chapters = 147, IsComplete = true, ImageUrl = "https://media.metrolatam.com/2020/01/22/template90-703d63d7f00a258de6aea0cc70cd8d85-600x400.jpg" }
            });
        }
    }
}