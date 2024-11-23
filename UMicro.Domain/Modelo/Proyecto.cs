using System;
using System.Collections.Generic;

namespace UMicro.Domain.Modelo
{
    public class Proyecto : BaseEntity
    {
        public string nombreProyecto { get; set; }
        public string descripcionProyecto { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }

        // Relación muchos a muchos 
        public ICollection<UsuarioProyecto> UsuarioProyectos { get; set; }

        // Relación uno a muchos 
        public ICollection<Tablero> Tableros { get; set; }
    }
}
