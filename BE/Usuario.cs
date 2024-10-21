using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario 
    {
        public int ID_Usuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Nick { get; set; }

        public string Contraseña { get; set; }

        public string Mail { get; set; }

        public int DVV { get; set; }

        public int CII { get; set; }
        public bool Estado { get; set; }

        public bool Eliminado { get; set; }


        public List<Patente> Patentes { get; set; } = new List<Patente>();

       

    }
}
