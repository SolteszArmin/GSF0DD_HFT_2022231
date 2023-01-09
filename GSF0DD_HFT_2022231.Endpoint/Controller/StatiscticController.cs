using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSF0DD_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatiscticController : ControllerBase
    {
        IGameLogic<Game> gamelogic;

        public StatiscticController(IGameLogic<Game> gamelogic)
        {
            this.gamelogic = gamelogic;
        }

        [HttpGet]
        public IEnumerable<Game> GamesWithActionGenre()
        {
            return this.gamelogic.GamesWithActionGenre();
        }
        [HttpGet]
        public IEnumerable<Game> GamesWithOpenWorldgenrereleasedByFromSoftware()
        {
            return this.gamelogic.GamesWithOpenWorldgenrereleasedByFromSoftware();
        }
        [HttpGet]
        public IEnumerable<Game> ActivisionGames()
        {
            return this.gamelogic.ActivisionGames();
        }
        [HttpGet]
        public IEnumerable<Game> GamesReleasedBetween2012And2022ByFromSoftware()
        {
            return this.gamelogic.GamesReleasedBetween2012And2022ByFromSoftware();
        }
        [HttpGet]
        public IEnumerable<Game> GamesPublishedByFromSoftware()
        {
            return this.gamelogic.GamesPublishedByFromSoftware();
        }
    }
}
