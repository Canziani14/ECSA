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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbConductor = new System.Windows.Forms.ComboBox();
            this.cmbInterno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDLinea = new System.Windows.Forms.TextBox();
            this.txtNombreLinea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date2);
            this.groupBox1.Controls.Add(this.date1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCrearServicio);
            this.groupBox1.Controls.Add(this.btnModificarServicio);
            this.groupBox1.Controls.Add(this.btnEliminarServicio);
            this.groupBox1.Location = new System.Drawing.Point(649, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 141);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Servicios";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Horario Terminal Rebote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Horario Teminal Principal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbConductor);
            this.groupBox2.Controls.Add(this.cmbInterno);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnAsignarServicio);
            this.groupBox2.Location = new System.Drawing.Point(658, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 203);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Despachos";
            // 
            // cmbConductor
            // 
            this.cmbConductor.FormattingEnabled = true;
            this.cmbConductor.Location = new System.Drawing.Point(73, 76);
            this.cmbConductor.Name = "cmbConductor";
            this.cmbConductor.Size = new System.Drawing.Size(197, 21);
            this.cmbConductor.TabIndex = 11;
            // 
            // cmbInterno
            // 
            this.cmbInterno.FormattingEnabled = true;
            this.cmbInterno.Location = new System.Drawing.Point(71, 32);
            this.cmbInterno.Name = "cmbInterno";
            this.cmbInterno.Size = new System.Drawing.Size(65, 21);
            this.cmbInterno.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Interno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Conductor";
            // 
            // txtServicio
            // 
            this.txtServicio.Enabled = false;
            this.txtServicio.Location = new System.Drawing.Point(706, 195);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(33, 20);
            this.txtServicio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(655, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Servicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(232, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(388, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Linea";
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
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgServicios);
            this.Name = "UIGestionarServicios";
            this.Text = "GestionarServicios";
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDLinea;
        private System.Windows.Forms.TextBox txtNombreLinea;
        private System.Windows.Forms.ComboBox cmbConductor;
        private System.Windows.Forms.ComboBox cmbInterno;
    }
}