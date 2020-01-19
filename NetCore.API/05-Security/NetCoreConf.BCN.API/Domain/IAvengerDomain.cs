namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using NetCoreConf.BCN.API.Model;
    public interface IAvengerDomain
    {
        Task<IEnumerable<Avenger>> GetAllAsync();
        IEnumerable<dynamic> GetAllAsync(ODataQueryOptions<Avenger> filter);
        Task<Avenger> GetByIdAsync(string id);

        Task<Avenger> InsertAsync(Avenger people);
        Task<bool> UpdateAsync(Avenger people);
        Task<bool> DeleteAsync(string id);
    }
}