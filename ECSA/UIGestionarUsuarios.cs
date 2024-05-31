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
    public partial class UIGestionarUsuarios : Form
    {
        public UIGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void GestionarUsuarios_Load(object sender, EventArgs e)
        {
            

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este usuario?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta ==DialogResult.Yes)
            {
                MessageBox.Show("Usuario eliminado con exito");
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            
                MessageBox.Show("Usuario creado con exito");
           
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario modificado con exito");
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se encontro el usuario");
        }

        private void btnBloquearUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario bloqueado");
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario desbloqueado");
        }
    }
}
