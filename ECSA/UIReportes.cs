using BE;
using BLL;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

namespace ECSA
{
    public partial class UIReportes : Form
    {
        public UIReportes(List<Traduccion> traducciones)
        {
            InitializeComponent();

            LlenarComboBox(CMBLineas);

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
            //dtgReportes.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgReportes.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgReportes.GridColor = Color.FromArgb(231, 231, 231);
            #endregion
        }
        
        BLL_ABM_Servicio BLLServicio = new BLL_ABM_Servicio();
        BLL_ABM_Linea BLLLinea = new BLL_ABM_Linea();
        private void button1_Click(object sender, EventArgs e)
        {
           
            string date1F = date1.Value.ToString("yyyy-MM-dd");
            string date2F = date2.Value.ToString("yyyy-MM-dd");
            

            // Verifica si se seleccionó una línea en el ComboBox
            if (CMBLineas.SelectedValue != null)
            {
                try
                {
                    // Obtén el ID de la línea seleccionada y llámalo en el método Listar
                    int idLinea = (int)CMBLineas.SelectedValue;

                    // Llama al método Listar de la capa BLL y asigna los datos a la tabla
                    dtgReportes.DataSource = BLLServicio.Listar(idLinea, date1F, date2F);
                    dtgReportes.Columns["DVH"].Visible = false;
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje en caso de error
                    MessageBox.Show("Error al listar los servicios: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una línea válida.");
            }
        }








        private void LlenarComboBox(ComboBox comboBox)
        {
            try
            {
              
                var lineas = BLLLinea.Listar();
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



        private void btnDescargar_Click(object sender, EventArgs e)
        {
            string logoPath = @"C:\\Users\\CASA\\Desktop\\ECSA\\ECSA\\colectivo.JPG"; // Ruta al logo (ajustar según sea necesario)

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar archivo PDF";
                saveFileDialog.FileName = "ReporteServicios.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = saveFileDialog.FileName;

                        Document document = new Document(PageSize.A4.Rotate(), 10, 10, 80, 50); // Ajustar margen superior
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

                        // Clase para gestionar el encabezado y pie de página
                        PdfPageEventHelperCustom pageEventHelper = new PdfPageEventHelperCustom(logoPath, "Reporte de Servicios");
                        writer.PageEvent = pageEventHelper;

                        document.Open();

                        // Inicializar el template para el total de páginas aquí
                        pageEventHelper.TotalPagesTemplate = writer.DirectContent.CreateTemplate(30, 16);

                        Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        Font fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                        PdfPTable table = new PdfPTable(dtgReportes.Columns.Count); // Asegúrate de incluir todas las columnas
                        table.WidthPercentage = 100;

                        // Agregar encabezados de columna
                        for (int i = 0; i < dtgReportes.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(dtgReportes.Columns[i].HeaderText, fontHeader))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY
                            };
                            table.AddCell(cell);
                        }

                        table.HeaderRows = 1;

                        // Agregar filas de datos
                        foreach (DataGridViewRow row in dtgReportes.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dtgReportes.Columns.Count; i++)
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

                        string pdfEspañol = "PDF guardado exitosamente como " + filename;
                        string pdfIngles = "PDF successfully saved as " + filename;
                        if (lblDesde.Text == "From:")
                        {
                            UINotificacion UINoti = new UINotificacion(pdfIngles, 2)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálog
                        }
                        else
                        {
                            UINotificacion UINoti = new UINotificacion(pdfEspañol, 1)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálogo modal
                        }
                    }
                    catch (Exception ex)
                    {
                    
                        string pdfEspañol1 = "Error al guardar el PDF: " + ex.Message;
                        string pdfIngles2 = "Error saving PDF: " + ex.Message;
                        if (lblDesde.Text == "From:")
                        {
                            UINotificacion UINoti = new UINotificacion(pdfIngles2, 2)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálog
                        }
                        else
                        {
                            UINotificacion UINoti = new UINotificacion(pdfEspañol1, 1)
                            {
                                StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                                TopMost = true // Siempre visible encima de otras ventanas
                            };
                            UINoti.ShowDialog(); // Mostrar como diálogo modal
                        }
                    }
                }
            }
        }

    // Clase para gestionar el encabezado y pie de página
    public class PdfPageEventHelperCustom : PdfPageEventHelper
        {
            private readonly string _logoPath;
            private readonly string _title; // Añadir variable para el título
            private readonly Font _footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            public PdfTemplate TotalPagesTemplate { get; set; }

            public PdfPageEventHelperCustom(string logoPath, string title) // Añadir parámetro para el título
            {
                _logoPath = logoPath;
                _title = title; // Asignar el título recibido
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
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

                // Usar la variable _title para definir el título del encabezado
                PdfPCell titleCell = new PdfPCell(new Phrase(_title, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
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
            }

            public void AddTotalPagesToFooter(PdfWriter writer, PdfTemplate template)
            {
                int pageNumber = writer.PageNumber;
                template.BeginText();
                template.SetFontAndSize(_footerFont.BaseFont, 10);
                template.ShowText(pageNumber.ToString());
                template.EndText();
                writer.DirectContent.AddTemplate(template, writer.PageSize.GetRight(50), writer.PageSize.GetBottom(30));
            }
        }
    }



}
  
