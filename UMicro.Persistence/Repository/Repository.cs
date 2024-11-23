using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

namespace UMicro.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context;
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

        public async Task<T> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues); // Busca por múltiples claves (si es necesario)
        }

        public IEnumerable<T> GetAllE()
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

        public async Task<Usuario> FindByUserNameAsync(string email)
        {

            return await _context.usuarios.SingleOrDefaultAsync(u => u.correo == email);
        }

        public async Task<IEnumerable<Permiso>> GetPermisosPorRolAsync(int rolId)
        {
            return await _context.rol_Permisos
                .Where(rp => rp.rolID == rolId)
                .Include(rp => rp.Permiso)
                .Select(rp => rp.Permiso)
                .ToListAsync();
        }

        public async Task<IEnumerable<Roles>> GetRolesPorPermisoAsync(int permisoId)
        {
            return await _context.rol_Permisos
                .Where(rp => rp.permisoID == permisoId)
                .Include(rp => rp.Roles)
                .Select(rp => rp.Roles)
                .ToListAsync();
        }
    }
}
