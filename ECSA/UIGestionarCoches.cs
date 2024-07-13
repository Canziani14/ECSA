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
      
        public UIGestionarCoches()
        {
            InitializeComponent();
            dtgCoches.DataSource= BLLCoche.Listar();
            LlenarComboBox(cmbLinea);
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
                    MessageBox.Show("Línea guardada con éxito. ID: " + BECoche.ID_Linea);
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una línea válida.");
                }
                

                if (BLLCoche.Crear(BECoche))
                {
                    MessageBox.Show("Coche creado con éxito");
                    CalcularDigitos();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el Coche");
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

