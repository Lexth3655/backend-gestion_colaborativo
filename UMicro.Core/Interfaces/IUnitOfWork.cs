/*
Fecha de Creacion: 29-10-2024
Autor: Roberto Alexander Toloza
 */
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
        public IRepository<Tarea> RepositoryTarea { get; }
        public IRepository<Permiso> RepositoryPermiso { get; }
        public IRepository<Rol_Permiso> RepositoryRol_Permiso { get; }
        public IRepository<Proyecto> RepositoryProyecto { get; }
        public IRepository<TableroKanban> RepositoryTableroKanban { get; }
        public IRepository<Usuario> RepositoryUsuario { get; }
        public IRepository<Rol> RepositoryRol { get; }
        
        Task SaveChangesAsync();
    
    
    
    }
}
