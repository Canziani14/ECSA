using BE;
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
using static iTextSharp.text.pdf.hyphenation.TernaryTree;

namespace ECSA
{
    public partial class UIInicio : Form
    {
        BLL.BLLSeguridad BLLSeguridad= new BLL.BLLSeguridad();

        private BE.Usuario usuarioLogin;
        private List<Patente> _patentes;
        public UIInicio(BE.Usuario usuarioLog, List<Patente> patentes)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarioLogin = usuarioLog;
            BLLSeguridad.VerificarDigitosVerificadores("Usuario");
            BLLSeguridad.CalcularDVV("Usuario");

            btnGestionarEmpleados.Enabled = false;
            btnGestionarUsuarios.Enabled = false;
            btnBKP.Enabled = false;
            btnGestionarLineas.Enabled = false;
            btnGestionarPatentes.Enabled = false;
            btnGestionarFamilias.Enabled = false;
            btnReportes.Enabled = false;
            btnAlertas.Enabled  = false;
            btnBitacora.Enabled = false;

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 36:
                        btnGestionarEmpleados.Enabled = true;
                        break;
                    case 35:
                        btnGestionarUsuarios.Enabled = true;
                        break;
                    case 37:
                        btnBKP.Enabled = true;
                        break;
                    case 38:
                        btnGestionarLineas.Enabled = true;
                        break;
                    case 41:
                        btnGestionarPatentes.Enabled = true;
                        break;
                    case 42:
                        btnGestionarFamilias.Enabled = true;
                        break;
                    case 43:
                        btnReportes.Enabled = true;
                        break;
                    case 45:
                        btnAlertas.Enabled = true;
                        break;
                    case 44:
                        btnBitacora.Enabled = true;
                        break;
                }

            }
            _patentes = patentes;
        }



        private void GestionarEmpleados_Click(object sender, EventArgs e)
        {
            UIGestionarEmpleados uigestionarEmpleados = new UIGestionarEmpleados(usuarioLogin, _patentes);
            uigestionarEmpleados.MdiParent = this;
            uigestionarEmpleados.Show();
        }

        private void btnGestionarUsuarios_Click_1(object sender, EventArgs e)
        {
            UIGestionarUsuarios uigestionarUsuarios = new UIGestionarUsuarios(usuarioLogin, _patentes);
            uigestionarUsuarios.MdiParent = this;
            uigestionarUsuarios.Show();
        }

        private void btnBKP_Click(object sender, EventArgs e)
        {
            UIGestionarBackUp uiGestionarBackUp = new UIGestionarBackUp(usuarioLogin);
            uiGestionarBackUp.MdiParent = this;
            uiGestionarBackUp.Show();
        }

        private void btnGestionarLineas_Click(object sender, EventArgs e)
        {
            UIGestionarLinea uigestionarEmpleados = new UIGestionarLinea(usuarioLogin, _patentes);
            uigestionarEmpleados.MdiParent = this;
            uigestionarEmpleados.Show();
        }

     /*   private void btnGestionarServicios_Click(object sender, EventArgs e)
        {
            UIGestionarServicios uiGestionarServicios = new UIGestionarServicios();
            uiGestionarServicios.MdiParent = this;
            uiGestionarServicios.Show();
        }*/

        private void btnGestionarPatentes_Click(object sender, EventArgs e)
        {
            UIGestionarPatentes uiGestionarPatentes = new UIGestionarPatentes(usuarioLogin, _patentes);
            uiGestionarPatentes.MdiParent = this;
            uiGestionarPatentes.Show();
        }

        private void btnGestionarFamilias_Click(object sender, EventArgs e)
        {
            UIGestionarFamilias uiGestionarFamilias = new UIGestionarFamilias(usuarioLogin, _patentes);
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
            UICambiarContraseña uiCambiarContraseña = new UICambiarContraseña(usuarioLogin);
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

        private void UIInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            BLLSeguridad.RegistrarEnBitacora(29, usuarioLogin.Nick, usuarioLogin.ID_Usuario);
            this.Close();
            // Abrir la ventana de inicio de sesión en un nuevo hilo
            System.Threading.Thread newThread = new System.Threading.Thread(OpenLoginForm);
            newThread.SetApartmentState(System.Threading.ApartmentState.STA);
            newThread.Start();
        }

        private void OpenLoginForm()
        {
            Application.Run(new UILogin());
        }



        #region habilitarBotones

        public void HabilitarGestionarEmpleados()
        {
            btnGestionarEmpleados.Enabled = true;
        }

        public void HabilitarGestionarUsuarios()
        {
            btnGestionarUsuarios.Enabled = true;
        }

        public void HabilitarBKP()
        {
            btnBKP.Enabled = true;
        }

        public void HabilitarGestionarLineas()
        {
            btnGestionarLineas.Enabled = true;
        }

        public void HabilitarGestionarPatentes()
        {
            btnGestionarPatentes.Enabled = true;
        }

        public void HabilitarGestionarFamilias()
        {
            btnGestionarFamilias.Enabled = true;
        }

        public void HabilitarReportes()
        {
            btnReportes.Enabled = true;
        }

        public void HabilitarAlertas()
        {
            btnAlertas.Enabled = true;
        }

        public void HabilitarBitacora()
        {
            btnBitacora.Enabled = true;
        }

        #endregion

    }

}
