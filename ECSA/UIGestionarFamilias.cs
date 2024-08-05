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
       
        public UIGestionarFamilias()
        {
            InitializeComponent();
           dtgFamilias.DataSource= BLLFamilia.Listar();
        }


        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Familia creada con éxito");
        }

        private void btnModificarFamilia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Familia modificada con éxito");
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar esta familia?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Familia eliminada con éxito");
            }
            
        }

        private void dtgPatentesActuales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
            ObtenerPatenteSeleccionadaActuales();
            ObtenerFamiliaSeleccionado();
            int id_Familia = familiaSeleccionada.ID_Familia;
            int id_Patente = PatenteSeleccionadaQuitar.ID_Patente;
            BLLFamilia.QuitarXFamilia(id_Familia, id_Patente);
            dtgPatentesActuales.DataSource = BLLFamilia.ListarActualesXFamilia(id_Familia, id_Patente);
            dtgPatentesSinAsignar.DataSource = BLLFamilia.ListarSinAsignarXFamilia(id_Familia, id_Patente);
            MessageBox.Show("Patente quitada de la familia correctamente");
            
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
        }
    }
}
