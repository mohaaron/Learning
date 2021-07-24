using BlazorApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Repositories
{
    // https://codewithshadman.com/repository-pattern-csharp
    // https://blog.zhaytam.com/2019/03/14/generic-repository-pattern-csharp/
    // https://pradeeploganathan.com/architecture/repository-and-unit-of-work-pattern-asp-net-core-3-1/
    // https://www.freecodespot.com/blog/dotnet-core-repository-pattern/
    //public class BaseAsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    public abstract class RepositoryAsyncBase<TDbContext> : IRepositoryBaseAsync where TDbContext : DbContext
    {
		internal readonly TDbContext context;

		public RepositoryAsyncBase(TDbContext context)
		{
            this.context = context;
		}

        public virtual async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
            => await context.Set<TEntity>().FindAsync(id);

        public virtual async Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
            => await context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        //public Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters)
        //{
        //    //
        //}

        //public Task Insert(TEntity entity)
        //{
        //    context.AddAsync(entity);
        //    return context.SaveChangesAsync();
        //}

        public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Remove(entity);
            return context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync<TEntity>(int id) where TEntity : class
        {
            TEntity entity = await context.Set<TEntity>().FindAsync(id);
            context.Remove(entity);
            return await context.SaveChangesAsync();
        }
    }
}
