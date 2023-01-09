using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSF0DD_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic<Game> gameLogic;

        public GameController(IGameLogic<Game> gameLogic)
        {
            this.gameLogic = gameLogic;
        }

        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.gameLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.gameLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Game c)
        {
            this.gameLogic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Game c)
        {
            this.gameLogic.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.gameLogic.Delete(id);
        }
    }
}
