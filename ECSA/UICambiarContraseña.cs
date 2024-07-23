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
    public partial class UICambiarContraseña : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private BE.Usuario usuarioLog;

        public UICambiarContraseña(BE.Usuario usuarioLog)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLog;
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            BLLSeguridad.RegistrarEnBitacora(30, usuarioLog.Nick, usuarioLog.ID_Usuario);
            MessageBox.Show("Contraseña modificada con éxito");
        }
    }
}
