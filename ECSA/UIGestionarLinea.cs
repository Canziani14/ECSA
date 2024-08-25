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
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        break;
                    case 14:
                        gbGestorLineas.Text = traduccion.Descripcion;
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
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }
            try
            {

                BELinea.NumeroDeLinea = BLLSeguridad.EncriptarCamposReversible(txtNombreLinea.Text);


                if (BLLinea.ValidarNumLinea(BELinea.NumeroDeLinea).Count > 0)
                {
                    MessageBox.Show("Nombre de linea ya utilizado");
                }
                else
                {
                    if (BLLinea.Crear(BELinea))
                    {
                        BLLSeguridad.RegistrarEnBitacora(18, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Linea creada con éxito");
                        CalcularDigitos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la Linea");
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
                        MessageBox.Show("Linea modificada con exito");
                        CalcularDigitos();
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la Linea");
                    }

                }
                catch (FormatException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una Linea para modificar");
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
                            MessageBox.Show("no se puede borrar la Linea");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar la Linea: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una Linea para borrar");
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
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("El ID de la línea debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

