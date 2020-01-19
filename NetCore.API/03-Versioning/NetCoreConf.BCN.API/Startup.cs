using System;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using NetCoreConf.BCN.API.Data;
using NetCoreConf.BCN.API.Model;

namespace NetCoreConf.BCN.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            AddVersioning(services);
            AddSwagger(services);

            services.AddEntityFrameworkInMemoryDatabase()
                    .AddDbContextPool<AvengerDbContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net Core Conf BCN API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Net Core Conf BCN API V2");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "Net Core Conf BCN API V3");
            });
        }
    }
}
