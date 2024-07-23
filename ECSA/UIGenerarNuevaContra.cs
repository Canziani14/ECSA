using BLL;
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
    public partial class UIGenerarNuevaContra : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BE.Usuario usuarioLog = new BE.Usuario();
        public UIGenerarNuevaContra()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            BLLSeguridad.RegistrarEnBitacora(31, usuarioLog.Nick, usuarioLog.ID_Usuario);
        }
    }
}
