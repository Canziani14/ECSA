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
    public partial class UIInicio : Form
    {
        public UIInicio()
        {
            InitializeComponent();
        }

    

        private void GestionarEmpleados_Click(object sender, EventArgs e)
        {
            UIGestionarEmpleados uigestionarEmpleados = new UIGestionarEmpleados();
            uigestionarEmpleados.MdiParent = this;
            uigestionarEmpleados.Show();
        }

        private void btnGestionarUsuarios_Click_1(object sender, EventArgs e)
        {
            UIGestionarUsuarios uigestionarUsuarios = new UIGestionarUsuarios();
            uigestionarUsuarios.MdiParent = this;
            uigestionarUsuarios.Show();
        }

        private void btnBKP_Click(object sender, EventArgs e)
        {
            UIGestionarBackUp uiGestionarBackUp = new UIGestionarBackUp();
            uiGestionarBackUp.MdiParent = this;
            uiGestionarBackUp.Show();
        }

        private void btnGestionarLineas_Click(object sender, EventArgs e)
        {
            UIGestionarLinea uigestionarEmpleados = new UIGestionarLinea();
            uigestionarEmpleados.MdiParent = this;
            uigestionarEmpleados.Show();
        }

        private void btnGestionarServicios_Click(object sender, EventArgs e)
        {
            UIGestionarServicios uiGestionarServicios = new UIGestionarServicios();
            uiGestionarServicios.MdiParent = this;
            uiGestionarServicios.Show();
        }

        private void btnGestionarPatentes_Click(object sender, EventArgs e)
        {
            UIGestionarPatentes uiGestionarPatentes = new UIGestionarPatentes();
            uiGestionarPatentes.MdiParent = this;
            uiGestionarPatentes.Show();
        }

        private void btnGestionarFamilias_Click(object sender, EventArgs e)
        {
            UIGestionarFamilias uiGestionarFamilias = new UIGestionarFamilias();
            uiGestionarFamilias.MdiParent = this;
            uiGestionarFamilias.Show();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            UIAyuda uiAyuda = new UIAyuda();
            uiAyuda.MdiParent = this;
            uiAyuda.Show();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            UICambiarContraseña uiCambiarContraseña = new UICambiarContraseña();
            uiCambiarContraseña.MdiParent = this;
            uiCambiarContraseña.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            UIBitacora uIBitacora = new UIBitacora();
            uIBitacora.MdiParent = this;
            uIBitacora.Show();
        }

        private void btnAlertas_Click(object sender, EventArgs e)
        {
            UIAlertas uIAlertas = new UIAlertas();
            uIAlertas.MdiParent = this;
            uIAlertas.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            UIReportes uIReportes = new UIReportes();
            uIReportes.MdiParent = this;
            uIReportes.Show();
        }
    }
}
