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
    public partial class UIGestionarCoches : Form
    {
        BLL.BLL_ABM_Coche BLLCoche = new BLL.BLL_ABM_Coche();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        public UIGestionarCoches()
        {
            InitializeComponent();
            dtgCoches.DataSource= BLLCoche.Listar();
        }

        private void btnCrearCoche_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coche creado con exito");
        }

        private void btnEliminarCoche_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este coche?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Coche eliminado con exito");
            }
        }

        private void btnBuscarCoche_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se encontro el coche");
        }
    }
}
