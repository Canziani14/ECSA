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
    public partial class UIGestionarEmpleados : Form
    {
        #region Inicializaciones

        BE.Empleado BEEmpleado = new BE.Empleado();
        BE.Empleado EmpleadoSeleccionado = new BE.Empleado();
        BLL.ABM_Empleado BLLEmpleado = new BLL.ABM_Empleado();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BLL.BLL_ABM_Linea BLLinea = new BLL.BLL_ABM_Linea();
        private BE.Usuario usuarioLog;

        public UIGestionarEmpleados(BE.Usuario usuarioLog)
        {
            InitializeComponent();
            dtgEmpleados.DataSource = BLLEmpleado.Listar();
            this.usuarioLog = usuarioLog;
            LlenarComboBox(cmbLinea);


            #region Perzonalizacion DTG
            dtgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgEmpleados.Columns["DVH"].Visible = false;
            dtgEmpleados.Columns["LineaPertenece"].Visible = false;
            dtgEmpleados.Columns["ServicioAsignado"].Visible = false;

            dtgEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEmpleados.ReadOnly = true;
            dtgEmpleados.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgEmpleados.BorderStyle = BorderStyle.None;
            dtgEmpleados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgEmpleados.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgEmpleados.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgEmpleados.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgEmpleados.EnableHeadersVisualStyles = false;
            dtgEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgEmpleados.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgEmpleados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgEmpleados.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgEmpleados.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgEmpleados.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
            txtNombre.Font = new Font("Arial", 10F, FontStyle.Regular);
            txtNombre.ForeColor = Color.Black;
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;


        }
        #endregion

        #region CrearEmpleado
        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            try
            {

                BEEmpleado.Nombre = txtNombre.Text;
                BEEmpleado.Apellido = txtApellido.Text;
                BEEmpleado.DNI = BLLSeguridad.EncriptarCamposReversible(txtDNI.Text);
                BEEmpleado.Direccion = BLLSeguridad.EncriptarCamposReversible(txtDireccion.Text);
                BEEmpleado.Telefono = BLLSeguridad.EncriptarCamposReversible(txtTelefono.Text);
                BEEmpleado.LineaPertenece = int.Parse(cmbLinea.Text);
                BEEmpleado.FechaDeingreso = DateTime.Parse(txtFechadeIngreso.Text);
                if (cmbLinea.SelectedValue != null)
                {

                    BEEmpleado.LineaPertenece = (int)cmbLinea.SelectedValue;
                    
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una línea válida.");
                }

                if (BLLEmpleado.ValidarDNI(BEEmpleado.DNI).Count > 0)
                {
                    MessageBox.Show("DNI ya en uso");
                }
                else
                {
                    if (BLLEmpleado.Crear(BEEmpleado))
                    {
                        BLLSeguridad.RegistrarEnBitacora(15, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Empleado creado con éxito");
                        CalcularDigitos();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el empleado");
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

        #region ModificarEmpleado
        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado != null)
            {
                try
                {
                    if (BLLEmpleado.Modificar(new BE.Empleado()
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        DNI = BLLSeguridad.EncriptarCamposReversible(txtDNI.Text),
                        Direccion = BLLSeguridad.EncriptarCamposReversible(txtDireccion.Text),
                        Telefono = BLLSeguridad.EncriptarCamposReversible(txtTelefono.Text),
                        LineaPertenece = int.Parse(cmbLinea.Text),
                        FechaDeingreso = DateTime.Parse(txtFechadeIngreso.Text),
                        Legajo = int.Parse(txtLegajo.Text),
                    }
            ))
                    {
                        BLLSeguridad.RegistrarEnBitacora(16, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Empleado modificado con exito");
                        CalcularDigitos();
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el empleado");
                    }

                }
                catch (FormatException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para modificar");
            }
        }

        private void dtgEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerEmpleadoSeleccionado();
        }


        public BE.Empleado ObtenerEmpleadoSeleccionado()
        {
            if (dtgEmpleados.SelectedRows.Count > 0)
            {
                EmpleadoSeleccionado = ((BE.Empleado)dtgEmpleados.SelectedRows[0].DataBoundItem);
                this.CompletarEmpleado(EmpleadoSeleccionado);
            }

            return EmpleadoSeleccionado;
        }


        public void CompletarEmpleado(BE.Empleado empleado)
        {
            txtNombre.Text = empleado.Nombre;
            txtApellido.Text = empleado.Apellido;
            txtDNI.Text = empleado.DNI.ToString();
            txtDireccion.Text = empleado.Direccion;
            txtTelefono.Text = empleado.Telefono;
            cmbLinea.Text = empleado.LineaPertenece.ToString();
            txtFechadeIngreso.Text = empleado.FechaDeingreso.ToString("yyyy-MM-dd");
            txtLegajo.Text = empleado.Legajo.ToString();
        }
        #endregion

        #region EliminarEmpleado
        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este empleado?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (EmpleadoSeleccionado != null)
                {
                    bool EmpleadoEliminado = BLLEmpleado.Eliminar(EmpleadoSeleccionado);

                    try
                    {
                        if (EmpleadoEliminado)
                        {
                            BLLSeguridad.RegistrarEnBitacora(17, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede borrar el empleado");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar el empleado: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un empleado para borrar");
                }
            }

        }
        #endregion

        #region BuscarEmlpeado
        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
           
            if (int.TryParse(txtBuscarEmpleado.Text, out int legajo))
            {
                // Perform the search using the parsed legajo
                List<BE.Empleado> empleados = BLLEmpleado.Buscar(legajo);

                if (empleados != null && empleados.Count > 0)
                {
                    dtgEmpleados.DataSource = empleados;
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                    dtgEmpleados.DataSource = empleados;
                }
            }
            else
            {
                // Show error message if the input is not a valid integer
                MessageBox.Show("Por favor, ingrese un número de legajo válido.");
                dtgEmpleados.DataSource = null;
            }
        }


        #endregion

        #region FuncionesVarias
        private void limpiarGrilla()
        {
            dtgEmpleados.DataSource = null;
            dtgEmpleados.DataSource = BLLEmpleado.Listar();
        }

        private void limpiartxt()
        {

            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNombre.Clear();
        }

        public void CalcularDigitos()
        {
            string tabla = "Empleado";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
        }

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

        #endregion



    }


}

