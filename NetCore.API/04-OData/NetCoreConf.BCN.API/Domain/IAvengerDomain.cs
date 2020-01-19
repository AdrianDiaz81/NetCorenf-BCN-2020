namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using NetCoreConf.BCN.API.Model;
    public interface IAvengerDomain
    {
        Task<IEnumerable<Avenger>> GetAllAsync();
        IEnumerable<Avenger> GetAllAsync(ODataQueryOptions<Avenger> filter);
        Task<IEnumerable<AvengerFilm>> GetAllFilmsByIdAsync(int avengerId);
        Task<Avenger> GetByIdAsync(int id);

        Task<Avenger> InsertAsync(Avenger people);
        Task<bool> UpdateAsync(Avenger people);
        Task<bool> DeleteAsync(int id);
    }
}