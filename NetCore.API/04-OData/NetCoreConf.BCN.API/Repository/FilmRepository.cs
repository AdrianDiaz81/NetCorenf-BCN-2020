namespace NetCoreConf.BCN.API.Repository
{
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Data;
    using NetCoreConf.BCN.API.Model;

    public class FilmRepository : RepositoryBase<Film>, IFilmRepository
    {
        public FilmRepository(ILogger logger, AvengerDbContext dataContext) : base(logger, dataContext)
        {
        }
    }
}