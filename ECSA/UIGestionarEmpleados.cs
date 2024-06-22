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

        BE.Empleado BEEmpleado = new BE.Empleado();
        BE.Empleado EmpleadoSeleccionado = new BE.Empleado();
        BLL.ABM_Empleado BLLEmpleado = new BLL.ABM_Empleado();
       


        public UIGestionarEmpleados()
        {
            InitializeComponent();
            dtgEmpleados.DataSource = BLLEmpleado.Listar();
        }

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

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Empleado modificado con exito");
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este empleado?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Empleado eliminado con exito");
            }
            
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se encontro el empleado");
        }






        private void limpiarGrilla()
        {
            dtgEmpleados.DataSource = null;
            dtgEmpleados.DataSource = BLLEmpleado.Listar();//AgendaSeleccionada.ID);
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

    }
}
