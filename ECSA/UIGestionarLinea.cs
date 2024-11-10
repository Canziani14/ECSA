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
    public partial class UIGestionarLinea : Form
    {

        BLL.BLL_ABM_Linea BLLinea = new BLL.BLL_ABM_Linea();
        BE.Linea BELinea = new BE.Linea();
        BE.Linea LineaSeleccionada = new BE.Linea();
        BLL.BLLSeguridad BLLSeguridad = new BLLSeguridad();
        private BE.Usuario usuarioLog;
        private List<Patente> _patentes;
        private List<Traduccion> _traducciones;
        public UIGestionarLinea(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            InitializeComponent();
            dtgLineas.DataSource = BLLinea.Listar();
            this.usuarioLog = usuarioLog;
            _patentes = patentes;
            _traducciones = traducciones;


            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 2:
                        btnCrearLinea.Text = traduccion.Descripcion;
                        break;
                    case 4:
                        btnModificarLinea.Text = traduccion.Descripcion;
                        break;                   
                    case 6:
                        btnEliminarLinea.Text = traduccion.Descripcion;
                        break;
                    case 26:
                        btnGestionarCoches.Text = traduccion.Descripcion;
                        break;
                    case 28:
                        btnGestionarServicios.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        lblID.Text = traduccion.Descripcion;
                        dtgLineas.Columns["ID_Linea"].HeaderText = traduccion.Descripcion;
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        break;
                    case 14:
                        gbGestorLineas.Text = traduccion.Descripcion;
                        break;
                    case 86:
                        dtgLineas.Columns["NumeroDeLinea"].HeaderText = traduccion.Descripcion;
                        break;
                }      
                
            }

            #endregion

            #region patentes
            btnCrearLinea.Enabled = false;
            btnEliminarLinea.Enabled = false;
            btnModificarLinea.Enabled = false;
            btnGestionarCoches.Enabled = false;
            btnGestionarServicios.Enabled = false;

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 14:
                        btnCrearLinea.Enabled = true;
                        break;
                    case 16:
                        btnEliminarLinea.Enabled = true;
                        break;
                    case 15:
                        btnModificarLinea.Enabled = true;
                        break;
                    case 40:
                        btnGestionarCoches.Enabled = true;
                        break;
                    case 39:
                        btnGestionarServicios.Enabled = true;
                        break;                  
                }

            }
            #endregion


            #region Perzonalizacion DTG
            dtgLineas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgLineas.Columns["DVH"].Visible = false;

            dtgLineas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgLineas.ReadOnly = true;
            dtgLineas.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgLineas.BorderStyle = BorderStyle.None;
            dtgLineas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgLineas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgLineas.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgLineas.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgLineas.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgLineas.EnableHeadersVisualStyles = false;
            dtgLineas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgLineas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgLineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgLineas.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgLineas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgLineas.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgLineas.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgLineas.GridColor = Color.FromArgb(231, 231, 231);
            #endregion


        }



        #region Crear Linea
        private void btnCrearLinea_Click(object sender, EventArgs e)
        {
            if (txtNombreLinea.Text == "")
            {
                if (btnCrearLinea.Text == "Create")
                {
                    MostrarMensajeIngles("Please complete all fields.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Por favor, complete todos los campos", 1);
                }
                
                return;
            }
            try
            {

                BELinea.NumeroDeLinea = BLLSeguridad.EncriptarCamposReversible(txtNombreLinea.Text);


                if (BLLinea.ValidarNumLinea(BELinea.NumeroDeLinea).Count > 0)
                {
                    if (btnCrearLinea.Text == "Create")
                    {
                        MostrarMensajeIngles("Line name already used.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Nombre de linea ya utilizado", 1);
                    }
                    
                }
                else
                {
                    if (BLLinea.Crear(BELinea))
                    {
                        BLLSeguridad.RegistrarEnBitacora(18, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        if (btnCrearLinea.Text == "Create")
                        {
                            MostrarMensajeIngles("Line created successfully.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Linea creada con éxito", 1);
                        }
                        
                        CalcularDigitos();
                    }
                    else
                    {
                        if (btnCrearLinea.Text == "Create")
                        {
                            MostrarMensajeIngles("Line could not be created.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se pudo crear la Linea.", 1);
                        }
                        
                    }
                }
               

                limpiarGrilla();
                limpiartxt();
            }
            catch (Exception ex)
            {
                if (btnCrearLinea.Text == "Create")
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
        #endregion

        #region Modificar Linea
        private void btnModificarLinea_Click(object sender, EventArgs e)
        {
            if (LineaSeleccionada != null)
            {
                try
                {
                    if (BLLinea.Modificar(new BE.Linea()
                    {
                        NumeroDeLinea = BLLSeguridad.EncriptarCamposReversible(txtNombreLinea.Text),
                        ID_Linea = int.Parse(txtIDLinea.Text)
                       
                    }))
                    {
                        BLLSeguridad.RegistrarEnBitacora(19, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        if (btnCrearLinea.Text == "Create")
                        {
                            MostrarMensajeIngles("Successfully modified line.", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Linea modificada con exito.", 1);
                        }
                  
                        CalcularDigitos();
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        if (btnCrearLinea.Text == "Create")
                        {
                            MostrarMensajeIngles("Could not modify the Line", 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("No se pudo modificar la Linea.", 1);
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
                if (btnCrearLinea.Text == "Create")
                {
                    MostrarMensajeIngles("Select a Line to modify", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Seleccione una Linea para modificar.", 1);
                }
                
            }
            
        }
        #endregion

        #region Eliminar Linea
        private void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar esta linea?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (LineaSeleccionada != null)
                {
                    bool LineaEliminada = BLLinea.Eliminar(LineaSeleccionada);

                    try
                    {
                        if (LineaEliminada)
                        {
                            BLLSeguridad.RegistrarEnBitacora(20, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            if (btnCrearLinea.Text == "Create")
                            {
                                MostrarMensajeIngles("cannot delete the line.", 2);
                            }
                            else
                            {
                                MostrarMensajeEspañol("no se puede borrar la Linea.", 1);
                            }
                        
                        }
                    }
                    catch (Exception ex)
                    {
                        if (btnCrearLinea.Text == "Create")
                        {
                            MostrarMensajeIngles("An error occurred while deleting the Line: " + ex.Message, 2);
                        }
                        else
                        {
                            MostrarMensajeEspañol("Ha ocurrido un error al borrar la Linea: " + ex.Message, 1);
                        }
                     
                    }
                }
                else
                {
                    if (btnCrearLinea.Text == "Create")
                    {
                        MostrarMensajeIngles("Select a Line to delete.", 2);
                    }
                    else
                    {
                        MostrarMensajeEspañol("Seleccione una Linea para borrar.", 1);
                    }
                  
                }
            }
        }
        #endregion




        private void btnGestionarCoches_Click(object sender, EventArgs e)
        {
            UIGestionarCoches uiGestionarCoches = new UIGestionarCoches(usuarioLog, _patentes, _traducciones);
            uiGestionarCoches.MdiParent = this.MdiParent;
            uiGestionarCoches.Show();
        }

        private void btnGestionarServicios_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtIDLinea.Text) || string.IsNullOrWhiteSpace(txtNombreLinea.Text))
            {
                if (btnCrearLinea.Text == "Create")
                {
                    MostrarMensajeIngles("Please complete all fields before continuing.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("Por favor, complete todos los campos antes de continuar.", 1);
                }
              
                return; // Salir del método si los campos están vacíos
            }

            // Intentar convertir txtIDLinea.Text a un entero
            if (int.TryParse(txtIDLinea.Text, out int IDLinea))
            {
                string NombreLinea = txtNombreLinea.Text;
                UIGestionarServicios uiGestionarServicios = new UIGestionarServicios(IDLinea, NombreLinea, usuarioLog, _patentes, _traducciones);
                uiGestionarServicios.MdiParent = this.MdiParent;
                uiGestionarServicios.Show();
            }
            else
            {
                // Mostrar mensaje si la conversión falla
                if (btnCrearLinea.Text == "Create")
                {
                    MostrarMensajeIngles("The line ID must be a valid number.", 2);
                }
                else
                {
                    MostrarMensajeEspañol("El ID de la línea debe ser un número válido.", 1);
                }
                
            }

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


        #region FuncionesVarias
        private void limpiarGrilla()
        {
            dtgLineas.DataSource = null;
            dtgLineas.DataSource = BLLinea.Listar();
        }

        private void limpiartxt()
        {
            txtNombreLinea.Clear();
        }

        public void CalcularDigitos()
        {
            string tabla = "Linea";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
        }
       
        private void dtgLineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerLineaSeleccionada();
        }

        public BE.Linea ObtenerLineaSeleccionada()
        {
            if (dtgLineas.SelectedRows.Count > 0)
            {
                LineaSeleccionada = ((BE.Linea)dtgLineas.SelectedRows[0].DataBoundItem);
                this.CompletarLinea(LineaSeleccionada);
            }

            return LineaSeleccionada;
        }

        public void CompletarLinea(BE.Linea linea)
        {
            txtIDLinea.Text = (linea.ID_Linea).ToString();
            txtNombreLinea.Text = linea.NumeroDeLinea;
            
        }

       
    }


    #endregion

}

