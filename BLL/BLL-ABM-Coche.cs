using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ABM_Coche : BE.ICrud<BE.Coche>
    {

        DAL.DALCoche DALCoche = new DAL.DALCoche();
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
            return DALCoche.Listar();
        }

        public bool Modificar(Coche objActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
