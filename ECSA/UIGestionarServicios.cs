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
    public partial class UIGestionarServicios : Form
    {
        public UIGestionarServicios()
        {
            InitializeComponent();
        }

        private void btnCrearServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se creo el servicio correctamente");
        }

        private void btnModificarServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se modifico el servicio correctamente");
        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se elimino el servicio correctamente");
        }

        private void btnAsignarServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se asigno interno y el conductor correctamente al servicio");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se envio la planilla a la cola de impresion");
        }
    }
}
