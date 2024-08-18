using BE;
using BLL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;

namespace ECSA
{
    public partial class UIGestionarServicios : Form
    {
        BLL.BLL_ABM_Servicio BLLServicios = new BLL.BLL_ABM_Servicio();
        BLL.ABM_Empleado BLLEempleado = new ABM_Empleado();
        BLL_ABM_Coche BLLCoche = new BLL_ABM_Coche();
        BE.Servicio BEServicio = new BE.Servicio();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BE.Servicio servicioSeleccionado = new BE.Servicio();
        private BE.Usuario usuarioLog;
        public UIGestionarServicios(int linea, string nombreLinea, BE.Usuario usuarioLog, List<Patente> patentes)
        {
            InitializeComponent();
            txtIDLinea.Text = (linea).ToString();
            txtNombreLinea.Text = nombreLinea;

            dtgServicios.DataSource = BLLServicios.Listar(linea);
            BEServicio.Linea = linea;
            this.usuarioLog = usuarioLog;
            LlenarComboBoxConductor(cmbConductor);
            LlenarComboBoxInternos(cmbInterno);

            btnCrearServicio.Enabled = false;
            btnModificarServicio.Enabled=false;
            btnEliminarServicio.Enabled = false;
            btnAsignarServicio.Enabled = false;
            btnImprimir.Enabled = false;

            foreach (var patente in patentes)
            {
                switch (patente.ID_Patente)
                {
                    case 18:
                        btnCrearServicio.Enabled = true;
                        break;
                    case 19:
                        btnModificarServicio.Enabled = true;
                        break;
                    case 20:
                        btnEliminarServicio.Enabled = true;
                        break;
                    case 22:
                        btnAsignarServicio.Enabled = true;
                        break;
                    case 46:
                        btnImprimir.Enabled = true;
                        break;               
                }

            }

            #region Perzonalizacion DTG
            dtgServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgServicios.Columns["DVH"].Visible = false;
            dtgServicios.Columns["Linea"].Visible = false;

            dtgServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgServicios.ReadOnly = true;
            dtgServicios.RowHeadersVisible = false;
            // Configuración básica para DataGridView
            dtgServicios.BorderStyle = BorderStyle.None;
            dtgServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtgServicios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgServicios.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtgServicios.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtgServicios.BackgroundColor = Color.White;

            // Configuración del estilo de los encabezados de columna
            dtgServicios.EnableHeadersVisualStyles = false;
            dtgServicios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgServicios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtgServicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajuste de la altura de las filas
            dtgServicios.RowTemplate.Height = 40;

            // Configuración de alineación y fuente de las celdas
            dtgServicios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgServicios.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);

            // Ajuste de los márgenes y bordes
            dtgServicios.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dtgServicios.GridColor = Color.FromArgb(231, 231, 231);
            #endregion





        }

        #region ABM-Servicios

