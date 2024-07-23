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
    public partial class UIAlertas : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        public UIAlertas()
        {
            InitializeComponent();
            dtgAlertas.DataSource = BLLSeguridad.ListarCrit3();
        }
    }
}
