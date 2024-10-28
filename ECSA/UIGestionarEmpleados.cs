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
using Bogus;

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

        public UIGestionarEmpleados(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dtgEmpleados.DataSource = BLLEmpleado.Listar();
            this.usuarioLog = usuarioLog;
            LlenarComboBox(cmbLinea);

            #region idioma
            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 6:
                        btnCrearEmpleado.Text = traduccion.Descripcion;
                        break;
                    case 8:
                        btnEliminarEmpleado.Text = traduccion.Descripcion;
                        break;
                    case 4:
                        btnModificarEmpleado.Text = traduccion.Descripcion;
                        break;
                    case 40:
                        btnBuscarEmpleado.Text = traduccion.Descripcion;
                        break;
                    case 108:
                        lblBuscarEmpleado.Text = traduccion.Descripcion;
                        break;
                    case 68:
                        lblNombre.Text = traduccion.Descripcion;
                        break;
                    case 70:
                        lblApellido.Text = traduccion.Descripcion;
                        break;
                    case 72:
                        lblDNI.Text = traduccion.Descripcion;
                        break;
                    case 110:
                        lblDireccion.Text = traduccion.Descripcion;
                        break;
                    case 112:
                        lblTelefono.Text = traduccion.Descripcion;
                        break;
                    case 86:
                        lblLinea.Text = traduccion.Descripcion;
                        break;
                    case 114:
                        lblFechaDeIngreo.Text = traduccion.Descripcion;
                        break;
                    case 116:
                        lblLegajo.Text = traduccion.Descripcion;
                        break;
                    case 12:
                        gbGestorEmpleados.Text = traduccion.Descripcion;
                        break;
                }
            }

            #endregion



            #region patente
            btnCrearEmpleado.Enabled = false;
            btnEliminarEmpleado.Enabled = false;
            btnModificarEmpleado.Enabled=false;

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 6:
                        btnCrearEmpleado.Enabled = true;
                        break;
                    case 8:
                        btnEliminarEmpleado.Enabled = true;
                        break;
                    case 7:
                        btnModificarEmpleado.Enabled = true;
                        break;
                    case 9:
                        btnBuscarEmpleado.Enabled = true;
                        break;
                }
            }

            #endregion



            #region Perzonalizacion DTG
            dtgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgEmpleados.Columns["DVH"].Visible = false;
            dtgEmpleados.Columns["LineaPertenece"].Visible = false;
            

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
                BEEmpleado.Eliminado = true;
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
                dtgEmpleados.DataSource = BLLEmpleado.Listar();
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
                        LineaPertenece = (int)cmbLinea.SelectedValue,
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
                        dtgEmpleados.DataSource = BLLEmpleado.Listar();
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
            LlenarComboBox(cmbLinea);
            cmbLinea.SelectedValue = empleado.LineaPertenece;
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
                            CalcularDigitos();
                            BLLSeguridad.RegistrarEnBitacora(17, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            limpiarGrilla();
                            limpiartxt();
                            dtgEmpleados.DataSource = BLLEmpleado.Listar();
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

        private void btnRecuperarEmlpeado_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de recuperar este empleado?", "Confirmación de recuperacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (EmpleadoSeleccionado != null)
                {
                    bool EmpleadoRecuperado = BLLEmpleado.RecuperarUsuario(EmpleadoSeleccionado);

                    try
                    {
                        if (EmpleadoRecuperado)
                        {
                            //ver agregar recuperar empleado en bitacora
                            BLLSeguridad.RegistrarEnBitacora(38, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            MessageBox.Show("Usuario Recuperado");
                            CalcularDigitos();
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede recuperar el empleado");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al recuperar el empleado: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para recuperar");
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
            dtgEmpleados.Columns["ID_Linea"].Visible = false;
            dtgEmpleados.Columns["DVH"].Visible = false;
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



    private void button1_Click(object sender, EventArgs e)
        {
            var faker = new Faker<BE.Empleado>()
                .RuleFor(employee => employee.Nombre, f => f.Name.FirstName())
                .RuleFor(employee => employee.Apellido, f => f.Name.LastName())
                .RuleFor(employee => employee.DNI, f => BLLSeguridad.EncriptarCamposReversible(f.Random.Number(10000000, 99999999).ToString()))
                .RuleFor(employee => employee.Direccion, f => BLLSeguridad.EncriptarCamposReversible(f.Address.StreetAddress()))
                .RuleFor(employee => employee.Telefono, f => BLLSeguridad.EncriptarCamposReversible(f.Phone.PhoneNumber()))
                .RuleFor(employee => employee.FechaDeingreso, f => f.Date.Past())
                .RuleFor(employee => employee.LineaPertenece, f => f.PickRandom(new[] { 1, 7, 8 })) // Seleccionar entre líneas 1, 7 y 8
                 .RuleFor(employee => employee.DVH, f => 0)
                .Generate(150);

            // Insertar los empleados en la base de datos
            foreach (var empleado in faker)
            {
                BLLEmpleado.Crear(empleado);
            }
        }




    }


}

