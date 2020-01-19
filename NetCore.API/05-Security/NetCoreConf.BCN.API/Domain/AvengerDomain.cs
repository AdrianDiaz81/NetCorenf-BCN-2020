namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using NetCoreConf.BCN.API.Model;
    using NetCoreConf.BCN.API.Repository;

    public class AvengerDomain : IAvengerDomain
    {
        private readonly IAvengerRepository avengerRepository;

        public AvengerDomain(IAvengerRepository avengerRepository)
        {
            this.avengerRepository = avengerRepository;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            return await avengerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Avenger>> GetAllAsync()
        {
            return await avengerRepository.GetAsync();
        }

        public IEnumerable<dynamic> GetAllAsync(ODataQueryOptions<Avenger> filter)
        {
            var result= (IQueryable<dynamic>) filter.ApplyTo(avengerRepository.List());
            return result.ToList();
        }

        public async Task<Avenger> GetByIdAsync(string id)
        {
            return await avengerRepository.GetByIdAsync(id);
        }

        public async Task<Avenger> InsertAsync(Avenger people)
        {
            return await avengerRepository.AddAsync(people);
        }

        public async Task<bool> UpdateAsync(Avenger people)
        {
            return await avengerRepository.UpdateAsync(people);
        }
    }
}