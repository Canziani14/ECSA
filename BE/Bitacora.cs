using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int ID_Bitacora { get; set; }

        public  string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public int Criticidad { get; set; }

        public  string NickUsuarioLogin { get; set; }

        public int ID_Usuario { get; set; }

        public int DVH { get; set; }
    }
}
