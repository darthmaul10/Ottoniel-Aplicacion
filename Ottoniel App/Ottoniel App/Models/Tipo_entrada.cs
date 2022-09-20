using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Tipo_entrada
    {
        public int id_tipo { get; set; }
        public String descripcion { get; set; }

        public string ToJson()
        {
            return "{ \"id_tipo\":\"" + id_tipo + " \",\"descripcion\":\"" + descripcion + "\" }";
        }


    }
}
