using MBIN.Data.Context;
using MBIN.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MBIN.Data.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression)
        {
            var Query = await _context.Set<TEntity>().Where(expression).ToListAsync();

            return Query;
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            await _context.AddAsync(entity);

            SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var result = GetByIdAsync(id).Result;
            if (result != null)
            {
                _context.Remove(result);

                SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ExistAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> ExistByAsync(Expression<Func<TEntity, bool>> expression)
        {
            var Query = await _context.Set<TEntity>().Where(expression).ToListAsync();

            if (Query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
