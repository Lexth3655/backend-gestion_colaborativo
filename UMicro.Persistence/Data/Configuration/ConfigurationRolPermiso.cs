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
    public class ConfigurationRolPermiso : IEntityTypeConfiguration<Rol_Permiso>
    {
        public void Configure(EntityTypeBuilder<Rol_Permiso> builder)
        {
            //definicon de llave compuesta
            builder.HasKey(x => new { x.id_rol, x.id_permiso});

            //configuracion de la relaciones
            builder.HasOne(rp => rp.Rol)
                .WithMany(r => r.RolPermiso)
                .HasForeignKey(rp => rp.id_rol)
                .OnDelete(DeleteBehavior.Restrict);// Evita cascada en eliminaciones para Rol

            builder.HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolPermiso)
                .HasForeignKey(rp => rp.id_permiso)
                .OnDelete(DeleteBehavior.Restrict);// Evita cascada en eliminaciones para Permiso



        }

    }
}
