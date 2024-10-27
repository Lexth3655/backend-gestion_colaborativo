using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Sub_Tarea: BaseEntity
    {
        public string tituloSb {  get; set; }
        public string estadoSb { get; set; }
        
        [ForeignKey("Tarea")]
        public int id_tarea { get; set; }
        public Tarea tarea { get; set; }


    }
}
