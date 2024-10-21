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
        public UIGestionarFamilias(BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            InitializeComponent();
            dtgFamilias.DataSource= BLLFamilia.Listar();
            this.usuarioLog = usuarioLog;
            StartPosition = FormStartPosition.CenterScreen;
            dtgFamilias.Columns["ID_Usuario"].Visible = false;
            dtgFamilias.Columns["ID_Patente"].Visible = false;

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
           /* if (txtNombreLinea.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }*/
            try
            {

                BEFamilia.Descripcion = txtNombreFamilia.Text;


                if (BLLFamilia.ValidarNombreFamilia(BEFamilia.Descripcion).Count > 0)
                {
                    MessageBox.Show("Nombre de familia ya utilizado");
                }
                else
                {
                    if (BLLFamilia.Crear(BEFamilia))
                    {
                        BLLSeguridad.RegistrarEnBitacora(12, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Familia creada con éxito");                       
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear la familia");
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
                        MessageBox.Show("familia modificada con exito");
                        limpiarGrilla();
                        limpiartxt();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la familia");
                    }

                }
                catch (FormatException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una familia para modificar");
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
                        MessageBox.Show("No se puede eliminar la familia porque contiene patentes únicas que están asignadas solo a un usuario.");
                        return; // Salir del método si no se puede eliminar
                    }

                    bool familiaEliminada = false;

                    try
                    {
                        // Intentar eliminar la familia
                        familiaEliminada = BLLFamilia.Eliminar(familiaSeleccionada);

                        if (familiaEliminada)
                        {
                            MessageBox.Show("Familia eliminada correctamente");
                            BLLSeguridad.RegistrarEnBitacora(13, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            limpiarGrilla();
                            limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("No se puede borrar la familia");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar la familia: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una familia para borrar");
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
                        MessageBox.Show("No se puede eliminar la patente porque es la única asignada a esta familia.",
                                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir del método sin hacer nada
                    }
                    BLLFamilia.QuitarXFamilia(id_Familia, id_Patente);
                    dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(id_Familia, id_Patente);
                    dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(id_Familia, id_Patente);

                    CalcularDigitos();
                    MessageBox.Show("Patente quitada de la familia correctamente");

                }

        
        

        private void ActualizarDataGridViewsFamilia(int id_Familia, int id_Patente)
        {
            dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(id_Familia, id_Patente);
            dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(id_Familia, id_Patente);
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
            MessageBox.Show("Patente asignada a la familia correctamente");
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
                MessageBox.Show("seleccione uan fila");
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
            string tabla = "Familia_Patente";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
        }

    }
}
