﻿namespace NetCoreConf.BCN.API.API.Avengers.v3
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreConf.BCN.API.Domain;
    using NetCoreConf.BCN.API.Model;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("3.0")]
    [ApiVersion("3.1")]
    [ApiVersion("3.2")]
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
        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers 3.0")]
        [EnableQuery()]
        [ODataRoute("")] 
        [MapToApiVersion("3.0")]
        public async Task<IActionResult> Get()
        {
            var result = await avengerDomain.GetAllAsync();

            return Ok(result);
        }

        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers 3.1")]
        [ODataRoute("")]
        [MapToApiVersion("3.1")]

        public async Task<IActionResult> Getv31(ODataQueryOptions<Avenger> filter)
        {

            var result = avengerDomain.GetAllAsync(filter);
            return Ok(result);
        }

        ///// <summary>
        ///// Get Avengers
        ///// </summary>
        [SwaggerOperation(Summary = "Get all Avenger", Description = "", Tags = new[] { "Avengers" })]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Avengers successfully", typeof(IEnumerable<Avenger>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data", typeof(ValidationProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", null)]
        [HttpGet(Name = "Get All Avengers 3.2")]
        [EnableQuery()]
        [ODataRoute("")]
        [MapToApiVersion("3.2")]
        public IActionResult Getv32(ODataQueryOptions<Avenger> filter)
        {

            var result = avengerDomain.GetAllAsync(filter);
            var page = new PageResult<Avenger>(result,
              Request.GetNextPageLink(10),
              Request.HttpContext.ODataFeature().TotalCount);
            return Ok(page);
        }

    }
}