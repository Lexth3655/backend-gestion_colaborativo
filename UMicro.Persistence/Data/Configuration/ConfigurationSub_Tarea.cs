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
    public class ConfigurationSub_Tarea : IEntityTypeConfiguration<Sub_Tarea>
    {
        public void Configure(EntityTypeBuilder<Sub_Tarea> builder)
        {
            builder.HasKey(x => x.id);
        }

    }
}
