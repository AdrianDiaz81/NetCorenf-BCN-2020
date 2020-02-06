namespace NetCoreConf.BCN.API.API.Avengers.v2
{
    using System.Collections.Generic;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [ODataRoutePrefix("Avengers")] 
    public class AvengersController : ODataController
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
        [HttpGet(Name = "Get All Avengers v2.0")]
        [ODataRoute]
        [MapToApiVersion("2.0")] 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 version 2", "value2" };
        }

        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers v2.1")]
        [ODataRoute]
        [MapToApiVersion("2.1")]
        public IEnumerable<string> GetV21()
        {
            return new string[] { "value1 version 2.1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet( Name = "GetByIDAvenger V2.x")] 
        [ODataRoute("({key})")]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("2.1")]
        public string Get([FromODataUri] int key)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost(Name = "Create Avenger V2.x")] 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name = "Update Avenger V2.x")] 

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}", Name = "Delete Avenger V2.x")] 
        public void Delete(int id)
        {
        }
    }
}
