namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.EntityFrameworkCore;
    using NetCoreConf.BCN.API.Model;
    using NetCoreConf.BCN.API.Repository;

    public class AvengerDomain : IAvengerDomain
    {
        private readonly IAvengerRepository avengerRepository;
        private readonly IAvengerFilmRepository avengerFilmRepository;

        public AvengerDomain(IAvengerRepository avengerRepository, IAvengerFilmRepository avengerFilmRepository)
        {
            this.avengerRepository = avengerRepository;
            this.avengerFilmRepository = avengerFilmRepository;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await avengerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Avenger>> GetAllAsync()
        {
            return await avengerRepository.GetAsync();
        }

        public async Task<IEnumerable<AvengerFilm>> GetAllFilmsByIdAsync(int avengerId)
        {
            //return await avengerFilmRepository.GetAsync(x=>x.AvengerId.Equals(avengerId),x=>x.Include(x=>x.Film));
            //var result= await avengerFilmRepository.GetAsync(x => x.AvengerId.Equals(avengerId));
            //return result.Select(o => new
            //{
            //   Film=o.Film
            //});
            return await avengerFilmRepository.GetAsync(x => x.AvengerId.Equals(avengerId));

        }

        public IEnumerable<dynamic> GetAllAsync(ODataQueryOptions<Avenger> filter)
        {
            var result= (IQueryable<dynamic>) filter.ApplyTo(avengerRepository.List());
            return result.ToList();
        }

        public async Task<Avenger> GetByIdAsync(int id)
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