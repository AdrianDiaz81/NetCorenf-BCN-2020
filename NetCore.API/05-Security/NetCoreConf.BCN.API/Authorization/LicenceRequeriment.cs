
namespace NetCoreConf.BCN.API.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    public class LicenceRequirement : IAuthorizationRequirement
    {
        public bool Licence { get; }

        public LicenceRequirement(bool licence )
        {
            Licence = licence;
        }
    }
}
