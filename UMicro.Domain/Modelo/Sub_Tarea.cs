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
    public class Sub_Tarea: BaseEntity
    {
        public int tareaID { get; set; }
        public string tituloSb {  get; set; }
        public string estadoSb { get; set; }
        
        //relacion de muchos a uno con tarea
        public Tarea Tareas { get; set; }


    }
}
