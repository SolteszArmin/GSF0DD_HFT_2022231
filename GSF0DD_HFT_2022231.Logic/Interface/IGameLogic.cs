using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Logic.Interface
{
    public interface IGameLogic<T> : ILogic<T> where T : class
    {
        IEnumerable<T> GamesWithActionGenre();
        IEnumerable<T> ActivisionGames();
        IEnumerable<T> GamesWithOpenWorldgenrereleasedByFromSoftware();
        IEnumerable<T> GamesPublishedByFromSoftware();
        IEnumerable<T> GamesReleasedBetween2012And2022ByFromSoftware();
    }
}
