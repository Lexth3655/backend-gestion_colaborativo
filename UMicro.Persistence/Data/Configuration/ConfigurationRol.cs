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
    public class ConfigurationRol : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> rol)
        {
            rol.HasKey(x => x.id);

            
        }
    }
}
