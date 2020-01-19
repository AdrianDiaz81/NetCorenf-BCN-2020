namespace NetCoreConf.BCN.API.Domain
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.EntityFrameworkCore;
    using NetCoreConf.BCN.API.Model;
    using NetCoreConf.BCN.API.Repository;

    public class FilmDomain : IFilmDomain
    {
        private readonly IFilmRepository filmRepository;

        public FilmDomain(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await filmRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await filmRepository.ListAllAsync(x => x.Include(x => x.AvengerFilm));
            //return await filmRepository.GetAsync();
        }

        public IEnumerable<dynamic> GetAllAsync(ODataQueryOptions<Film> filter)
        {
            var result= (IQueryable<dynamic>) filter.ApplyTo(filmRepository.List());
            return result.ToList();
        }

        public async Task<Film> GetByIdAsync(int id)
        {
            return await filmRepository.GetByIdAsync(id);
        }

        public async Task<Film> InsertAsync(Film film)
        {
            return await filmRepository.AddAsync(film);
        }

        public async Task<bool> UpdateAsync(Film film)
        {
            return await filmRepository.UpdateAsync(film);
        }
    }
}