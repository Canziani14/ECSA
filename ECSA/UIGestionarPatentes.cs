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
        public UIGestionarPatentes()
        {
            InitializeComponent();
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
            MessageBox.Show("No se encontro el usuario");
        }
    }
}
