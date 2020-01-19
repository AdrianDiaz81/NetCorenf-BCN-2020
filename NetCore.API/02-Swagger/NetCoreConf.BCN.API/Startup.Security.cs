namespace NetCoreConf.BCN.API
{
    using Microsoft.Extensions.DependencyInjection;
    public partial class Startup
    {
        public void AddSecurity(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(nameof(Model.Enum.Cors.AllAccess),
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }

}
