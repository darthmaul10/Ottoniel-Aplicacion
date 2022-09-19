using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Empleado
    {
        public int id_empleado { get; set; }
        public String nombre { get; set; }
        public String fecha_nacimiento { get; set; }
        public int id_puesto { get; set; }
        public String nacionalidad { get; set; }

        public string ToJson()
        {
            return "{ \"nombre\":\"" + nombre + "\", \"id_empleado\":\"" + id_empleado + "\"}";
        }
    }
}
