using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data.Configuration;
using UMicro.Persistence.Data.Configuration.TablaNaN;

namespace UMicro.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {            
        public DbSet<Roles> roles { get; set; }
        public DbSet<Rol_Permiso> rol_Permisos { get; set; }
        public DbSet<Permiso> permisos { get; set; }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<UsuarioProyecto> usuarioProyectos { get; set; }
        public DbSet<Proyecto> proyectos { get; set; }

        public DbSet<Tablero> tableros { get; set; }
        public DbSet<Tarea> tareas { get; set; }
        public DbSet<Sub_Tarea> subtareas { get; set; }

        public DbSet<Comentarios> comentarios { get; set; }
        public DbSet<Recurso> recursos { get; set; }
        public DbSet<Notificacion> notificacions { get; set; }
        public IEnumerable<object> Comentarios { get; set; }
        public object Tareas { get; set; }
        public object Usuarios { get; set; }
        public object Recursos { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*Configuraracion de las entidades que define como se guardaran
            y organizaran los datos dentro DB*/
            
            modelBuilder.ApplyConfiguration(new ConfigurationRol());
            modelBuilder.ApplyConfiguration(new ConfigurationRolPermiso());
            modelBuilder.ApplyConfiguration(new ConfigurationPermiso());

            modelBuilder.ApplyConfiguration(new ConfigurationUsuario());
            modelBuilder.ApplyConfiguration(new ConfigurationUsuarioProyecto());
            modelBuilder.ApplyConfiguration(new ConfigurationProyecto());

            modelBuilder.ApplyConfiguration(new ConfigurationTablero());
            modelBuilder.ApplyConfiguration(new ConfigurationTarea());
            modelBuilder.ApplyConfiguration(new ConfigurationSub_Tarea());

            modelBuilder.ApplyConfiguration(new ConfigurationComentarios());
            modelBuilder.ApplyConfiguration(new ConfigurationRecurso());
            modelBuilder.ApplyConfiguration(new ConfigurationNotificacion());

        }
    }
}
