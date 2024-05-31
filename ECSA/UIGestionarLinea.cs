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
    public partial class UIGestionarLinea : Form
    {
        public UIGestionarLinea()
        {
            InitializeComponent();
        }

        private void btnGestionarCoches_Click(object sender, EventArgs e)
        {
            UIGestionarCoches uiGestionarCoches = new UIGestionarCoches();
            uiGestionarCoches.MdiParent = this.MdiParent;
            uiGestionarCoches.Show();
        }

        private void btnCrearLinea_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Linea creada con exito");
        }

        private void btnModificarLinea_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Linea modificada con exito");
        }

        private void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar esta linea?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("linea eliminada con exito");
            }
        }
    }
}
