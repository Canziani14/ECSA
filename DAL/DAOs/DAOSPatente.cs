using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SQLHelper;

namespace DAL.DAOs
{
    internal class DAOSPatente
    {
        private DAOSPatente() { }
        private static DAOs.DAOSPatente instance;

        public static DAOs.DAOSPatente GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSPatente();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        string queryAsignarPatente = "insert into Usuario_Patente (ID_Usuario,ID_Patente) values(@ID_Usuario,@ID_Patente)";
        string queryQuitarPatente = "delete from Usuario_Patente where ID_Usuario=@ID_Usuario and ID_Patente=@ID_Patente";

        /*string querySelect = "SELECT p.id_patente, dp.descripcion "+
            "FROM Patente p "+
            "INNER JOIN Usuario_Patente up ON p.id_patente = up.id_patente "+
            "INNER JOIN Patente dp ON p.id_patente = dp.id_patente "+
            "WHERE up.id_usuario =@ID_Usuario";
        */
        string querySelect = "SELECT p.id_patente, p.descripcion " +
                     "FROM Patente p " +
                     "INNER JOIN Usuario_Patente up ON p.id_patente = up.id_patente " +
                     "WHERE up.id_usuario = @ID_Usuario";

        /*
                string querySelecSin = "SELECT p.id_patente, dp.Descripcion " +
                    "FROM Patente p " +
                    "LEFT JOIN Usuario_Patente up ON p.ID_Patente = up.ID_Patente AND up.id_usuario =@ID_Usuario " +
                    "INNER JOIN Patente dp ON p.id_patente = dp.id_patente "+
                    "WHERE up.id_patente IS NULL;";
        */
        string querySelecSin = "SELECT p.id_patente, p.descripcion " +
                               "FROM Patente p " +
                               "LEFT JOIN Usuario_Patente up ON p.ID_Patente = up.ID_Patente AND up.id_usuario = @ID_Usuario " +
                               "WHERE up.id_patente IS NULL";

        public bool Asignar(int id_usuario, int id_patente)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@ID_Usuario", id_usuario),
                    new SqlParameter("@ID_Patente", id_patente),
                };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryAsignarPatente, parameters);
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


        public bool Quitar(int id_usuario, int id_patente)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                    new SqlParameter("@ID_Usuario", id_usuario),
                    new SqlParameter("@ID_Patente", id_patente),
            };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryQuitarPatente, parameters);
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


        public List<Patente> ListarActuales(int id_usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@ID_Usuario", id_usuario),
            
            };


            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(querySelect, parameters);


            return Mappers.MAPPERSUsuario_Patente.GetInstance().Map(table);
        }

        public List<Patente> ListarSinAsignar(int id_usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@ID_Usuario", id_usuario),

            };



            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(querySelecSin, parameters);

            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine(column.ColumnName);
            }

            return Mappers.MAPPERSUsuario_Patente.GetInstance().Map(table);
        }

        public List<Patente> ObtenerPatentesPorUsuario(string usuarioId)
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Obtener patentes individuales
                SqlCommand command = new SqlCommand(
                    @"SELECT p.ID_Patente, p.Descripcion 
                  FROM Usuario_Patente up
                  INNER JOIN Patente p ON up.ID_Patente = p.ID_Patente 
                  WHERE up.ID_Usuario = @UsuarioId", connection);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                    ID_Patente = int.Parse(reader["ID_Patente"].ToString()),
                    Descripcion = reader["Descripcion"].ToString()
                    });
                }
                reader.Close();

                // Obtener patentes de familias
                command.CommandText =
                    @"SELECT p.ID_Patente, p.Descripcion 
                  FROM Familia_Patente fp
                  INNER JOIN Patente p ON fp.ID_Patente = p.ID_Patente 
                  WHERE fp.ID_Familia IN 
                      (SELECT ID_Familia FROM Usuario_Familia WHERE ID_Usuario = @UsuarioId)";

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                        ID_Patente = int.Parse(reader["ID_Patente"].ToString()),
                        Descripcion = reader["Descripcion"].ToString()
                    });
                }
            }

            return patentes;
        }

    }
}
