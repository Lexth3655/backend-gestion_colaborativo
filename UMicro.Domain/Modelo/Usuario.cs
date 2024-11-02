/*
Fecha de Creacion: 28-10-2024
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
    public class Usuario: BaseEntity
    {
        public string nombreU {  get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime anioCreado { get; set; }
        
        public int rolID { get; set; }
        public Rol Rols { get; set; }
        public ICollection<ProyectoUsuarioRol> ProyectoUsuarioRols { get; set; } = new List<ProyectoUsuarioRol>();

    }
}
