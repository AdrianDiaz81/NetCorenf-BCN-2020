using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace NetCoreConf.BCN.API.Extensions
{
    /// <summary>
    /// ODataQueryOptionsFilter
    /// </summary>
    public class ODataQueryOptionsFilter : IOperationFilter
    {
        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var queryAttribute = context.MethodInfo.GetCustomAttributes(true)
                .Union(context.MethodInfo.DeclaringType.GetCustomAttributes(true))
                .OfType<EnableQueryAttribute>().FirstOrDefault();

            if (queryAttribute != null)
            { 
                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Select))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$select",
                        In = ParameterLocation.Query,
                        Description = "Selects which properties to include in the response.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Expand))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$expand",
                        In = ParameterLocation.Query,
                        Description = "Expands related entities inline.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                // Additional OData query options are available for collections of entities only

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Filter))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$filter",
                        In = ParameterLocation.Query,
                        Description = "Filters the results, based on a Boolean condition.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.OrderBy))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$orderby",
                        In = ParameterLocation.Query,
                        Description = "Determines what values are used to order a collection of results.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Top))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$top",
                        In = ParameterLocation.Query,
                        Description = "The max number of results.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Skip))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$skip",
                        In = ParameterLocation.Query,
                        Description = "The number of results to skip.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (queryAttribute.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Count))
                {
                    operation.Parameters?.Add(new OpenApiParameter
                    {
                        Name = "$count",
                        In = ParameterLocation.Query,
                        Description = "Returns count of results.",
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }
            }
        }
    }
}
