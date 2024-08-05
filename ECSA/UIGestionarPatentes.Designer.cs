namespace ECSA
{
    partial class UIGestionarPatentes
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
            this.dtgUsuarios = new System.Windows.Forms.DataGridView();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgPatentesSinAsignar = new System.Windows.Forms.DataGridView();
            this.dtgPatentesActuales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgUsuarios
            // 
            this.dtgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsuarios.Location = new System.Drawing.Point(12, 53);
            this.dtgUsuarios.Name = "dtgUsuarios";
            this.dtgUsuarios.Size = new System.Drawing.Size(278, 454);
            this.dtgUsuarios.TabIndex = 0;
            this.dtgUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUsuarios_CellDoubleClick);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Location = new System.Drawing.Point(215, 27);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarUsuario.TabIndex = 3;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Location = new System.Drawing.Point(78, 29);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(134, 20);
            this.txtBuscarUsuario.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtgPatentesSinAsignar);
            this.groupBox1.Controls.Add(this.dtgPatentesActuales);
            this.groupBox1.Location = new System.Drawing.Point(312, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 476);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Patentes";
            // 
            // dtgPatentesSinAsignar
            // 
            this.dtgPatentesSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesSinAsignar.Location = new System.Drawing.Point(6, 244);
            this.dtgPatentesSinAsignar.Name = "dtgPatentesSinAsignar";
            this.dtgPatentesSinAsignar.Size = new System.Drawing.Size(479, 160);
            this.dtgPatentesSinAsignar.TabIndex = 7;
            this.dtgPatentesSinAsignar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesSinAsignar_CellDoubleClick);
            // 
            // dtgPatentesActuales
            // 
            this.dtgPatentesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesActuales.Location = new System.Drawing.Point(6, 42);
            this.dtgPatentesActuales.Name = "dtgPatentesActuales";
            this.dtgPatentesActuales.Size = new System.Drawing.Size(479, 140);
            this.dtgPatentesActuales.TabIndex = 6;
            this.dtgPatentesActuales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesActuales_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Asignadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sin Asignar";
            // 
            // UIGestionarPatentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.dtgUsuarios);
            this.Name = "UIGestionarPatentes";
            this.Text = "GestionarPatentes";
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgUsuarios;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgPatentesActuales;
        private System.Windows.Forms.DataGridView dtgPatentesSinAsignar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}