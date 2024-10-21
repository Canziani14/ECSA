using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


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



        private static string connectionString;

        private string ConnectionString
        {
            get { return connectionString; }

        }
        #endregion

        #region Lectura de Datos
        public DataTable ExecuteDataTable(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        public DataTable ExecuteDataTable(string query, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = query;
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

        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection; // Asigna la conexión al comando
                connection.Open();
                table.Load(cmd.ExecuteReader());
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

    

    #endregion

    public static int ExecuteNonQuery(string connectionString, string query, List<SqlParameter> parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }

    public static object ExecuteScalar(string connectionString, string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteScalar();
        }
    }


        public static object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string connectionString, string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Añadir los parámetros al comando
                command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static DataTable ExecuteQuery(string connectionString, string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }

        #region digitos verificadores

      
        public decimal ExecuteScalar(string mcommand)
        {
            try
            {
                using (SqlConnection mcon = new SqlConnection(connectionString))
                {
                    SqlCommand mcom = new SqlCommand(mcommand, mcon);
                    mcon.Open();
                    object result = mcom.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        throw new Exception("La consulta no devolvió ningún valor.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta y convertir a Decimal.", ex);
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        public DataSet ExecuteDataSet(string mcommand)
        {
            DataSet mds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter mda = new SqlDataAdapter(mcommand, conn);
                    mda.Fill(mds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta y llenar DataSet.", ex);
            }
            return mds;

        }

        #endregion


        #region ADODesconectado
        /*
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
        */
        #endregion


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
}
    

