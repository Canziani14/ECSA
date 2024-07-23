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
    public partial class UIBitacora : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        public UIBitacora()
        {
            InitializeComponent();
           dtgBitacora.DataSource= BLLSeguridad.Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnDescargarBitacora_Click(object sender, EventArgs e)
        {

        }
    }
}
