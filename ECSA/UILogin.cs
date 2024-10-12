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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ECSA
{
    public partial class UILogin : Form 
    {
        public UILogin()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LlenarComboBoxInternos(cmbIdiomas);
            txtContraseña.PasswordChar = '*';
        }
        BLL.BLL_ABM_Usuario BLLUsuario= new BLL.BLL_ABM_Usuario();
        BLL.BLLSeguridad BLLSeguridad = new BLLSeguridad();
        BE.Idioma BEIdioma = new BE.Idioma();
        BLL.BLLIdioma BLLIdioma = new BLLIdioma();
        BLL.BLLDAL BLLDAL = new BLLDAL();


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
        string nick =txtUsuario.Text;
        string contraseña = BLLSeguridad.EncriptarCamposIrreversible(txtContraseña.Text);

        BE.Usuario UsuarioLog =BLLUsuario.BuscarNick(nick);

        List<BE.Usuario> ContraseñaBuscada = BLLUsuario.BuscarContraseña(contraseña);

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Complete todos los campos, por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UsuarioLog.Estado)
                {
                    if (UsuarioLog == null || UsuarioLog.Nick == null)
                    {
                        MessageBox.Show("Error al ingresar. Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Clear();
                        txtContraseña.Clear();
                        txtUsuario.Focus();
                    }
                    else
                    {
                        if (ContraseñaBuscada.Count > 0)
                        {

                            BLLUsuario.ContadorIngresos0(UsuarioLog);
                            BLLSeguridad.RegistrarEnBitacora(1, UsuarioLog.Nick, UsuarioLog.ID_Usuario);
                            MessageBox.Show("Login exitoso. ¡Bienvenido " + UsuarioLog.Nick + "!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Verificar integridad
                            bool integridadCorrecta = BLLDAL.VerificarIntegridad();
                            BLLSeguridad.RegistrarEnBitacora(33, UsuarioLog.Nick, UsuarioLog.ID_Usuario);

                            if (!integridadCorrecta)
                            {
                                MessageBox.Show("Error en la Integridad de los datos");

                                // Si la integridad no es correcta, reparar
                                BLLDAL.RepararIntegridad();
                                BLLSeguridad.RegistrarEnBitacora(34, UsuarioLog.Nick, UsuarioLog.ID_Usuario);
                                // Mensaje después de reparar
                                MessageBox.Show("La integridad de los datos fue reparada.", "Reparación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            // Obtener las patentes del usuario
                            var iterator = BLLUsuario.ObtenerPatentesPorUsuario(UsuarioLog.ID_Usuario.ToString());
                            var patentes = new List<Patente>();

                            while (iterator.HasNext())
                            {
                                patentes.Add(iterator.GetNext());
                            }
                            //Idioma
                            int idIdiomaSeleccionado = (int)cmbIdiomas.SelectedValue;
                            List<Traduccion> traducciones = BLLUsuario.ListarTraduccionesXIdioma(idIdiomaSeleccionado);

                            // Crear instancia de la ventana principal con patentes
                            UIInicio uiInicio = new UIInicio(UsuarioLog, patentes, traducciones, idIdiomaSeleccionado);

                            // Mostrar la ventana principal
                            uiInicio.Show();
                            this.Hide();
                        }
                        else
                        {
                            int intentosFallidos = BLLUsuario.SumarIntento(UsuarioLog);

                            if (intentosFallidos >= 3)
                            {
                                BLLSeguridad.RegistrarEnBitacora(3, UsuarioLog.Nick, UsuarioLog.ID_Usuario);
                                BLLUsuario.BloquearUsuario(UsuarioLog.ID_Usuario);
                                MessageBox.Show("Cuenta bloqueada después de 3 intentos fallidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                BLLSeguridad.RegistrarEnBitacora(2, UsuarioLog.Nick, UsuarioLog.ID_Usuario);
                                MessageBox.Show("Contraseña incorrecta. Intento " + intentosFallidos + " de 3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtContraseña.Clear();
                                txtContraseña.Focus();
                            }
                        }
                    }

                }
                else
                {
                    BLLSeguridad.RegistrarEnBitacora(4, UsuarioLog.Nick, UsuarioLog.ID_Usuario);
                    MessageBox.Show("No puede iniciar sesion. " + UsuarioLog.Nick + " bloqueado");
                }
            }



            

            



        }

        private void btnGenerarNuevaClave_Click(object sender, EventArgs e)
        {
            int idIdiomaSeleccionado = (int)cmbIdiomas.SelectedValue;
            List<Traduccion> traducciones = BLLUsuario.ListarTraduccionesXIdioma(idIdiomaSeleccionado);

            UIGenerarNuevaContra uIGenerarNuevaContra = new UIGenerarNuevaContra(traducciones);
        uIGenerarNuevaContra.Show();
        }




        private void LlenarComboBoxInternos(ComboBox comboBox)
        {
            try
            {
                var idiomas = BLLIdioma.Listar();
                comboBox.DataSource = null; // Limpiar cualquier DataSource anterior
                comboBox.Items.Clear(); // Limpiar elementos anteriores
                comboBox.DataSource = idiomas; // Establecer nuevo DataSource
                comboBox.DisplayMember = "Descripcion"; // La propiedad que quieres mostrar
                comboBox.ValueMember = "ID_Idioma"; // La propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
