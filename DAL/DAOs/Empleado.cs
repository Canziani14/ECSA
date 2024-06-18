using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;
using System.Configuration;

namespace DAL.DAOs
{
    internal class Empleado
    {
        private Empleado() { }
        private static DAOs.Empleado instance;

        public static DAOs.Empleado GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.Empleado();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;

        string QueryInsert = "AgendaInsert";
        string QueryDelete = "AgendaDelete";
        string QuerySelect = "SELECT [Legajo],[Nombre],[Apellido],[FechaIngreso],[DNI],[Telefono],[Direccion],[LineaQuePertenece]FROM [ECSA].[dbo].[Empleado]";
        string QueryUpdate = "AgendaUpdate";




        public List<BE.Empleado> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);
         

            return Mappers.Empleado.GetInstance().Map(table);
        }

    }
}
