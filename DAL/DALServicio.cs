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
            throw new NotImplementedException();
        }

        public bool Eliminar(Servicio objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<Servicio> Listar()
        {
            return DAOs.DAOSServicio.GetInstance().Listar();
        }

        public bool Modificar(Servicio objActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
