using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPatente
    {
        DAL.DALPatente DALPatente = new DAL.DALPatente();
        public bool Asignar(Patente objAgregar)
        {
            return DALPatente.Asignar(objAgregar);
        }

        public bool Quitar(Patente objEliminar)
        {
            return DALPatente.Quitar(objEliminar);
        }

        public List<Patente> ListarActuales(int id_usuario)
        {
            return DALPatente.ListarActuales(id_usuario);
        }

        public List<Patente> ListarSinAsignar(int id_usuario)
        {
            return DALPatente.ListarSinAsignar(id_usuario);
        }
    }
}
