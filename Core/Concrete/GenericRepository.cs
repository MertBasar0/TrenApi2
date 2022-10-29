using Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<bool> CreateAsync(TEntity entity)
        {
            using TContext context = new();
            await context.AddAsync<TEntity>(entity);
            int result = await context.SaveChangesAsync();
            return Convert.ToBoolean(result);
                

        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using TContext context = new();
            await Task.Run(() => context.Remove<TEntity>(entity));
            int result = await context.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new();
            if (filter is null)
                return await context.Set<TEntity>().ToListAsync();
            else
                return await context.Set<TEntity>().Where(filter).ToListAsync();
          
        }

    }
}
