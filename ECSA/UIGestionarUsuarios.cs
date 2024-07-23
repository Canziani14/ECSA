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

namespace ECSA
{
    public partial class UIGestionarUsuarios : Form
    {

        BE.Usuario BEUsuario = new BE.Usuario();
        BE.Usuario UsuarioSeleccionado = new BE.Usuario();
        BLL.BLL_ABM_Usuario BLLUsuario = new BLL.BLL_ABM_Usuario();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private BE.Usuario usuarioLog;
        public UIGestionarUsuarios(BE.Usuario usuarioLog)
        {
            this.usuarioLog = usuarioLog;
            InitializeComponent();
            dtgUsuarios.DataSource = BLLUsuario.Listar();

        }


        #region EliminarUsuario
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este usuario?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (UsuarioSeleccionado != null)
                {
                    bool UsuarioEliminado = BLLUsuario.Eliminar(UsuarioSeleccionado);

                    try
                    {
                        if (UsuarioEliminado)
                        {
                            BLLSeguridad.RegistrarEnBitacora(7, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede borrar el usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar el usuario: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para borrar");
                }
            }
        }
        #endregion


        #region CrearUsuario
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            
              if (txtNombre.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos");
                    return;
                }

                try
                {

                    BEUsuario.Nombre = BLLSeguridad.EncriptarCamposReversible(txtNombre.Text);
                    BEUsuario.Apellido = BLLSeguridad.EncriptarCamposReversible(txtApellido.Text);
                    BEUsuario.Nick= BLLSeguridad.EncriptarCamposReversible(txtNick.Text);
                    BEUsuario.Mail = BLLSeguridad.EncriptarCamposReversible(txtMail.Text);
                    BEUsuario.DNI= BLLSeguridad.EncriptarCamposReversible(txtDNI.Text);

                    int longitudClave = 12; // Puedes cambiar la longitud de la clave aquí
                    string claveGenerada = BLLSeguridad.GenerarClave(longitudClave);
                    Console.WriteLine($"Clave generada: {claveGenerada}");
                    BLLSeguridad.GuardarClaveEnArchivo(claveGenerada);
                    BEUsuario.Contraseña = BLLSeguridad.EncriptarCamposIrreversible(claveGenerada);





                if (BLLUsuario.Crear(BEUsuario))
                    {
                    BLLSeguridad.RegistrarEnBitacora(5, usuarioLog.Nick, usuarioLog.ID_Usuario);
                    MessageBox.Show("Usuario creado con éxito");
                        CalcularDigitos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el Usuario");
                    }

                    limpiarGrilla();
                    limpiartxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }            
        }

        #endregion


        #region ModificarUsuario

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (UsuarioSeleccionado != null)
            {
                try
                {
                    if (BLLUsuario.Modificar(new BE.Usuario()
                    {
                        Nombre = BLLSeguridad.EncriptarCamposReversible(txtNombre.Text),
                        Apellido = BLLSeguridad.EncriptarCamposReversible(txtApellido.Text),
                        DNI = BLLSeguridad.EncriptarCamposReversible(txtDNI.Text),
                        Mail = BLLSeguridad.EncriptarCamposReversible(txtMail.Text),
                        Nick= BLLSeguridad.EncriptarCamposReversible(txtNick.Text),
                        ID_Usuario= int.Parse(txtIDUsuario.Text),
                    }
            ))
                    {
                        BLLSeguridad.RegistrarEnBitacora(6, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Usuario modificado con exito");
                        CalcularDigitos();
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el Usuario");
                    }

                }
                catch (FormatException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Usuario para modificar");
            }
        }
           

        #endregion


        #region BuscarUsuario
        private void btnBuscarUsuario_Click(object sender, EventArgs e)
            {
                MessageBox.Show("No se encontro el usuario");
            }

        #endregion


        #region Bloquear y Desbloquear Usuario
        private void btnBloquearUsuario_Click(object sender, EventArgs e)
            {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de bloquear este usuario?", "Confirmación de bloqueo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (UsuarioSeleccionado != null)
                {
                    bool Usuariobloqueado = BLLUsuario.BloquearUsuario(UsuarioSeleccionado.ID_Usuario);

                    try
                    {
                        if (Usuariobloqueado)
                        {
                            BLLSeguridad.RegistrarEnBitacora(8, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            MessageBox.Show("Usuario bloqueado");
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede bloquear el usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al bloquear el usuario: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para bloquear");
                }
            }           
        }

            private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
            {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de desbloquear este usuario?", "Confirmación de desbloqueo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (UsuarioSeleccionado != null)
                {
                    bool Usuariobloqueado = BLLUsuario.DesbloquearUsuario(UsuarioSeleccionado.ID_Usuario);

                    try
                    {
                        if (Usuariobloqueado)
                        {
                            BLLSeguridad.RegistrarEnBitacora(9, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            MessageBox.Show("Usuario desbloqueado");
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede desbloquear el usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al desbloquear el usuario: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para desbloquear");
                }
            }
        }
        #endregion


        #region FuncionesVarias
            private void limpiarGrilla()
            {
                dtgUsuarios.DataSource = null;
                dtgUsuarios.DataSource = BLLUsuario.Listar();
            }

            private void limpiartxt()
            {
                txtDNI.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtNick.Clear();
                txtMail.Clear();
                txtIDUsuario.Clear();         
            }

            public void CalcularDigitos()
            {
                string tabla = "Usuario";
                BLLSeguridad.VerificarDigitosVerificadores(tabla);
                BLLSeguridad.CalcularDVV(tabla);
            }
        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerUsuarioSeleccionado();
        }

        public BE.Usuario ObtenerUsuarioSeleccionado()
        {
            if (dtgUsuarios.SelectedRows.Count > 0)
            {
                UsuarioSeleccionado = ((BE.Usuario)dtgUsuarios.SelectedRows[0].DataBoundItem);
                this.ComlpetarUsuario(UsuarioSeleccionado);
            }

            return UsuarioSeleccionado;
        }

        public void ComlpetarUsuario(BE.Usuario usuario)
        {
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtMail.Text = usuario.Mail;
            txtNick.Text = usuario.Nick;
            txtDNI.Text = usuario.DNI;
            txtIDUsuario.Text = usuario.ID_Usuario.ToString();
        }

    }

            
    #endregion



}

