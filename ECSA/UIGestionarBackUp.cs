using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECSA
{
    public partial class UIGestionarBackUp : Form
    {
        private BE.Usuario usuarioLog;
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BLL.BLLDAL BLLDAL = new BLL.BLLDAL();
        

        public UIGestionarBackUp(BE.Usuario usuarioLog, List<Traduccion> traducciones)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLog;

            #region idioma
            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 46:
                        btnBKP.Text = traduccion.Descripcion;
                        break;
                    case 48:
                        btnRestore.Text = traduccion.Descripcion;
                        break;
                    
                }
            }
            #endregion



        }

        private void btnBKP_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SQL Backup files (*.bak)|*.bak";
                saveFileDialog.Title = "Guardar Respaldo de Base de Datos";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupPath = saveFileDialog.FileName;
                    try
                    {
                        BLLDAL.RealizarBKP(backupPath);


                        string pdfEspañol = "Backup realizado con éxito.";
                        string pdfIngles = "Backup performed successfully.";
                        if (btnBKP.Text == "Perform Backup")
                        {
                            UINotificacion UINoti = new UINotificacion(pdfIngles, 2)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálog
                        }
                        else
                        {
                            UINotificacion UINoti = new UINotificacion(pdfEspañol, 1)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálogo modal
                        }
                    
                        BLLSeguridad.RegistrarEnBitacora(35, usuarioLog.Nick, usuarioLog.ID_Usuario);
                    }
                    catch (Exception ex)
                    {
                        string pdfEspañol1 = "Error al realizar el backup: " + ex.Message;
                        string pdfIngles1 = "Error while performing backup: " + ex.Message;
                        if (btnBKP.Text == "Perform Backup")
                        {
                            UINotificacion UINoti = new UINotificacion(pdfIngles1, 2)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálog
                        }
                        else
                        {
                            UINotificacion UINoti = new UINotificacion(pdfEspañol1, 1)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálogo modal
                        }
                        MessageBox.Show("Error al realizar el backup: " + ex.Message);
                    }
                }
                

            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Backup files (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar Archivo de Respaldo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupPath = openFileDialog.FileName;
                    BLLDAL.RealizarRestore(backupPath);
                }
            }
          
            BLLSeguridad.RegistrarEnBitacora(36, usuarioLog.Nick, usuarioLog.ID_Usuario);
        }
    }
}
