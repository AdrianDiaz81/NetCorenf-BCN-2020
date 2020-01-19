namespace NetCoreConf.BCN.API.API.Avengers.v2
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    // [Route("api/v{v:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class AvengersController : ControllerBase
    {
        // GET: api/<controller>
        /// <summary>
        /// Get Avengers v2
        /// </summary>
        /// <returns>IEnumerable</returns>
        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers v2")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 version 2", "value2" };
        }
        [HttpGet, MapToApiVersion("2.1")]
        public IEnumerable<string> GetV21()
        {
            return new string[] { "value1 version 2.1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
