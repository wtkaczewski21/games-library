using GamesLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "Skyrim",
                    Category = "RPG",
                    ReleaseDate = new DateTime(2011, 11, 11),
                },
                new Game
                {
                    Id = 2,
                    Title = "Heroes",
                    Category = "Strategy",
                    ReleaseDate = new DateTime(2011, 11, 11),
                }, new Game
                {
                    Id = 3,
                    Title = "FIFA",
                    Category = "Sport",
                    ReleaseDate = new DateTime(2011, 11, 11),
                }
                );
        }

        public DbSet<Game> Games { get; set; }
    }
}
