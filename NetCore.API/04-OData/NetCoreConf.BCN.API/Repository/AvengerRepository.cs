namespace NetCoreConf.BCN.API.Repository
{
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Data;
    using NetCoreConf.BCN.API.Model;

    public class AvengerRepository : RepositoryBase<Avenger>, IAvengerRepository
    {
        public AvengerRepository(ILogger logger, AvengerDbContext dataContext) : base(logger, dataContext)
        {
        }
    }
}