using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ABM_Linea : BE.ICrud<BE.Linea>
    {
        DAL.DALLinea DALLinea = new DAL.DALLinea();

        public List<Linea> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Linea objAgregar)
        {
            return DALLinea.Crear(objAgregar);
        }

        public bool Eliminar(Linea objEliminar)
        {
            return DALLinea.Eliminar(objEliminar);
        }

        public List<Linea> Listar()
        {
            return DALLinea.Listar();
        }

        public bool Modificar(Linea objActualizar)
        {
            return DALLinea.Modificar(objActualizar);
        }
    }
}
