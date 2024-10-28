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
            this.gbGestorPatentes = new System.Windows.Forms.GroupBox();
            this.lblSinAsignar = new System.Windows.Forms.Label();
            this.lblAsignadas = new System.Windows.Forms.Label();
            this.dtgPatentesSinAsignar = new System.Windows.Forms.DataGridView();
            this.dtgPatentesActuales = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).BeginInit();
            this.gbGestorPatentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgUsuarios
            // 
            this.dtgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsuarios.Location = new System.Drawing.Point(104, 53);
            this.dtgUsuarios.Name = "dtgUsuarios";
            this.dtgUsuarios.Size = new System.Drawing.Size(682, 190);
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
            // gbGestorPatentes
            // 
            this.gbGestorPatentes.Controls.Add(this.lblSinAsignar);
            this.gbGestorPatentes.Controls.Add(this.lblAsignadas);
            this.gbGestorPatentes.Controls.Add(this.dtgPatentesSinAsignar);
            this.gbGestorPatentes.Controls.Add(this.dtgPatentesActuales);
            this.gbGestorPatentes.Location = new System.Drawing.Point(12, 249);
            this.gbGestorPatentes.Name = "gbGestorPatentes";
            this.gbGestorPatentes.Size = new System.Drawing.Size(877, 280);
            this.gbGestorPatentes.TabIndex = 5;
            this.gbGestorPatentes.TabStop = false;
            this.gbGestorPatentes.Text = "Gestor de Patentes";
            // 
            // lblSinAsignar
            // 
            this.lblSinAsignar.AutoSize = true;
            this.lblSinAsignar.Location = new System.Drawing.Point(631, 20);
            this.lblSinAsignar.Name = "lblSinAsignar";
            this.lblSinAsignar.Size = new System.Drawing.Size(60, 13);
            this.lblSinAsignar.TabIndex = 9;
            this.lblSinAsignar.Text = "Sin Asignar";
            // 
            // lblAsignadas
            // 
            this.lblAsignadas.AutoSize = true;
            this.lblAsignadas.Location = new System.Drawing.Point(200, 16);
            this.lblAsignadas.Name = "lblAsignadas";
            this.lblAsignadas.Size = new System.Drawing.Size(56, 13);
            this.lblAsignadas.TabIndex = 8;
            this.lblAsignadas.Text = "Asignadas";
            // 
            // dtgPatentesSinAsignar
            // 
            this.dtgPatentesSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesSinAsignar.Location = new System.Drawing.Point(441, 43);
            this.dtgPatentesSinAsignar.Name = "dtgPatentesSinAsignar";
            this.dtgPatentesSinAsignar.Size = new System.Drawing.Size(436, 231);
            this.dtgPatentesSinAsignar.TabIndex = 7;
            this.dtgPatentesSinAsignar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesSinAsignar_CellDoubleClick);
            // 
            // dtgPatentesActuales
            // 
            this.dtgPatentesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatentesActuales.Location = new System.Drawing.Point(-1, 43);
            this.dtgPatentesActuales.Name = "dtgPatentesActuales";
            this.dtgPatentesActuales.Size = new System.Drawing.Size(436, 231);
            this.dtgPatentesActuales.TabIndex = 6;
            this.dtgPatentesActuales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatentesActuales_CellDoubleClick);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(-1, 35);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(82, 13);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "Buscar Usuario:";
            // 
            // UIGestionarPatentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 541);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gbGestorPatentes);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.dtgUsuarios);
            this.Name = "UIGestionarPatentes";
            this.Text = "GestionarPatentes";
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).EndInit();
            this.gbGestorPatentes.ResumeLayout(false);
            this.gbGestorPatentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesSinAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgUsuarios;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.GroupBox gbGestorPatentes;
        private System.Windows.Forms.DataGridView dtgPatentesActuales;
        private System.Windows.Forms.DataGridView dtgPatentesSinAsignar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblSinAsignar;
        private System.Windows.Forms.Label lblAsignadas;
    }
}