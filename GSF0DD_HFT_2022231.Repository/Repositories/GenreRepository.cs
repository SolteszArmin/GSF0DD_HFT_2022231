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
    public class GenreRepository : Repository<Genre>, IRepository<Genre>
    {
        public GenreRepository(GameListDbContext ctx) : base(ctx)
        {
        }

        public override Genre Read(int id)
        {
            return ctx.Genres.FirstOrDefault(t => t.GenreId == id);
        }

        public override void Update(Genre item)
        {
            var old = Read(item.GenreId);
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
