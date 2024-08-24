using BE;
using iTextSharp.text.pdf.parser;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.DAOs
{
    internal class DAOSDal
    {
        private DAOSDal() { }
        private static DAOs.DAOSDal instance;

        public static DAOs.DAOSDal GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSDal();
            }
            return instance;
        }

        DAL.DALDAL DALDAL = new DAL.DALDAL();
        DAOs.DAOSSeguridad DAOSeguridad = new DAOSSeguridad();

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        string queryBKP = "BACKUP DATABASE [ECSA] " +
            "TO DISK = @backupPath "+
            "WITH FORMAT, INIT, NAME = 'Full Backup of ECSA';";
        string queryRestore =
            "USE [master]; " +
            "ALTER DATABASE [ECSA] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " + // Desconecta a todos los usuarios
            "RESTORE DATABASE [ECSA] FROM DISK = @backupPath " +
            "WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5; " +
            "ALTER DATABASE [ECSA] SET MULTI_USER;"; // Devuelve la base de datos al modo multiusuario





        #region bkp y restore

        public void RealizarBKP(string path)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryBKP, connection);
                command.Parameters.AddWithValue("@backupPath", path);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar el respaldo: " + ex.Message);
                }
            }
        }

    


        

        public void RealizarRestore(string path)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryRestore, connection);
                command.Parameters.AddWithValue("@backupPath", path);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Restauración realizada con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la restauración: " + ex.Message);
                }
            }
        }
        #endregion


        #region Verificar y Reparar Integridad
        public bool VerificarIntegridad()
        {
            var tablasConDVH = new List<(string NombreTabla, Func<DataRow, int> FuncionCalculoDVH)>
            {
                ("Bitacora", DAOSeguridad.DVHBitacora),
                ("Coche", DAOSeguridad.DVHCoche),
                ("Empleado", DAOSeguridad.DVHEmpleado),
                ("Familia_Patente", DAOSeguridad.DVHFamiliaPatente),
                ("Linea", DAOSeguridad.DVHLinea),
                ("Servicio", DAOSeguridad.DVHServicio),
                ("Usuario", DAOSeguridad.DVHUsuario),
                ("Usuario_Familia", DAOSeguridad.DVHFamiliaUsuario),
                ("Usuario_Patente", DAOSeguridad.DVHPatenteUsuario)
            };

            bool integridad = true;

            foreach (var tabla in tablasConDVH)
            {
                Console.WriteLine($"Verificando integridad para la tabla {tabla.NombreTabla}");

                // Obtener todos los registros de la tabla
                DataTable registros = ObtenerRegistrosDeTabla(tabla.NombreTabla);

                foreach (DataRow registro in registros.Rows)
                {
                    // Calcular el DVH utilizando la función específica para la tabla
                    int dvhCalculado = tabla.FuncionCalculoDVH(registro);

                    // Obtener el DVH almacenado en la base de datos
                    int dvhAlmacenado = int.Parse(registro["DVH"].ToString());

                    // Comparar los DVH
                    if (dvhCalculado != dvhAlmacenado)
                    {
                        Console.WriteLine($"Inconsistencia detectada en la tabla {tabla.NombreTabla}, registro ID: {registro[0]}");
                        integridad = false;
                    }
                }

                // Verificar y reparar el DVV
                if (!VerificarDVV(tabla.NombreTabla))
                {
                    Console.WriteLine($"Inconsistencia detectada en el DVV para la tabla {tabla.NombreTabla}");
                    integridad = false;
                }
            }

            return integridad; // Devuelve true si no hay inconsistencias
        }
        private DataTable ObtenerRegistrosDeTabla(string nombreTabla)
        {
            string sql = $"SELECT * FROM {nombreTabla}";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private bool VerificarDVV(string tabla)
        {
            int dvvAlmacenado = ObtenerDVVAlmacenado(tabla);
            int dvvCalculado = DAOSeguridad.CalcularDVV(tabla);

            return dvvAlmacenado == dvvCalculado;
        }

        private int ObtenerDVVAlmacenado(string tabla)
        {
            int dvv = 0;

            string sql = "SELECT DVV FROM DVV WHERE Tabla = @Tabla";
            using (var connection = new SqlConnection(connectionString))
            using (var command1 = new SqlCommand(sql, connection)) // Usa 'command1' aquí
            {
                command1.Parameters.AddWithValue("@Tabla", tabla);

                connection.Open();
                object result = command1.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    dvv = Convert.ToInt32(result);
                }
            }

            return dvv;
        }

        public void RepararIntegridad()
        {
            var tablasConDVH = new List<(string NombreTabla, Func<DataRow, int> FuncionCalculoDVH)>
                {
                    ("Bitacora", DAOSeguridad.DVHBitacora),
                    ("Coche", DAOSeguridad.DVHCoche),
                    ("Empleado", DAOSeguridad.DVHEmpleado),
                    ("Familia_Patente", DAOSeguridad.DVHFamiliaPatente),
                    ("Linea", DAOSeguridad.DVHLinea),
                    ("Servicio", DAOSeguridad.DVHServicio),
                    ("Usuario", DAOSeguridad.DVHUsuario),
                    ("Usuario_Familia", DAOSeguridad.DVHFamiliaUsuario),
                    ("Usuario_Patente", DAOSeguridad.DVHPatenteUsuario)
                };

            foreach (var tabla in tablasConDVH)
            {
                Console.WriteLine($"Reparando integridad para la tabla {tabla.NombreTabla}");

                // Obtener todos los registros de la tabla
                DataTable registros = ObtenerRegistrosDeTabla(tabla.NombreTabla);

                foreach (DataRow registro in registros.Rows)
                {
                    // Calcular el DVH utilizando la función específica para la tabla
                    int dvhCalculado = tabla.FuncionCalculoDVH(registro);

                    // Obtener el DVH almacenado en la base de datos
                    int dvhAlmacenado = int.Parse(registro["DVH"].ToString());

                    // Comparar los DVH
                    if (dvhCalculado != dvhAlmacenado)
                    {
                        Console.WriteLine($"Inconsistencia detectada en la tabla {tabla.NombreTabla}, registro ID: {registro[0]}");

                        // Reparar el registro actualizando el DVH
                        RepararRegistro(tabla.NombreTabla, registro, dvhCalculado);
                    }
                }

                // Reparar el DVV si es necesario
                RepararDVV(tabla.NombreTabla);
            }
        }

        private void RepararDVV(string tabla)
        {
            // Calcula el DVV correcto
            int dvvCalculado = DAOSeguridad.CalcularDVV(tabla);

            // Actualiza el DVV en la tabla DVV
            ActualizarDVV(tabla, dvvCalculado);
        }

        private void ActualizarDVV(string tabla, int dvvCalculado)
        {
            string sql = "UPDATE DVV SET DVV = @DVV WHERE Tabla = @Tabla";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@DVV", dvvCalculado);
                command.Parameters.AddWithValue("@Tabla", tabla);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void RepararRegistro(string nombreTabla, DataRow registro, int dvhCalculado)
        {
            // Obtén las columnas de la clave primaria (puede ser un array)
            string[] primaryKeyColumns = ObtenerColumnasClavePrimaria(nombreTabla);

            // Construye la parte de la cláusula WHERE
            string whereClause = string.Join(" AND ", primaryKeyColumns.Select(column => $"{column} = @{column}"));

            // Construye la consulta SQL
            string sql = $"UPDATE {nombreTabla} SET DVH = @DVH WHERE {whereClause}";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                // Agrega el parámetro DVH
                command.Parameters.AddWithValue("@DVH", dvhCalculado);

                // Agrega los parámetros de la clave primaria
                foreach (var column in primaryKeyColumns)
                {
                    command.Parameters.AddWithValue($"@{column}", registro[column]);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private string[] ObtenerColumnasClavePrimaria(string nombreTabla)
        {
            // Consulta SQL para obtener las columnas de la clave primaria de la tabla
            string sql = @"
                    SELECT COLUMN_NAME
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                    WHERE TABLE_NAME = @NombreTabla
                    AND CONSTRAINT_NAME = (
                        SELECT CONSTRAINT_NAME
                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                        WHERE TABLE_NAME = @NombreTabla
                        AND CONSTRAINT_TYPE = 'PRIMARY KEY'
                    )";

            // Lista para almacenar los nombres de las columnas de la clave primaria
            var columnasClavePrimaria = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                // Añadir el parámetro de la tabla
                command.Parameters.AddWithValue("@NombreTabla", nombreTabla);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    // Leer los resultados y añadir los nombres de las columnas a la lista
                    while (reader.Read())
                    {
                        columnasClavePrimaria.Add(reader["COLUMN_NAME"].ToString());
                    }
                }
            }

            // Convertir la lista a un array y devolver
            return columnasClavePrimaria.ToArray();
        }
        #endregion

    }
}

