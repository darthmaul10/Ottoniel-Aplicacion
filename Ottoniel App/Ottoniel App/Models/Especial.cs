using System;
using System.Collections.Generic;
using System.Text;

namespace Ottoniel_App.Models
{
    internal class Especial
    {
        public int id_departamento { get; set; }
        public string nombreDepto { get; set; }
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string nombrePuesto { get; set; }
        public int? id_tipo { get; set; }
        public string tipoMarcador { get; set; }
        public DateTime? fecha { get; set; }
        public DateTime? hora { get; set; }
    }
}
