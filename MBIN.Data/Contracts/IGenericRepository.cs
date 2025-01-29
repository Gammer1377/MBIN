using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MBIN.Data.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey id);
        Task<bool> ExistAsync(TKey id);
        Task<bool> ExistByAsync(Expression<Func<TEntity, bool>> expression);
        Task SaveChangesAsync();
    }
}
