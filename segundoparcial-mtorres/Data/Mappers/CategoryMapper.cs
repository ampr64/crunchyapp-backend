using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using segundoparcial_mtorres.Models;

namespace segundoparcial_mtorres.DAL.Mappers
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}