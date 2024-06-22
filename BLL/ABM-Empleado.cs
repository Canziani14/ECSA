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

        DAL.Empleado DALEmpleado = new DAL.Empleado();
        public bool Actualizar(Empleado objActualizar)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Empleado objAgregar)
        {
            return DALEmpleado.Crear(objAgregar);
        }
        //objAgregar.Nombre,objAgregar.Apellido, objAgregar.FechaDeingreso, objAgregar.DNI, objAgregar.Telefono,objAgregar.Direccion, objAgregar.LineaPertenece



        public bool Eliminar(Empleado objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> Listar()
        {
            return DALEmpleado.Listar(); ;
        }

        public List<Empleado> Listar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
