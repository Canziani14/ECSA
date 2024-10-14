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
        BLL.BLL_ABM_Familia BLLFamilia = new BLL.BLL_ABM_Familia();
        BE.Familia FamiliaSeleccionadaAsignar = new BE.Familia();
        BE.Familia FamiliaSeleccionadaQuitar = new BE.Familia();


        public UIGestionarUsuarios(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            this.usuarioLog = usuarioLog;
            InitializeComponent();
            dtgUsuarios.DataSource = BLLUsuario.Listar();

            btnCrearUsuario.Enabled = false;
            btnModificarUsuario.Enabled=false;
            btnEliminarUsuario.Enabled = false;
            btnBloquearUsuario.Enabled = false;
            btnDesbloquearUsuario.Enabled = false;
            
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
                        break;
                    case 72:
                        lblDNI.Text = traduccion.Descripcion;
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        break;
                    case 66:
                        lblidUsuario.Text = traduccion.Descripcion;
                        break;
                    case 74:
                        lblNick.Text = traduccion.Descripcion;
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
                        btnRecuperarUsuario.Text=traduccion.Descripcion;
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
                            MessageBox.Show("No se puede eliminar el usuario que está actualmente en sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir del método si no se puede eliminar
                        }

                        // Verifica si el usuario tiene patentes exclusivas
                        if (BLLSeguridad.TienePatentesExclusivas(UsuarioSeleccionado.ID_Usuario))
                        {
                            MessageBox.Show("El usuario " + UsuarioSeleccionado.Nick + " tiene asignada una patente única, no puede ser eliminado.");
                        }
                        else
                        {
                            bool UsuarioEliminado = BLLUsuario.Eliminar(UsuarioSeleccionado);

                            if (UsuarioEliminado)
                            {
                                BLLSeguridad.RegistrarEnBitacora(7, usuarioLog.Nick, usuarioLog.ID_Usuario);
                                CalcularDigitos();
                                limpiarGrilla();
                                limpiartxt();
                            }
                            else
                            {
                                MessageBox.Show("No se puede borrar el usuario.");
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar el usuario: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para borrar.");
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
                    MessageBox.Show("Nick ya utilizado");
                    validacionFallida = true;
                }

                // Validar DNI
                if (BLLUsuario.ValidarDNI(BEUsuario.DNI).Count > 0)
                {
                    MessageBox.Show("DNI ya utilizado");
                    validacionFallida = true;
                }

                // Validar Mail
                if (BLLUsuario.ValidarMail(BEUsuario.Mail).Count > 0)
                {
                    MessageBox.Show("Mail ya utilizado");
                    validacionFallida = true;
                }

                // Si todas las validaciones pasaron, crear el usuario
                if (!validacionFallida)
                {
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
            string nick = txtBuscarUsuario.Text;
            string nickEncriptado=BLLSeguridad.EncriptarCamposReversible(nick);
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
                    MessageBox.Show("Usuario no encontrado.");
                    dtgUsuarios.DataSource = usuarios;
                }
            }
            else
            {
                // Show error message if the input is not a valid integer
                MessageBox.Show("Por favor, ingrese un Nick válido.");
                dtgUsuarios.DataSource = null;
            }
        }

        #endregion
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
                            MessageBox.Show("Usuario Recuperado");
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede recuperar el usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al recuperar el usuario: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para recuperar");
                }
            }
        }

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
                        if (BLLSeguridad.TienePatentesExclusivas(UsuarioSeleccionado.ID_Usuario))
                        {
                            MessageBox.Show("El usuario " + UsuarioSeleccionado.Nick + " tiene asignada una patente unica, no puede ser bloqueado");
                        }
                        else
                        {
                            bool Usuariobloqueado = BLLUsuario.BloquearUsuario(UsuarioSeleccionado.ID_Usuario);
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
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            BLLUsuario.ContadorIngresos0(usuarioLog);
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

        #region UsuariosFamilia
        private void dtgFamiliaActual_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerFamiliaSeleccionadaActuales();
            ObtenerUsuarioSeleccionado();
            
            
            int id_Usuario = UsuarioSeleccionado.ID_Usuario;
            int id_Familia =FamiliaSeleccionadaQuitar.ID_Familia ;
            BLLUsuario.QuitarFamilia(id_Usuario, id_Familia);
            dtgFamiliaActual.DataSource = BLLFamilia.ListarFamiliasActualesXUsuario(id_Usuario);
            dtgFamiliasSinAsignar.DataSource = BLLFamilia.ListarFamiliasSinAsignarXUsuario(id_Usuario);
            dtgFamiliasSinAsignar.AutoGenerateColumns = true;
            dtgFamiliaActual.AutoGenerateColumns = true;
            CalcularDigitos2();
            BLLSeguridad.RegistrarEnBitacora(11, usuarioLog.Nick, usuarioLog.ID_Usuario);
            MessageBox.Show("Familia quitada correctamente");
           

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
            MessageBox.Show("Familia asignada correctamente");
            
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

        public void CalcularDigitos2()
        {
            string tabla = "Usuario_Familia";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
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

