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
    public partial class UIGestionarFamilias : Form
    {
        BE.Familia BEFamilia= new BE.Familia();
        BE.Familia familiaSeleccionada = new BE.Familia();
        BLL.BLL_ABM_Familia BLLFamilia = new BLL.BLL_ABM_Familia();
        BLL.BLLPatente BLLPatente = new BLL.BLLPatente();
        BE.Patente PatenteSeleccionadaAsignar = new BE.Patente();
        BE.Patente PatenteSeleccionadaQuitar = new BE.Patente();
        private BE.Usuario usuarioLog;       
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        int _idiomaSeleccionado;
       
        public UIGestionarFamilias(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones, int idiomaSeleccionado)
        {
            
            InitializeComponent();
            dtgFamilias.DataSource= BLLFamilia.Listar();
            this.usuarioLog = usuarioLog;
            StartPosition = FormStartPosition.CenterScreen;
            dtgFamilias.Columns["ID_Usuario"].Visible = false;
            dtgFamilias.Columns["ID_Patente"].Visible = false;
            this._idiomaSeleccionado = idiomaSeleccionado;

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 2:
                        btnCrearFamilia.Text = traduccion.Descripcion;
                        break;
                    case 4:
                        btnModificarFamilia.Text = traduccion.Descripcion;
                        break;
                    case 6:
                        btnEliminarFamilia.Text = traduccion.Descripcion;
                        break;
                    case 102:
                        gbGestorFamilias.Text = traduccion.Descripcion;
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        lblID.Text = traduccion.Descripcion;
                        dtgFamilias.Columns["ID_Familia"].HeaderText = traduccion.Descripcion;

                        break;
                    case 140:
                        lblFamilia.Text = traduccion.Descripcion;
                        break;
                    case 80:
                        lblPatentesActuales.Text = traduccion.Descripcion;
                        break;
                    case 82:
                        lblPatentesSinAsignar.Text = traduccion.Descripcion;
                        break;
                   
                }   
            }

            #endregion

            #region patentes

            btnCrearFamilia.Enabled= false;
            btnModificarFamilia.Enabled = false;
            btnEliminarFamilia.Enabled=false;

            dtgPatentesActuales.Enabled=false;
            dtgPatentesSinAsignar.Enabled=false;

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 27:
                        btnCrearFamilia.Enabled = true;
                        break;
                    case 28:
                        btnModificarFamilia.Enabled = true;
                        break;
                    case 29:
                        btnEliminarFamilia.Enabled = true;
                        break;
                    case 3:
                        dtgPatentesActuales.Enabled = true;
                        dtgPatentesSinAsignar.Enabled = true;
                        break;
                }

            }
            #endregion

            #region Perzonalizacion DTG


            dtgFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFamilias.ReadOnly = true;
            dtgFamilias.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgFamilias.BorderStyle = BorderStyle.None;
            dtgFamilias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgFamilias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgFamilias.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgFamilias.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgFamilias.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgFamilias.EnableHeadersVisualStyles = false;
            dtgFamilias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgFamilias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgFamilias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgFamilias.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgFamilias.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgFamilias.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgFamilias.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgFamilias.GridColor = Color.FromArgb(231, 231, 231);
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
        
        

        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            if (txtNombreFamilia.Text == "")
            {


                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("Please complete all fields.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Por favor, complete todos los campos.", 1);
                }

                return;
            }
            try
            {

                BEFamilia.Descripcion = txtNombreFamilia.Text;


                if (BLLFamilia.ValidarNombreFamilia(BEFamilia.Descripcion).Count > 0)
                {
                    if (btnCrearFamilia.Text == "Create")
                    {
                        MostrarMensajeIngles("Family name already used.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Nombre de familia ya utilizado.", 1);
                    }
                    
                }
                else
                {
                    if (BLLFamilia.Crear(BEFamilia))
                    {
                        BLLSeguridad.RegistrarEnBitacora(12, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("Successfully created family.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Familia creada con éxito.", 1);
                        }
                                          
                    }
                    else
                    {
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("Family could not be created.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se pudo crear la familia.", 1);
                        }
                      
                    }
                }
                limpiarGrilla();
                limpiartxt();
            }
            catch (Exception ex)
            {
                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("Mistake: " + ex.Message, 2);
                }
                else
                {
                    MostrarMensajeEspañol("Error: " + ex.Message, 1);
                }
                
                return;
            }        
        }

        private void btnModificarFamilia_Click(object sender, EventArgs e)
        {
            if (familiaSeleccionada != null)
            {
                try
                {
                    if (BLLFamilia.Modificar(new BE.Familia()
                    {
                        ID_Familia = familiaSeleccionada.ID_Familia,
                        Descripcion = txtNombreFamilia.Text,                       
                    }))
                    {
                        BLLSeguridad.RegistrarEnBitacora(14, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("successfully modified family.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("familia modificada con exito.", 1);
                        }
                        
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("Could not modify family.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se pudo modificar la familia.", 1);
                        }
                   
                    }

                }
                catch (FormatException ex)
                {
                    if (btnCrearFamilia.Text == "Create")
                    {
                        MostrarMensajeIngles(ex.Message, 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol(ex.Message, 1);
                    }
                 
                }
            }
            else
            {
                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("Select a family to modify.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Seleccione una familia para modificar.", 1);
                }
               
            }

        }


        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar esta familia?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                if (familiaSeleccionada != null)
                {
                    // Verificar si se puede eliminar la familia
                    if (!BLLSeguridad.PuedeEliminarFamilia(familiaSeleccionada.ID_Familia))
                    {
                        // Solo mostrar el mensaje si no se puede eliminar
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("The family cannot be deleted because it contains unique patents that are assigned to only one user.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se puede eliminar la familia porque contiene patentes únicas que están asignadas solo a un usuario.", 1);
                        }
                        
                        return; // Salir del método si no se puede eliminar
                    }

                    bool familiaEliminada = false;

                    try
                    {
                        // Intentar eliminar la familia
                        familiaEliminada = BLLFamilia.Eliminar(familiaSeleccionada);

                        if (familiaEliminada)
                        {
                            if (btnCrearFamilia.Text == "Create")
                            {
                                MostrarMensajeIngles("Successfully deleted family", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("Familia eliminada correctamente", 1);
                            }
                            
                            BLLSeguridad.RegistrarEnBitacora(13, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            if (btnCrearFamilia.Text == "Create")
                            {
                                MostrarMensajeIngles("You cannot delete the family", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("No se puede borrar la familia", 1);
                            }
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        if (btnCrearFamilia.Text == "Create")
                        {
                            MostrarMensajeIngles("An error occurred while deleting the family: " + ex.Message, 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Ha ocurrido un error al borrar la familia: " + ex.Message, 1);
                        }
                       
                    }
                }
                else
                {
                    if (btnCrearFamilia.Text == "Create")
                    {
                        MostrarMensajeIngles("Select a family to delete", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione una familia para borrar", 1);
                    }
                  
                }
            }
        }



        private void dtgPatentesActuales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
                {


                    ObtenerPatenteSeleccionadaActuales();
                    ObtenerFamiliaSeleccionado();
           
                    int id_Familia = familiaSeleccionada.ID_Familia;
                    int id_Patente = PatenteSeleccionadaQuitar.ID_Patente;

                    // Validar si la patente puede ser quitada de la familia
                    if (!BLLSeguridad.PuedeEliminarPatenteDeFamilia(id_Familia, id_Patente))
                    {
                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("The patent cannot be deleted because it is the only one assigned to this family.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("No se puede eliminar la patente porque es la única asignada a esta familia.", 1);
                }
                
                        return; // Salir del método sin hacer nada
                    }
                    bool tieneOtrasAsignaciones = BLLSeguridad.VerificarOtrasAsignacionesDePatente(id_Patente, id_Familia);
                    if (!tieneOtrasAsignaciones)
                    {
                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("The patent cannot be deleted because it is not assigned to any other user or family.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("No se puede eliminar la patente porque no está asignada a ningún otro usuario o familia.", 1);
                }
               
                        return; // Salir del método sin hacer nada
                    }
            BLLFamilia.QuitarXFamilia(id_Familia, id_Patente);
                    dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(id_Familia, id_Patente);
                    dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(id_Familia, id_Patente);

                    CalcularDigitos();
            if (btnCrearFamilia.Text == "Create")
            {
                MostrarMensajeIngles("Patent removed from family correctly", 2);
            }
            else
            {
                MostrarMensajeEspañol("Patente quitada de la familia correctamente.", 1);
            }
          

                }

        
        

     




        private void dtgPatentesSinAsignar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerPatenteSeleccionadaNoActuales();
            ObtenerFamiliaSeleccionado();
           
            
            int id_Familia = familiaSeleccionada.ID_Familia;
            int id_Patente = PatenteSeleccionadaAsignar.ID_Patente;
            BLLFamilia.AsignarXFamilia(id_Familia, id_Patente);
            dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(id_Familia, id_Patente);
            dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(id_Familia, id_Patente);
            CalcularDigitos();
            if (btnCrearFamilia.Text == "Create")
            {
                MostrarMensajeIngles("Patent assigned to family correctly.", 2);
            }
            else
            {
                MostrarMensajeEspañol("Patente asignada a la familia correctamente.", 1);
            }
            
        }


        public BE.Patente ObtenerPatenteSeleccionadaActuales()
        {
            if (dtgPatentesActuales.SelectedRows.Count > 0)
            {
                var selectedRow = dtgPatentesActuales.SelectedRows[0];
                var dataBoundItem = selectedRow.DataBoundItem;

                

                // Verifica si el objeto en DataBoundItem es del tipo BE.Patente
                if (dataBoundItem is BE.Patente patente)
                {
                    PatenteSeleccionadaQuitar = patente;
                }
                else
                {
                    throw new InvalidCastException("El objeto seleccionado no es del tipo BE.Patente.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
                throw new InvalidOperationException("No se ha seleccionado ninguna fila.");
            }

            return PatenteSeleccionadaQuitar;
        }

        public BE.Patente ObtenerPatenteSeleccionadaNoActuales()
        {
            if (dtgPatentesSinAsignar.SelectedRows.Count > 0)
            {
                var selectedRow = dtgPatentesSinAsignar.SelectedRows[0];
                var dataBoundItem = selectedRow.DataBoundItem;

                

                // Verifica si el objeto en DataBoundItem es del tipo BE.Patente
                if (dataBoundItem is BE.Patente patente)
                {
                    PatenteSeleccionadaAsignar = patente;
                }
                else
                {
                    throw new InvalidCastException("El objeto seleccionado no es del tipo BE.Patente.");
                }
            }
            else
            {
                if (btnCrearFamilia.Text == "Create")
                {
                    MostrarMensajeIngles("select a row.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("seleccione una fila.", 1);
                }
                
                throw new InvalidOperationException("No se ha seleccionado ninguna fila.");
            }

            return PatenteSeleccionadaAsignar;
        }

        public BE.Familia ObtenerFamiliaSeleccionado()
        {
            if (dtgFamilias.SelectedRows.Count > 0)
            {
                familiaSeleccionada = ((BE.Familia)dtgFamilias.SelectedRows[0].DataBoundItem);
                txtID.Text = familiaSeleccionada.ID_Familia.ToString();
                txtNombre.Text = familiaSeleccionada.Descripcion;
                txtNombreFamilia.Text = familiaSeleccionada.Descripcion;
                
                
            }

            return familiaSeleccionada;
        }



        private void dtgFamilias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerFamiliaSeleccionado();
            int familia=familiaSeleccionada.ID_Familia;
            int patente=familiaSeleccionada.ID_Patente;
            dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(familia,patente);
            dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(familia, patente);
            if (_idiomaSeleccionado == 2)
            {
                dtgPatentesActuales.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesSinAsignar.Columns["ID_Patente"].HeaderText = "ID";
                dtgPatentesActuales.Columns["Descripcion"].HeaderText = "Description";
                dtgPatentesSinAsignar.Columns["Descripcion"].HeaderText = "Description";
            }
            dtgPatentesActuales.Columns["ID_Usuario"].Visible = false;
            dtgPatentesSinAsignar.Columns["ID_Usuario"].Visible = false;
            dtgFamilias.Columns["ID_Usuario"].Visible = false;
            dtgFamilias.Columns["ID_Patente"].Visible = false;



        }

        private void limpiarGrilla()
        {
            dtgFamilias.DataSource = null;
            dtgFamilias.DataSource = BLLFamilia.Listar();
            dtgFamilias.Columns["ID_Usuario"].Visible = false;
            dtgFamilias.Columns["ID_Patente"].Visible = false;
        }

        private void limpiartxt()
        {
            txtNombre.Clear();           
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
