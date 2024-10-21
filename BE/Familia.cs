using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia 
    {
        public int ID_Familia { get; set; }

        public string Descripcion { get; set; }

        public int ID_Patente { get; set; }

        public int ID_Usuario { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        // Lista de patentes asignadas a la familia
        public List<Patente> Patentes { get; set; } = new List<Patente>();

       
    }
}
