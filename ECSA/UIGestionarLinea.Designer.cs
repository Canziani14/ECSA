namespace ECSA
{
    partial class UIGestionarLinea
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
            this.dtgLineas = new System.Windows.Forms.DataGridView();
            this.btnCrearLinea = new System.Windows.Forms.Button();
            this.btnModificarLinea = new System.Windows.Forms.Button();
            this.btnEliminarLinea = new System.Windows.Forms.Button();
            this.btnGestionarCoches = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGestionarServicios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreLinea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDLinea = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgLineas
            // 
            this.dtgLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLineas.Location = new System.Drawing.Point(12, 21);
            this.dtgLineas.Name = "dtgLineas";
            this.dtgLineas.Size = new System.Drawing.Size(194, 262);
            this.dtgLineas.TabIndex = 0;
            this.dtgLineas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLineas_CellDoubleClick);
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.Location = new System.Drawing.Point(42, 76);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(75, 23);
            this.btnCrearLinea.TabIndex = 1;
            this.btnCrearLinea.Text = "Crear";
            this.btnCrearLinea.UseVisualStyleBackColor = true;
            this.btnCrearLinea.Click += new System.EventHandler(this.btnCrearLinea_Click);
            // 
            // btnModificarLinea
            // 
            this.btnModificarLinea.Location = new System.Drawing.Point(153, 76);
            this.btnModificarLinea.Name = "btnModificarLinea";
            this.btnModificarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnModificarLinea.TabIndex = 2;
            this.btnModificarLinea.Text = "Modificar";
            this.btnModificarLinea.UseVisualStyleBackColor = true;
            this.btnModificarLinea.Click += new System.EventHandler(this.btnModificarLinea_Click);
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.Location = new System.Drawing.Point(98, 115);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLinea.TabIndex = 3;
            this.btnEliminarLinea.Text = "Eliminar";
            this.btnEliminarLinea.UseVisualStyleBackColor = true;
            this.btnEliminarLinea.Click += new System.EventHandler(this.btnEliminarLinea_Click);
            // 
            // btnGestionarCoches
            // 
            this.btnGestionarCoches.Location = new System.Drawing.Point(89, 159);
            this.btnGestionarCoches.Name = "btnGestionarCoches";
            this.btnGestionarCoches.Size = new System.Drawing.Size(102, 23);
            this.btnGestionarCoches.TabIndex = 4;
            this.btnGestionarCoches.Text = "Gestionar Coches";
            this.btnGestionarCoches.UseVisualStyleBackColor = true;
            this.btnGestionarCoches.Click += new System.EventHandler(this.btnGestionarCoches_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDLinea);
            this.groupBox1.Controls.Add(this.btnGestionarServicios);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNombreLinea);
            this.groupBox1.Controls.Add(this.btnModificarLinea);
            this.groupBox1.Controls.Add(this.btnGestionarCoches);
            this.groupBox1.Controls.Add(this.btnCrearLinea);
            this.groupBox1.Controls.Add(this.btnEliminarLinea);
            this.groupBox1.Location = new System.Drawing.Point(233, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 262);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Lineas";
            // 
            // btnGestionarServicios
            // 
            this.btnGestionarServicios.Location = new System.Drawing.Point(89, 201);
            this.btnGestionarServicios.Name = "btnGestionarServicios";
            this.btnGestionarServicios.Size = new System.Drawing.Size(102, 34);
            this.btnGestionarServicios.TabIndex = 7;
            this.btnGestionarServicios.Text = "Gestionar Servicios";
            this.btnGestionarServicios.UseVisualStyleBackColor = true;
            this.btnGestionarServicios.Click += new System.EventHandler(this.btnGestionarServicios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // txtNombreLinea
            // 
            this.txtNombreLinea.Location = new System.Drawing.Point(78, 46);
            this.txtNombreLinea.Name = "txtNombreLinea";
            this.txtNombreLinea.Size = new System.Drawing.Size(159, 20);
            this.txtNombreLinea.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID";
            // 
            // txtIDLinea
            // 
            this.txtIDLinea.Location = new System.Drawing.Point(78, 17);
            this.txtIDLinea.Name = "txtIDLinea";
            this.txtIDLinea.Size = new System.Drawing.Size(43, 20);
            this.txtIDLinea.TabIndex = 8;
            // 
            // UIGestionarLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 295);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgLineas);
            this.Name = "UIGestionarLinea";
            this.Text = "GestionarLinea";
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgLineas;
        private System.Windows.Forms.Button btnCrearLinea;
        private System.Windows.Forms.Button btnModificarLinea;
        private System.Windows.Forms.Button btnEliminarLinea;
        private System.Windows.Forms.Button btnGestionarCoches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreLinea;
        private System.Windows.Forms.Button btnGestionarServicios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDLinea;
    }
}