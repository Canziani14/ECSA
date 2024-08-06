using BE;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.DAOs
{
    internal class DAOSFamilia
    {
        private DAOSFamilia() { }
        private static DAOs.DAOSFamilia instance;

        public static DAOs.DAOSFamilia GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSFamilia();
            }
            return instance;
        }



        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        string QueryInsert = "";
        string QuerySelect = "select * from Familia";
        string QuerySelectPatentesAsignadas = "SELECT fp.ID_Patente, p.Descripcion, fp.ID_Familia " +
        "FROM Familia_Patente fp " +
        "INNER JOIN Patente p ON fp.ID_Patente = p.ID_Patente " +
        "WHERE fp.ID_Familia = @ID_Familia;";
        string queryDeleteXFamilia = "DELETE FROM Familia_Patente WHERE ID_Familia = @ID_Familia AND ID_Patente = @ID_Patente";
        string queryInsertXFamilia = "INSERT INTO Familia_Patente (ID_Familia, ID_Patente) VALUES (@ID_Familia, @ID_Patente);";
        string QuerySelectPatentesSinAsignar = "SELECT p.ID_Patente, p.Descripcion,fp.ID_Familia " +
            "FROM Familia_Patente fp " +
            "RIGHT JOIN Patente p ON fp.ID_Patente = p.ID_Patente AND fp.ID_Familia = @ID_Familia " +
            "WHERE fp.ID_Patente IS NULL;";
        string QuerySelectPatentesAsignadasXFamilia = "SELECT fp.id_patente, p.descripcion, fp.id_familia " +
            "FROM familia_patente fp " +
            "INNER JOIN patente p ON fp.id_patente = p.id_patente " +
            "WHERE fp.id_familia = @ID_Familia;";

        string QuerySelectPatentesSinAsignarXFamilia = "SELECT p.id_patente, p.descripcion, fp.id_familia " +
            "FROM patente p " +
            "LEFT JOIN familia_patente fp ON p.id_patente = fp.id_patente AND fp.id_familia = @ID_Familia " +
            "WHERE fp.id_patente IS NULL;";

        string QuerySelectfamiliasPorUsuarioAsignadas = "SELECT f.ID_Familia,f.Descripcion " +
            "FROM familia f JOIN usuario_familia uf ON f.ID_Familia = uf.ID_Familia " +
            "JOIN usuario u ON u.ID_Usuario = uf.ID_Usuario " +
            "WHERE u.ID_Usuario = @ID_Usuario;";

        string QuerySelectFamiliasPorUsuarioSinAsignar = "SELECT f.ID_Familia, f.Descripcion FROM familia f " +
            "WHERE f.ID_Familia NOT IN (SELECT uf.ID_Familia FROM usuario_familia uf " +
            "WHERE uf.ID_Usuario = @ID_Usuario);";

        string QueryUpdate = "";
        string QueryDelete = "";


        public bool Agregar(string Descripcion)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Descripcion", Descripcion),
        
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



        public List<BE.Familia> Listar()
        {

            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSUsuario_Familia.GetInstance().Map(table);
        }

        public List<BE.Familia> ListarActuales(int ID_Familia)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Familia", ID_Familia),

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectPatentesAsignadas, parameters);


            return Mappers.MAPPERSUsuario_Familia.GetInstance().Map(table);
        }

        public List<BE.Familia> ListarSinAsignar(int ID_Familia)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Familia", ID_Familia),

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectPatentesSinAsignar, parameters);


            return Mappers.MAPPERSUsuario_Familia.GetInstance().Map(table);
        }







        public bool Modificar(string Descripcion)
        {

            bool returnValue = false;



            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Descripcion", Descripcion),
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
                    Console.WriteLine("Empleado actualizado con éxito.");
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



        public bool Eliminar(int? id_Familia)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@id_Familia", id_Familia),
            };

            SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
            returnValue = true;
            return returnValue;
        }





        public List<Patente> ListarSinAsignarXFamilia(int id_familia, int id_patente)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Familia", id_familia),
                new SqlParameter("@ID_Patente", id_patente),

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectPatentesSinAsignarXFamilia, parameters);


            return Mappers.MAPPERSFamilia_Patente.GetInstance().Map(table);
        }

        public List<Patente> ListarActualesXFamilia(int id_familia, int id_patente)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Familia", id_familia),
                new SqlParameter("@ID_Patente", id_patente),

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectPatentesAsignadasXFamilia, parameters);


            return Mappers.MAPPERSFamilia_Patente.GetInstance().Map(table);
        }


        public bool AsignarXFamilia(int ID_Familia, int id_Patente)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@ID_Familia", ID_Familia),
        new SqlParameter("@ID_Patente", id_Patente)
    };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryInsertXFamilia, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Patente asignada con éxito.");
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
        public bool QuitarXFamilia(int id_Familia, int id_Patente)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@ID_Familia", id_Familia),
        new SqlParameter("@ID_Patente", id_Patente)
    };

            try
            {
                Console.WriteLine("Trying to execute delete operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryDeleteXFamilia, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Patente quitada con éxito.");
                }
                else
                {
                    Console.WriteLine("No se eliminó ninguna fila.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                returnValue = false;
            }

            return returnValue;
        }



        public List<Familia> ListarFamiliasActualesXUsuario(int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID_Usuario", ID_Usuario),
                

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectfamiliasPorUsuarioAsignadas, parameters);


            return Mappers.MAPPERSUsuario_Familia.GetInstance().Map(table);
        }

        public List<Familia> ListarFamiliasSinAsignarXUsuario(int ID_Usuario)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                 new SqlParameter("@ID_Usuario", ID_Usuario),

            };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectFamiliasPorUsuarioSinAsignar, parameters);


            return Mappers.MAPPERSUsuario_Familia.GetInstance().Map(table); 
        }




    }
}
