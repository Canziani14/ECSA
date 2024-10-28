using BE;
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
    public partial class UIGestionarCoches : Form
    {
        BLL.BLL_ABM_Coche BLLCoche = new BLL.BLL_ABM_Coche();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BLL.BLL_ABM_Linea BLLinea = new BLL.BLL_ABM_Linea();
        BE.Coche BECoche = new BE.Coche();
        BE.Coche cocheSeleccionado = new BE.Coche();
        private BE.Usuario usuarioLog;
        public UIGestionarCoches(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            InitializeComponent();
            dtgCoches.DataSource= BLLCoche.Listar();
            LlenarComboBox(cmbLinea);
            this.usuarioLog = usuarioLog;
            btnCrearCoche.Enabled = false;
            btnEliminarCoche.Enabled = false;


            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 40:
                        btnBuscarCoche.Text = traduccion.Descripcion;
                        break;
                    case 2:
                        btnCrearCoche.Text = traduccion.Descripcion;
                        break;
                    case 6:
                        btnEliminarCoche.Text = traduccion.Descripcion;
                        break;
                    case 118:
                        lblBuscarInterno.Text = traduccion.Descripcion;
                        break;
                    case 120:
                        gbGestorCoches.Text = traduccion.Descripcion;
                        break;
                    case 96:
                        lblInterno.Text = traduccion.Descripcion;
                        dtgCoches.Columns["Interno"].HeaderText = traduccion.Descripcion;
                        break;
                    case 122:
                        lblPatente.Text = traduccion.Descripcion;
                        dtgCoches.Columns["Patente"].HeaderText = traduccion.Descripcion;
                        break;
                    case 124:
                        lblLineaAsignar.Text = traduccion.Descripcion;
                        break;
                    

                }
            }

            #endregion

            #region patente
            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 10:
                        btnCrearCoche.Enabled = true;
                        break;
                    case 12:
                        btnEliminarCoche.Enabled = true;
                        break;
                    case 13:
                        btnEliminarCoche.Enabled = true;
                        break;
                }
            }
            #endregion

            #region Perzonalizacion DTG
            dtgCoches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCoches.Columns["ID_Linea"].Visible = false;
            dtgCoches.Columns["DVH"].Visible = false;

            dtgCoches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCoches.ReadOnly = true;
            dtgCoches.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgCoches.BorderStyle = BorderStyle.None;
            dtgCoches.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgCoches.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgCoches.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgCoches.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgCoches.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgCoches.EnableHeadersVisualStyles = false;
            dtgCoches.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgCoches.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgCoches.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgCoches.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgCoches.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgCoches.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);


            // Ajuste de los márgenes y bordes
            dtgCoches.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgCoches.GridColor = Color.FromArgb(231, 231, 231);
            #endregion



        }

        private void btnCrearCoche_Click(object sender, EventArgs e)
        {
            if (txtPatente.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            try
            {

                BECoche.Patente = BLLSeguridad.EncriptarCamposReversible(txtPatente.Text);
                
                if (cmbLinea.SelectedValue != null)
                {
                    
                    BECoche.ID_Linea = (int)cmbLinea.SelectedValue;
                    
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una línea válida.");
                }

                if (BLLCoche.ValidarPatente(BECoche.Patente).Count()>0)
                {
                    MessageBox.Show("Patente ya utilizada");
                }
                else
                {
                    if (BLLCoche.Crear(BECoche))
                    {
                        BLLSeguridad.RegistrarEnBitacora(21, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Coche creado con éxito");
                        CalcularDigitos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el Coche");
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

        private void btnEliminarCoche_Click(object sender, EventArgs e)
        {
            
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este Coche?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {

                    if (cocheSeleccionado != null)
                    {
                        bool cocheEliminado = BLLCoche.Eliminar(cocheSeleccionado);

                        try
                        {
                            if (cocheEliminado)
                            {
                                BLLSeguridad.RegistrarEnBitacora(22, usuarioLog.Nick, usuarioLog.ID_Usuario);
                                CalcularDigitos();
                                limpiarGrilla();
                                limpiartxt();
                            }
                            else
                            {
                                MessageBox.Show("no se puede borrar el Coche");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrido un error al borrar el Coche: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un Coche para borrar");
                    }
                }
            
        }

        private void btnBuscarCoche_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se encontro el coche");
        }

















        #region FuncionesVarias

        private void LlenarComboBox(ComboBox comboBox)
        {
            try
            {
                var lineas = BLLinea.Listar();
                comboBox.DataSource = null; // Limpiar cualquier DataSource anterior
                comboBox.Items.Clear(); // Limpiar elementos anteriores
                comboBox.DataSource = lineas; // Establecer nuevo DataSource
                comboBox.DisplayMember = "NumeroDeLinea"; // La propiedad que quieres mostrar
                comboBox.ValueMember = "ID_Linea"; // La propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void limpiarGrilla()
        {
            dtgCoches.DataSource = null;
            dtgCoches.DataSource = BLLCoche.Listar();
            dtgCoches.Columns["ID_Linea"].Visible = false;
            dtgCoches.Columns["DVH"].Visible = false;
        }

        private void limpiartxt()
        {
            txtPatente.Clear();          
        }

        public void CalcularDigitos()
        {
            string tabla = "Coche";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
        }
        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerCocheSeleccionado();
            
        }

        public BE.Coche ObtenerCocheSeleccionado()
        {
            if (dtgCoches.SelectedRows.Count > 0)
            {
                cocheSeleccionado = ((BE.Coche)dtgCoches.SelectedRows[0].DataBoundItem);
                this.CompletarCoche(cocheSeleccionado);
            }

            return cocheSeleccionado;
        }

        public void CompletarCoche(BE.Coche coche)
        {
            txtPatente.Text = coche.Patente;
            cmbLinea.SelectedValue = coche.ID_Linea;
            txtInterno.Text = (coche.Interno).ToString();
        }

    }


    #endregion








}

