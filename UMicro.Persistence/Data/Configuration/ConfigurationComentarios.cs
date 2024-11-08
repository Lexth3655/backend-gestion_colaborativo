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
    public class ConfigurationComentarios : IEntityTypeConfiguration<Comentarios>
    {
        public void Configure(EntityTypeBuilder<Comentarios> builder)
        {
            //definimos la llave primaria
            builder.HasKey(x => x.id);
            builder.Property(t => t.contenido).IsRequired().HasMaxLength(500);
            
            //relacion muchos a uno con tarea
            builder.HasOne(s => s.Tareas)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(s => s.tareaID);

            //relacion muchos a uno con usuario
            builder.HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.usuarioID);
        }

    }
}
