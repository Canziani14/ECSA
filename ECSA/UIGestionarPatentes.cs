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
    public partial class UIGestionarPatentes : Form
    {
        BE.Usuario BEUsuario = new BE.Usuario();
        BE.Usuario UsuarioSeleccionado = new BE.Usuario();
        BLL.BLL_ABM_Usuario BLLUsuario = new BLL.BLL_ABM_Usuario();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private BE.Usuario usuarioLog;
        BLL.BLLPatente BLLPatente = new BLL.BLLPatente();
        public UIGestionarPatentes(BE.Usuario usuarioLogin)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLogin;
            dtgUsuarios.DataSource = BLLUsuario.Listar();
        }

        private void btnAsignarPatente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patente asignada correctamente");
        }

        private void btnQuitarPatente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patente quitada correctamente");
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string nick = txtBuscarUsuario.Text;
            string nickEncriptado = BLLSeguridad.EncriptarCamposReversible(nick);
            if (!string.IsNullOrEmpty(nick))
            {
                // Perform the search using the parsed legajo
                List<BE.Usuario> usuarios = BLLUsuario.Buscar(nickEncriptado);


                if (usuarios != null && usuarios.Count > 0)
                {
                    dtgUsuarios.DataSource = usuarios;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                    dtgUsuarios.DataSource = usuarios;
                }
            }
            else
            {
                // Show error message if the input is not a valid integer
                MessageBox.Show("Por favor, ingrese un Nick válido.");
                dtgUsuarios.DataSource = null;
            }
        }









        public BE.Usuario ObtenerUsuarioSeleccionado()
        {
            if (dtgUsuarios.SelectedRows.Count > 0)
            {
                UsuarioSeleccionado = ((BE.Usuario)dtgUsuarios.SelectedRows[0].DataBoundItem);
            }

            return UsuarioSeleccionado;
        }

        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerUsuarioSeleccionado();
            int id_Usuario=UsuarioSeleccionado.ID_Usuario;
            dtgPatentesActuales.DataSource = BLLPatente.ListarActuales(id_Usuario);
            dtgPatentesSinAsignar.DataSource = BLLPatente.ListarSinAsignar(id_Usuario);
            
        }


    }
}
