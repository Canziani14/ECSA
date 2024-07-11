using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SQLHelper;
using System.Net;

namespace DAL.DAOs
{
    internal class DAOSLinea
    {
        private DAOSLinea() { }
        private static DAOs.DAOSLinea instance;

        public static DAOs.DAOSLinea GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSLinea();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;
        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Linea] order by Nombre_Linea";
        string QueryInsert = "INSERT INTO Linea (Nombre_Linea)" +
           "VALUES (@Nombre_Linea)";
        string QueryDelete = "delete from Linea where ID_Linea = @ID_Linea";
        string QueryUpdate = "UPDATE Linea SET Nombre_Linea = @Nombre_Linea WHERE ID_Linea = @ID_Linea";




                public bool Agregar(string NumeroDeLinea)
                {
                    bool returnValue = false;

                    List<SqlParameter> parameters = new List<SqlParameter>()
                        {
                            new SqlParameter("@Nombre_Linea", NumeroDeLinea),
                            
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
            

        public List<Linea> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSLinea.GetInstance().Map(table);
        }

        public List<Linea> Buscar(int id)
        {
            throw new NotImplementedException();
        }


        public bool Modificar(string Nombre_Linea, int ID_Linea)
        {
            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Nombre_Linea", Nombre_Linea),
        new SqlParameter("@ID_Linea", ID_Linea),

    };

            try
            {
                Console.WriteLine("Executing SQL: " + QueryUpdate);
                foreach (var param in parameters)
                {
                    Console.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryUpdate, parameters);
                returnValue = true;

                if (returnValue)
                {
                    Console.WriteLine("Usuario actualizado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se actualizó ninguna fila.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                returnValue = false;
            }


            return returnValue;
        }
   

        public bool Eliminar(int ID_Linea)
        {
        bool returnValue = false;

        List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@ID_Linea", ID_Linea),
            };

        SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
        returnValue = true;
        return returnValue;
        }

    }
}
