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
    public class GenreLogic : ILogic<Genre>
    {
        IRepository<Genre> repository;

        public GenreLogic(IRepository<Genre> repository)
        {
            this.repository = repository;
        }

        public void Create(Genre item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Genre Read(int id)
        {
            var genre = repository.Read(id);
            if (genre == null)
            {
                throw new ArgumentException("There is no Genre with id like this!");
            }
            return genre;
        }

        public IEnumerable<Genre> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Genre item)
        {
            this.repository.Update(item);
        }
    }
}
