using BE;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs
{
    internal class DAOSCoche 
    {
        private DAOSCoche() { }
        private static DAOs.DAOSCoche instance;

        public static DAOs.DAOSCoche GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSCoche();
            }
            return instance;
        }


        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;

        string QueryInsert = "INSERT INTO Coche (Patente, ID_Linea) VALUES (@Patente, @ID_Linea)";

        string QueryDelete = "delete from Coche where Interno = @Interno";

        string QuerySelect = "SELECT * from coche;";













        public bool Crear(string patente, int idLinea)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Patente", patente),
        new SqlParameter("@ID_Linea", idLinea)

    };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryInsert, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Empleado creado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se insertó ninguna fila.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                returnValue = false;
            }

            return returnValue;
        }

        public List<Coche> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSCoche.GetInstance().Map(table);
        }

        public List<Coche> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Coche objActualizar)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int interno)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@Interno", interno),
            };

            SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
            returnValue = true;
            return returnValue;
        }

       
    }
}
