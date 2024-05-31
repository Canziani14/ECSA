using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ECSA
{
    public partial class UILogin : Form
    {
        public UILogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGenerarNuevaClave_Click(object sender, EventArgs e)
        {
            UIGenerarNuevaContra uIGenerarNuevaContra = new UIGenerarNuevaContra();
            uIGenerarNuevaContra.MdiParent = this;
            uIGenerarNuevaContra.Show();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            if (usuario == "canziani14" && contraseña == "123")
            {
                MessageBox.Show("Login exitoso. ¡Bienvenido " + usuario + "!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UIInicio uiInicio = new UIInicio();
                uiInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al ingresar");
                txtUsuario.Clear();
                txtContraseña.Clear();
                txtUsuario.Focus();
            }

            
        }
    }
}
