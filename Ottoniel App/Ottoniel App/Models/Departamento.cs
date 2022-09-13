using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Departamento
    {
        public int id_departamento { get; set; }
        public String nombre { get; set; }

        public string ToJson()
        {
            return "{ \"nombre\":\"" + nombre + "\" }";
        }
    }
}
