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
    public class ConfigurationTableroKanban : IEntityTypeConfiguration<TableroKanban>
    {
        public void Configure(EntityTypeBuilder<TableroKanban> builder)
        {
            //definimos la primary key
            builder.HasKey(t => t.id);

            //configurmos al relaciones entre entidades
            builder.HasOne(p => p.proyecto_tablero)
                .WithMany(t => t.Tableros) //  se agrega la coleccion de Tableros definida en la entidad proyecto
                .HasForeignKey(p => p.proyecto_id);

            builder.HasMany(t => t.tareasK) //  se agrega la coleccion una coleccion de tarea al tablero.
                .WithOne(static t => t.Tablero)
                .HasForeignKey(c => c.tablero_id);
        }
    }
}
