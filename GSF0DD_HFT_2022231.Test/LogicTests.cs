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
        Mock<IRepository<Genre>> genreMocRepo;

        [SetUp]
        public void Initialize()
        {
            Publisher FromSoftware = new Publisher() { PublisherId = 1, Name = "From Software" };
            Publisher Activision = new Publisher() { PublisherId = 2, Name = "Activision" };
            Publisher Blizzard = new Publisher() { PublisherId = 3, Name = "Blizzard" };
            Publisher CDRED = new Publisher() { PublisherId = 4, Name = "CD Project Red" };
            Publisher Valve = new Publisher() { PublisherId = 5, Name = "Valve" };


            Genre Action = new Genre() { GenreId = 1, Name = "Action" };
            Genre RPG = new Genre() { GenreId = 2, Name = "RPG" };
            Genre MMO = new Genre() { GenreId = 3, Name = "MMO" };
            Genre OpenWorld = new Genre() { GenreId = 4, Name = "OpenWorld" };

            var publishers = new List<Publisher>()
            {
                FromSoftware,
                Activision,
                Blizzard
            }.AsQueryable();

            var genres = new List<Genre>()
            {
                Action,
                MMO,
                OpenWorld,
                RPG
            }.AsQueryable();

            var games = new List<Game>()
            {
                new Game() {GameId =1, Publisher=CDRED, PublisherId=CDRED.PublisherId,Genre=OpenWorld, GenreId=OpenWorld.GenreId, ReleaseDate=new DateTime(2006,06,10), Name= "Witcher 3"},
                new Game() { GameId = 2,Publisher=FromSoftware, PublisherId = FromSoftware.PublisherId,Genre=RPG, GenreId = RPG.GenreId, ReleaseDate=new DateTime(2017,10,1), Name = "Dark Souls 3" },
                new Game() { GameId = 3,Publisher=FromSoftware, PublisherId = FromSoftware.PublisherId,Genre=OpenWorld, GenreId = OpenWorld.GenreId, ReleaseDate=new DateTime(2022,03,10),  Name = "Elden Ring" },
                new Game() { GameId = 4,Publisher=Activision, PublisherId = Activision.PublisherId,Genre=Action, GenreId = Action.GenreId, ReleaseDate=new DateTime(2004,06,11), Name = "Call of Duty 2" },
                new Game() { GameId = 5,Publisher=Blizzard, PublisherId = Blizzard.PublisherId,Genre=MMO, GenreId = MMO.GenreId, ReleaseDate=new DateTime(2006,08,20),  Name = "World of Warcraft" },
                new Game() { GameId = 6, Publisher=Valve,PublisherId = Valve.PublisherId,Genre=Action, GenreId = Action.GenreId, ReleaseDate=new DateTime(2003,02,16), Name = "Half Life 2" },
            }.AsQueryable();

            gameMocRepo = new Mock<IRepository<Game>>();
            gameMocRepo.Setup(x => x.ReadAll()).Returns(games);
            GameLogic = new GameLogic(gameMocRepo.Object);

            genreMocRepo = new Mock<IRepository<Genre>>();
            genreMocRepo.Setup(x => x.ReadAll()).Returns(genres);
            GenreLogic = new GenreLogic(genreMocRepo.Object);

            publisherMocRepo = new Mock<IRepository<Publisher>>();
            publisherMocRepo.Setup(x => x.ReadAll()).Returns(publishers);
            PublisherLogic = new PublisherLogic(publisherMocRepo.Object);
        }

        [Test]
        public void GamesPublishedByFromSoftwareTEST()
        {
            var result = GameLogic.GamesPublishedByFromSoftware();

            var expected = new List<Game>()
            {
                new Game() { GameId = 2, PublisherId = 1, GenreId = 2, ReleaseDate=new DateTime(2017,10,1), Name = "Dark Souls 3" },
                new Game() { GameId = 3, PublisherId = 1, GenreId = 4, ReleaseDate=new DateTime(2022,03,10),  Name = "Elden Ring" },
            }.AsQueryable();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GamesReleasedBetween2012And2022ByFromSoftwareTEST()
        {
            var result = GameLogic.GamesReleasedBetween2012And2022ByFromSoftware();

            var expected = new List<Game>()
            {
                new Game() { GameId = 2, PublisherId = 1, GenreId = 2, ReleaseDate=new DateTime(2017,10,1), Name = "Dark Souls 3" },
            }.AsQueryable();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GamesWithActionGenreTEST()
        {
            var result = GameLogic.GamesWithActionGenre();

            var expected = new List<Game>()
            {
                new Game() { GameId = 4, ReleaseDate=new DateTime(2004,06,11), Name = "Call of Duty 2" },
                new Game() { GameId = 6,  ReleaseDate=new DateTime(2003,02,16), Name = "Half Life 2" }
            }.AsQueryable();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GamesWithOpenWorldgenrereleasedByFromSoftwareTEST()
        {
            var result = GameLogic.GamesWithOpenWorldgenrereleasedByFromSoftware();

            var expected = new List<Game>()
            {
                new Game() { GameId = 3, ReleaseDate=new DateTime(2022,03,10),  Name = "Elden Ring" },
            }.AsQueryable();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ActivisionGamesTEST()
        {
            var result = GameLogic.ActivisionGames();

            var expected = new List<Game>()
            {
                new Game() { GameId = 4, ReleaseDate=new DateTime(2004,06,11), Name = "Call of Duty 2" },
            }.AsQueryable();

            Assert.AreEqual(expected, result);
        }


        [Test]
        public void CreateTest1()
        {
            var proc = new Game() { Name = "sajt", ReleaseDate = new DateTime(1999, 01, 01) };
            GameLogic.Create(proc);
            gameMocRepo.Verify(x => x.Create(proc), Times.Once());
        }
        [Test]
        public void CreateTest2()
        {
            var proc = new Game() { Name = "" };
            try
            {
                GameLogic.Create(proc);
            }
            catch
            {
            }
            gameMocRepo.Verify(t => t.Create(proc), Times.Never);
        }

        [Test]
        public void CreatTest3()
        {
            var game = new Game();
            try
            {
                GameLogic.Create(game);
            }
            catch
            {
            }
            Assert.That(() => GameLogic.Create(game), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ReadWithIdTEST()
        {
            Game expected = new Game() { GameId = 1, ReleaseDate = new DateTime(2006, 06, 10), Name = "Witcher 3" };
            gameMocRepo.Setup(t => t.Read(1)).Returns(expected);
            var result = GameLogic.Read(1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DeleteTEST()
        {
            GameLogic.Delete(1);
            gameMocRepo.Verify(t => t.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
