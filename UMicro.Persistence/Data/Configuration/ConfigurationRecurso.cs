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
    public class ConfigurationRecurso : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            //definimos la llave primaria
            builder.HasKey(x => x.id);
            builder.Property(t => t.nombreRecurso).IsRequired().HasMaxLength(100);
            builder.Property(t => t.url).IsRequired().HasMaxLength(200);
            builder.Property(t => t.tipoRecurso).IsRequired().HasMaxLength(50);

            //relacion muchos a uno con tarea
            builder.HasOne(s => s.Tarea)
                .WithMany(t => t.Recurso)
                .HasForeignKey(s => s.tareasID);

        }
   
    }
}
