using BE;
using DAL;
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
            return DALCoche.Buscar(id);
        }

        public bool Crear(Coche objAgregar)
        {
            return DALCoche.Crear(objAgregar);
        }

        public bool Eliminar(Coche objEliminar)
        {
            return DALCoche.Eliminar(objEliminar);
        }

        public List<Coche> Listar()
        {
            return DALCoche.Listar();
        }

        public List<Coche> Listar(int linea)
        {
            return DALCoche.Listar(linea);
        }

        public bool Modificar(Coche objActualizar)
        {
            return DALCoche.Modificar(objActualizar);
        }

        public List<Coche> ValidarPatente(string patente)
        {
            return DALCoche.ValidarPatente(patente);
        }

    }
}
