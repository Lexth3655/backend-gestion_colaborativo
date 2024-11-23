using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

namespace UMicro.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

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

        // Interfaz personalizada
        public IRepositoryRol RepositorioRoles { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            RepositoryRol = new Repository<Roles>(context);
            RepositoryRol_Permiso = new Repository<Rol_Permiso>(context);
            RepositoryPermiso = new Repository<Permiso>(context);
            RepositoryUsuario = new Repository<Usuario>(context);
            RepositoryUsuarioProyecto = new Repository<UsuarioProyecto>(context);
            RepositoryProyecto = new Repository<Proyecto>(context);
            RepositoryTablero = new Repository<Tablero>(context);
            RepositoryTarea = new Repository<Tarea>(context);
            RepositorySubTarea = new Repository<Sub_Tarea>(context);
            RepositoryComentarios = new Repository<Comentarios>(context);
            RepositoryRecurso = new Repository<Recurso>(context);
            RepositoryNotificacion = new Repository<Notificacion>(context);

            // Inicialización del repositorio personalizado
            RepositorioRoles = new RepositoryRol(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
