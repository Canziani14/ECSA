using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ABM_Servicio : BE.ICrud<BE.Servicio>
    {

        DAL.DALServicio DALServicio = new DAL.DALServicio();

        #region ABM-Listar-Buscar Servicio

        public List<Servicio> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Servicio objAgregar)
        {
            return DALServicio.Crear(objAgregar);
        }

        public bool CrearServicio(Servicio objAgregar)
        {
            return DALServicio.CrearServicio(objAgregar);
        }

        public bool Eliminar(Servicio objEliminar)
        {
            return DALServicio.Eliminar(objEliminar);
        }

        public List<Servicio> Listar(int idLinea)
        {
            return DALServicio.Listar(idLinea);
        }

        public List<Servicio> Listar()
        {
            return DALServicio.Listar();
        }

        public bool Modificar(Servicio objActualizar)
        {
            return DALServicio.Modificar(objActualizar);
        }


        

        #endregion
    }
}
