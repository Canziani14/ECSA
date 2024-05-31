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
    public partial class UIGestionarFamilias : Form
    {
        public UIGestionarFamilias()
        {
            InitializeComponent();
        }

        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Familia creada con éxito");
        }

        private void btnModificarFamilia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Familia modificada con éxito");
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar esta familia?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Familia eliminada con éxito");
            }
            
        }
    }
}
