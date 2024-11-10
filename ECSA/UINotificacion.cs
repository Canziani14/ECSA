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
    public partial class UINotificacion : Form
    {
        public UINotificacion(string mensaje, int idioma)
        {
            InitializeComponent();
            lblGeneral.Text= mensaje;
            if (idioma==2)
            {
                btnAceptar.Text = "Accept";
            } 
        }

        

      

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
