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
using Image = iTextSharp.text.Image;


namespace ECSA
{
    public partial class UIBitacora : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        private int _IdiomaSeleccionado;
        public UIBitacora(List<Traduccion> traducciones)
        {
            InitializeComponent();
           dtgBitacora.DataSource= BLLSeguridad.Listar();
            StartPosition = FormStartPosition.CenterScreen;


            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 40:
                        btnBuscar.Text = traduccion.Descripcion;
                        break;
                    case 56:
                        btnDescargarBitacora.Text = traduccion.Descripcion;
                        break;
                    case 60:
                        lblDesde.Text = traduccion.Descripcion;
                        break;
                    case 62:
                        lblHasta.Text = traduccion.Descripcion;
                        break;
                    case 64:
                        lblBuscarUsuario.Text = traduccion.Descripcion;
                        break;
                    case 84:
                        dtgBitacora.Columns["ID_Bitacora"].HeaderText = traduccion.Descripcion;
                        break;
                    case 145:
                        dtgBitacora.Columns["Descripcion"].HeaderText = traduccion.Descripcion;
                        break;
                    case 146:
                        dtgBitacora.Columns["Fecha"].HeaderText = traduccion.Descripcion;
                        break;
                    case 147:
                        dtgBitacora.Columns["Criticidad"].HeaderText = traduccion.Descripcion;
                        break;
                    case 74:
                        dtgBitacora.Columns["NickUsuarioLogin"].HeaderText = traduccion.Descripcion;
                        break;
                } 
            }

            #endregion



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

        string logoPath = @"C:\\Users\\CASA\\Desktop\\ECSA\\ECSA\\colectivo.JPG"; // Ruta al logo
        private void btnDescargarBitacora_Click(object sender, EventArgs e)
        {          
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar archivo PDF";
                saveFileDialog.FileName = "BitacoraReport.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = saveFileDialog.FileName;

                        Document document = new Document(PageSize.A4.Rotate(), 10, 10, 80, 50); // Ajustar margen superior
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

                        // Asignamos el event handler antes de abrir el documento
                        PdfPageEventHelperCustom pageEventHelper = new PdfPageEventHelperCustom(logoPath);
                        writer.PageEvent = pageEventHelper;

                        document.Open();

                        // Inicializar el template para el total de páginas aquí
                        pageEventHelper.TotalPagesTemplate = writer.DirectContent.CreateTemplate(30, 16);

                        Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        Font fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                        PdfPTable table = new PdfPTable(dtgBitacora.Columns.Count - 1); // Excluye la última columna
                        table.WidthPercentage = 100;

                        // Agregar encabezados de columna (excluyendo la última columna)
                        for (int i = 0; i < dtgBitacora.Columns.Count - 1; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(dtgBitacora.Columns[i].HeaderText, fontHeader))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY
                            };
                            table.AddCell(cell);
                        }
                        table.HeaderRows = 1;
                        // Agregar filas de datos (excluyendo la última columna)
                        foreach (DataGridViewRow row in dtgBitacora.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dtgBitacora.Columns.Count - 1; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? string.Empty;
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontCell))
                                {
                                    NoWrap = false
                                };
                                table.AddCell(pdfCell);
                            }
                        }

                        document.Add(table);

                        document.Close(); // Cerrar el documento antes de añadir la página total

                        // Añadir número total de páginas en el pie de página
                        pageEventHelper.AddTotalPagesToFooter(writer, pageEventHelper.TotalPagesTemplate);

                        MessageBox.Show("PDF guardado exitosamente como " + filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el PDF: " + ex.Message);
                    }
                }
            }
        }
    }

    public class PdfPageEventHelperCustom : PdfPageEventHelper
    {
        private readonly string _logoPath;
        private readonly Font _footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
        public PdfTemplate TotalPagesTemplate { get; set; }

        public PdfPageEventHelperCustom(string logoPath)
        {
            _logoPath = logoPath;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            TotalPagesTemplate = writer.DirectContent.CreateTemplate(50, 50);
        }


        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Encabezado
            PdfPTable headerTable = new PdfPTable(3);
            headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            headerTable.SetWidths(new float[] { 1, 2, 1 });

            if (File.Exists(_logoPath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(_logoPath);
                logo.ScaleToFit(50f, 50f);
                PdfPCell logoCell = new PdfPCell(logo)
                {
                    Border = PdfPCell.NO_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                headerTable.AddCell(logoCell);
            }
            else
            {
                headerTable.AddCell("");
            }

            PdfPCell titleCell = new PdfPCell(new Phrase("Reporte de Bitácora", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            headerTable.AddCell(titleCell);

            PdfPCell dateCell = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            headerTable.AddCell(dateCell);

            headerTable.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.Height - 30, writer.DirectContent);

            // Pie de página con espacio para el número total de páginas
            PdfPTable footerTable = new PdfPTable(1);
            footerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

            PdfPCell footerCell = new PdfPCell(new Phrase($"Hoja {writer.PageNumber} de ", _footerFont))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_LEFT
            };

            // Aquí añadimos el template para el número total de páginas
            footerCell.Phrase.Add(new Chunk(Image.GetInstance(TotalPagesTemplate), 0, 0, true));

            footerTable.AddCell(footerCell);
            footerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 15, writer.DirectContent);
        }



       

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            int totalPages = writer.PageNumber;
            ColumnText.ShowTextAligned(
             TotalPagesTemplate,
             Element.ALIGN_LEFT, // Asegura que esté alineado a la izquierda
             new Phrase(totalPages.ToString(), _footerFont), // Asegura que el tamaño sea el mismo
             2, 0, 0
           
            );
        }
     


        public void AddTotalPagesToFooter(PdfWriter writer, PdfTemplate totalPagesTemplate)
        {
            int totalPages = writer.PageNumber;
            ColumnText.ShowTextAligned(
                totalPagesTemplate,
                Element.ALIGN_LEFT,
                new Phrase(totalPages.ToString()),  // Mostrar el número total de páginas
                2,
                2,
                0
            );
        }










    }

}

























