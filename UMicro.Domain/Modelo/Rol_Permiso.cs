/*
Fecha de Creacion: 27-10-2024
Autor: Roberto Alexander Toloza 
 */
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
        //union explicita entre las rol y permiso
        public int rolID {  get; set; }
        public Roles Roles { get; set; }

        public int permisoID { get; set; }
        public Permiso Permiso { get; set; }

    }
}
