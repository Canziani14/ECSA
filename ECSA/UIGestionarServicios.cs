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
using Bogus;

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
        public UIGestionarServicios(int linea, string nombreLinea, BE.Usuario usuarioLog, List<Patente> patentes, List<Traduccion> traducciones)
        {
            InitializeComponent();
            txtIDLinea.Text = (linea).ToString();
            txtNombreLinea.Text = nombreLinea;
            StartPosition = FormStartPosition.CenterScreen;

            dtgServicios.DataSource = BLLServicios.Listar(linea);
            BEServicio.Linea = linea;
            this.usuarioLog = usuarioLog;
            LlenarComboBoxConductor(cmbConductor);
            LlenarComboBoxInternos(cmbInterno);

            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 84:
                        lblID.Text = traduccion.Descripcion;
                        dtgServicios.Columns["ID_Servicio"].HeaderText = traduccion.Descripcion;
                        break;
                    case 86:
                        lblLinea.Text = traduccion.Descripcion;
                        break;
                    case 28:
                        gbGestorServicios.Text = traduccion.Descripcion;
                        break;
                    case 88:
                        lblHoraPrincipal.Text = traduccion.Descripcion;
                        dtgServicios.Columns["HorarioLlegada"].HeaderText = traduccion.Descripcion;
                        break;
                    case 90:
                        lblHoraRebote.Text = traduccion.Descripcion;
                        dtgServicios.Columns["HorarioSalida"].HeaderText = traduccion.Descripcion;
                        break;
                    case 2:
                        btnCrearServicio.Text = traduccion.Descripcion;
                        break;
                    case 4:
                        btnModificarServicio.Text = traduccion.Descripcion;
                        break;
                    case 6:
                        btnEliminarServicio.Text = traduccion.Descripcion;
                        break;
                    case 94:
                        gbDespachos.Text = traduccion.Descripcion;
                        break;
                    case 96:
                        lblInterno.Text = traduccion.Descripcion;
                        dtgServicios.Columns["Coche"].HeaderText = traduccion.Descripcion;
                        break;
                    case 98:
                        lblConductor.Text = traduccion.Descripcion;
                        break;
                    case 42:
                        btnAsignarServicio.Text = traduccion.Descripcion;
                        break;
                    case 44:
                        btnImprimir.Text = traduccion.Descripcion;
                        break;
                    case 92:
                        lblServicio.Text = traduccion.Descripcion;
                        break;
                    case 116:
                        dtgServicios.Columns["LegajoEmpleado"].HeaderText = traduccion.Descripcion;
                        break;
                    case 68:
                        dtgServicios.Columns["NombreEmpleado"].HeaderText = traduccion.Descripcion;
                        break;
                    case 70:
                        dtgServicios.Columns["ApellidoEmpleado"].HeaderText = traduccion.Descripcion;
                        break;
                }
            }

            #endregion

            #region patentes

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
            #endregion

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

                // Si todas las validaciones pasaron, crear el servicio
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
            // Validar campos vacíos antes de continuar
            if (string.IsNullOrWhiteSpace(cmbInterno.Text) || string.IsNullOrWhiteSpace(txtServicio.Text) || cmbConductor.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                try
                {
                    // Asignar valores a la entidad BEServicio
                    if (!int.TryParse(cmbInterno.Text, out int coche))
                    {
                        throw new FormatException("Número de interno inválido.");
                    }
                    BEServicio.Coche = coche;

                    if (!int.TryParse(cmbConductor.SelectedValue.ToString(), out int legajoEmpleado))
                    {
                        throw new FormatException("Legajo de empleado inválido.");
                    }
                    BEServicio.LegajoEmpleado = legajoEmpleado;

                    if (!int.TryParse(txtServicio.Text, out int idServicio))
                    {
                        throw new FormatException("ID del servicio inválido.");
                    }
                    BEServicio.ID_Servicio = idServicio;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error en los datos ingresados: " + ex.Message);
                    return;
                }

                bool validacionFallida = false;

                // Validar Conductor
                if (BLLServicios.ValidarConductor(BEServicio.LegajoEmpleado).Count > 0)
                {
                    MessageBox.Show("Conductor ya utilizado.");
                    validacionFallida = true;
                }

                // Validar Interno
                if (BLLServicios.ValidarInterno(BEServicio.Coche).Count > 0)
                {
                    MessageBox.Show("Interno ya utilizado.");
                    validacionFallida = true;
                }

                // Solo crear servicio si no hay validaciones fallidas
                if (!validacionFallida)
                {
                    if (BLLServicios.CrearServicio(BEServicio))
                    {
                        BLLSeguridad.RegistrarEnBitacora(26, usuarioLog.Nick, usuarioLog.ID_Usuario);
                        MessageBox.Show("Servicio asignado con éxito.");
                        CalcularDigitos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo asignar el servicio.");
                    }
                }

                limpiarGrilla();
                // Limpiar otros campos si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var lineasPermitidas = new[] { 1, 7, 8 };
            var faker = new Faker<Coche>()
                    .RuleFor(c => c.Patente, f => BLLSeguridad.EncriptarCamposReversible( f.Vehicle.Vin()))
                    .RuleFor(c => c.ID_Linea, f => f.PickRandom(new[] { 1, 7, 8 }))
                    .RuleFor(c => c.DVH, f => 0)
                    .Generate(150);

            // Insertar los empleados en la base de datos
            foreach (var coche in faker)
            {
                BLLCoche.Crear(coche);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            var linea1Servicios = new Dictionary<int, (List<int> Empleados, List<int> Coches)>
{
    { 1, (
        new List<int> { 77, 80, 123, 124, 133, 142, 153, 155, 165, 168, 175, 197, 201, 214, 221, 222, 231, 233, 235, 238, 242, 245 },
        new List<int> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 18, 19, 20, 21, 24, 26, 28, 31, 33, 38, 39 }
    ) },

    { 2, (
        new List<int> { 250, 276, 282, 285, 287, 296, 297, 306, 312, 313, 315, 319, 323, 327, 332, 335, 338, 340, 351, 365, 369, 377 },
        new List<int> { 45, 47, 50, 61, 65, 70, 73, 74, 75, 77, 84, 85, 86, 95, 96, 105, 116, 118, 119 }
    ) },

    { 3, (
        new List<int> { 382, 384, 385, 388, 395, 396, 400, 410, 415, 422, 430, 435, 444, 446, 449, 451, 454, 457, 458, 463, 476, 485 },
        new List<int> { 120, 123, 124, 126, 127, 130, 132, 133, 134, 138, 140, 143, 146, 147, 148, 152, 153, 154, 156, 157, 161, 162, 163, 164, 167, 168, 169, 171 }
    ) }
};

            // Generador Faker utilizando los datos de los servicios
            var faker = new Faker<Servicio>()
                .RuleFor(s => s.HorarioSalida, f => f.Date.Recent(10)) // Fecha reciente
                .RuleFor(s => s.HorarioLlegada, f => f.Date.Recent(5))  // Fecha reciente
                .RuleFor(s => s.Linea, f => 7) // Selecciona una línea aleatoria // Selecciona una línea aleatoria
                .RuleFor(s => s.LegajoEmpleado, (f, s) =>
                {
                    // Selecciona aleatoriamente un legajo basado en la línea del servicio
                    var empleados = linea1Servicios[s.Linea].Empleados;
                    return f.PickRandom(empleados);
                })
                .RuleFor(s => s.Coche, (f, s) =>
                {
                    // Selecciona aleatoriamente un coche basado en la línea del servicio
                    var coches = linea1Servicios[s.Linea].Coches;
                    return f.PickRandom(coches);
                })
                .RuleFor(s => s.DVH, f => 0) // Inicializa DVH en 0
                .Generate(150); // Genera 150 servicios

            BLL.BLL_ABM_Servicio BLLServicio = new BLL_ABM_Servicio();
            // Insertar los servicios en la base de datos
            foreach (var servicio in faker)
            {
                BLLServicio.Crear(servicio);
            }*/

            /*
            var linea7Servicios = new Dictionary<int, (List<int> Empleados, List<int> Coches)>
                {
                    { 7, (
                        new List<int> { 97, 113, 115, 120, 128, 130, 131, 134, 173, 185, 186, 190, 193, 195, 215, 220, 227, 236, 237, 247, 248, 261, 266, 267, 268, 270, 278, 329, 341, 344, 346, 370, 392, 398, 407, 417, 424, 426, 438, 447, 452, 470, 498, 509, 529, 531, 536, 554, 560, 562, 573, 574, 578, 606, 607, 631, 644, 652, 655, 668, 670, 672, 682, 683, 693, 699, 700, 716, 724, 729, 733, 742, 749, 750, 752, 763, 765, 768, 778, 784, 803, 806, 809, 815, 817, 823, 828, 847 },
                        new List<int> { 22, 30, 35, 41, 46, 48, 49, 51, 52, 58, 59, 62, 63, 67, 68, 69, 79, 80, 81, 83, 87, 93, 98, 104, 106, 108, 110, 112, 113, 125, 129, 137, 139, 141, 150, 151, 155, 159, 166, 170 }
                    ) }
                };

            // Generador Faker utilizando los datos de los servicios
            var faker = new Faker<Servicio>()
                .RuleFor(s => s.HorarioSalida, f => f.Date.Recent(10)) // Fecha reciente
                .RuleFor(s => s.HorarioLlegada, f => f.Date.Recent(5))  // Fecha reciente
                .RuleFor(s => s.Linea, f => 7) // Fijar línea 7
                .RuleFor(s => s.LegajoEmpleado, (f, s) =>
                {
                    // Selecciona aleatoriamente un legajo basado en la línea del servicio
                    var empleados = linea7Servicios[s.Linea].Empleados;
                    return f.PickRandom(empleados);
                })
                .RuleFor(s => s.Coche, (f, s) =>
                {
                    // Selecciona aleatoriamente un coche basado en la línea del servicio
                    var coches = linea7Servicios[s.Linea].Coches;
                    return f.PickRandom(coches);
                })
                .RuleFor(s => s.DVH, f => 0) // Inicializa DVH en 0
                .Generate(150); // Genera 150 servicios

            BLL.BLL_ABM_Servicio BLLServicio = new BLL_ABM_Servicio();
            // Insertar los servicios en la base de datos
            foreach (var servicio in faker)
            {
                BLLServicio.Crear(servicio);
            }*/
            var linea8Servicios = new Dictionary<int, (List<int> Empleados, List<int> Coches)>
{
    { 8, (
        new List<int> { 103, 104, 107, 108, 111, 114, 127, 143, 148, 150, 166, 172, 183, 191, 199, 203, 213, 217, 226, 240, 244, 251, 274, 284, 288, 294, 303, 308, 328, 334, 337, 347, 360, 366, 375, 378, 412, 413, 414, 428, 431, 442, 461, 472, 488, 507, 543, 544, 550, 551, 556, 569, 577, 586, 595, 615, 618, 624, 626, 630, 632, 636, 649, 662, 663, 667, 687, 690, 692, 697, 704, 707, 713, 715, 717, 722, 726, 727, 728, 734, 736, 744, 751, 753, 775, 791, 798, 810, 811, 827, 829, 831, 839, 842 },
        new List<int> { 23, 25, 27, 29, 32, 34, 36, 37, 40, 42, 43, 44, 53, 54, 55, 56, 57, 60, 64, 66, 71, 72, 76, 78, 82, 88, 89, 90, 91, 92, 94, 97, 99, 100, 101, 102, 103, 107, 109, 111, 114, 115, 117, 121, 122, 128, 131, 135, 136, 142, 144, 145, 149, 158, 160, 165 }
    ) }
};

            // Generador Faker utilizando los datos de los servicios
            var faker = new Faker<Servicio>()
                .RuleFor(s => s.HorarioSalida, f => f.Date.Recent(10)) // Fecha reciente
                .RuleFor(s => s.HorarioLlegada, f => f.Date.Recent(5))  // Fecha reciente
                .RuleFor(s => s.Linea, f => 8) // Fijar línea 8
                .RuleFor(s => s.LegajoEmpleado, (f, s) =>
                {
                    // Selecciona aleatoriamente un legajo basado en la línea del servicio
                    var empleados = linea8Servicios[s.Linea].Empleados;
                    return f.PickRandom(empleados);
                })
                .RuleFor(s => s.Coche, (f, s) =>
                {
                    // Selecciona aleatoriamente un coche basado en la línea del servicio
                    var coches = linea8Servicios[s.Linea].Coches;
                    return f.PickRandom(coches);
                })
                .RuleFor(s => s.DVH, f => 0) // Inicializa DVH en 0
                .Generate(150); // Genera 150 servicios

            BLL.BLL_ABM_Servicio BLLServicio = new BLL_ABM_Servicio();
            // Insertar los servicios en la base de datos
            foreach (var servicio in faker)
            {
                BLLServicio.Crear(servicio);
            }



        }

    }
}
