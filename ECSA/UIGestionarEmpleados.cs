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
       


        public UIGestionarEmpleados()
        {
            InitializeComponent();
            dtgEmpleados.DataSource = BLLEmpleado.Listar();
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
                BEEmpleado.DNI = int.Parse(txtDNI.Text);
                BEEmpleado.Direccion = txtDireccion.Text;
                BEEmpleado.Telefono = txtTelefono.Text;
                BEEmpleado.LineaPertenece = int.Parse(cmbLinea.Text);
                BEEmpleado.FechaDeingreso = DateTime.Parse(txtFechadeIngreso.Text);



                if (BLLEmpleado.Crear(BEEmpleado))
                {
                    MessageBox.Show("Empleado creado con éxito");
                }
                else
                {
                    MessageBox.Show("No se pudo crear el empleado");
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
                        Nombre = txtNombre.Text ,
                        Apellido = txtApellido.Text ,
                        DNI = int.Parse(txtDNI.Text) ,
                        Direccion = txtDireccion.Text ,
                        Telefono= txtTelefono.Text,
                        LineaPertenece= int.Parse(cmbLinea.Text) ,
                        FechaDeingreso = DateTime.Parse( txtFechadeIngreso.Text),
                        Legajo = int.Parse(txtLegajo.Text),
                }
            ))
                    {
                        MessageBox.Show("Empleado modificado con exito");
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
            MessageBox.Show("No se encontro el empleado");
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
        #endregion

       
    }
}
