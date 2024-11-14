using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Data.Configuration
{
    public class ConfigurationTarea : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            //definimos la llave primaria
            builder.HasKey(x => x.id);
            builder.Property(t => t.titulo).IsRequired().HasMaxLength(100);
            builder.Property(t => t.descrpcion).HasMaxLength(500);
            builder.Property(t => t.prioridad).HasMaxLength(20);
            builder.Property(t => t.estado).HasMaxLength(20);

            //relacion uno a muchos con subtarea
            builder.HasMany(st => st.Subtareas)
                .WithOne(t => t.Tareas)
                .HasForeignKey(t => t.tareaID);

            //relacion uno a muchos con comentarios
            builder.HasMany(t => t.Comentarios)
                .WithOne(r => r.Tareas)
                .HasForeignKey(r => r.tareaID);

            //relacion uno a muchos con recursos
            builder.HasMany(t => t.Recurso)
                .WithOne(r => r.Tarea)
                .HasForeignKey(r => r.tareasID);
        }

    }
}
