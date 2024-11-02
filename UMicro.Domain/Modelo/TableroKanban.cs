using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class TableroKanban: BaseEntity
    {
        
        public string nombreTablero {  get; set; }

        public int proyecto_id {  get; set; }
        public Proyecto proyecto_tablero { get; set; }
        public ICollection<Tarea> tareasK { get; set; } = new List<Tarea>();

    }
}
