using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCoche : ICrud<BE.Coche>
    {
        public List<Coche> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Coche objAgregar)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Coche objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<Coche> Listar()
        {
            return DAOs.DAOSCoche.GetInstance().Listar();
        }

        public bool Modificar(Coche objActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
