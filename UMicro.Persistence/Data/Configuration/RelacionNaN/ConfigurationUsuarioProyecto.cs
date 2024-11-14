using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Data.Configuration.TablaNaN
{
    public class ConfigurationUsuarioProyecto : IEntityTypeConfiguration<UsuarioProyecto>
    {
        public void Configure(EntityTypeBuilder<UsuarioProyecto> builder)
        {
            //configuracion de la lleve primaria compuesta para UsuarioProyectos
            builder.HasKey(x => new { x.usuarioID, x.proyectoID });

            //configuracion de las relaciones entre entidades
            builder.HasOne(u => u.Usuario)
                .WithMany(r => r.UsuarioProyectos)
                .HasForeignKey(u => u.usuarioID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Proyecto)
                .WithMany(r => r.UsuarioProyectos)
                .HasForeignKey(u => u.proyectoID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Roles)
                .WithMany()
                .HasForeignKey(u => u.rolID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
