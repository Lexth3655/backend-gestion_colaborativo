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
            //definimos la llave primaria
            proyecto.HasKey(x => x.id);

            //relacion uno a muchos con tablero
            proyecto.HasMany(p => p.Tableros)
                .WithOne(t => t.ProyectoT)
                .HasForeignKey(t => t.proyectoID);
                        
        }
    }
}
