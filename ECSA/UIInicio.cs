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
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();

        private BE.Usuario usuarioLogin;
        private List<Patente> _patentes;
        private List<Traduccion> _traducciones;
        private int _idIdiomaSeleccionado;
        public UIInicio(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones, int idIdiomaSeleccionado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarioLogin = usuarioLog;
            BLLSeguridad.VerificarDigitosVerificadores("Usuario");
            BLLSeguridad.CalcularDVV("Usuario");
            _idIdiomaSeleccionado = idIdiomaSeleccionado;

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 12:
                        btnGestionarEmpleados.Text = traduccion.Descripcion;
                        break;
                    case 10:
                        btnGestionarUsuarios.Text = traduccion.Descripcion;
                        break;
                    case 18:
                        btnBKP.Text = traduccion.Descripcion;
                        break;
                    case 14:
                        btnGestionarLineas.Text = traduccion.Descripcion;
                        break;
                    case 20:
                        btnGestionarPatentes.Text = traduccion.Descripcion;
                        break;
                    case 22:
                        btnGestionarFamilias.Text = traduccion.Descripcion;
                        break;
                    case 24:
                        btnReportes.Text = traduccion.Descripcion;
                        break;
                    case 30:
                        btnAlertas.Text = traduccion.Descripcion;
                        break;
                    case 32:
                        btnBitacora.Text = traduccion.Descripcion;
                        break;
                    case 38:
                        btnAyuda.Text = traduccion.Descripcion;
                        break;
                    case 34:
                        btnCerrarSesion.Text = traduccion.Descripcion;
                        break;
                    case 36:
                        btnCambiarContra.Text = traduccion.Descripcion;
                        break;

                }
                _traducciones = traducciones;
            }

            #endregion

            #region patentes
            btnGestionarEmpleados.Enabled = false;
            btnGestionarUsuarios.Enabled = false;
            btnBKP.Enabled = false;
            btnGestionarLineas.Enabled = false;
            btnGestionarPatentes.Enabled = false;
            btnGestionarFamilias.Enabled = false;
            btnReportes.Enabled = false;
            btnAlertas.Enabled = false;
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
            #endregion

            this.KeyPreview = true; // Permite que el formulario capture teclas
            this.KeyDown += new KeyEventHandler(F1);

            #region alerta
            Timer timer = new Timer();
            bool isRed = false;

            // Configura el temporizador
            timer.Interval = 500; // Intervalo en milisegundos (500ms = 0.5s)
            timer.Tick += (s, e) =>
            {
                // Alterna el color del botón
                if (isRed)
                {
                    btnAlertas.BackColor = Color.Red;
                }
                else
                {
                    btnAlertas.BackColor = SystemColors.Control;
                }

                // Cambia el estado del color
                isRed = !isRed;
            };

            // Inicia el temporizador
            timer.Start();
            btnAlertas.Click += (s, e) =>
            {
                // Detiene el temporizador cuando se hace clic
                timer.Stop();

                // Restablece el color del botón
                btnAlertas.BackColor = SystemColors.Control;
            };
            #endregion

        }





        private void F1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Acción a realizar cuando se presiona la tecla Enter
                UIAyuda uIAyuda = new UIAyuda();
                uIAyuda.MdiParent = this;
                uIAyuda.Show();
            }
        }




        private void GestionarEmpleados_Click(object sender, EventArgs e)
        {
            UIGestionarEmpleados uigestionarEmpleados = new UIGestionarEmpleados(usuarioLogin, _patentes, _traducciones);
            uigestionarEmpleados.MdiParent = this;
            uigestionarEmpleados.Show();
        }

        private void btnGestionarUsuarios_Click_1(object sender, EventArgs e)
        {
            UIGestionarUsuarios uigestionarUsuarios = new UIGestionarUsuarios(usuarioLogin, _patentes, _traducciones, _idIdiomaSeleccionado);
            uigestionarUsuarios.MdiParent = this;
            uigestionarUsuarios.Show();
        }

        private void btnBKP_Click(object sender, EventArgs e)
        {
            UIGestionarBackUp uiGestionarBackUp = new UIGestionarBackUp(usuarioLogin, _traducciones);
            uiGestionarBackUp.MdiParent = this;
            uiGestionarBackUp.Show();
        }

        private void btnGestionarLineas_Click(object sender, EventArgs e)
        {
            UIGestionarLinea uigestionarEmpleados = new UIGestionarLinea(usuarioLogin, _patentes, _traducciones);
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
            UIGestionarPatentes uiGestionarPatentes = new UIGestionarPatentes(usuarioLogin, _patentes, _traducciones, _idIdiomaSeleccionado);
            uiGestionarPatentes.MdiParent = this;
            uiGestionarPatentes.Show();
        }

        private void btnGestionarFamilias_Click(object sender, EventArgs e)
        {
            UIGestionarFamilias uiGestionarFamilias = new UIGestionarFamilias(usuarioLogin, _patentes, _traducciones, _idIdiomaSeleccionado);
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
            UICambiarContraseña uiCambiarContraseña = new UICambiarContraseña(usuarioLogin, _traducciones);
            uiCambiarContraseña.MdiParent = this;
            uiCambiarContraseña.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            UIBitacora uIBitacora = new UIBitacora(_traducciones);
            uIBitacora.MdiParent = this;
            uIBitacora.Show();
        }

        private void btnAlertas_Click(object sender, EventArgs e)
        {
            UIAlertas uIAlertas = new UIAlertas(_traducciones);
            uIAlertas.MdiParent = this;
            uIAlertas.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            UIReportes uIReportes = new UIReportes(_traducciones);
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
