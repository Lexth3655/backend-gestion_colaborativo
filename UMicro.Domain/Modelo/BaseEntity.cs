using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class BaseEntity
    {
        public string id { get; set; }
        public DateTime fecha_creado{ get; set; }
        public DateTime fecha_modificado{ get; set; }        
        public bool activo {  get; set; }
   
    }
}
