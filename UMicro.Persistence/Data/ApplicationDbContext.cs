using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data.Configuration;

namespace UMicro.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public DbSet<Tarea> tareas {  get; set; }
        public DbSet<Permiso> permisos { get; set; }
        public DbSet<Rol_Permiso> rol_Permisos { get; set; }
        public DbSet<Proyecto> proyectos { get; set; }
        public DbSet<ProyectoUsuarioRol> proyectoUsuarioRols { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rol> rols { get; set; }

        public DbSet<TableroKanban> tableroKanbans { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica si el contexto ya ha sido configurado
            if (!optionsBuilder.IsConfigured)
            {
                // Configura la cadena de conexión y el ensamblado de migraciones
                optionsBuilder.UseSqlServer("DefaultConnection",
                    b => b.MigrationsAssembly("UMicro.Persistence")); // Especifica el ensamblado de migraciones
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*Configuraracion de las entidades que define como se guardaran
            y organizaran los datos dentro DB*/
            modelBuilder.ApplyConfiguration(new ConfigurationProyecto());
            modelBuilder.ApplyConfiguration(new ConfigurationRol());
            modelBuilder.ApplyConfiguration(new ConfigurationUsuario());
            modelBuilder.ApplyConfiguration(new ConfigurationTarea());
            modelBuilder.ApplyConfiguration(new ConfigurationSub_Tarea());
            modelBuilder.ApplyConfiguration(new ConfigurationPermiso());
            modelBuilder.ApplyConfiguration(new ConfigurationTableroKanban());
        }
    }
}
