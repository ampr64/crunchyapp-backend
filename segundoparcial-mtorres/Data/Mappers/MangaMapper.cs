using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segundoparcial_mtorres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.DAL.Mappers
{
    public class MangaMapper : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.ImageURL)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}