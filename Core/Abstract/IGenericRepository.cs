using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        Task<bool> CreateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null);
    }
}
