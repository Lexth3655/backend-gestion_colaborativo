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
    public class Roles: BaseEntity
    {
        public string nombreRol {  get; set; }
        public string descripcion { get; set; }

        
        // Relacion muchos a muchos con permiso 
        public ICollection<Rol_Permiso> Roles_Permiso { get; set; }      

    }
}
