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
using System.Net;
using System.Security.Cryptography;

namespace DAL.DAOs
{
    internal class DAOSUsuario
    {
        #region SingletonEmpleado, ConnectionString y Querys
        private DAOSUsuario() { }
        private static DAOs.DAOSUsuario instance;

        public static DAOs.DAOSUsuario GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSUsuario();
            }
            return instance;
        }




        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;

        string QueryInsert = "INSERT INTO Usuario (Nombre, Apellido, Nick, Mail, DNI, Contraseña, estado)" +
            "VALUES (@Nombre, @Apellido, @Nick, @Mail, @DNI, @Contraseña, 1)";

        string QueryDelete = "delete from Usuario where ID_Usuario = @ID_Usuario";

        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Usuario]";

        string QueryUpdate = "UPDATE Usuario " +
                         "SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, " +
                         "Mail = @Mail " +
                         "WHERE ID_Usuario = @ID_Usuario";

        string QuerySelectByID = "SELECT * FROM [ECSA].[dbo].[Usuario] where Legajo = @ID_Usuario";
        string QuerySelectByNick = "SELECT * FROM [ECSA].[dbo].[Usuario] where Nick = @Nick";
        string QuerySelectByContraseña = "SELECT * FROM [ECSA].[dbo].[Usuario] where Contraseña = @Contraseña";
        string QuerySumarIntento = "UPDATE Usuario SET Contador_Int_Fallidos = Contador_Int_Fallidos + 1 WHERE ID_Usuario = @ID_Usuario";
        string QueryBloquearUsuario = "Update usuario set Estado = 'False' where ID_Usuario = @ID_Usuario";
        string QueryDesbloquearUsuario = "Update usuario set Estado = 'True', Contador_Int_Fallidos=0 where ID_Usuario = @ID_Usuario";
        string QueryUpdateContador0 = "update usuario set Contador_Int_Fallidos = 0 where ID_Usuario = @ID_Usuario";
        #endregion

        #region Agregar Usuario
        public bool Agregar(string Nombre, string Apellido,string Nick, string Mail, string DNI, string contraseña)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Nombre", Nombre),
        new SqlParameter("@Apellido", Apellido),
        new SqlParameter("@Nick", Nick),
        new SqlParameter("@Mail", Mail),
        new SqlParameter("@DNI",DNI ),
        new SqlParameter("@Contraseña",contraseña ),
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
        #endregion


        #region ListarUsuarios
        public List<BE.Usuario> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSUsuario.GetInstance().Map(table);
        }

        public List<BE.Usuario> Buscar(int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@ID_Usuario", ID_Usuario),

    };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByID, parameters);
            return Mappers.MAPPERSUsuario.GetInstance().Map(table);
        }
        #endregion


        #region ModificarUsuario
        public bool Modificar(string Nombre, string Apellido, string Nick, string Mail, string DNI, int ID_Usuario)
        {

            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Apellido", Apellido),
                new SqlParameter("@Nick", Nick),
                new SqlParameter("@Mail", Mail),
                new SqlParameter("@DNI", DNI),
                new SqlParameter("@ID_Usuario", ID_Usuario),
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

        #endregion


        #region ElimminarUsuario
        public bool Eliminar(int ID_Usuario)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@ID_Usuario", ID_Usuario),
            };

            SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
            returnValue = true;
            return returnValue;
        }

        #endregion


        #region Inciar Sesion

        public BE.Usuario BuscarNick(string Nick)
        {
            // Obtener los datos de la tabla Usuario
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable("SELECT * FROM Usuario", null);

            // Mapear los resultados y desencriptar el Nick de cada usuario
            List<BE.Usuario> usuarios = Mappers.MAPPERSUsuario.GetInstance().Map(table);

            // Filtrar el usuario que coincida con el Nick proporcionado
            BE.Usuario usuarioFiltrado = usuarios.FirstOrDefault(u => u.Nick == Nick);

            return usuarioFiltrado;
        }

        public List<BE.Usuario> BuscarContraseña(string contraseña)
        {
        List<SqlParameter> parameters = new List<SqlParameter>()
        {
        new SqlParameter("@Contraseña", contraseña),

        };
        DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByContraseña, parameters);
        return Mappers.MAPPERSUsuario.GetInstance().Map(table);
        }


        public int SumarIntento(BE.Usuario usuariolog)
        {
            List<SqlParameter> parametersUpdate = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario", usuariolog.ID_Usuario)
            };

            // Consulta para incrementar el contador de intentos fallidos
            string queryUpdate = "UPDATE Usuario SET Contador_Int_Fallidos = Contador_Int_Fallidos + 1 WHERE ID_Usuario = @ID_Usuario;";
            SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryUpdate, parametersUpdate);

            // Crear nuevos parámetros para la siguiente consulta
            List<SqlParameter> parametersSelect = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario", usuariolog.ID_Usuario)
            };

            // Consulta para obtener el nuevo valor de IntentosFallidos
            string querySelect = "SELECT Contador_Int_Fallidos FROM Usuario WHERE ID_Usuario = @ID_Usuario;";
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(querySelect, parametersSelect);

            if (table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0]["Contador_Int_Fallidos"]);
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        }

        
        public bool ContadorIngresos0(int ID_Usuario)
                {
                    bool returnValue = false;

                    List<SqlParameter> parameters = new List<SqlParameter>()
                    {
                        new SqlParameter("@ID_Usuario", ID_Usuario)

                    };

                    try
                    {
                        Console.WriteLine("Executing SQL: " + QueryUpdateContador0);
                        foreach (var param in parameters)
                        {
                            Console.WriteLine($"{param.ParameterName}: {param.Value}");
                        }

                        int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryUpdateContador0, parameters);
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










        public bool BloquearUsuario(int ID_Usuario)
        {
            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario", ID_Usuario)

            };

            try
            {
                Console.WriteLine("Executing SQL: " + QueryBloquearUsuario);
                foreach (var param in parameters)
                {
                    Console.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryBloquearUsuario, parameters);
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




        public bool DesbloquearUsuario(int ID_Usuario)
        {
            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@ID_Usuario", ID_Usuario)

        };

            try
            {
                Console.WriteLine("Executing SQL: " + QueryDesbloquearUsuario);
                foreach (var param in parameters)
                {
                    Console.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDesbloquearUsuario, parameters);
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



        /*

        {
            List<SqlParameter> parameters = new List<SqlParameter>()
        {
            new SqlParameter("@ID_Usuario", usuariolog.ID_Usuario),

            };
                    DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySumarIntento, parameters);
                    return Mappers.MAPPERSUsuario.GetInstance().Map(table);
                }

        */






        #endregion

    }
}
