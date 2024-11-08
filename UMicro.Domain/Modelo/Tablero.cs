using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Tablero: BaseEntity
    {
        public int proyectoID { get; set; }
        public string nombreTablero {  get; set; }
        public string tipo {  get; set; }// Kanban, lista, cronograma

        //relacion de muchos a uno con proyecto        
        public Proyecto ProyectoT { get; set; }
        //Relacion de uno a muchos con tareas
        public ICollection<Tarea> Tareas { get; set; }

    }
}
