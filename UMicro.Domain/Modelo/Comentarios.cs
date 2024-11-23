using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Comentarios : BaseEntity
    {
        public DateTime FechaCreacion;

        public int tareaID { get; set; }
        public int usuarioID { get; set; }
        public string contenido { get; set; }

        //relacion muchos a uno con tareas
        public Tarea Tareas { get; set; }
        public Usuario Usuario { get; set; }

        
    }
}
