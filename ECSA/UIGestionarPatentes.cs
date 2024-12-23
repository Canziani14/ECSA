﻿using BE;
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
    public partial class UIGestionarPatentes : Form
    {
        BE.Usuario BEUsuario = new BE.Usuario();
        BE.Usuario UsuarioSeleccionado = new BE.Usuario();
        BLL.BLL_ABM_Usuario BLLUsuario = new BLL.BLL_ABM_Usuario();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private BE.Usuario usuarioLog;
        BLL.BLLPatente BLLPatente = new BLL.BLLPatente();
        BE.Patente PatenteSeleccionadaAsignar = new BE.Patente();
        BE.Patente PatenteSeleccionadaQuitar = new BE.Patente();
        int _idiomaSeleccionado;
        public UIGestionarPatentes(BE.Usuario usuarioLogin, List<Patente> patentes, List<Traduccion> traducciones, int idiomaSeleccionado)
        {
            InitializeComponent();
            this.usuarioLog = usuarioLogin;
            dtgUsuarios.DataSource = BLLUsuario.Listar();
            this.StartPosition = FormStartPosition.CenterScreen;
            this._idiomaSeleccionado = idiomaSeleccionado;

            #region idioma


            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 40:
                        btnBuscarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 64:
                        lblBuscar.Text = traduccion.Descripcion;
                        break;
                    case 80:
                        lblAsignadas.Text = traduccion.Descripcion;
                        break;
                    case 82:
                        lblSinAsignar.Text = traduccion.Descripcion;
                        break;
                    case 100:
                        gbGestorPatentes.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        dtgUsuarios.Columns["ID_Usuario"].HeaderText = traduccion.Descripcion;
                        break;
                    case 68:
                        dtgUsuarios.Columns["Nombre"].HeaderText = traduccion.Descripcion;
                        break;
                    case 70:
                        dtgUsuarios.Columns["Apellido"].HeaderText = traduccion.Descripcion;
                        break;
                    case 72:
                        dtgUsuarios.Columns["DNI"].HeaderText = traduccion.Descripcion;
                        break;
                    case 74:
                        dtgUsuarios.Columns["Nick"].HeaderText = traduccion.Descripcion;
                        break;
                    case 148:
                        dtgUsuarios.Columns["Estado"].HeaderText = traduccion.Descripcion;
                        break;
                    case 149:
                        dtgUsuarios.Columns["Eliminado"].HeaderText = traduccion.Descripcion;
                        break;


                }
            }
            #endregion| 



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


            dtgPatentesSinAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgPatentesSinAsignar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPatentesSinAsignar.ReadOnly = true;
            dtgPatentesSinAsignar.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgPatentesSinAsignar.BorderStyle = BorderStyle.None;
            dtgPatentesSinAsignar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgPatentesSinAsignar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgPatentesSinAsignar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgPatentesSinAsignar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgPatentesSinAsignar.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgPatentesSinAsignar.EnableHeadersVisualStyles = false;
            dtgPatentesSinAsignar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgPatentesSinAsignar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgPatentesSinAsignar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgPatentesSinAsignar.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgPatentesSinAsignar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPatentesSinAsignar.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgPatentesSinAsignar.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgPatentesSinAsignar.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
            #region Perzonalizacion DTG


            dtgPatentesActuales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgPatentesActuales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPatentesActuales.ReadOnly = true;
            dtgPatentesActuales.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgPatentesActuales.BorderStyle = BorderStyle.None;
            dtgPatentesActuales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgPatentesActuales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgPatentesActuales.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgPatentesActuales.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgPatentesActuales.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgPatentesActuales.EnableHeadersVisualStyles = false;
            dtgPatentesActuales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgPatentesActuales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgPatentesActuales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgPatentesActuales.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgPatentesActuales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPatentesActuales.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgPatentesActuales.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgPatentesActuales.GridColor = Color.FromArgb(231, 231, 231);
            #endregion

        }

      

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string nick = txtBuscarUsuario.Text;
            string nickEncriptado = BLLSeguridad.EncriptarCamposReversible(nick);
            if (!string.IsNullOrEmpty(nick))
            {
               
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
                        MostrarMensajeEspañol("Usuario no encontrado", 1);
                    }
                   
                    dtgUsuarios.DataSource = usuarios;
                }
            }
            else
            {
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





        public BE.Patente ObtenerPatenteSeleccionadaActuales()
        {
            if (dtgPatentesActuales.SelectedRows.Count > 0)
            {
                PatenteSeleccionadaQuitar = ((BE.Patente)dtgPatentesActuales.SelectedRows[0].DataBoundItem);
            }
            return PatenteSeleccionadaQuitar;
        }



     

      
        public BE.Patente ObtenerPatenteSeleccionadaNoActuales()
        {
            if (dtgPatentesSinAsignar.SelectedRows.Count > 0)
            {
                PatenteSeleccionadaAsignar = ((BE.Patente)dtgPatentesSinAsignar.SelectedRows[0].DataBoundItem);
            }
            return PatenteSeleccionadaAsignar;
        }






        private void dtgPatentesActuales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerPatenteSeleccionadaActuales();
            BE.Usuario usuarioSeleccionado = ObtenerUsuarioSeleccionado();

            if (usuarioSeleccionado == null)
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("No user selected.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("No se ha seleccionado un usuario", 1);
                }
                
                return;
            }

            if (_idiomaSeleccionado == 2)
            {
                dtgPatentesActuales.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesSinAsignar.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesActuales.Columns["Descripcion"].HeaderText = "Description";
                dtgPatentesSinAsignar.Columns["Descripcion"].HeaderText = "Description";
            }

            int idUsuario = usuarioSeleccionado.ID_Usuario;
            int idPatente = PatenteSeleccionadaQuitar.ID_Patente;

            Console.WriteLine($"ID Usuario seleccionado: {idUsuario}");
            Console.WriteLine($"ID Patente seleccionada para quitar: {idPatente}");

            // Verificar si puede eliminar la patente (por usuario o familia)
            bool puedeEliminarPorUsuario = BLLSeguridad.PuedeEliminarPatenteDeUsuario(idPatente, idUsuario);
            bool puedeEliminarPorFamilia = BLLSeguridad.PuedeEliminarPatenteDeFamilia2(idPatente, idUsuario);
            bool PuedeEliminarPatente = BLLSeguridad.PuedeEliminarPatente(idUsuario,idPatente);
            bool puedeEliminar = puedeEliminarPorUsuario || puedeEliminarPorFamilia;

            //if (puedeEliminar)
            if (puedeEliminar || PuedeEliminarPatente)
            {
                try
                {
                    BLLPatente.Quitar(idUsuario, idPatente);
                    
                    CalcularDigitos();
                    BLLSeguridad.RegistrarEnBitacora(28, usuarioLog.Nick, usuarioLog.ID_Usuario);
                    RefrescarDTG();
                    dtgPatentesActuales.Columns["ID_Usuario"].Visible = false;
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles("Patent removed successfully.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Patente quitada correctamente", 1);
                    }
                   
                }
                catch (Exception ex)
                {
                    if (btnBuscarUsuario.Text == "Search")
                    {
                        MostrarMensajeIngles($"Error removing patent: {ex.Message}", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol($"Error al quitar la patente: {ex.Message}", 1);
                    }
                   
                }
            }
            else
            {
                if (btnBuscarUsuario.Text == "Search")
                {
                    MostrarMensajeIngles("The patent cannot be deleted because it is the sole owner or it is associated with a family to which the user belongs.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("No se puede eliminar la patente porque es el único propietario o está asociada a una familia a la que pertenece el usuario", 1);
                }
                
            }
        }















        private void dtgPatentesSinAsignar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerPatenteSeleccionadaNoActuales();
            ObtenerUsuarioSeleccionado();
            int id_Usuario = UsuarioSeleccionado.ID_Usuario;
            int id_Patente=PatenteSeleccionadaAsignar.ID_Patente;
            BLLPatente.Asignar(id_Usuario, id_Patente);
            dtgPatentesActuales.DataSource = BLLPatente.ListarActuales(id_Usuario);
            dtgPatentesSinAsignar.DataSource = BLLPatente.ListarSinAsignar(id_Usuario);
            if (_idiomaSeleccionado == 2)
            {
                dtgPatentesActuales.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesSinAsignar.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesActuales.Columns["Descripcion"].HeaderText = "Description";
                dtgPatentesSinAsignar.Columns["Descripcion"].HeaderText = "Description";
            }
            CalcularDigitos();
            RefrescarDTG();
            BLLSeguridad.RegistrarEnBitacora(27, usuarioLog.Nick, usuarioLog.ID_Usuario);
            dtgPatentesSinAsignar.Columns["ID_Usuario"].Visible = false;
            MessageBox.Show("Patente asignada correctamente");
        }
        

        public void RefrescarDTG()
        {
            int id_Usuario = UsuarioSeleccionado.ID_Usuario;
            dtgPatentesActuales.DataSource = BLLPatente.ListarActuales(id_Usuario);
            dtgPatentesSinAsignar.DataSource = BLLPatente.ListarSinAsignar(id_Usuario);

        }

        public BE.Usuario ObtenerUsuarioSeleccionado()
        {
            if (dtgUsuarios.SelectedRows.Count > 0)
            {
                UsuarioSeleccionado = ((BE.Usuario)dtgUsuarios.SelectedRows[0].DataBoundItem);
            }

            return UsuarioSeleccionado;
        }

        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerUsuarioSeleccionado();
            int id_Usuario=UsuarioSeleccionado.ID_Usuario;
            dtgPatentesActuales.DataSource = BLLPatente.ListarActuales(id_Usuario);
            dtgPatentesSinAsignar.DataSource = BLLPatente.ListarSinAsignar(id_Usuario);
            if (_idiomaSeleccionado == 2)
            {
                dtgPatentesActuales.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesSinAsignar.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesActuales.Columns["Descripcion"].HeaderText = "Description";
                dtgPatentesSinAsignar.Columns["Descripcion"].HeaderText = "Description";
            }
            dtgPatentesActuales.Columns["ID_Usuario"].Visible = false;
            dtgPatentesSinAsignar.Columns["ID_Usuario"].Visible = false;

        }

        public void CalcularDigitos()
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
}
