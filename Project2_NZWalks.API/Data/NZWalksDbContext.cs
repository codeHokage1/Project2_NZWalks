using Microsoft.EntityFrameworkCore;
using Project2_NZWalks.API.Models.Entities;

namespace Project2_NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options): base(options)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a list of difficulties: Easy,Medium,Hard
            var difficulties = new List<Difficulty>(){
                new Difficulty()
                {
                    Id= Guid.NewGuid(),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id= Guid.NewGuid(),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id= Guid.NewGuid(),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Create list of Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id= Guid.NewGuid(),
                    Code= "LA",
                    Name="Lagos",
                    RegionImageURL="https://lagos.jpeg"
                },
                new Region()
                {
                    Id= Guid.NewGuid(),
                    Code= "KW",
                    Name="Kwara",
                    RegionImageURL="https://kwara.jpeg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
