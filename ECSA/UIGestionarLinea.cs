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
    }
}
