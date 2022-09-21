using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Empleado
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string fecha_nacimiento { get; set; }
        public int id_puesto { get; set; }
        public string nacionalidad { get; set; }

        public string ToJson()
        {
            return "{ \"id_empleado\":\"" + id_empleado + "\", \"nombre\":\"" + nombre + "\", \"fecha_nacimiento\":\"" + fecha_nacimiento + "\", \"id_puesto\":\"" + id_puesto + "\", \"nacionalidad\":\"" + nacionalidad + "\"}";
        }
    }
}
