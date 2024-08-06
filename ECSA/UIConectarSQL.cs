using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ECSA
{
    public partial class UIConectarSQL : Form
    {
        public UIConectarSQL()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAbrirArchivoSQL_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar un archivo de texto";

                DialogResult result = openFileDialog.ShowDialog();
                

                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    

                    try
                    {
                        string connectionString;
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            connectionString = reader.ReadToEnd().Trim();
                        }

                        

                        if (TestDatabaseConnection(connectionString))
                        {
                            UpdateConnectionString(connectionString);
                            MessageBox.Show("Connection string actualizada correctamente.");

                            this.DialogResult = DialogResult.OK;
                            
                            UILogin uilogin = new UILogin();
                            uilogin.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("No se pudo conectar a la base de datos. Verifique el connection string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al leer el archivo o al intentar conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }


        private bool TestDatabaseConnection(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true; // Conexión exitosa
                }
            }
            catch
            {
                return false; // Error al conectar
            }
        }

        private void UpdateConnectionString(string connectionString)
        {
            // Obtener el archivo de configuración
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Obtener la sección de conexiones
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            // Actualizar el connection string
            if (connectionStringsSection.ConnectionStrings["DefaultConnection"] != null)
            {
                connectionStringsSection.ConnectionStrings["DefaultConnection"].ConnectionString = connectionString;
            }
            else
            {
                connectionStringsSection.ConnectionStrings.Add(new ConnectionStringSettings("DefaultConnection", connectionString));
            }

            // Guardar los cambios en el archivo de configuración
            config.Save(ConfigurationSaveMode.Modified);

            // Volver a cargar la configuración
            ConfigurationManager.RefreshSection("connectionStrings");
        }





    }

}
