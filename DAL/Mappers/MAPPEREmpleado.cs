using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPEREmpleado
    {
        private MAPPEREmpleado() { }
        private static MAPPEREmpleado instance;

        public static MAPPEREmpleado GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPEREmpleado();
            }
            return instance;
        }
        public List<BE.Empleado> Map(DataTable table)
        {
            List<BE.Empleado> empleados = new List<BE.Empleado>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                empleados.Add(new BE.Empleado()
                {
                    Legajo= item.Field<int>("Legajo"),
                    Nombre= item.Field<string>("Nombre"),
                    Apellido = item.Field<string>("Apellido"),
                    FechaDeingreso = item.Field<DateTime>("FechaIngreso"),
                    DNI =DALSeguridad.DesencriptarCamposReversible(item.Field<string>("DNI")),
                    Telefono= DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Telefono")),
                    Direccion= DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Direccion")),
                    LineaPertenece =item.Field<int>("ID_Linea")
                });
            }
            return empleados;
        }

    }
}
