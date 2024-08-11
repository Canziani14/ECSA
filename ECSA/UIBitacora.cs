using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;


namespace ECSA
{
    public partial class UIBitacora : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        public UIBitacora()
        {
            InitializeComponent();
           dtgBitacora.DataSource= BLLSeguridad.Listar();


            #region Perzonalizacion DTG
            dtgBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgBitacora.Columns["ID_Usuario"].Visible = false;
            dtgBitacora.Columns["DVH"].Visible = false;

            dtgBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgBitacora.ReadOnly = true;
            dtgBitacora.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgBitacora.BorderStyle = BorderStyle.None;
            dtgBitacora.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgBitacora.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgBitacora.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgBitacora.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgBitacora.EnableHeadersVisualStyles = false;
            dtgBitacora.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgBitacora.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgBitacora.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgBitacora.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgBitacora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgBitacora.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);


            // Ajuste de los márgenes y bordes
            dtgBitacora.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgBitacora.GridColor = Color.FromArgb(231, 231, 231);
            #endregion


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener los valores del DateTimePicker y TextBox
            string fechaDesde = DateDesde.Value.ToString("yyyy-MM-dd");
            string fechaHasta = DateHasta.Value.ToString("yyyy-MM-dd");
            string usuario = txtBuscarUsuario.Text;

            // Realizar la búsqueda
            List<Bitacora> bitacoras = BLLSeguridad.BuscarEnBitacora(fechaDesde, fechaHasta, usuario);

            // Verificar si se encontraron bitacoras
            if (bitacoras != null && bitacoras.Count > 0)
            {
                // Mostrar los resultados en el DataGridView
                dtgBitacora.DataSource = bitacoras;
            }
            else
            {
                // Mostrar mensaje de no encontrado y limpiar el DataGridView
                MessageBox.Show("Bitacoras no encontradas.");
                dtgBitacora.DataSource = null;
            }
        }
        

        private void btnDescargarBitacora_Click(object sender, EventArgs e)
        {
            // Crear un SaveFileDialog para permitir al usuario elegir la ubicación del archivo
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar archivo PDF";
                saveFileDialog.FileName = "BitacoraReport.pdf";

                // Mostrar el cuadro de diálogo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtener la ruta del archivo seleccionado
                        string filename = saveFileDialog.FileName;

                        // Crear el documento PDF
                        Document document = new Document();
                        PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                        document.Open();

                        // Configurar fuentes y estilos
                        Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                        Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        Font fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                        // Agregar título
                        Paragraph title = new Paragraph("Reporte de Bitácora", fontTitle);
                        title.Alignment = Element.ALIGN_CENTER;
                        document.Add(title);
                        document.Add(new Paragraph("\n")); // Espacio después del título

                        // Crear tabla para los datos
                        PdfPTable table = new PdfPTable(dtgBitacora.Columns.Count);

                        // Agregar encabezados de columna
                        foreach (DataGridViewColumn column in dtgBitacora.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }

                        // Agregar filas de datos
                        foreach (DataGridViewRow row in dtgBitacora.Rows)
                        {
                            if (row.IsNewRow) continue; // Ignorar la fila nueva

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string cellValue = cell.Value?.ToString() ?? string.Empty;
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontCell))
                                {
                                    NoWrap = false // Permite que el texto se ajuste automáticamente
                                };
                                table.AddCell(pdfCell);
                            }
                        }

                        document.Add(table);
                        document.Close();

                        // Mostrar mensaje de éxito
                        MessageBox.Show("PDF guardado exitosamente como " + filename);
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores
                        MessageBox.Show("Error al guardar el PDF: " + ex.Message);
                    }
                }
            }
        }
    }
}
