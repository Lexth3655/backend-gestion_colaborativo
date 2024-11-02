using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T t)
        {
            await _dbSet.AddAsync(t);
            return t;
        }

        public async Task<bool> DeleteAsync(T t)
        {
            return await Task.Run(() =>
            {
                _dbSet.Remove(t);
                return true;
            });
        }

        public IEnumerable<T> GetAll()
        {            
            return _dbSet.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<T> UpdateAsync(T t)
        {
            return await Task.Run(() =>
            {
                _dbSet.Update(t);
                return t;
            });
        }
    }
}
