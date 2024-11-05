/*
Fecha de Creacion: 27-10-2024
Autor: Roberto Alexander Toloza 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Permiso: BaseEntity
    {
        public string nombreP {  get; set; }
        public string descripcionP { get; set; }

        // Colección de la relación N a N
        public ICollection<Rol_Permiso> RolPermiso { get; set; } = new List<Rol_Permiso>();
    }
}
