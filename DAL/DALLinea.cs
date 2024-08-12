using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALLinea : BE.ICrud<BE.Linea>
    {
        public List<Linea> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Linea objAgregar)
        {
            return DAOs.DAOSLinea.GetInstance().Agregar(objAgregar.NumeroDeLinea);
        }

        public bool Eliminar(Linea objEliminar)
        {
            return DAOs.DAOSLinea.GetInstance().Eliminar(objEliminar.ID_Linea);
        }

        public List<Linea> Listar()
        {
            return DAOs.DAOSLinea.GetInstance().Listar();
        }

        public bool Modificar(Linea objActualizar)
        {
            return DAOs.DAOSLinea.GetInstance().Modificar(objActualizar.NumeroDeLinea, objActualizar.ID_Linea);
        }

        public List<Linea> ValidarNumLinea(string NumeroLinea)
        {
            return DAOs.DAOSLinea.GetInstance().ValidarNumLinea(NumeroLinea);
        }
    }
}
