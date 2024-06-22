using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Empleado : BE.ICrud<BE.Empleado>
    {
        public bool Actualizar(BE.Empleado objActualizar)
        {
            throw new NotImplementedException();
        }

        public bool Crear(BE.Empleado objAgregar)
        {
            return DAOs.Empleado.GetInstance().Agregar(objAgregar.Nombre, objAgregar.Apellido, objAgregar.FechaDeingreso, objAgregar.DNI, objAgregar.Telefono, objAgregar.Direccion, objAgregar.LineaPertenece);
        }

        public bool Eliminar(BE.Empleado objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<BE.Empleado> Listar()
        {
            return DAOs.Empleado.GetInstance().Listar();
        }

        public List<BE.Empleado> Listar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
