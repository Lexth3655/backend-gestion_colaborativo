using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Usuario: BaseEntity
    {
        public string nombreU {  get; set; }
        public string correo_electronico { get; set; }
        public string password { get; set; }
        

        [ForeignKey("Rol")]
        public int id_rol { get; set; }
        public Rol rol { get; set; }
        
    }
}
