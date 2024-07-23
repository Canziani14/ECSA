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
    public partial class UIGestionarBackUp : Form
    {
        private BE.Usuario usuarioLog;
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();

        public UIGestionarBackUp(BE.Usuario usuarioLog)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLog;
        }

        private void btnBKP_Click(object sender, EventArgs e)
        {
            BLLSeguridad.RegistrarEnBitacora(35, usuarioLog.Nick, usuarioLog.ID_Usuario);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            BLLSeguridad.RegistrarEnBitacora(36, usuarioLog.Nick, usuarioLog.ID_Usuario);
        }
    }
}
