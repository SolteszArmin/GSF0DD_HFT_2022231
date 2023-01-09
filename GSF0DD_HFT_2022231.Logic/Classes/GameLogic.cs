using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using GSF0DD_HFT_2022231.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Logic.Classes
{
    public class GameLogic : IGameLogic<Game>
    {
        IRepository<Game> repository;

        public GameLogic(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Game> ActivisionGames()
        {
            return from x in this.repository.ReadAll()
                   where x.Publisher.Name.Equals("Activision")
                   select new Game()
                   {
                       GameId = x.GameId,
                       GenreId = x.GenreId,
                       Name = x.Name,
                       PublisherId = x.PublisherId,
                       ReleaseDate = x.ReleaseDate
                   };
        }

        public void Create(Game item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ArgumentException("Name is empty");
            }

            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public IEnumerable<Game> GamesPublishedByFromSoftware()
        {
            return from x in this.repository.ReadAll()
                   where x.Publisher.Name.Equals("From Software")
                   select new Game()
                   {
                       GameId = x.GameId,
                       GenreId = x.GenreId,
                       Name = x.Name,
                       PublisherId = x.PublisherId,
                       ReleaseDate = x.ReleaseDate
                   };
        }

        public IEnumerable<Game> GamesWithOpenWorldgenrereleasedByFromSoftware()
        {
            return from x in this.repository.ReadAll()
                   where x.Genre.Name.Equals("OpenWorld") && x.Publisher.Name.Equals("From Software")
                   select new Game()
                   {
                       GameId = x.GameId,
                       GenreId = x.GenreId,
                       Name = x.Name,
                       PublisherId = x.PublisherId,
                       ReleaseDate = x.ReleaseDate
                   };
        }

        public IEnumerable<Game> GamesWithActionGenre()
        {
            return from x in this.repository.ReadAll()
                   where x.Genre.Name.Equals("Action")
                   select new Game()
                   {
                       GameId = x.GameId,
                       GenreId = x.GenreId,
                       Name = x.Name,
                       PublisherId = x.PublisherId,
                       ReleaseDate = x.ReleaseDate
                   };
        }

        public Game Read(int id)
        {
            var game = repository.Read(id);
            if (game == null)
            {
                throw new ArgumentException("There is no such game with id like this!");
            }
            return game;
        }

        public IEnumerable<Game> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Game item)
        {
            this.repository.Update(item);
        }

        public IEnumerable<Game> GamesReleasedBetween2012And2022ByFromSoftware()
        {
            return from x in this.repository.ReadAll()
                   where x.ReleaseDate >= new DateTime(2012, 01, 01) &&
                   x.ReleaseDate < new DateTime(2022, 01, 01) &&
                   x.Publisher.Name.Equals("From Software")
                   select new Game()
                   {
                       GameId = x.GameId,
                       GenreId = x.GenreId,
                       Name = x.Name,
                       PublisherId = x.PublisherId,
                       ReleaseDate = x.ReleaseDate
                   };
        }
    }
}
