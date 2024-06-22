using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLHelper
{
    public class SqlHelper
    {
        #region Singleton
        private static SqlHelper instance;

        public static SqlHelper GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new SqlHelper(connectionString);
            }

            return instance;
        }

        private SqlHelper(string connString)
        {
            connectionString = connString;

        }



        private string connectionString;

        private string ConnectionString
        {
            get { return connectionString; }

        }
        #endregion

        #region Lectura de Datos
        public DataTable ExecuteDataTable(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Connection = connection;

                connection.Open();
                table.Load(command.ExecuteReader());
            }

            return table;

        }

        public DataTable ExecuteDataTable(string query, int id)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                command.CommandText = query;

                connection.Open();
                table.Load(command.ExecuteReader());
            }

            return table;

        }

        public DataTable ExecuteDataTable(string storeProcedureName, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storeProcedureName;
                command.Connection = connection;

                // Si el Objeto parameters no esta en nulo y si tieen mas de cero parameros lso agrego
                // con el metodo add range el cual pide un ARRAY no un Listado generico, es por ellos
                // Que debo aplicale el metodo ToArray.
                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                connection.Open();
                table.Load(command.ExecuteReader());

            }

            return table;
        }
        #endregion

        #region Update,Delete e Insert

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Connection = connection;

                connection.Open();
                return command.ExecuteNonQuery();

            }
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            /*  int value = 1;
              using (SqlConnection connection = new SqlConnection(this.ConnectionString))
              {


                  using (SqlCommand command = new SqlCommand())
                  {

                      command.CommandText = query;
                      command.CommandType = CommandType.Text;
                      command.Connection = connection;

                      if (parameters != null && parameters.Count > 0)
                      {
                          command.Parameters.AddRange(parameters.ToArray());

                      }
                      try
                      {
                          connection.Open();

                          return command.ExecuteNonQuery();
                      }
                      catch (Exception ex)
                      {

                          Console.WriteLine(ex.Message);
                      }

                      return value;

                  }
              }*/
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    try
                    {
                        Console.WriteLine("Executing SQL: " + query);
                        foreach (var param in parameters)
                        {
                            Console.WriteLine($"{param.ParameterName}: {param.Value}");
                        }

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error executing SQL: " + ex.Message);
                    }
                }
            }
            return rowsAffected;
        }

    }

    #endregion
    /*
            #region ADODesconectado
            public DataTable ExecuteDataTableConADODesconectado(string query)
            {
                DataTable table = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();

                SqlConnection connection = new SqlConnection(this.ConnectionString);

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;

                    dataAdapter.SelectCommand = command;
                    //dataAdapter.UpdateCommand = command;
                    //dataAdapter.DeleteCommand = command;
                    //dataAdapter.InsertCommand = command;

                    dataAdapter.Fill(table);



                    return table;
                    // extracion
                    // deposito
                    //pago

                }

            }
    */
    /*
        public DataTable ExecuteDataTableConADODesconectado(string storeProcedure, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            SqlConnection connection = new SqlConnection(this.ConnectionString);

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storeProcedure;
                command.Connection = connection;

                dataAdapter.SelectCommand = command;
                //dataAdapter.UpdateCommand = command;
                //dataAdapter.DeleteCommand = command;
                //dataAdapter.InsertCommand = command;

                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());

                }

                dataAdapter.Fill(table);

                return table;
                // extracion
                // deposito
                //pago

            }

        }
        #endregion
    */
    #region Archivos y XML
    /*
     public class FileHelper
     {
         // Método para escribir texto en un archivo
         public static void EscribirTexto(string rutaArchivo, string contenido)
         {
             File.WriteAllText(rutaArchivo, contenido);
         }

         // Método para leer texto desde un archivo
         public static string LeerTexto(string rutaArchivo)
         {
             return File.ReadAllText(rutaArchivo);
         }

         // Método para escribir objetos serializados en formato XML en un archivo
         public static void EscribirXml<T>(string rutaArchivo, T objeto)
         {
             XmlSerializer serializer = new XmlSerializer(typeof(T));

             using (TextWriter writer = new StreamWriter(rutaArchivo))
             {
                 serializer.Serialize(writer, objeto);
             }
         }

         // Método para leer objetos desde un archivo XML
         public static T LeerXml<T>(string rutaArchivo)
         {
             XmlSerializer serializer = new XmlSerializer(typeof(T));

             using (TextReader reader = new StreamReader(rutaArchivo))
             {
                 return (T)serializer.Deserialize(reader);
             }
         }

     }*/


    #endregion

}
