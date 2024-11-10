using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        BLL.BLL_ABM_Familia BLLFamilia = new BLL.BLL_ABM_Familia();
        BE.Familia FamiliaSeleccionadaAsignar = new BE.Familia();
        BE.Familia FamiliaSeleccionadaQuitar = new BE.Familia();
        int _idiomaSeleccionado;

        public UIGestionarUsuarios(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones, int idiomaSeleccionado)
        {
            this.usuarioLog = usuarioLog;
            InitializeComponent();
            dtgUsuarios.DataSource = BLLUsuario.Listar();
            this._idiomaSeleccionado = idiomaSeleccionado;
            btnCrearUsuario.Enabled = false;
            btnModificarUsuario.Enabled = false;
            btnEliminarUsuario.Enabled = false;
            btnBloquearUsuario.Enabled = false;
            btnDesbloquearUsuario.Enabled = false;
            StartPosition = FormStartPosition.CenterScreen;
            dtgFamiliasSinAsignar.Enabled = false;
            dtgFamiliaActual.Enabled = false;


            #region idioma
            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 40:
                        btnBuscarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 2:
                        btnCrearUsuario.Text = traduccion.Descripcion;
                        break;
                    case 4:
                        btnModificarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 6:
                        btnEliminarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 8:
                        btnBloquearUsuario.Text = traduccion.Descripcion;
                        break;
                    case 10:
                        btnDesbloquearUsuario.Text = traduccion.Descripcion;
                        break;
                    case 70:
                        lblApellido.Text = traduccion.Descripcion;
                        dtgUsuarios.Columns["Apellido"].HeaderText = traduccion.Descripcion;
                        break;
                    case 72:
                        lblDNI.Text = traduccion.Descripcion;
                        dtgUsuarios.Columns["DNI"].HeaderText = traduccion.Descripcion;
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        dtgUsuarios.Columns["Nombre"].HeaderText = traduccion.Descripcion;
                        break;
                    case 66:
                        lblidUsuario.Text = traduccion.Descripcion;
                        break;
                    case 74:
                        lblNick.Text = traduccion.Descripcion;
                        dtgUsuarios.Columns["Nick"].HeaderText = traduccion.Descripcion;
                        break;
                    case 76:
                        lblMail.Text = traduccion.Descripcion;
                        break;
                    case 78:
                        gbGestorFamiliasPorUsuario.Text = traduccion.Descripcion;
                        break;
                    case 80:
                        lblAsignadas.Text = traduccion.Descripcion;
                        break;
                    case 82:
                        lblSinAsignar.Text = traduccion.Descripcion;
                        break;
                    case 64:
                        lblBuscarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 16:
                        gbGestorUsuarios.Text = traduccion.Descripcion;
                        break;
                    case 142:
                        btnRecuperarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        dtgUsuarios.Columns["ID_Usuario"].HeaderText = traduccion.Descripcion;
                        break;
                    case 148:
                        dtgUsuarios.Columns["Estado"].HeaderText = traduccion.Descripcion;
                        break;
                    case 149:
                        dtgUsuarios.Columns["Eliminado"].HeaderText = traduccion.Descripcion;
                        break;
                }
            }

            #endregion

            #region patente

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 23:
                        btnCrearUsuario.Enabled = true;
                        break;
                    case 24:
                        btnModificarUsuario.Enabled = true;
                        break;
                    case 25:
                        btnEliminarUsuario.Enabled = true;
                        break;
                    case 1:
                        btnBloquearUsuario.Enabled = true;
                        break;
                    case 2:
                        btnDesbloquearUsuario.Enabled = true;
                        break;
                    case 34:
                        dtgFamiliasSinAsignar.Enabled = true;
                        dtgFamiliaActual.Enabled = true;
                        break;
                }

            }
            #endregion




            #region Perzonalizacion DTG
            dtgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgUsuarios.Columns["Contraseña"].Visible = false;
            dtgUsuarios.Columns["CII"].Visible = false;
            dtgUsuarios.Columns["DVV"].Visible = false;

            dtgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgUsuarios.ReadOnly = true;
            dtgUsuarios.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgUsuarios.BorderStyle = BorderStyle.None;
            dtgUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgUsuarios.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgUsuarios.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgUsuarios.EnableHeadersVisualStyles = false;
            dtgUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgUsuarios.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgUsuarios.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgUsuarios.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgUsuarios.GridColor = Color.FromArgb(231, 231, 231);
            #endregion

            #region Perzonalizacion DTG

            dtgFamiliasSinAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgFamiliasSinAsignar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFamiliasSinAsignar.ReadOnly = true;
            dtgFamiliasSinAsignar.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgFamiliasSinAsignar.BorderStyle = BorderStyle.None;
            dtgFamiliasSinAsignar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgFamiliasSinAsignar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgFamiliasSinAsignar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgFamiliasSinAsignar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgFamiliasSinAsignar.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgFamiliasSinAsignar.EnableHeadersVisualStyles = false;
            dtgFamiliasSinAsignar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgFamiliasSinAsignar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgFamiliasSinAsignar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgFamiliasSinAsignar.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgFamiliasSinAsignar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgFamiliasSinAsignar.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgFamiliasSinAsignar.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgFamiliasSinAsignar.GridColor = Color.FromArgb(231, 231, 231);
            #endregion

            #region Perzonalizacion DTG

            dtgFamiliaActual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgFamiliaActual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFamiliaActual.ReadOnly = true;
            dtgFamiliaActual.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgFamiliaActual.BorderStyle = BorderStyle.None;
            dtgFamiliaActual.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgFamiliaActual.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgFamiliaActual.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgFamiliaActual.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgFamiliaActual.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgFamiliaActual.EnableHeadersVisualStyles = false;
            dtgFamiliaActual.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgFamiliaActual.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgFamiliaActual.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgFamiliaActual.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgFamiliaActual.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgFamiliaActual.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgFamiliaActual.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgFamiliaActual.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
        }


        #region EliminarUsuario
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Confirmación antes de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                if (UsuarioSeleccionado != null)
                {
                    try
                    {
                        // Verifica si el usuario seleccionado es el mismo que el usuario en sesión
                        if (UsuarioSeleccionado.ID_Usuario == usuarioLog.ID_Usuario)
                        {
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("Cannot delete user who is currently logged in", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("No se puede eliminar el usuario que está actualmente en sesión", 1);
                            }
                            MessageBox.Show(".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir del método si no se puede eliminar
                        }

                        // Validaciones para evitar la eliminación
                        bool tienePatenteUnica = BLLSeguridad.TienePatenteUnica(UsuarioSeleccionado.ID_Usuario);
                        bool tieneFamiliaConPatenteUnica = BLLSeguridad.TieneFamiliaConPatenteUnica(UsuarioSeleccionado.ID_Usuario);

                        if (tienePatenteUnica || tieneFamiliaConPatenteUnica)
                        {
                            string mensajeError = "El usuario " + UsuarioSeleccionado.Nick;

                            if (tienePatenteUnica)
                                mensajeError += " tiene asignada una patente única, no puede ser eliminado.";
                            else if (tieneFamiliaConPatenteUnica)
                                mensajeError += " tiene patentes asignadas a familias y no puede ser eliminado.";
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles(mensajeError, 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol(mensajeError, 1);
                            }
                            
                            return; // Salir del método si alguna de las condiciones impide la eliminación
                        }

                        // Si todas las condiciones son satisfechas, proceder a eliminar el usuario
                        bool usuarioEliminado = BLLUsuario.Eliminar(UsuarioSeleccionado);

                        // Manejo del resultado de la eliminación
                        if (usuarioEliminado)
                        {
                            BLLSeguridad.RegistrarEnBitacora(7, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("User deleted successfully.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("Usuario eliminado correctamente.", 1);
                            }
                            
                        }
                        else
                        {
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("The user cannot be deleted.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("No se puede borrar el usuario.", 1);
                            }
                           
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Warning.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Advertencia.", 1);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Warning.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("An error occurred while deleting the user: " + ex.Message, 1);
                        }
                        
                    }
                }
                else
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Select a user to delete.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione un usuario para borrar.", 1);
                    }
                    
                }
            }
        }





        #endregion


        #region CrearUsuario
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            #region validaciones
            if (!ValidarNombre(txtNombre.Text))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Error in Name field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error en el campo Nombre: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                }
               
                return;
            }

            if (!ValidarApellido(txtApellido.Text))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Error in Surname field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error en el campo Apellido: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                }
               
                return;
            }

            if (!ValidarDNI(txtDNI.Text))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Error in DNI field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error en el campo DNI: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                }

                return;
            }

            if (!ValidarMail(txtMail.Text))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Error in Mail field: Only up to 50 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error en el campo Mail: Solo se permiten hasta 50 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                }
               
                return;
            }

            if (!ValidarNick(txtNick.Text))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Error in Nick field: Only up to 15 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error en el campo Nick: Solo se permiten hasta 15 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                }
                
                return;
            }
            #endregion



            try
            {
                BEUsuario.Nombre = BLLSeguridad.EncriptarCamposReversible(txtNombre.Text);
                BEUsuario.Apellido = BLLSeguridad.EncriptarCamposReversible(txtApellido.Text);
                BEUsuario.Nick = BLLSeguridad.EncriptarCamposReversible(txtNick.Text);
                BEUsuario.Mail = BLLSeguridad.EncriptarCamposReversible(txtMail.Text);
                BEUsuario.DNI = BLLSeguridad.EncriptarCamposReversible(txtDNI.Text);
                BEUsuario.CII = 0;
                BEUsuario.Eliminado = true;

                int longitudClave = 12; // Puedes cambiar la longitud de la clave aquí
                string claveGenerada = BLLSeguridad.GenerarClave(longitudClave);
                Console.WriteLine($"Clave generada: {claveGenerada}");
                BLLSeguridad.GuardarClaveEnArchivo(claveGenerada);
                BEUsuario.Contraseña = BLLSeguridad.EncriptarCamposIrreversible(claveGenerada);

                bool validacionFallida = false;

                // Validar Nick
                if (BLLUsuario.ValidarNick(BEUsuario.Nick).Count > 0)
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Nick already used", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Nick ya utilizado", 1);
                    }
                    validacionFallida = true;
                }

                // Validar DNI
                if (BLLUsuario.ValidarDNI(BEUsuario.DNI).Count > 0)
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("ID already used", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("DNI ya utilizado", 1);
                    }
                    validacionFallida = true;
                }

                // Validar Mail
                if (BLLUsuario.ValidarMail(BEUsuario.Mail).Count > 0)
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Email already used", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Mail ya utilizado", 1);
                    }
                    validacionFallida = true;
                }

                // Si todas las validaciones pasaron, crear el usuario
                if (!validacionFallida)
                {
                    if (BLLUsuario.Crear(BEUsuario))
                    {
                        BLLSeguridad.RegistrarEnBitacora(5, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("User created successfully", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Usuario creado con éxito", 1);
                        }
                        CalcularDigitos();
                    }
                    else
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("User could not be created", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se pudo crear el Usuario", 1);
                        }
                    }
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
                    // Validación de campos vacíos
                    #region validaciones
                    if (!ValidarNombre(txtNombre.Text))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Error in Name field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Error en el campo Nombre: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                        }

                        return;
                    }

                    if (!ValidarApellido(txtApellido.Text))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Error in Surname field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Error en el campo Apellido: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                        }

                        return;
                    }

                    if (!ValidarDNI(txtDNI.Text))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Error in DNI field: Only up to 30 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Error en el campo DNI: Solo se permiten hasta 30 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                        }

                        return;
                    }

                    if (!ValidarMail(txtMail.Text))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Error in Mail field: Only up to 50 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Error en el campo Mail: Solo se permiten hasta 50 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                        }

                        return;
                    }

                    if (!ValidarNick(txtNick.Text))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Error in Nick field: Only up to 15 characters of a-z, A-Z, 0-9, and some special characters are allowed.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Error en el campo Nick: Solo se permiten hasta 15 caracteres de a-z, A-Z, 0-9, y algunos caracteres especiales.", 1);
                        }

                        return;
                    }
                    #endregion

                    // Actualización de datos en el objeto de usuario
                    BE.Usuario usuarioModificado = new BE.Usuario()
                    {
                        Nombre = BLLSeguridad.EncriptarCamposReversible(txtNombre.Text),
                        Apellido = BLLSeguridad.EncriptarCamposReversible(txtApellido.Text),
                        Nick = BLLSeguridad.EncriptarCamposReversible(txtNick.Text),
                        Mail = BLLSeguridad.EncriptarCamposReversible(txtMail.Text),
                        DNI = BLLSeguridad.EncriptarCamposReversible(txtDNI.Text),
                        ID_Usuario = UsuarioSeleccionado.ID_Usuario // Utiliza el ID del usuario seleccionado
                    };

                    bool validacionFallida = false;

                    // Validar Nick
                    if (BLLUsuario.ValidarNick(usuarioModificado.Nick).Any(u => u.ID_Usuario != usuarioModificado.ID_Usuario))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Nick already used", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Nick ya utilizado", 1);
                        }
                        
                        validacionFallida = true;
                    }

                    // Validar DNI
                    if (BLLUsuario.ValidarDNI(usuarioModificado.DNI).Any(u => u.ID_Usuario != usuarioModificado.ID_Usuario))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("ID already used", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("DNI ya utilizado", 1);
                        }

                        validacionFallida = true;
                    }

                    // Validar Mail
                    if (BLLUsuario.ValidarMail(usuarioModificado.Mail).Any(u => u.ID_Usuario != usuarioModificado.ID_Usuario))
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("Email already used", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Mail ya utilizado", 1);
                        }

                        validacionFallida = true;
                    }

                    // Si todas las validaciones pasaron, modifica el usuario
                    if (!validacionFallida)
                    {
                        if (BLLUsuario.Modificar(usuarioModificado))
                        {
                            BLLSeguridad.RegistrarEnBitacora(6, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("Successfully modified user", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("Usuario modificado con éxito", 1);
                            }

                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("User could not be modified", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("No se pudo modificar el Usuario", 1);
                            }
                      
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Select a User to modify", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Seleccione un Usuario para modificar", 1);
                }
          ;
            }
        }



        #endregion


        #region BuscarUsuario
        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string nick = txtBuscarUsuario.Text;
            string nickEncriptado = BLLSeguridad.EncriptarCamposReversible(nick);
            if (!string.IsNullOrEmpty(nick))
            {
                // Perform the search using the parsed legajo
                List<BE.Usuario> usuarios = BLLUsuario.Buscar(nickEncriptado);


                if (usuarios != null && usuarios.Count > 0)
                {
                    dtgUsuarios.DataSource = usuarios;
                }
                else
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("User not found.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Usuario no encontrado.", 1);
                    }
                    
                    dtgUsuarios.DataSource = usuarios;
                }
            }
            else
            {
                // Show error message if the input is not a valid integer
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Please enter a valid Nickname.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Por favor, ingrese un Nick válido.", 1);
                }
               
                dtgUsuarios.DataSource = null;
            }
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
                    try
                    {
                        if (BLLSeguridad.TienePatenteUnica(UsuarioSeleccionado.ID_Usuario))
                        {
                            MessageBox.Show("El usuario " + UsuarioSeleccionado.Nick + " tiene asignada una patente unica, no puede ser bloqueado");
                        }
                        else if (BLLSeguridad.TieneFamiliaConPatenteUnica(UsuarioSeleccionado.ID_Usuario))
                        {
                            MessageBox.Show("El usuario " + UsuarioSeleccionado.Nick + " tiene patentes asignadas a familias, no puede ser bloqueado.");
                        }
                        else
                        {
                            bool Usuariobloqueado = BLLUsuario.BloquearUsuario(UsuarioSeleccionado.ID_Usuario);
                            if (Usuariobloqueado)
                            {
                                BLLSeguridad.RegistrarEnBitacora(8, usuarioLog.Nick, usuarioLog.ID_Usuario);
                                if (btnBuscarUsuario.Text == "Search")
                                {
                                    MostrarMensajeIngles("Blocked user", 2);
                                }
                                else
                                {
                                    MostrarMensajeEspañol("Usuario bloqueado", 1);
                                }
                                CalcularDigitos();
                                limpiarGrilla();
                                limpiartxt();
                            }
                            else
                            {
                                if (btnBuscarUsuario.Text == "Search")
                                {
                                    MostrarMensajeIngles("cannot block user.", 2);
                                }
                                else
                                {
                                    MostrarMensajeEspañol("no se puede bloquear el usuario.", 1);
                                }
                               
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Select a user to block.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione un usuario para bloquear.", 1);
                    }
                   
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
                            BLLUsuario.ContadorIngresos0(usuarioLog);
                            BLLSeguridad.RegistrarEnBitacora(9, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("Unlocked user.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("Usuario desbloqueado", 1);
                            }
                           
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("cannot unlock user.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("no se puede desbloquear el usuario", 1);
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("An error occurred while unlocking the user: " + ex.Message, 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Ha ocurrido un error al desbloquear el usuario: " + ex.Message, 1);
                        }
                      
                    }
                }
                else
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Select a user to unblock.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione un usuario para desbloquear", 1);
                    }
                   
                }
            }
        }

        private void btnRecuperarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de recuperar este usuario?", "Confirmación de recuperacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (UsuarioSeleccionado != null)
                {
                    bool UsuarioRecuperado = BLLUsuario.RecuperarUsuario(UsuarioSeleccionado.ID_Usuario);

                    try
                    {
                        if (UsuarioRecuperado)
                        {
                            //ver agregar recuperar usuario en bitacora
                            BLLSeguridad.RegistrarEnBitacora(37, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("Recovered User.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("Usuario Recuperado.", 1);
                            }

                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            if (btnBuscarUsuario.Text == "Search")
                            {
                                MostrarMensajeIngles("cannot recover user.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("no se puede recuperar el usuario.", 1);
                            }
                            MessageBox.Show("no se puede recuperar el usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        if (btnBuscarUsuario.Text == "Search")
                        {
                            MostrarMensajeIngles("An error occurred while recovering the user: " + ex.Message, 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Ha ocurrido un error al recuperar el usuario: " + ex.Message, 1);
                        }

                    }
                }
                else
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Select a user to recover.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione un usuario para recuperar.", 1);
                    }

                }
            }
        }
        #endregion

        #region UsuariosFamilia
        private void dtgFamiliaActual_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerFamiliaSeleccionadaActuales();
            ObtenerUsuarioSeleccionado();

            int id_Usuario = UsuarioSeleccionado.ID_Usuario;
            int id_Familia = FamiliaSeleccionadaQuitar.ID_Familia;

            // Validación 1: Verificar si la familia puede eliminarse
            bool puedeEliminarFamilia = BLLSeguridad.PuedeEliminarFamilia(id_Familia);


            // Validación 2: Verificar si la familia contiene una patente única para el usuario
            bool contienePatenteUnica = BLLSeguridad.FamiliaContienePatenteUnicaParaUsuario(id_Usuario, id_Familia);


            // Validación 3: Verificar si el usuario quedaría con patentes sin asignación
            bool quedaSinAsignacion = BLLSeguridad.UsuarioQuedariaConPatentesSinFamilia(id_Usuario, id_Familia);


            // Validación 4: Verificar si la familia tendría patentes sin usuarios
            bool familiaTendriaPatenteSinUsuario = BLLSeguridad.FamiliaTendriaPatenteSinUsuario(id_Usuario, id_Familia);


            // Condición compuesta para verificar todas las validaciones
            if (!puedeEliminarFamilia || contienePatenteUnica || (quedaSinAsignacion && familiaTendriaPatenteSinUsuario))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("You cannot remove the family or the user because some patent would be left unassigned.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("No se puede quitar la familia o el usuario porque se dejaría alguna patente sin asignación", 1);
                }
               
            }
            else
            {
                BLLUsuario.QuitarFamilia(id_Usuario, id_Familia);
                dtgFamiliaActual.DataSource = BLLFamilia.ListarFamiliasActualesXUsuario(id_Usuario);
                dtgFamiliasSinAsignar.DataSource = BLLFamilia.ListarFamiliasSinAsignarXUsuario(id_Usuario);
                dtgFamiliasSinAsignar.AutoGenerateColumns = true;
                dtgFamiliaActual.AutoGenerateColumns = true;
                CalcularDigitos2();
                BLLSeguridad.RegistrarEnBitacora(11, usuarioLog.Nick, usuarioLog.ID_Usuario);
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("Successfully removed family.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Familia quitada correctamente", 1);
                }
                
            }

        }

       

















        private void dtgFamiliasSinAsignar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerFamiliaSeleccionadaNoActuales();
            ObtenerUsuarioSeleccionado();


            int id_Usuario = UsuarioSeleccionado.ID_Usuario;
            int id_Familia = FamiliaSeleccionadaAsignar.ID_Familia;
            BLLUsuario.AsignarFamilia(id_Usuario, id_Familia);
            dtgFamiliaActual.DataSource = BLLFamilia.ListarFamiliasActualesXUsuario(id_Usuario);
            dtgFamiliasSinAsignar.DataSource = BLLFamilia.ListarFamiliasSinAsignarXUsuario(id_Usuario);
            dtgFamiliasSinAsignar.AutoGenerateColumns = true;
            dtgFamiliaActual.AutoGenerateColumns = true;
            CalcularDigitos2();
            BLLSeguridad.RegistrarEnBitacora(10, usuarioLog.Nick, usuarioLog.ID_Usuario);
            if (btnBuscarUsuario.Text == "Search")
            {
                MostrarMensajeIngles("Successfully assigned family.", 2);
            }
            else
            {
                MostrarMensajeEspañol("Familia asignada correctamente", 1);
            }
           

        }

        public BE.Familia ObtenerFamiliaSeleccionadaActuales()
        {
            if (dtgFamiliaActual.SelectedRows.Count > 0)
            {
                FamiliaSeleccionadaQuitar = ((BE.Familia)dtgFamiliaActual.SelectedRows[0].DataBoundItem);
            }
            return FamiliaSeleccionadaQuitar;
        }

        public BE.Familia ObtenerFamiliaSeleccionadaNoActuales()
        {
            if (dtgFamiliasSinAsignar.SelectedRows.Count > 0)
            {
                FamiliaSeleccionadaAsignar = ((BE.Familia)dtgFamiliasSinAsignar.SelectedRows[0].DataBoundItem);
            }
            return FamiliaSeleccionadaAsignar;
        }



        #endregion


        #region funciones de validacion

        private bool ValidarNombre(string input)
        {
            return ValidarCampo(input, 30, @"^[a-zA-Z0-9.@#$%&*()-]*$");
        }

        private bool ValidarApellido(string input)
        {
            return ValidarCampo(input, 30, @"^[a-zA-Z0-9.@#$%&*()-]*$");
        }

        private bool ValidarDNI(string input)
        {
            // Patrón para verificar que el DNI tenga exactamente 8 dígitos numéricos.
            string patronDNI = @"^\d{8}$";
            return ValidarCampo(input, 8, patronDNI);
        }

        private bool ValidarMail(string input)
        {
            // Patrón para verificar el formato de correo electrónico.
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return ValidarCampo(input, 50, patronCorreo);
        }

        private bool ValidarNick(string input)
        {
            return ValidarCampo(input, 15, @"^[a-zA-Z0-9.@#$%&*()-]*$");
        }


        private bool ValidarCampo(string input, int maxLongitud, string patron)
        {
            // Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(input))
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("The field cannot be empty.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("El campo no puede estar vacío.", 1);
                }
               
                return false;
            }

            // Validar longitud máxima
            if (input.Length > maxLongitud)
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles($"The field must not exceed {maxLongitud} characters.", 2);
                }
                else
                {
                    MostrarMensajeEspañol($"El campo no debe exceder los {maxLongitud} caracteres.", 1);
                }
                MessageBox.Show($"El campo no debe exceder los {maxLongitud} caracteres.");
                return false;
            }

            // Validar patrón
            if (!Regex.IsMatch(input, patron))
            {
                //No cumple el patron
                return false;
            }

            return true;
        }


        #endregion


        #region FuncionesVarias
        private void limpiarGrilla()
        {
            dtgUsuarios.DataSource = null;
            dtgUsuarios.DataSource = BLLUsuario.Listar();
            dtgUsuarios.Columns["Contraseña"].Visible = false;
            dtgUsuarios.Columns["CII"].Visible = false;
            dtgUsuarios.Columns["DVV"].Visible = false;
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

        public void CalcularDigitos2()
        {
            string tabla = "Usuario_Familia";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);

            string tabla1 = "Usuario_Patente";
            BLLSeguridad.VerificarDigitosVerificadores(tabla1);
            BLLSeguridad.CalcularDVV(tabla1);
            
            string tabla3 = "Familia_Patente";
            BLLSeguridad.VerificarDigitosVerificadores(tabla3);
            BLLSeguridad.CalcularDVV(tabla3);
        }




        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerUsuarioSeleccionado();
            int id_usuario = UsuarioSeleccionado.ID_Usuario;
            dtgFamiliaActual.DataSource = BLLFamilia.ListarFamiliasActualesXUsuario(id_usuario);
            dtgFamiliasSinAsignar.DataSource = BLLFamilia.ListarFamiliasSinAsignarXUsuario(id_usuario);

            dtgFamiliasSinAsignar.AutoGenerateColumns = true;
            dtgFamiliaActual.AutoGenerateColumns = true;
            dtgFamiliaActual.Columns["ID_Patente"].Visible = false;
            dtgFamiliaActual.Columns["ID_Usuario"].Visible = false;
            dtgFamiliasSinAsignar.Columns["ID_Patente"].Visible = false;
            dtgFamiliasSinAsignar.Columns["ID_Usuario"].Visible = false;
            if (_idiomaSeleccionado == 2)
            {
                dtgFamiliasSinAsignar.Columns["ID_Familia"].HeaderText = "ID";
                dtgFamiliaActual.Columns["ID_Familia"].HeaderText = "ID";
                dtgFamiliasSinAsignar.Columns["Descripcion"].HeaderText = "Description";
                dtgFamiliaActual.Columns["Descripcion"].HeaderText = "Description";
            }
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



        public static void MostrarMensajeEspañol(string mensaje, int codigo)
        {

            UINotificacion UINoti = new UINotificacion(mensaje, codigo)
            {
                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                TopMost = true // Siempre visible encima de otras ventanas
            };
            UINoti.ShowDialog(); // Mostrar como diálog
        }

        public static void MostrarMensajeIngles(string mensaje, int codigo)
        {

            UINotificacion UINoti = new UINotificacion(mensaje, codigo)
            {
                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                TopMost = true // Siempre visible encima de otras ventanas
            };
            UINoti.ShowDialog(); // Mostrar como diálog
        }





    }

    



    #endregion



}

