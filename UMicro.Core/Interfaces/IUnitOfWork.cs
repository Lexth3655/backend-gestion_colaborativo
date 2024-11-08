using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Interfaces
{
    public interface IUnitOfWork
    {
        //Repositorios 
        public IRepository<Roles> RepositoryRol { get; }
        public IRepository<Rol_Permiso> RepositoryRol_Permiso { get; }
        public IRepository<Permiso> RepositoryPermiso { get; }


        public IRepository<Usuario> RepositoryUsuario { get; }
        public IRepository<UsuarioProyecto> RepositoryUsuarioProyecto { get; }
        public IRepository<Proyecto> RepositoryProyecto { get; }
        public IRepository<Tablero> RepositoryTablero { get; }
        public IRepository<Tarea> RepositoryTarea { get; }
        public IRepository<Sub_Tarea> RepositorySubTarea { get; }

        public IRepository<Comentarios> RepositoryComentarios { get; }
        public IRepository<Recurso> RepositoryRecurso { get; }
        public IRepository<Notificacion> RepositoryNotificacion { get; }

        Task SaveChangesAsync();
    
    
    
    }
}
