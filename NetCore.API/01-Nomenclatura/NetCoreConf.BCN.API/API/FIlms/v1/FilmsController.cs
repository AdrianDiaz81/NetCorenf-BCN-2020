using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreConf.BCN.API.Domain;
using NetCoreConf.BCN.API.Model;

namespace NetCoreConf.BCN.API.API.FIlms
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmDomain filmsDomain;

        public FilmsController(IFilmDomain filmsDomain)
        {
            this.filmsDomain = filmsDomain;
        }
        // GET: api/Films
        [HttpGet]
        public async Task<IEnumerable<Film>> Get()
        {
            var result = await filmsDomain.GetAllAsync();
            return result;
        }

        // GET: api/Films/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Films
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Films/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
