using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Notificacion: BaseEntity
    {
        public int userID { get; set; }
        public string tipoNotificacion { get; set; }
        public string mensaje {  get; set; }
        public DateTime fechaEnvio { get; set; }

        //relacion de muchos a uno
        public Usuario Usuario { get; set; }
    }
}
