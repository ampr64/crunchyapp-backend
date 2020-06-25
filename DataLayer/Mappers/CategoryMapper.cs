using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segundoparcial_mtorres.Entities;
using System.Collections.Generic;

namespace segundoparcial_mtorres.DataLayer.Mappers
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(new List<Category>
            {
                new Category(1, "Shounen", "Young male hero focused on action, adventure and fighting."),
                new Category(2, "Isekai", "Isekai is a 'accidental travel' genre of light novels, manga, anime and video games that revolve around a normal person from Earth being transported to, reborn or otherwise trapped in a parallel universe, fantasy world or virtual world."),
                new Category(3, "Western", "Anime and manga in this category reflect the traditions of the Western genre. Westerns usually take place in the American Old West, but the genre has expanded to frontiers beyond, like space and future Japan."),
                new Category(4, "Seinen", "Aimed at demographic of young men between the ages of 15-24. Seinen anime and manga tend to be of a more violent and/or psychological nature than shonen series—though, of course, there are seinen comedies as well. They can also have content of a pornographic nature (though this is not the focus of the work)."),
                new Category(5, "Shojo", @"“Shojo” (少女), which is often translated as “young girl,” is the female counterpart to shonen, and anime and manga of this type are aimed at girls between the ages of ten and eighteen. These tend to focus on romance and interpersonal relationships—though this does not mean they are necessarily without action or adventure."),
                new Category(6, "Josei", @"Anime and manga of the “josei” (女性) variety are aimed at adult women. Josei series are often slice-of-life or romantic tales featuring adult women, though, in recent years, shonen-like action-adventures have become popular as well. In general, these works tend to contain more realistic interpersonal relationships (as opposed to shojo’s often idealized ones) and can cover darker subjects like rape and infidelity.")
            });
        }
    }
}