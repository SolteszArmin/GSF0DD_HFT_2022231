using GSF0DD_HFT_2022231.Logic.Interface;
using GSF0DD_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSF0DD_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        ILogic<Publisher> publisherLogic;

        public PublisherController(ILogic<Publisher> publisherLogic)
        {
            this.publisherLogic = publisherLogic;
        }

        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.publisherLogic.ReadAll();
        }
        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return this.publisherLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher c)
        {
            this.publisherLogic.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Publisher c)
        {
            this.publisherLogic.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.publisherLogic.Delete(id);
        }
    }
}
