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
        public string nombre {  get; set; }
        public string correo { get; set; }
        public string password { get; set; }

        
        public int rolID { get; set; }
        public Roles Roles { get; set; }

        //Relacion muchos a muchos con proyecto
        public ICollection<UsuarioProyecto> UsuarioProyectos { get; set; }
        

    }
}
