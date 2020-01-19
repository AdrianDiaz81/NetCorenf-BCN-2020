namespace NetCoreConf.BCN.API.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using NetCoreConf.BCN.API.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Base, new()
    {
        private readonly DbContext dataContext;
        private readonly ILogger logger;

        public RepositoryBase(ILogger logger, DbContext dataContext)
        {
            this.logger = logger;
            this.dataContext = dataContext;
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return default(T);
                }
                await this.dataContext.Set<T>().AddAsync(entity);
                await this.dataContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, exception.Message);
                return default(T);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            this.dataContext.Remove(entity);
            var result = await this.dataContext.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await this.dataContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public  IQueryable<T> List()
        {
            return  this.dataContext.Set<T>().AsNoTracking();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> queryable = dataContext.Set<T>();
            return await queryable.Where(filter).ToListAsync();
        }


        public async Task<T> GetByIdAsync(string id)
        {
            return await this.dataContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
            var result = await this.dataContext.SaveChangesAsync();
            return result > 0;
        }

        #region Dispose Pattern
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}