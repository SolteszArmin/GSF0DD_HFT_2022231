using GSF0DD_HFT_2022231.Logic.Classes;
using GSF0DD_HFT_2022231.Models;
using GSF0DD_HFT_2022231.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTests
    {
        GameLogic GameLogic;
        GenreLogic GenreLogic;
        PublisherLogic PublisherLogic;
        Mock<IRepository<Game>> gameMocRepo;
        Mock<IRepository<Publisher>> publisherMocRepo;
        Mock<IRepository<Genre>> GenreMocRepo;

        [SetUp]
        public void Initialize()
        {
            Publisher FromSoftware = new Publisher() { Name = "From Software", PublisherId = 1 };
            Publisher Activision = new Publisher() { Name = "Activision", PublisherId = 2 };
            Publisher Blizzard = new Publisher() { Name = "Blizzard", PublisherId = 3 };

            Genre Action = new Genre() { Name = "Action", GenreId = 1 };
            Genre MMO = new Genre() { Name = "MMO", GenreId = 2 };
            Genre OpenWorld = new Genre() { Name = "OpenWorld", GenreId = 3 };

            var publishers = new List<Publisher>()
            {
                new Publisher() { Name="From Software", PublisherId=1 },
            new Publisher() { Name = "Activision", PublisherId = 2 },
            new Publisher() { Name = "Blizzard", PublisherId = 3 }
            }.AsQueryable();

            var genres = new List<Genre>()
            {
                new Genre() { Name = "Action", GenreId = 1 },
                new Genre() { Name = "MMO", GenreId = 2 },
                new Genre() { Name = "OpenWorld", GenreId = 3 }
            }.AsQueryable();

            var games = new List<Game>()
            {
                new Game() {GameId=1,Name="World of Warcraft", GenreId=2, PublisherId=3, ReleaseDate=new DateTime(2004,10,4)},
                new Game() {GameId=2,Name="Elden Ring", GenreId=3, PublisherId=1, ReleaseDate=new DateTime(2022,10,4)},
                new Game() {GameId=3,Name="Dark souls 2", GenreId=1, PublisherId=1, ReleaseDate=new DateTime(20015,10,4)},
                new Game() {GameId=4,Name="Sekiro", GenreId=1, PublisherId=1, ReleaseDate=new DateTime(2021,10,4)},
                new Game() {GameId=5,Name="Call of Duty 2", GenreId=1, PublisherId=2, ReleaseDate=new DateTime(2012,10,4)},
            }.AsQueryable();

            gameMocRepo = new Mock<IRepository<Game>>();
            gameMocRepo.Setup(x => x.ReadAll()).Returns(games);
            GameLogic = new GameLogic(gameMocRepo.Object);

            GenreMocRepo = new Mock<IRepository<Genre>>();
            GenreMocRepo.Setup(x => x.ReadAll()).Returns(genres);
            GenreLogic = new GenreLogic(GenreMocRepo.Object);

            publisherMocRepo = new Mock<IRepository<Publisher>>();
            publisherMocRepo.Setup(x => x.ReadAll()).Returns(publishers);
            PublisherLogic = new PublisherLogic(publisherMocRepo.Object);
        }
    }
}
