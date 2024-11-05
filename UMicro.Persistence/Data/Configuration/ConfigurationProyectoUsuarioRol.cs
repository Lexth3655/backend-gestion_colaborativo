using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Data.Configuration
{
    public class ConfigurationProyectoUsuarioRol : IEntityTypeConfiguration<ProyectoUsuarioRol>
    {
        public void Configure(EntityTypeBuilder<ProyectoUsuarioRol> builder)
        {
            //definicion compuesta de primary key
            builder.HasKey(x => new { x.usuario_id, x.proyecto_id, x.rol_id});

            //configuracion de la relaciones
            builder.HasOne(x => x.usuarioPUR)
                .WithMany(p => p.ProyectoUsuarioRols)
                .HasPrincipalKey(x => x.id)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascadas en eliminaciones

            builder.HasOne(x => x.proyectoPUR)
                .WithMany(p => p.ProyectoUsuarioRols)
                .HasPrincipalKey(x => x.id)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascadas en eliminaciones

            builder.HasOne(x => x.rolPUR)
                .WithMany(p => p.ProyectoUsuarioRols)
                .HasPrincipalKey(x => x.id)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascadas en eliminaciones

        }
    }
}
