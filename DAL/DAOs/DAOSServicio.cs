using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.DAOs
{
    internal class DAOSServicio 
    {

        private DAOSServicio() { }
        private static DAOs.DAOSServicio instance;

        public static DAOs.DAOSServicio GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSServicio();
            }
            return instance;
        }




        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Servicio] " +
            "WHERE CONVERT(date, Hora_Cabecera_Principal) = CONVERT(date, GETDATE())";
           
      
        string QueryInsert = "INSERT INTO Servicio (Hora_Cabecera_Principal,Hora_Cabecera_Retorno, ID_Linea, Legajo, Interno )" +
           "VALUES (@Hora_Cabecera_Principal, @Hora_Cabecera_Retorno, @ID_Linea, @Legajo, @Interno)";

        string QueryDelete = "delete from servicio where ID_Servicio = @ID_Servicio";
        string QueryUpdate = "UPDATE Servicio SET Hora_Cabecera_Principal = @Hora_Cabecera_Principal,Hora_Cabecera_Retorno = @Hora_Cabecera_Retorno WHERE ID_Servicio = @ID_Servicio";

        string QuerySelectByLinea = "SELECT Servicio.ID_Servicio,Servicio.Hora_Cabecera_Principal,Servicio.Hora_Cabecera_Retorno, "+
        "Servicio.Interno, Servicio.Legajo,Empleado.Nombre, Empleado.Apellido, Servicio.ID_Linea FROM Servicio "+
        "INNER JOIN Empleado ON Servicio.legajo = Empleado.legajo WHERE Servicio.ID_Linea = @ID_Linea;";



        string QueryInsertServicio = "UPDATE Servicio SET Legajo = @Legajo ,Interno = @Interno WHERE ID_Servicio = @ID_Servicio";


        public List<Servicio> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(DateTime Hora_Cabecera_Principal, DateTime Hora_Cabecera_Retorno, int ID_Linea, int legajo, int interno)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
                        {
                            new SqlParameter("@Hora_Cabecera_Principal", Hora_Cabecera_Principal),
                            new SqlParameter("@Hora_Cabecera_Retorno", Hora_Cabecera_Retorno),
                            new SqlParameter("@ID_Linea", ID_Linea),
                            new SqlParameter("@Legajo", legajo),
                            new SqlParameter("@Interno", interno),

                        };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryInsert, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Coche creado con éxito.");
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


        
    public bool CrearServicio(int emlpeado, int coche, int idServicio)
            {
                bool returnValue = false;

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Legajo", emlpeado),
                    new SqlParameter("@Interno", coche),
                    new SqlParameter("@ID_Servicio", idServicio),

                };

                try
                {
                    Console.WriteLine("Trying to execute insert operation...");
                    int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryInsertServicio, parameters);
                    returnValue = rowsAffected > 0;

                    if (returnValue)
                    {
                        Console.WriteLine("Coche creado con éxito.");
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





        public bool Eliminar(int ID_Servicio)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@ID_Servicio", ID_Servicio),
            };

            SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
            returnValue = true;
            return returnValue;
        }

        public List<Servicio> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }

        public List<Servicio> Listar (int IDLinea)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Linea", IDLinea),
            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByLinea, parameters);
            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }

        public bool Modificar(DateTime salida, DateTime llegada, int idServicio)
        {
            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Hora_Cabecera_Principal", salida),
                new SqlParameter("@Hora_Cabecera_Retorno", llegada),
                new SqlParameter("@ID_Servicio", idServicio),
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

        public List<Servicio> ValidarConductor(int legajo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Legajo", legajo),
            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByLinea, parameters);
            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }
        public List<Servicio> ValidarInterno(int interno)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Interno", interno),
            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByLinea, parameters);
            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }
        public List<Servicio> ValidarHorario(DateTime horario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Hora_Cabecera_Principal", horario),
            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByLinea, parameters);
            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }



    }
}
