using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class Empleado
    {
        private Empleado() { }
        private static Empleado instance;

        public static Empleado GetInstance()
        {
            if (instance == null)
            {
                instance = new Empleado();
            }
            return instance;
        }
        public List<BE.Empleado> Map(DataTable table)
        {
            List<BE.Empleado> empleados = new List<BE.Empleado>();

            foreach (DataRow item in table.Rows)
            {
                empleados.Add(new BE.Empleado()
                {
                    Legajo= item.Field<int>("Legajo"),
                    Nombre= item.Field<string>("Nombre"),
                    Apellido = item.Field<string>("Apellido"),
                    FechaDeingreso = item.Field<DateTime>("FechaIngreso"),
                    DNI = item.Field<int>("DNI"),
                    Telefono= item.Field<string>("Telefono"),
                    Direccion= item.Field<string>("Direccion"),
                    LineaPertenece =item.Field<int>("ID_Linea")
                });
            }
            return empleados;
        }

    }
}
