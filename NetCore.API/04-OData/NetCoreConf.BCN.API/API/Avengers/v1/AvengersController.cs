namespace NetCoreConf.BCN.API.API.Avengers.v1
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Model;
    using Swashbuckle.AspNetCore.Annotations;
    [ApiVersion("1.0")]
    //[ApiVersion("1.0", Deprecated = true)]
    // [Route("api/v{v:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class AvengersController : ControllerBase
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
        public async Task<IActionResult> Get()
        {
            var result = await avengerDomain.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get Avengers by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetByIDAvenger")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await avengerDomain.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Films by Avengers 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/films", Name = "GetByFilmsIDAvenger")]
        public async Task<IActionResult> GetFilmsById(int id)
        {
            
            
            var result =  await avengerDomain.GetAllFilmsByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Add Avengers
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Avenger avenger)
        {
            var result = await avengerDomain.InsertAsync(avenger);
            return Ok(result);
        }

        /// <summary>
        /// Update Avengers
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Avenger avenger)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await avengerDomain.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
