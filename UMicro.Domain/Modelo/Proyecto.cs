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
    public class Proyecto: BaseEntity
    {
        
        public string nombreProyecto {  get; set; }
        public string descripcionProyecto { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }

        //Relacion muchos a muchos 
        public ICollection<UsuarioProyecto> UsuarioProyectos { get; set; } //con usuario
                                                                           
        //Relacion uno a muchos 
        public ICollection<Tablero> Tableros { get; set; }//con tableros

    }
}
