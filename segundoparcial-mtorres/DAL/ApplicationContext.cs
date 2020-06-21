using segundoparcial_mtorres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace segundoparcial_mtorres.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Anime> Anime { get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Manga> Manga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnimeBuilder());
        }
    }
}
