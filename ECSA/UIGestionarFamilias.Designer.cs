namespace ECSA
{
    partial class UIGestionarFamilias
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
            this.dtgPatentesActuales = new System.Windows.Forms.DataGridView();
            this.btnCrearFamilia = new System.Windows.Forms.Button();
            this.btnModificarFamilia = new System.Windows.Forms.Button();
            this.btnEliminarFamilia = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgFamilias = new System.Windows.Forms.DataGridView();
            this.dtgPatentesSinAsignar = new System.Windows.Forms.DataGridView();
            this.labelNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Familia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamilias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPatentesActuales
            // 
            this.dtgPatentesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesActuales.Location = new System.Drawing.Point(275, 98);
            this.dtgPatentesActuales.Name = "dtgPatentesActuales";
            this.dtgPatentesActuales.Size = new System.Drawing.Size(351, 330);
            this.dtgPatentesActuales.TabIndex = 0;
            this.dtgPatentesActuales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesActuales_CellDoubleClick);
            // 
            // btnCrearFamilia
            // 
            this.btnCrearFamilia.Location = new System.Drawing.Point(46, 367);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnCrearFamilia.TabIndex = 1;
            this.btnCrearFamilia.Text = "Crear";
            this.btnCrearFamilia.UseVisualStyleBackColor = true;
            this.btnCrearFamilia.Click += new System.EventHandler(this.btnCrearFamilia_Click);
            // 
            // btnModificarFamilia
            // 
            this.btnModificarFamilia.Location = new System.Drawing.Point(127, 367);
            this.btnModificarFamilia.Name = "btnModificarFamilia";
            this.btnModificarFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnModificarFamilia.TabIndex = 2;
            this.btnModificarFamilia.Text = "Modificar";
            this.btnModificarFamilia.UseVisualStyleBackColor = true;
            this.btnModificarFamilia.Click += new System.EventHandler(this.btnModificarFamilia_Click);
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.Location = new System.Drawing.Point(87, 396);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFamilia.TabIndex = 3;
            this.btnEliminarFamilia.Text = "Eliminar";
            this.btnEliminarFamilia.UseVisualStyleBackColor = true;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreFamilia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtgFamilias);
            this.groupBox1.Controls.Add(this.btnCrearFamilia);
            this.groupBox1.Controls.Add(this.btnEliminarFamilia);
            this.groupBox1.Controls.Add(this.btnModificarFamilia);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 425);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Familias";
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(98, 326);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(100, 20);
            this.txtNombreFamilia.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // dtgFamilias
            // 
            this.dtgFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFamilias.Location = new System.Drawing.Point(5, 19);
            this.dtgFamilias.Name = "dtgFamilias";
            this.dtgFamilias.Size = new System.Drawing.Size(237, 287);
            this.dtgFamilias.TabIndex = 5;
            this.dtgFamilias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFamilias_CellDoubleClick);
            // 
            // dtgPatentesSinAsignar
            // 
            this.dtgPatentesSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesSinAsignar.Location = new System.Drawing.Point(643, 98);
            this.dtgPatentesSinAsignar.Name = "dtgPatentesSinAsignar";
            this.dtgPatentesSinAsignar.Size = new System.Drawing.Size(351, 330);
            this.dtgPatentesSinAsignar.TabIndex = 5;
            this.dtgPatentesSinAsignar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesSinAsignar_CellDoubleClick);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(612, 13);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(0, 13);
            this.labelNombre.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Patentes Actuales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(768, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Patentes Sin Asignar";
            // 
            // Familia
            // 
            this.Familia.AutoSize = true;
            this.Familia.Location = new System.Drawing.Point(562, 36);
            this.Familia.Name = "Familia";
            this.Familia.Size = new System.Drawing.Size(39, 13);
            this.Familia.TabIndex = 10;
            this.Familia.Text = "Familia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(598, 10);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(33, 20);
            this.txtID.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(598, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // UIGestionarFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 463);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Familia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.dtgPatentesSinAsignar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgPatentesActuales);
            this.Name = "UIGestionarFamilias";
            this.Text = "GestionarFamilias";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamilias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPatentesActuales;
        private System.Windows.Forms.Button btnCrearFamilia;
        private System.Windows.Forms.Button btnModificarFamilia;
        private System.Windows.Forms.Button btnEliminarFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgFamilias;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgPatentesSinAsignar;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Familia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
    }
}