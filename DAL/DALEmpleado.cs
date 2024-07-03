using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALEmpleado : BE.ICrud<BE.Empleado>
    {
        public bool Modificar(BE.Empleado objActualizar)
        {
            return DAOs.DAOSEmpleado.GetInstance().Modificar(objActualizar.Legajo, objActualizar.Nombre, objActualizar.Apellido, objActualizar.FechaDeingreso, objActualizar.DNI, objActualizar.Telefono, objActualizar.Direccion, objActualizar.LineaPertenece);
        }

        public bool Crear(BE.Empleado objAgregar)
        {
            return DAOs.DAOSEmpleado.GetInstance().Agregar(objAgregar.Nombre, objAgregar.Apellido, objAgregar.FechaDeingreso, objAgregar.DNI, objAgregar.Telefono, objAgregar.Direccion, objAgregar.LineaPertenece);
        }

        public bool Eliminar(BE.Empleado objEliminar)
        {
            return DAOs.DAOSEmpleado.GetInstance().Eliminar(objEliminar.Legajo);
        }

        public List<BE.Empleado> Listar()
        {
            return DAOs.DAOSEmpleado.GetInstance().Listar();
        }

        public List<BE.Empleado> Buscar(int Legajo)
        {
            return DAOs.DAOSEmpleado.GetInstance().Buscar(Legajo);
        }
    }
}
