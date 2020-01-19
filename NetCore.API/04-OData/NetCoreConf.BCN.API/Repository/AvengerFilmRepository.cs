namespace NetCoreConf.BCN.API.Repository
{
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Data;
    using NetCoreConf.BCN.API.Model;

    public class AvengerFilmRepository : RepositoryBase<AvengerFilm>, IAvengerFilmRepository
    {
        public AvengerFilmRepository(ILogger logger, AvengerDbContext dataContext) : base(logger, dataContext)
        {
        }
    }
}
