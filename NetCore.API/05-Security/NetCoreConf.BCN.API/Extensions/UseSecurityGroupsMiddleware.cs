namespace NetCoreConf.BCN.API.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using NetCoreConf.BCN.API.Middleware;

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityGroups(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SecurityGroupsMiddleware>();
        }
    }
}
