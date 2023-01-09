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
    public class PublisherLogic : ILogic<Publisher>
    {
        IRepository<Publisher> repository;

        public PublisherLogic(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }

        public void Create(Publisher item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Publisher Read(int id)
        {
            var publisher = repository.Read(id);
            if (publisher == null)
            {
                throw new ArgumentException("There is no publisher with this id!");
            }
            return publisher;
        }

        public IEnumerable<Publisher> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.repository.Update(item);
        }
    }
}
