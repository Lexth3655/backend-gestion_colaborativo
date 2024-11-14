using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class UsuarioProyecto
    {
        //Union explicita de la relacion de N a N entre Usuario y Proyecto
        public int usuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public int proyectoID { get; set; }
        public Proyecto Proyecto { get; set; }

        //Rol especifico del usuario en el proyecto
        public int rolID { get; set; }
        public Roles Roles { get; set; }



    }
}
