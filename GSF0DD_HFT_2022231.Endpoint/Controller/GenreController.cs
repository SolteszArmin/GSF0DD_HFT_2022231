using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSF0DD_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        ILogic<Genre> genrelogic;

        public GenreController(ILogic<Genre> genrelogic)
        {
            this.genrelogic = genrelogic;
        }

        [HttpGet]
        public IEnumerable<Genre> ReadAll()
        {
            return this.genrelogic.ReadAll();
        }
        [HttpGet("{id}")]
        public Genre Read(int id)
        {
            return this.genrelogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Genre c)
        {
            this.genrelogic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Genre c)
        {
            this.genrelogic.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.genrelogic.Delete(id);
        }
    }
}
