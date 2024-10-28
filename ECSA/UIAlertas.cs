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
    public partial class UIAlertas : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        public UIAlertas(List<Traduccion> traducciones)
        {
            InitializeComponent();
            dtgAlertas.DataSource = BLLSeguridad.ListarCrit3();

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 138:
                        lblAlertasCriticidad.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        dtgAlertas.Columns["ID_Bitacora"].HeaderText = traduccion.Descripcion;
                        break;
                    case 145:
                        dtgAlertas.Columns["Descripcion"].HeaderText = traduccion.Descripcion; 
                        break;
                    case 146:
                        dtgAlertas.Columns["Fecha"].HeaderText = traduccion.Descripcion;
                        break;
                    case 147:
                        dtgAlertas.Columns["Criticidad"].HeaderText = traduccion.Descripcion;  
                        break;
                    case 74:
                        dtgAlertas.Columns["NickUsuarioLogin"].HeaderText = traduccion.Descripcion;
                        break;
                }

            }

            #endregion


            #region Perzonalizacion DTG
            dtgAlertas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgAlertas.Columns["DVH"].Visible = false;
            dtgAlertas.Columns["ID_Usuario"].Visible = false;

            dtgAlertas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgAlertas.ReadOnly = true;
            dtgAlertas.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgAlertas.BorderStyle = BorderStyle.None;
            dtgAlertas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgAlertas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgAlertas.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgAlertas.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgAlertas.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgAlertas.EnableHeadersVisualStyles = false;
            dtgAlertas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgAlertas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgAlertas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgAlertas.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgAlertas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgAlertas.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgAlertas.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgAlertas.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
        }
    }
}
