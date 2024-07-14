using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALServicio : BE.ICrud<BE.Servicio>
    {
        public List<Servicio> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Servicio objAgregar)
        {
            return DAOs.DAOSServicio.GetInstance().Crear(objAgregar.HorarioSalida, objAgregar.HorarioLlegada, objAgregar.Linea, objAgregar.LegajoEmpleado,objAgregar.Coche);
        }

        public bool CrearServicio(Servicio objAgregar)
        {
            return DAOs.DAOSServicio.GetInstance().CrearServicio(objAgregar.Coche,objAgregar.LegajoEmpleado, objAgregar.ID_Servicio);
        }

        public bool Eliminar(Servicio objEliminar)
        {
            return DAOs.DAOSServicio.GetInstance().Eliminar(objEliminar.ID_Servicio);
        }

        public List<Servicio> Listar(int idLinea)
        {
            return DAOs.DAOSServicio.GetInstance().Listar(idLinea);
        }
        public List<Servicio> Listar()
        {
            return DAOs.DAOSServicio.GetInstance().Listar();
        }

        public bool Modificar(Servicio objActualizar)
        {
            return DAOs.DAOSServicio.GetInstance().Modificar(objActualizar.HorarioSalida, objActualizar.HorarioLlegada, objActualizar.ID_Servicio);
        }
    }
}
