using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Puesto
    {
        public int id_puesto { get; set; }
        public String desc { get; set; }
        public int id_departamento { get; set; }

        public String nombre_departamento { get; set; }

        public string ToJson()
        {
            return "{ \"desc\":\"" + desc + "\", \"id_departamento\":\"" + id_departamento + "\", \"id_puesto \":\"" + id_puesto + "\", \"nombre_departamento \":\"" + nombre_departamento + "\"}";
        }
    }
}
