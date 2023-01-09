using GSF0DD_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GSF0DD_HFT_2022231.Repository.Data
{
    public class GameListDbContext : DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        public GameListDbContext()
        {
            this.Database.EnsureCreated();
        }

        public GameListDbContext(DbContextOptions<GameListDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("gamelistdb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(game => game.Publisher)
                    .WithMany(Publisher => Publisher.Games)
                    .HasForeignKey(game => game.PublisherId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(game => game.Genre)
                .WithMany(Genre => Genre.Games)
                .HasForeignKey(game => game.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() {GenreId=1, Name= "Action" },
                new Genre() { GenreId = 2, Name = "RPG" },
                new Genre() { GenreId = 3, Name = "MMO" },
                new Genre() { GenreId = 4, Name = "OpenWorld" },
            });

            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher() { PublisherId = 1, Name = "From Software" },
                new Publisher() { PublisherId = 2, Name = "Activision" },
                new Publisher() { PublisherId = 3, Name = "Blizzard" },
                new Publisher() { PublisherId = 4, Name = "CD Project Red" },
                new Publisher() { PublisherId = 5, Name = "Valve" },

            });
            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                new Game() {GameId =1, PublisherId=4, GenreId=2, ReleaseDate=new DateTime(2006,06,10), Name= "Witcher 3"},
                new Game() { GameId = 2, PublisherId = 1, GenreId = 1, ReleaseDate=new DateTime(2017,10,1), Name = "Dark Souls 3" },
                new Game() { GameId = 3, PublisherId = 1, GenreId = 4, ReleaseDate=new DateTime(2022,03,10),  Name = "Elden Ring" },
                new Game() { GameId = 4, PublisherId = 2, GenreId = 1, ReleaseDate=new DateTime(2004,06,11), Name = "Call of Duty 2" },
                new Game() { GameId = 5, PublisherId = 3, GenreId = 3, ReleaseDate=new DateTime(2006,08,20),  Name = "World of Warcraft" },
                new Game() { GameId = 6, PublisherId = 5, GenreId = 1, ReleaseDate=new DateTime(2003,02,16), Name = "Half Life 2" },
            });
        }
    }
}
