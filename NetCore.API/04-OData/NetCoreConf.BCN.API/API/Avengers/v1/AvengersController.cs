namespace NetCoreConf.BCN.API.API.Avengers.v1
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Model;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")] 
    [ODataRoutePrefix("Avengers")]
    public class AvengersController : ODataController
    {

        private readonly IAvengerDomain avengerDomain;

        public AvengersController(IAvengerDomain avengerDomain)
        {
            this.avengerDomain = avengerDomain;
        }
        /// <summary>
        /// Get Avengers
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers")]
        [EnableQuery()]
        [ODataRoute] 
        public async Task<IActionResult> Get()
        {
            var result = await avengerDomain.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get Avengers by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetByIDAvenger")] 
        [ODataRoute("({key})")]
        public async Task<IActionResult> GetById([FromODataUri] int key)
        { 
            var result = await avengerDomain.GetByIdAsync(key);
            return Ok(result);
        }

        /// <summary>
        /// Get Films by Avengers 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetByFilmsIDAvenger")]
        [ODataRoute("({key})/AvengerFilm")]
        public async Task<IActionResult> AvengerFilm([FromODataUri] int key)
        {

            var result = await avengerDomain.GetAllFilmsByIdAsync(key);
            return Ok(result);
        }

        /// <summary>
        /// Add Avengers
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "Create Avenger")]
        [ODataRoute]  
        public async Task<IActionResult> Post([FromBody]Avenger avenger)
        {
            var result = await avengerDomain.InsertAsync(avenger);
            return Ok(result);
        }

        /// <summary>
        /// Update Avengers
        /// </summary>
        /// <returns></returns>
        [HttpPut(Name = "Update Avenger")]
        [ODataRoute("({key})")] 
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody]Avenger avenger)
        {
            var result = await avengerDomain.UpdateAsync(avenger);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }

        /// <summary>
        /// Delete Avengers
        /// </summary>
        /// <returns></returns>
        [HttpDelete(Name = "Delete Avenger")]
        [ODataRoute("({key})")]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var result = await avengerDomain.DeleteAsync(key);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
