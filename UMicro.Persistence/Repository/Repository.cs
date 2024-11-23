using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

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
            _dbSet.Remove(t);
            return await Task.FromResult(true);
        }

        public async Task<bool> ExistsAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => _dbSet.Any(predicate));
        }

        public Task<bool> ExistsAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {            
            return _dbSet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<T> GetAllE()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Proyecto>> GetProyectosDeUsuarioAsync(int usuarioId)
        {
            if (typeof(T) != typeof(Proyecto))
            {
                throw new InvalidOperationException("Este método solo puede usarse para el tipo Proyecto.");
            }

            return await _dbSet
                .OfType<Proyecto>()
                .Include(p => p.UsuarioProyectos)
                .Where(p => p.UsuarioProyectos.Any(up => up.usuarioID == usuarioId))
                .ToListAsync();
        }

        public async Task GetUsuariosByProyectoIdAsync(int proyectoId)
        {
            if (typeof(T) != typeof(UsuarioProyecto))
            {
                throw new InvalidOperationException("Este método solo puede usarse para el tipo UsuarioProyecto.");
            }

            var usuarios = await _dbSet
                .OfType<UsuarioProyecto>()
                .Include(up => up.Usuario)
                .Where(up => up.proyectoID == proyectoId)
                .ToListAsync();

            // Aquí podrías retornar o manipular los usuarios según sea necesario
        }


        public async Task ObtenerPorUsuarioYProyectoAsync(int usuarioID, int proyectoID)
        {
            if (typeof(T) != typeof(UsuarioProyecto))
            {
                throw new InvalidOperationException("Este método solo puede usarse para el tipo UsuarioProyecto.");
            }

            var usuarioProyecto = await _dbSet
                .OfType<UsuarioProyecto>()
                .FirstOrDefaultAsync(up => up.usuarioID == usuarioID && up.proyectoID == proyectoID);

            // Opcional: retornar o manipular el registro según sea necesario
        }

        public async Task<T> UpdateAsync(T t)
        {
            _dbSet.Update(t);
            return await Task.FromResult(t);
        }

        IQueryable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
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
