using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ABM_Empleado : BE.ICrud<BE.Empleado>
    {

        DAL.DALEmpleado DALEmpleado = new DAL.DALEmpleado();

        #region ABM-Listar-Buscar Empelado
        public bool Modificar(Empleado objActualizar)
        {
            return DALEmpleado.Modificar(objActualizar);
        }

        public bool Crear(Empleado objAgregar)
        {
            return DALEmpleado.Crear(objAgregar);
        }

        public bool Eliminar(Empleado objEliminar)
        {
            return DALEmpleado.Eliminar(objEliminar);
        }

        public List<Empleado> Listar()
        {
            return DALEmpleado.Listar();
        }

        public List<Empleado> Listar(int linea)
        {
            return DALEmpleado.Listar(linea);
        }

        public List<Empleado> Buscar(int Legajo)
        {
            return DALEmpleado.Buscar(Legajo);
        }

        #endregion

        public List<Empleado> ValidarDNI(string DNI)
        {
            return DALEmpleado.ValidarDNI(DNI);
        }



    }
}
