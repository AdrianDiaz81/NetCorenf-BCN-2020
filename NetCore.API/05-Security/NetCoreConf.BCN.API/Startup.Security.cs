namespace NetCoreConf.BCN.API
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyInjection;
    using NetCoreConf.BCN.API.Authorization;

    public partial class Startup
    {
        public void AddSecurity(IServiceCollection services)
        {
            // Add all of your handlers to DI.
            services.AddSingleton<IAuthorizationHandler, HulkHandler>();
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Licence", policy =>
                    policy.Requirements.Add(new LicenceRequirement(true)));
            });
        }
    }

}
