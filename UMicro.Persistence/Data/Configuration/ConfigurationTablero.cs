using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Persistence.Data.Configuration
{
    public class ConfigurationTablero : IEntityTypeConfiguration<Tablero>
    {
        public void Configure(EntityTypeBuilder<Tablero> builder)
        {
            //definimos la primary key
            builder.HasKey(t => t.id);
            builder.Property(t => t.nombreTablero).IsRequired().HasMaxLength(100);
            builder.Property(t => t.tipo).HasMaxLength(50);

            //relacion uno a muchos con tablero
            builder.HasMany(t => t.Tareas) 
                .WithOne(static t => t.Tablero)
                .HasForeignKey(c => c.tableroID);
        }
    }
}
