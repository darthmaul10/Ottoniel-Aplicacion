using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Reloj_marcador
    {
        public int id_registro { get; set; }
        public int id_tipo { get; set; }
        public String fecha { get; set; }
        public String hora { get; set; }
        public int id_empleado { get; set; }

        public string ToJson()
        {
            return "{ \"id_registro\":\"" + id_registro + " \",\"id_tipo\":\"" + id_tipo + " \",\"fecha\":\"" + fecha + " \",\"hora\":\"" + hora + " \",\"id_empleado\":\"" + id_empleado + "\" }";
        }
    }
}
