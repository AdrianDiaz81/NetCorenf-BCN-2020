
namespace NetCoreConf.BCN.API.Middleware
{
    using Microsoft.AspNetCore.Http;
    using NetCoreConf.BCN.API.Services;
    using System.Threading.Tasks;

    public class SecurityGroupsMiddleware
    {
        private readonly RequestDelegate next;
        private readonly INetCoreConfServices netCoreConfServices;
        public SecurityGroupsMiddleware(RequestDelegate next, INetCoreConfServices netCoreConfServices)
        {
            this.next = next;
            this.netCoreConfServices = netCoreConfServices;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.Value.Contains("/api"))
            {
                await next(context);
            }
            else
            {                
                var groups = netCoreConfServices.GetLicence(context.User.Identity.Name);
                if (groups)
                {
                    await next(context);
                }
                else
                {
                    context.Abort();                    
                }
            }
        }
    }
    
}
