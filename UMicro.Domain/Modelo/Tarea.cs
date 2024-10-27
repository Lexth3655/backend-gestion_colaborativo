using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public  class Tarea: BaseEntity
    {
        public string titulo {  get; set; }
        public string descrpcion { get; set; }
        public string prioridad { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_limite { get; set; }
        public string estadoT { get; set; }
        public int recurrente { get; set; }
        public int tiempo_invertido { get; set; }
        public int id_proyecto { get; set; }
        public int id_usuario_propietario { get; set; }
        
    }
}
