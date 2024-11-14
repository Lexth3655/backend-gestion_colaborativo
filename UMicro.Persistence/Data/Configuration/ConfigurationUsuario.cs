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
    public class ConfigurationUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //configuracion de la lleve primaria
            builder.HasKey(x => x.id);

            //configuracion de la relacion usuario rol
            builder.HasOne(u => u.Roles)
                .WithMany()
                .HasForeignKey(u => u.id);

            
        }
    }
}
