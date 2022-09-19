using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Telefono
    {
        public int id_telefono { get; set; }
        public int idempleado { get; set; }
        public int telefono { get; set; }

        public string ToJson()
        {
            return "{ \"id_telefono\":\"" + id_telefono + " \",\"idempleado\":\"" + idempleado + " \",\"telefono\":\"" + telefono +"\" }";
        }
    }
}
