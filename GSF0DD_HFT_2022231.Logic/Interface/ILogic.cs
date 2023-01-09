using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Logic.Interface
{
    public interface ILogic<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
    }
}
