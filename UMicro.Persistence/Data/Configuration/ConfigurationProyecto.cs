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
    public class ConfigurationProyecto : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> proyecto)
        {
            proyecto.HasKey(x => x.id);

            proyecto.HasMany(u => u.ProyectoUsuarioRols)
                .WithOne(x => x.proyectoPUR)
                .HasPrincipalKey(x => x.id);
        }
    }
}
