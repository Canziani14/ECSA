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
        public UIGestionarLinea(BE.Usuario usuarioLog)
        {
            InitializeComponent();
            dtgLineas.DataSource = BLLinea.Listar();
            this.usuarioLog = usuarioLog;
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
                       
                    }
            ))
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
            UIGestionarCoches uiGestionarCoches = new UIGestionarCoches(usuarioLog);
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
                UIGestionarServicios uiGestionarServicios = new UIGestionarServicios(IDLinea, NombreLinea, usuarioLog);
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

