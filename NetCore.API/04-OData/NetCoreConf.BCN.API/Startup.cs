using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OData;
using Microsoft.OData.Edm;
using NetCoreConf.BCN.API.Data;
using NetCoreConf.BCN.API.Model;
using System;
using System.Linq;

namespace NetCoreConf.BCN.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            AddVersioning(services);
            AddSwagger(services); 
            services.AddODataQueryFilter();
            services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContextPool<AvengerDbContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddControllers();
            services.AddControllers(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
                foreach (var formatter in mvcOptions.OutputFormatters.OfType<ODataOutputFormatter>().Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
                foreach (var formatter in mvcOptions.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            }
           );
        }

        /// <summary>
        /// Configures the application using the provided builder, hosting environment, and logging factory.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current application environment.</param>
        /// <param name="modelBuilder">The <see cref="VersionedODataModelBuilder">model builder</see> used to create OData entity data models (EDMs).</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, VersionedODataModelBuilder modelBuilder, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMvc(routeBuilder =>
            {                    
                routeBuilder.SetDefaultODataOptions( new ODataOptions() { UrlKeyDelimiter = ODataUrlKeyDelimiter.Parentheses } );
                //routeBuilder.ServiceProvider.GetRequiredService<ODataOptions>().UrlKeyDelimiter = ODataUrlKeyDelimiter.Parentheses;
 
                routeBuilder.Select().Filter().OrderBy().Expand().Count().MaxTop(10);
                routeBuilder.MapVersionedODataRoutes("odata", "api", modelBuilder.GetEdmModels());
            });

            app.UseSwagger();
             
            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

        }

        IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Avenger>("Person").EntityType
           .Filter()
           .Count()
           .Expand()
           .OrderBy()
           .Page()
           .Select();
            odataBuilder.EntitySet<Avenger>("Avengers").EntityType
            .Filter()
            .Count()
            .Expand()
            .OrderBy()
            .Page()
            .Select();
            return odataBuilder.GetEdmModel();
        }
    }

    public class OdataModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        { 
            builder.EntitySet<Avenger>("Person").EntityType
               .Filter()
               .Count()
               .Expand()
               .OrderBy()
               .Page()
               .Select();
            builder.EntitySet<Avenger>("Avengers").EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();
        }
    }
}
