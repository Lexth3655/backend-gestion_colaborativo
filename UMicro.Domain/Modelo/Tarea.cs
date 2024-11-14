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
    public  class Tarea: BaseEntity
    {
        public int tableroID { get; set; }//llave foranea
        public string titulo {  get; set; }
        public string descrpcion { get; set; }
        public string prioridad { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_limite { get; set; }
        public string estado { get; set; }//Ej: --> Por hacer, En progreso, Completado
        
        //relacion mucho a uno
        public Tablero Tablero { get; set; }
        //Relacion de uno a muchos
        public ICollection<Sub_Tarea> Subtareas { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
        public ICollection<Recurso> Recurso { get; set; }

    }
}
