using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class ProyectoUsuarioRol
    {
        [ForeignKey("Proyecto")]
        public int proyecto_id {  get; set; }
        public Proyecto proyectoPUR { get; set; }

        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        public Usuario usuarioPUR { get; set; }

        [ForeignKey("Rol")]
        public int rol_id { get; set; }
        public Rol rolPUR { get; set; }

    }
}
