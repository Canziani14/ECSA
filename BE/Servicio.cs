using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Servicio
    {
        public int ID_Servicio { get; set; }

        public DateTime HorarioLlegada { get; set; }
        public DateTime HorarioSalida { get; set; }

        public int Coche { get; set; }

        public int Linea { get; set; }

        public int LegajoEmpleado { get; set; }

        public int DVH { get; set; }

    }
}
