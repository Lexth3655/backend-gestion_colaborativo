using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Rol_Permiso
    {
        public int id_rol {  get; set; }
        public int id_permiso { get; set; }

        //relacion de navegacion con rol y permiso
        public Rol rol { get; set; }
    }
}
