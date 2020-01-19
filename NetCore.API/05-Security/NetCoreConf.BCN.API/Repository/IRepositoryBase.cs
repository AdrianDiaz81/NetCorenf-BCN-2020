namespace NetCoreConf.BCN.API.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAsync();
         IQueryable<T> List();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}