namespace NetCoreConf.BCN.API.Authorization
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using NetCoreConf.BCN.API.Services;

    public class HulkHandler : AuthorizationHandler<LicenceRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       LicenceRequirement requirement)
        {

           
                context.Succeed(requirement);
            

 
            return Task.CompletedTask;
        }
    }
}
