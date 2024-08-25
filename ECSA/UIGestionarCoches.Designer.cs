namespace ECSA
{
    partial class UIGestionarCoches
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
            this.dtgCoches = new System.Windows.Forms.DataGridView();
            this.btnCrearCoche = new System.Windows.Forms.Button();
            this.btnEliminarCoche = new System.Windows.Forms.Button();
            this.btnBuscarCoche = new System.Windows.Forms.Button();
            this.gbGestorCoches = new System.Windows.Forms.GroupBox();
            this.lblLineaAsignar = new System.Windows.Forms.Label();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.txtInterno = new System.Windows.Forms.TextBox();
            this.lblInterno = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscarInterno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoches)).BeginInit();
            this.gbGestorCoches.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCoches
            // 
            this.dtgCoches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCoches.Location = new System.Drawing.Point(3, 76);
            this.dtgCoches.Name = "dtgCoches";
            this.dtgCoches.Size = new System.Drawing.Size(155, 362);
            this.dtgCoches.TabIndex = 0;
            this.dtgCoches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUsuarios_CellDoubleClick);
            // 
            // btnCrearCoche
            // 
            this.btnCrearCoche.Location = new System.Drawing.Point(16, 136);
            this.btnCrearCoche.Name = "btnCrearCoche";
            this.btnCrearCoche.Size = new System.Drawing.Size(75, 23);
            this.btnCrearCoche.TabIndex = 1;
            this.btnCrearCoche.Text = "Crear";
            this.btnCrearCoche.UseVisualStyleBackColor = true;
            this.btnCrearCoche.Click += new System.EventHandler(this.btnCrearCoche_Click);
            // 
            // btnEliminarCoche
            // 
            this.btnEliminarCoche.Location = new System.Drawing.Point(126, 136);
            this.btnEliminarCoche.Name = "btnEliminarCoche";
            this.btnEliminarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCoche.TabIndex = 2;
            this.btnEliminarCoche.Text = "Eliminar";
            this.btnEliminarCoche.UseVisualStyleBackColor = true;
            this.btnEliminarCoche.Click += new System.EventHandler(this.btnEliminarCoche_Click);
            // 
            // btnBuscarCoche
            // 
            this.btnBuscarCoche.Location = new System.Drawing.Point(179, 34);
            this.btnBuscarCoche.Name = "btnBuscarCoche";
            this.btnBuscarCoche.Size = new System.Drawing.Size(62, 23);
            this.btnBuscarCoche.TabIndex = 3;
            this.btnBuscarCoche.Text = "Buscar";
            this.btnBuscarCoche.UseVisualStyleBackColor = true;
            this.btnBuscarCoche.Click += new System.EventHandler(this.btnBuscarCoche_Click);
            // 
            // gbGestorCoches
            // 
            this.gbGestorCoches.Controls.Add(this.lblLineaAsignar);
            this.gbGestorCoches.Controls.Add(this.cmbLinea);
            this.gbGestorCoches.Controls.Add(this.txtPatente);
            this.gbGestorCoches.Controls.Add(this.lblPatente);
            this.gbGestorCoches.Controls.Add(this.txtInterno);
            this.gbGestorCoches.Controls.Add(this.lblInterno);
            this.gbGestorCoches.Controls.Add(this.btnCrearCoche);
            this.gbGestorCoches.Controls.Add(this.btnEliminarCoche);
            this.gbGestorCoches.Location = new System.Drawing.Point(164, 102);
            this.gbGestorCoches.Name = "gbGestorCoches";
            this.gbGestorCoches.Size = new System.Drawing.Size(236, 200);
            this.gbGestorCoches.TabIndex = 4;
            this.gbGestorCoches.TabStop = false;
            this.gbGestorCoches.Text = "Gestor de Coches";
            // 
            // lblLineaAsignar
            // 
            this.lblLineaAsignar.AutoSize = true;
            this.lblLineaAsignar.Location = new System.Drawing.Point(6, 93);
            this.lblLineaAsignar.Name = "lblLineaAsignar";
            this.lblLineaAsignar.Size = new System.Drawing.Size(79, 13);
            this.lblLineaAsignar.TabIndex = 10;
            this.lblLineaAsignar.Text = "Linea a asignar";
            // 
            // cmbLinea
            // 
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(102, 90);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(71, 21);
            this.cmbLinea.TabIndex = 9;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(102, 55);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(71, 20);
            this.txtPatente.TabIndex = 8;
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(6, 58);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(44, 13);
            this.lblPatente.TabIndex = 7;
            this.lblPatente.Text = "Patente";
            // 
            // txtInterno
            // 
            this.txtInterno.Enabled = false;
            this.txtInterno.Location = new System.Drawing.Point(102, 22);
            this.txtInterno.Name = "txtInterno";
            this.txtInterno.Size = new System.Drawing.Size(71, 20);
            this.txtInterno.TabIndex = 6;
            // 
            // lblInterno
            // 
            this.lblInterno.AutoSize = true;
            this.lblInterno.Location = new System.Drawing.Point(6, 29);
            this.lblInterno.Name = "lblInterno";
            this.lblInterno.Size = new System.Drawing.Size(40, 13);
            this.lblInterno.TabIndex = 3;
            this.lblInterno.Text = "Interno";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(83, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(90, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // lblBuscarInterno
            // 
            this.lblBuscarInterno.AutoSize = true;
            this.lblBuscarInterno.Location = new System.Drawing.Point(3, 40);
            this.lblBuscarInterno.Name = "lblBuscarInterno";
            this.lblBuscarInterno.Size = new System.Drawing.Size(79, 13);
            this.lblBuscarInterno.TabIndex = 6;
            this.lblBuscarInterno.Text = "Buscar Interno:";
            // 
            // UIGestionarCoches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.lblBuscarInterno);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.gbGestorCoches);
            this.Controls.Add(this.btnBuscarCoche);
            this.Controls.Add(this.dtgCoches);
            this.Name = "UIGestionarCoches";
            this.Text = "GestionarCoches";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoches)).EndInit();
            this.gbGestorCoches.ResumeLayout(false);
            this.gbGestorCoches.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCoches;
        private System.Windows.Forms.Button btnCrearCoche;
        private System.Windows.Forms.Button btnEliminarCoche;
        private System.Windows.Forms.Button btnBuscarCoche;
        private System.Windows.Forms.GroupBox gbGestorCoches;
        private System.Windows.Forms.TextBox txtInterno;
        private System.Windows.Forms.Label lblInterno;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Label lblLineaAsignar;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.Label lblBuscarInterno;
    }
}