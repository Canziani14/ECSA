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
            throw new NotImplementedException();
        }

        public bool Eliminar(Servicio objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<Servicio> Listar()
        {
            return DALServicio.Listar();
        }

        public bool Modificar(Servicio objActualizar)
        {
            throw new NotImplementedException();
        }

        

        #endregion
    }
}
