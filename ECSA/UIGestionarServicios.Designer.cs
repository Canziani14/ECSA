namespace ECSA
{
    partial class UIGestionarServicios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgServicios = new System.Windows.Forms.DataGridView();
            this.btnCrearServicio = new System.Windows.Forms.Button();
            this.btnModificarServicio = new System.Windows.Forms.Button();
            this.btnEliminarServicio = new System.Windows.Forms.Button();
            this.btnAsignarServicio = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbGestorServicios = new System.Windows.Forms.GroupBox();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.lblHoraRebote = new System.Windows.Forms.Label();
            this.lblHoraPrincipal = new System.Windows.Forms.Label();
            this.gbDespachos = new System.Windows.Forms.GroupBox();
            this.cmbConductor = new System.Windows.Forms.ComboBox();
            this.cmbInterno = new System.Windows.Forms.ComboBox();
            this.lblInterno = new System.Windows.Forms.Label();
            this.lblConductor = new System.Windows.Forms.Label();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.txtIDLinea = new System.Windows.Forms.TextBox();
            this.txtNombreLinea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            this.gbGestorServicios.SuspendLayout();
            this.gbDespachos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgServicios
            // 
            this.dtgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgServicios.Location = new System.Drawing.Point(2, 49);
            this.dtgServicios.Name = "dtgServicios";
            this.dtgServicios.Size = new System.Drawing.Size(641, 389);
            this.dtgServicios.TabIndex = 0;
            this.dtgServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgServicios_CellDoubleClick);
            // 
            // btnCrearServicio
            // 
            this.btnCrearServicio.Location = new System.Drawing.Point(25, 95);
            this.btnCrearServicio.Name = "btnCrearServicio";
            this.btnCrearServicio.Size = new System.Drawing.Size(75, 23);
            this.btnCrearServicio.TabIndex = 1;
            this.btnCrearServicio.Text = "Crear";
            this.btnCrearServicio.UseVisualStyleBackColor = true;
            this.btnCrearServicio.Click += new System.EventHandler(this.btnCrearServicio_Click);
            // 
            // btnModificarServicio
            // 
            this.btnModificarServicio.Location = new System.Drawing.Point(124, 95);
            this.btnModificarServicio.Name = "btnModificarServicio";
            this.btnModificarServicio.Size = new System.Drawing.Size(75, 23);
            this.btnModificarServicio.TabIndex = 2;
            this.btnModificarServicio.Text = "Modificar";
            this.btnModificarServicio.UseVisualStyleBackColor = true;
            this.btnModificarServicio.Click += new System.EventHandler(this.btnModificarServicio_Click);
            // 
            // btnEliminarServicio
            // 
            this.btnEliminarServicio.Location = new System.Drawing.Point(222, 95);
            this.btnEliminarServicio.Name = "btnEliminarServicio";
            this.btnEliminarServicio.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarServicio.TabIndex = 3;
            this.btnEliminarServicio.Text = "Eliminar";
            this.btnEliminarServicio.UseVisualStyleBackColor = true;
            this.btnEliminarServicio.Click += new System.EventHandler(this.btnEliminarServicio_Click);
            // 
            // btnAsignarServicio
            // 
            this.btnAsignarServicio.Location = new System.Drawing.Point(71, 107);
            this.btnAsignarServicio.Name = "btnAsignarServicio";
            this.btnAsignarServicio.Size = new System.Drawing.Size(108, 23);
            this.btnAsignarServicio.TabIndex = 4;
            this.btnAsignarServicio.Text = "Asignar Servicio";
            this.btnAsignarServicio.UseVisualStyleBackColor = true;
            this.btnAsignarServicio.Click += new System.EventHandler(this.btnAsignarServicio_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(56, 146);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 34);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir Planilla de Servicio";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gbGestorServicios
            // 
            this.gbGestorServicios.Controls.Add(this.date2);
            this.gbGestorServicios.Controls.Add(this.date1);
            this.gbGestorServicios.Controls.Add(this.lblHoraRebote);
            this.gbGestorServicios.Controls.Add(this.lblHoraPrincipal);
            this.gbGestorServicios.Controls.Add(this.btnCrearServicio);
            this.gbGestorServicios.Controls.Add(this.btnModificarServicio);
            this.gbGestorServicios.Controls.Add(this.btnEliminarServicio);
            this.gbGestorServicios.Location = new System.Drawing.Point(649, 49);
            this.gbGestorServicios.Name = "gbGestorServicios";
            this.gbGestorServicios.Size = new System.Drawing.Size(319, 141);
            this.gbGestorServicios.TabIndex = 6;
            this.gbGestorServicios.TabStop = false;
            this.gbGestorServicios.Text = "Gestor de Servicios";
            // 
            // date2
            // 
            this.date2.CustomFormat = "HH:mm";
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(149, 53);
            this.date2.Name = "date2";
            this.date2.ShowUpDown = true;
            this.date2.Size = new System.Drawing.Size(53, 20);
            this.date2.TabIndex = 9;
            // 
            // date1
            // 
            this.date1.CustomFormat = "HH:mm";
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(149, 23);
            this.date1.Name = "date1";
            this.date1.ShowUpDown = true;
            this.date1.Size = new System.Drawing.Size(53, 20);
            this.date1.TabIndex = 8;
            // 
            // lblHoraRebote
            // 
            this.lblHoraRebote.AutoSize = true;
            this.lblHoraRebote.Location = new System.Drawing.Point(6, 60);
            this.lblHoraRebote.Name = "lblHoraRebote";
            this.lblHoraRebote.Size = new System.Drawing.Size(122, 13);
            this.lblHoraRebote.TabIndex = 6;
            this.lblHoraRebote.Text = "Horario Terminal Rebote";
            // 
            // lblHoraPrincipal
            // 
            this.lblHoraPrincipal.AutoSize = true;
            this.lblHoraPrincipal.Location = new System.Drawing.Point(6, 30);
            this.lblHoraPrincipal.Name = "lblHoraPrincipal";
            this.lblHoraPrincipal.Size = new System.Drawing.Size(124, 13);
            this.lblHoraPrincipal.TabIndex = 4;
            this.lblHoraPrincipal.Text = "Horario Teminal Principal";
            // 
            // gbDespachos
            // 
            this.gbDespachos.Controls.Add(this.cmbConductor);
            this.gbDespachos.Controls.Add(this.cmbInterno);
            this.gbDespachos.Controls.Add(this.lblInterno);
            this.gbDespachos.Controls.Add(this.lblConductor);
            this.gbDespachos.Controls.Add(this.btnImprimir);
            this.gbDespachos.Controls.Add(this.btnAsignarServicio);
            this.gbDespachos.Location = new System.Drawing.Point(649, 221);
            this.gbDespachos.Name = "gbDespachos";
            this.gbDespachos.Size = new System.Drawing.Size(311, 203);
            this.gbDespachos.TabIndex = 7;
            this.gbDespachos.TabStop = false;
            this.gbDespachos.Text = "Despachos";
            // 
            // cmbConductor
            // 
            this.cmbConductor.FormattingEnabled = true;
            this.cmbConductor.Location = new System.Drawing.Point(109, 76);
            this.cmbConductor.Name = "cmbConductor";
            this.cmbConductor.Size = new System.Drawing.Size(177, 21);
            this.cmbConductor.TabIndex = 11;
            // 
            // cmbInterno
            // 
            this.cmbInterno.FormattingEnabled = true;
            this.cmbInterno.Location = new System.Drawing.Point(109, 35);
            this.cmbInterno.Name = "cmbInterno";
            this.cmbInterno.Size = new System.Drawing.Size(65, 21);
            this.cmbInterno.TabIndex = 10;
            // 
            // lblInterno
            // 
            this.lblInterno.AutoSize = true;
            this.lblInterno.Location = new System.Drawing.Point(9, 35);
            this.lblInterno.Name = "lblInterno";
            this.lblInterno.Size = new System.Drawing.Size(40, 13);
            this.lblInterno.TabIndex = 9;
            this.lblInterno.Text = "Interno";
            // 
            // lblConductor
            // 
            this.lblConductor.AutoSize = true;
            this.lblConductor.Location = new System.Drawing.Point(6, 79);
            this.lblConductor.Name = "lblConductor";
            this.lblConductor.Size = new System.Drawing.Size(56, 13);
            this.lblConductor.TabIndex = 8;
            this.lblConductor.Text = "Conductor";
            // 
            // txtServicio
            // 
            this.txtServicio.Enabled = false;
            this.txtServicio.Location = new System.Drawing.Point(706, 195);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(33, 20);
            this.txtServicio.TabIndex = 11;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(655, 198);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(45, 13);
            this.lblServicio.TabIndex = 10;
            this.lblServicio.Text = "Servicio";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(232, 18);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(31, 25);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.Location = new System.Drawing.Point(388, 17);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(60, 25);
            this.lblLinea.TabIndex = 13;
            this.lblLinea.Text = "Linea";
            // 
            // txtIDLinea
            // 
            this.txtIDLinea.Enabled = false;
            this.txtIDLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDLinea.Location = new System.Drawing.Point(269, 13);
            this.txtIDLinea.Name = "txtIDLinea";
            this.txtIDLinea.Size = new System.Drawing.Size(39, 30);
            this.txtIDLinea.TabIndex = 14;
            // 
            // txtNombreLinea
            // 
            this.txtNombreLinea.Enabled = false;
            this.txtNombreLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreLinea.Location = new System.Drawing.Point(454, 12);
            this.txtNombreLinea.Name = "txtNombreLinea";
            this.txtNombreLinea.Size = new System.Drawing.Size(100, 30);
            this.txtNombreLinea.TabIndex = 15;
            // 
            // UIGestionarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 450);
            this.Controls.Add(this.txtNombreLinea);
            this.Controls.Add(this.txtIDLinea);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.gbDespachos);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.gbGestorServicios);
            this.Controls.Add(this.dtgServicios);
            this.Name = "UIGestionarServicios";
            this.Text = "GestionarServicios";
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            this.gbGestorServicios.ResumeLayout(false);
            this.gbGestorServicios.PerformLayout();
            this.gbDespachos.ResumeLayout(false);
            this.gbDespachos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgServicios;
        private System.Windows.Forms.Button btnCrearServicio;
        private System.Windows.Forms.Button btnModificarServicio;
        private System.Windows.Forms.Button btnEliminarServicio;
        private System.Windows.Forms.Button btnAsignarServicio;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox gbGestorServicios;
        private System.Windows.Forms.GroupBox gbDespachos;
        private System.Windows.Forms.Label lblHoraRebote;
        private System.Windows.Forms.Label lblHoraPrincipal;
        private System.Windows.Forms.Label lblInterno;
        private System.Windows.Forms.Label lblConductor;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.TextBox txtIDLinea;
        private System.Windows.Forms.TextBox txtNombreLinea;
        private System.Windows.Forms.ComboBox cmbConductor;
        private System.Windows.Forms.ComboBox cmbInterno;
    }
}