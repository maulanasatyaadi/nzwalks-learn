using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Difficulity> Difficulities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WalkingPath> WalkingPaths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulities = new[]
            {
                new Difficulity { Id = 1, Title = "Easy", DifficulityScale = 1 },
                new Difficulity { Id = 2, Title = "Moderate", DifficulityScale = 2 },
                new Difficulity { Id = 3, Title = "Hard", DifficulityScale = 3 }
            };

            modelBuilder.Entity<Difficulity>().HasData(difficulities);

            var regions = new[]
            {
                new Region { Id = 1, Name = "Northland" },
                new Region { Id = 2, Name = "Auckland" },
                new Region { Id = 3, Name = "Waikato" },
                new Region { Id = 4, Name = "Bay of Plenty" },
                new Region { Id = 5, Name = "Gisborne" },
                new Region { Id = 6, Name = "Hawke's Bay" },
                new Region { Id = 7, Name = "Taranaki" },
                new Region { Id = 8, Name = "Manawatu-Wanganui" },
                new Region { Id = 9, Name = "Wellington" },
                new Region { Id = 10, Name = "Tasman" },
                new Region { Id = 11, Name = "Nelson" },
                new Region { Id = 12, Name = "Marlborough" },
                new Region { Id = 13, Name = "West Coast" },
                new Region { Id = 14, Name = "Canterbury" },
                new Region { Id = 15, Name = "Otago" },
                new Region { Id = 16, Name = "Southland" }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
