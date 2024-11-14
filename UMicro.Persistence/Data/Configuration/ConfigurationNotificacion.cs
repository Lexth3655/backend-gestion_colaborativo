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
    public class ConfigurationNotificacion : IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            //definimos la llave primaria
            builder.HasKey(x => x.id);
            builder.Property(x => x.tipoNotificacion).IsRequired().HasMaxLength(50);
            builder.Property(x => x.mensaje).IsRequired().HasMaxLength(200);
            

            //relacion muchos a uno con tarea
            builder.HasOne(n => n.Usuario)
                .WithMany()
                .HasForeignKey(s => s.userID);

        }

    }
}
