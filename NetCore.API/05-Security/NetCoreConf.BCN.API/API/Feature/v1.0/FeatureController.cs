using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreConf.BCN.API.API.Hulk.v1._0
{
    [Route("api/[controller]")]
    [ApiController]

    public class FeatureAvengersController : ControllerBase
    {
        // GET: api/Hulk
        [HttpGet]
        [Route("featurehulk")]
        [Authorize(Roles = "Hulk")]
        public IEnumerable<string> GetHulk()
        {
            return new string[] { "fuerte", "leal" };
        }

        [HttpGet]
        [Route("featureviudanegra")]
        [Authorize(Roles = "ViudaNeegra")]
        public IEnumerable<string> GetViudaNegra()
        {
            return new string[] { "habilidosa", "silenciosa", "inteligente" };
        }
        
        [HttpGet]        
        [Authorize]
        public IEnumerable<string> Get()
        {
            if (User.IsInRole("Hulk"))
            {
                return new string[] { "fuerte", "leal" };
            }
            else
            {
                return new string[] { "difernte" };
            }
        }


        // GET: api/Hulk/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize(Policy = "Licence")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hulk
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Hulk/5
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
