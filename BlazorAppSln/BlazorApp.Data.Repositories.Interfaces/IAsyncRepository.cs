using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories.Interfaces
{
    //public interface IAsyncRepository<TEntity> where TEntity : class
    public interface IAsyncRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class;
        //Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters);
        //Task Insert(TEntity entity);
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteByIdAsync<TEntity>(int id) where TEntity : class;
    }
}
