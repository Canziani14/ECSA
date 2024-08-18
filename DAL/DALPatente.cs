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
        public bool Asignar(int id_Usuario, int id_Patente)
        {
            return DAOs.DAOSPatente.GetInstance().Asignar(id_Usuario, id_Patente);
        }

        public bool Quitar(int id_Usuario, int id_Patente)
        {
            return DAOs.DAOSPatente.GetInstance().Quitar(id_Usuario, id_Patente);
        }

        public List<BE.Patente> ListarActuales(int id_usuario)
        {
            return DAOs.DAOSPatente.GetInstance().ListarActuales(id_usuario);
        }

        public List<BE.Patente> ListarSinAsignar(int id_usuario)
        {
            return DAOs.DAOSPatente.GetInstance().ListarSinAsignar(id_usuario);
        }

        public Iterator<Patente> ObtenerPatentesPorUsuario(string usuarioId)
        {
            List<Patente> patentes = DAOs.DAOSPatente.GetInstance().ObtenerPatentesPorUsuario(usuarioId);
            return new PatenteIterator(patentes);
        }


    }
}
