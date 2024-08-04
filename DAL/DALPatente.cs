using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALPatente
    {
        public bool Asignar(BE.Patente objAgregar)
        {
            return DAOs.DAOSPatente.GetInstance().Asignar(objAgregar.ID_Usuario,objAgregar.ID_Patente);
        }

        public bool Quitar(BE.Patente objEliminar)
        {
            return DAOs.DAOSPatente.GetInstance().Quitar(objEliminar.ID_Usuario,objEliminar.ID_Patente);
        }

        public List<BE.Patente> ListarActuales(int id_usuario)
        {
            return DAOs.DAOSPatente.GetInstance().ListarActuales(id_usuario);
        }

        public List<BE.Patente> ListarSinAsignar(int id_usuario)
        {
            return DAOs.DAOSPatente.GetInstance().ListarSinAsignar(id_usuario);
        }
    }
}
