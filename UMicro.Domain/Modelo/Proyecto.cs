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

        //hace referencia a que un proyecto puede tener un coleccion
        public ICollection<ProyectoUsuarioRol> ProyectoUsuarioRols { get; set; }

        public ICollection<TableroKanban> Tableros { get; set; }

    }
}
