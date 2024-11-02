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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Tarea> RepositoryTarea {  get; }

        public IRepository<Permiso> RepositoryPermiso { get; }

        public IRepository<Rol_Permiso> RepositoryRol_Permiso { get; }

        public IRepository<Proyecto> RepositoryProyecto { get; }

        public IRepository<Usuario> RepositoryUsuario { get; }

        public IRepository<Rol> RepositoryRol { get; }

        public IRepository<TableroKanban> RespositoryTableroKanban { get; }

        IRepository<TableroKanban> IUnitOfWork.RepositoryTableroKanban => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            RepositoryTarea = new Repository<Tarea>(context);
            RepositoryPermiso = new Repository<Permiso>(context); 
            RepositoryRol_Permiso = new Repository<Rol_Permiso>(context);
            RepositoryProyecto = new Repository<Proyecto>(context);
            RespositoryTableroKanban = new Repository<TableroKanban>(context);
            RepositoryUsuario = new Repository<Usuario>(context);
            RepositoryRol = new Repository<Rol>(context);
            
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
