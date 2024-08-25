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
                MessageBox.Show("La contraseña actual es incorrecta.");
                return;
            }

            // Verificar si la nueva contraseña coincide con la confirmación
            if (nuevaContraseña != confirmarContraseña)
            {
                limpiartxt();
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.");
                return;
            }

            // Verificar que la nueva contraseña no sea igual a la actual
            if (nuevaContraseña == contraseñaActualIngresada)
            {
                limpiartxt();
                MessageBox.Show("La nueva contraseña no puede ser igual a la actual.");
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
                MessageBox.Show("Contraseña modificada con éxito");
            }
            else
            {
                MessageBox.Show("Hubo un error al modificar la contraseña.");
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