        private void btnCrearServicio_Click(object sender, EventArgs e)
        {

            if (date1.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            try
            {
                try
                {
                    BEServicio.HorarioSalida = DateTime.Parse(date1.Text);
                    BEServicio.HorarioLlegada = DateTime.Parse(date2.Text);
                    BEServicio.LegajoEmpleado = 0;
                    BEServicio.Coche = 0;

                    
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Formato de hora inválido: " + ex.Message);
                }

                bool validacionFallida = false;
                // Validar Conductor
                if (BLLServicios.ValidarConductor(BEServicio.LegajoEmpleado).Count > 0)
                {
                    MessageBox.Show("Conductor ya utilizado");
                    validacionFallida = true;
                }

                // Validar Interno
                if (BLLServicios.ValidarInterno(BEServicio.Coche).Count > 0)
                {
                    MessageBox.Show("Interno ya utilizado");
                    validacionFallida = true;
                }

                // Validar Horario
                if (BLLServicios.ValidarHorario(BEServicio.HorarioSalida).Count > 0)
                {
                    MessageBox.Show("Horario ya utilizado");
                    validacionFallida = true;
                }

                // Si todas las validaciones pasaron, crear el usuario
                if (!validacionFallida)
                {

                    if (BLLServicios.Crear(BEServicio))
                {
                    BLLSeguridad.RegistrarEnBitacora(25, usuarioLog.Nick, usuarioLog.ID_Usuario);
                    MessageBox.Show("Servicio creado con éxito");
                    CalcularDigitos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el servicio");
                    }
                }

                limpiarGrilla();
                //limpiartxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void btnModificarServicio_Click(object sender, EventArgs e)
        {
            if (servicioSeleccionado != null)
            {
                try
                {
                    DateTime horarioSalida, horarioLlegada;

                    // Convertir texto HH:mm a DateTime
                    if (!DateTime.TryParseExact(date1.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horarioSalida))
                    {
                        MessageBox.Show("Formato de hora de salida inválido. Formato esperado: HH:mm");
                        return;
                    }

                    if (!DateTime.TryParseExact(date2.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horarioLlegada))
                    {
                        MessageBox.Show("Formato de hora de llegada inválido. Formato esperado: HH:mm");
                        return;
                    }

                    // Crear objeto BE.Servicio con los valores actualizados
                    BE.Servicio servicioModificado = new BE.Servicio()
                    {
                        ID_Servicio = servicioSeleccionado.ID_Servicio,
                        // Aquí asumimos que servicioSeleccionado.HorarioSalida y HorarioLlegada son DateTime completos
                        // Si solo tienes la hora en servicioSeleccionado.HorarioSalida, deberías construir un DateTime nuevo
                        HorarioSalida = new DateTime(servicioSeleccionado.HorarioSalida.Year, servicioSeleccionado.HorarioSalida.Month, servicioSeleccionado.HorarioSalida.Day, horarioSalida.Hour, horarioSalida.Minute, 0),
                        HorarioLlegada = new DateTime(servicioSeleccionado.HorarioLlegada.Year, servicioSeleccionado.HorarioLlegada.Month, servicioSeleccionado.HorarioLlegada.Day, horarioLlegada.Hour, horarioLlegada.Minute, 0),
                        Linea = servicioSeleccionado.Linea
                    };

                    // Intenta modificar el servicio en la base de datos
                    if (BLLServicios.Modificar(servicioModificado))
                    {
                        BLLSeguridad.RegistrarEnBitacora(23, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Servicio modificado con éxito");
                        CalcularDigitos();
                        limpiarGrilla();
                        // Actualizar la interfaz con los datos modificados si es necesario
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el servicio");
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error al convertir la hora: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio para modificar");
            }

        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de eliminar este servicio?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {

                if (servicioSeleccionado != null)
                {
                    bool LineaEliminada = BLLServicios.Eliminar(servicioSeleccionado);

                    try
                    {
                        if (LineaEliminada)
                        {
                            BLLSeguridad.RegistrarEnBitacora(24, usuarioLog.Nick, usuarioLog.ID_Usuario);
                            CalcularDigitos();
                            limpiarGrilla();
                           // limpiartxt();
                        }
                        else
                        {
                            MessageBox.Show("no se puede borrar el servicio");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error al borrar el servicio: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un servicio para borrar");
                }
            }
        }

        #endregion



        #region Asignar servicios
        private void btnAsignarServicio_Click(object sender, EventArgs e)
        {
            /*if (.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }*/
            
            try
            {
                try
                {
                    
                    BEServicio.Coche = int.Parse(cmbInterno.Text);

                    int? legajoEmpleado = null;
                    if (cmbConductor.SelectedValue != null && int.TryParse(cmbConductor.SelectedValue.ToString(), out int tempLegajoEmpleado))
                    {
                        legajoEmpleado = tempLegajoEmpleado;
                    }
                    BEServicio.LegajoEmpleado = legajoEmpleado.Value;
                    BEServicio.ID_Servicio = int.Parse(txtServicio.Text);

                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (true)
                {

                }

                if (BLLServicios.CrearServicio(BEServicio))
                {
                    BLLSeguridad.RegistrarEnBitacora(26, usuarioLog.Nick, usuarioLog.ID_Usuario);
                    MessageBox.Show("Servicio asignado con éxito");
                    CalcularDigitos();
                }
                else
                {
                    MessageBox.Show("No se pudo asignar el servicio");
                }

                limpiarGrilla();
                //limpiartxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la ruta del escritorio del usuario
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string pdfFileName = Path.Combine(desktopPath, "PlanillaServicio_" + cmbConductor.Text + ".pdf");

                // Crear el documento PDF en la ubicación especificada
                Document document = new Document(PageSize.A4, 50f, 50f, 100f, 50f); // Márgenes
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFileName, FileMode.Create));
                document.Open();

                // Encabezado (agregado en cada página)
                PdfPTable headerTable = new PdfPTable(3);
                headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                headerTable.SetWidths(new float[] { 1, 2, 1 });

                // Logo
                string logoPath = @"C:\\Users\\CASA\\Desktop\\ECSA\\ECSA\\colectivo.jpg"; 
                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
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

                // Título
                PdfPCell titleCell = new PdfPCell(new Phrase("Planilla de Servicio", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                headerTable.AddCell(titleCell);

                // Fecha
                PdfPCell dateCell = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                headerTable.AddCell(dateCell);

                // Escribir encabezado en la primera página
                headerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - document.TopMargin + 100, writer.DirectContent);

                // Título principal: Detalles del Servicio
                iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                iTextSharp.text.Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 14);

                Paragraph mainTitle = new Paragraph("Detalles del Servicio", boldFont)
                {
                    SpacingBefore = 20f,
                    SpacingAfter = 10f
                };
                document.Add(mainTitle);

                // Contenido de la sección Detalles del Servicio
                Paragraph detallesServicio = new Paragraph($"Número de Servicio: {txtServicio.Text}", regularFont)
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };
                document.Add(detallesServicio);

                Paragraph detallesLinea = new Paragraph($"Línea: {txtNombreLinea.Text}", regularFont)
                {
                    SpacingAfter = 10f
                };
                document.Add(detallesLinea);

                // Mostrar el Conductor con el formato adecuado
                if (cmbConductor.SelectedItem != null)
                {
                    string conductorInfo = cmbConductor.SelectedItem.ToString();
                    string displayNamePart = conductorInfo.Substring(conductorInfo.IndexOf("DisplayName = ") + "DisplayName = ".Length);
                    if (displayNamePart.EndsWith("}"))
                    {
                        displayNamePart = displayNamePart.Substring(0, displayNamePart.Length - 1).Trim();
                    }

                    Paragraph conductorParagraph = new Paragraph($"Conductor: {displayNamePart}", regularFont)
                    {
                        SpacingAfter = 10f
                    };
                    document.Add(conductorParagraph);
                }
                else
                {
                    Paragraph conductorParagraph = new Paragraph("Conductor: Información no disponible", regularFont)
                    {
                        SpacingAfter = 10f
                    };
                    document.Add(conductorParagraph);
                }

                Paragraph interno = new Paragraph($"Interno: {cmbInterno.Text}", regularFont)
                {
                    SpacingAfter = 10f
                };
                document.Add(interno);

                // Título de la sección Horarios
                Paragraph horariosTitle = new Paragraph("Horarios", boldFont)
                {
                    SpacingBefore = 20f,
                    SpacingAfter = 10f
                };
                document.Add(horariosTitle);

                // Contenido de la sección Horarios
                Paragraph horarioPrincipal = new Paragraph($"Horario Terminal Principal: {date1.Text}", regularFont)
                {
                    SpacingAfter = 10f
                };
                document.Add(horarioPrincipal);

                Paragraph horarioRebote = new Paragraph($"Horario Terminal Rebote: {date2.Text}", regularFont)
                {
                    SpacingAfter = 10f
                };
                document.Add(horarioRebote);

                document.Close();

                MessageBox.Show($"Planilla guardada en el escritorio como '{pdfFileName}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la planilla: " + ex.Message);
            }
        }







        #endregion



        #region FuncionesVarias
        private void limpiarGrilla()
        {
            dtgServicios.DataSource = null;
            dtgServicios.DataSource = BLLServicios.Listar(BEServicio.Linea);
        }

     /*   private void limpiartxt()
        {
            date1.Items.Clear();
            date2.Items.Clear();

        }*/

        public void CalcularDigitos()
        {
            string tabla = "Servicio";
            BLLSeguridad.VerificarDigitosVerificadores(tabla);
            BLLSeguridad.CalcularDVV(tabla);
        }
        
      

        public BE.Servicio ObtenerServicioSeleccionado()
        {
            if (dtgServicios.SelectedRows.Count > 0)
            {
                servicioSeleccionado = ((BE.Servicio)dtgServicios.SelectedRows[0].DataBoundItem);
                this.CompletarServicio(servicioSeleccionado);
            }

            return servicioSeleccionado;
        }

        public void CompletarServicio(BE.Servicio servicio)
        {
            date1.Text = (servicio.HorarioSalida).ToString();
            date2.Text = (servicio.HorarioLlegada).ToString();
            txtServicio.Text = (servicio.ID_Servicio).ToString();
        }


        #endregion

        private void dtgServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerServicioSeleccionado();
        }


        private void LlenarComboBoxConductor(ComboBox comboBox)
        {
            try
            {
                var conductores = BLLEempleado.Listar(BEServicio.Linea);

                // Crear una lista temporal de objetos anónimos con el formato deseado
                var conductoresDisplay = conductores.Select(c => new
                {
                    Legajo = c.Legajo,
                    DisplayName = $"{c.Legajo} - {c.Nombre} {c.Apellido}"
                }).ToList();

                comboBox.DataSource = null; // Limpiar cualquier DataSource anterior
                comboBox.Items.Clear(); // Limpiar elementos anteriores

                // Asignar la lista temporal como DataSource
                comboBox.DataSource = conductoresDisplay;
                comboBox.DisplayMember = "DisplayName"; // La propiedad que quieres mostrar
                comboBox.ValueMember = "Legajo"; // La propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarComboBoxInternos(ComboBox comboBox)
        {
            try
            {
                var coches = BLLCoche.Listar(BEServicio.Linea);
                comboBox.DataSource = null; // Limpiar cualquier DataSource anterior
                comboBox.Items.Clear(); // Limpiar elementos anteriores
                comboBox.DataSource = coches; // Establecer nuevo DataSource
                comboBox.DisplayMember = "Interno"; // La propiedad que quieres mostrar
                comboBox.ValueMember = "Interno"; // La propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




    }
}
