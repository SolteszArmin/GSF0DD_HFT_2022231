using GSF0DD_HFT_2022231.Models;
using GSF0DD_HFT_2022231.Repository.Data;
using GSF0DD_HFT_2022231.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Repository.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {
        public PublisherRepository(GameListDbContext ctx) : base(ctx)
        {
        }

        public override Publisher Read(int id)
        {
            return ctx.Publishers.FirstOrDefault(t => t.PublisherId == id);
        }

        public override void Update(Publisher item)
        {
            var old = Read(item.PublisherId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
