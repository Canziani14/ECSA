using BE;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        string queryBKP = "BACKUP DATABASE [ECSA] " +
            "TO DISK = @backupPath "+
            "WITH FORMAT, INIT, NAME = 'Full Backup of ECSA';";
        string queryRestore = 
        "USE ECSA; "+
        "ALTER DATABASE ECSA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;"+
        "RESTORE DATABASE ECSA FROM DISK = @backupPath WITH REPLACE;" +
        "ALTER DATABASE ECSA SET MULTI_USER;";


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

    }
}
