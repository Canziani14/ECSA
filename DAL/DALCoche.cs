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
            return DAOs.DAOSCoche.GetInstance().Crear(objAgregar.Patente,objAgregar.ID_Linea);
        }

        public bool Eliminar(Coche objEliminar)
        {
            return DAOs.DAOSCoche.GetInstance().Eliminar(objEliminar.Interno);
        }

        public List<Coche> Listar()
        {
            return DAOs.DAOSCoche.GetInstance().Listar();
        }

        public List<Coche> Listar(int linea)
        {
            return DAOs.DAOSCoche.GetInstance().Listar(linea);
        }

        public bool Modificar(Coche objActualizar)
        {
            return DAOs.DAOSCoche.GetInstance().Modificar(objActualizar.Patente, objActualizar.ID_Linea);
        }

        public List<Coche> ValidarPatente(string patente)
        {
            return DAOs.DAOSCoche.GetInstance().ValidarPatente(patente);
        }

    }
}
