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
        public UICambiarContraseña()
        {
            InitializeComponent();
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña modificada con éxito");
        }
    }
}
