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
    public partial class UIReportes : Form
    {
        public UIReportes(List<Traduccion> traducciones)
        {
            InitializeComponent();

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 12:
                        btnReporte.Text = traduccion.Descripcion;
                        break;
                   /* case 10:
                        lblSeleccionarReporte.Text = traduccion.Descripcion;
                        break;*/
                    case 60:
                        lblDesde.Text = traduccion.Descripcion;
                        break;
                    case 62:
                        lblHasta.Text = traduccion.Descripcion;
                        break;

                }
            }

            #endregion

            #region Perzonalizacion DTG

            dtgReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgReportes.ReadOnly = true;
            dtgReportes.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgReportes.BorderStyle = BorderStyle.None;
            dtgReportes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgReportes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgReportes.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgReportes.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgReportes.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgReportes.EnableHeadersVisualStyles = false;
            dtgReportes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgReportes.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgReportes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgReportes.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgReportes.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgReportes.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
