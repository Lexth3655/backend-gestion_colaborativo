using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Recurso: BaseEntity
    {
        public int tareasID {  get; set; }
        public string nombreRecurso { get; set; }
        public string url { get; set; }
        public string tipoRecurso { get; set; }

        //relacion muchos a uno
        public Tarea Tarea { get; set; }
    }
}
