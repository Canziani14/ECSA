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
    public partial class UICambiarContraseña : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private BE.Usuario usuarioLog;
        BLL.BLL_ABM_Usuario BLLUsuario = new BLL.BLL_ABM_Usuario();

        public UICambiarContraseña(BE.Usuario usuarioLog, List<Traduccion> traducciones)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLog;

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 36:
                        btnCambiarContra.Text = traduccion.Descripcion;
                        break;
                    case 128:
                        lblIngreseActual.Text = traduccion.Descripcion;
                        break;
                    case 130:
                        lblIngreseNueva.Text = traduccion.Descripcion;
                        break;
                    case 132:
                        lblConfirmarNueva.Text = traduccion.Descripcion;
                        break;          

                }
            }

            #endregion





        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            string contraseñaActualIngresada = txtContraseñaActual.Text;
            string nuevaContraseña = txtContraseñaNueva.Text;
            string confirmarContraseña = txtConfirmacionContraseñaNueva.Text;

            // Encriptar la contraseña actual ingresada para compararla con la almacenada
            string contraseñaActualEncriptada = BLLSeguridad.EncriptarCamposIrreversible(contraseñaActualIngresada);

            // Verificar si la contraseña actual es correcta
            if (usuarioLog.Contraseña != contraseñaActualEncriptada)
            {
                limpiartxt();
                string contraincespañol = "La contraseña actual es incorrecta.";
                string contraincingles = "The current password is incorrect.";
                if (lblIngreseActual.Text == "Enter Current Password")
                {
                    UINotificacion UINoti = new UINotificacion(contraincingles, 2)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálog
                }
                else
                {
                    UINotificacion UINoti = new UINotificacion(contraincespañol, 1)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálogo modal
                }

                
                return;
            }

            // Verificar si la nueva contraseña coincide con la confirmación
            if (nuevaContraseña != confirmarContraseña)
            {
                limpiartxt();
                string contraincespañol1 = "La nueva contraseña y la confirmación no coinciden.";
                string contraincingles1 = "The new password and the confirmation do not match.";
                if (lblIngreseActual.Text == "Enter Current Password")
                {
                    UINotificacion UINoti = new UINotificacion(contraincingles1, 2)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálog
                }
                else
                {
                    UINotificacion UINoti = new UINotificacion(contraincespañol1, 1)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálogo modal
                }
                
                return;
            }

            // Verificar que la nueva contraseña no sea igual a la actual
            if (nuevaContraseña == contraseñaActualIngresada)
            {
                limpiartxt();
                string contraincespañol2 = "La nueva contraseña no puede ser igual a la actual.";
                string contraincingles2 = "The new password cannot be the same as the current one.";
                if (lblIngreseActual.Text == "Enter Current Password")
                {
                    UINotificacion UINoti = new UINotificacion(contraincingles2, 2)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálog
                }
                else
                {
                    UINotificacion UINoti = new UINotificacion(contraincespañol2, 1)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálogo modal
                }

               
                return;
            }

            // Encriptar la nueva contraseña antes de almacenarla
            string nuevaContraseñaEncriptada = BLLSeguridad.EncriptarCamposIrreversible(nuevaContraseña);

            // Actualizar la contraseña en la base de datos
            bool actualizacionExitosa = BLLUsuario.CambiarContraseña(usuarioLog.ID_Usuario, nuevaContraseñaEncriptada);

            if (actualizacionExitosa)
            {
                BLLSeguridad.RegistrarEnBitacora(30, usuarioLog.Nick, usuarioLog.ID_Usuario);
                limpiartxt();
                string contraincespañol3 = "Contraseña modificada con éxito.";
                string contraincingles3 = "Password changed successfully.";
                if (lblIngreseActual.Text == "Enter Current Password")
                {
                    UINotificacion UINoti = new UINotificacion(contraincingles3, 2)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálog
                }
                else
                {
                    UINotificacion UINoti = new UINotificacion(contraincespañol3, 1)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálogo modal
                }
             
            }
            else
            {
                string contraincespañol4 = "Hubo un error al modificar la contraseña.";
                string contraincingles4 = "There was an error changing the password.";
                if (lblIngreseActual.Text == "Enter Current Password")
                {
                    UINotificacion UINoti = new UINotificacion(contraincingles4, 2)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálog
                }
                else
                {
                    UINotificacion UINoti = new UINotificacion(contraincespañol4, 1)
                    {
                        StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                        TopMost = true // Siempre visible encima de otras ventanas
                    };
                    UINoti.ShowDialog(); // Mostrar como diálogo modal
                }
               
            }
        }


        private void limpiartxt()
        {
            txtContraseñaActual.Clear();
            txtContraseñaNueva.Clear();
            txtConfirmacionContraseñaNueva.Clear();
        }


    }
}
