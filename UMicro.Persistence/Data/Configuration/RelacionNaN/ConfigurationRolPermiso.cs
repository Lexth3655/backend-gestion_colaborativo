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
    public class ConfigurationRolPermiso : IEntityTypeConfiguration<Rol_Permiso>
    {
        public void Configure(EntityTypeBuilder<Rol_Permiso> builder)
        {
            //configuracion de la lleve primaria compuesta para Rol y Permiso
            builder.HasKey(rp => new { rp.rolID, rp.permisoID });//llave compuesta

            //configuracion de las relaciones entre entidades de uno a muchos
            builder.HasOne(rp => rp.Roles)
                .WithMany(r => r.Roles_Permiso)
                .HasForeignKey(rp => rp.rolID);

            builder.HasOne(rp => rp.Permiso)
                .WithMany(r => r.Roles_Permiso)
                .HasForeignKey(rp => rp.permisoID);


        }
    }
}
