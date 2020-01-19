namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using NetCoreConf.BCN.API.Model;
    public interface IFilmDomain
    {
        Task<IEnumerable<Film>> GetAllAsync();
        IEnumerable<dynamic> GetAllAsync(ODataQueryOptions<Film> filter);
        Task<Film> GetByIdAsync(int id);

        Task<Film> InsertAsync(Film people);
        Task<bool> UpdateAsync(Film people);
        Task<bool> DeleteAsync(int id);
    }
}