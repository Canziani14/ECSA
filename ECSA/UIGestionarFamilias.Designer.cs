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
            this.gbGestorFamilias = new System.Windows.Forms.GroupBox();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtgFamilias = new System.Windows.Forms.DataGridView();
            this.dtgPatentesSinAsignar = new System.Windows.Forms.DataGridView();
            this.labelNombre = new System.Windows.Forms.Label();
            this.lblPatentesActuales = new System.Windows.Forms.Label();
            this.lblPatentesSinAsignar = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).BeginInit();
            this.gbGestorFamilias.SuspendLayout();
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
            // gbGestorFamilias
            // 
            this.gbGestorFamilias.Controls.Add(this.txtNombreFamilia);
            this.gbGestorFamilias.Controls.Add(this.lblNombre);
            this.gbGestorFamilias.Controls.Add(this.dtgFamilias);
            this.gbGestorFamilias.Controls.Add(this.btnCrearFamilia);
            this.gbGestorFamilias.Controls.Add(this.btnEliminarFamilia);
            this.gbGestorFamilias.Controls.Add(this.btnModificarFamilia);
            this.gbGestorFamilias.Location = new System.Drawing.Point(2, 3);
            this.gbGestorFamilias.Name = "gbGestorFamilias";
            this.gbGestorFamilias.Size = new System.Drawing.Size(267, 425);
            this.gbGestorFamilias.TabIndex = 4;
            this.gbGestorFamilias.TabStop = false;
            this.gbGestorFamilias.Text = "Gestor de Familias";
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(98, 326);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(100, 20);
            this.txtNombreFamilia.TabIndex = 7;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(52, 329);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre";
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
            // lblPatentesActuales
            // 
            this.lblPatentesActuales.AutoSize = true;
            this.lblPatentesActuales.Location = new System.Drawing.Point(392, 79);
            this.lblPatentesActuales.Name = "lblPatentesActuales";
            this.lblPatentesActuales.Size = new System.Drawing.Size(93, 13);
            this.lblPatentesActuales.TabIndex = 8;
            this.lblPatentesActuales.Text = "Patentes Actuales";
            // 
            // lblPatentesSinAsignar
            // 
            this.lblPatentesSinAsignar.AutoSize = true;
            this.lblPatentesSinAsignar.Location = new System.Drawing.Point(768, 79);
            this.lblPatentesSinAsignar.Name = "lblPatentesSinAsignar";
            this.lblPatentesSinAsignar.Size = new System.Drawing.Size(105, 13);
            this.lblPatentesSinAsignar.TabIndex = 9;
            this.lblPatentesSinAsignar.Text = "Patentes Sin Asignar";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(562, 36);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(39, 13);
            this.lblFamilia.TabIndex = 10;
            this.lblFamilia.Text = "Familia";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(583, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "ID";
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
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.lblPatentesSinAsignar);
            this.Controls.Add(this.lblPatentesActuales);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.dtgPatentesSinAsignar);
            this.Controls.Add(this.gbGestorFamilias);
            this.Controls.Add(this.dtgPatentesActuales);
            this.Name = "UIGestionarFamilias";
            this.Text = "GestionarFamilias";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatentesActuales)).EndInit();
            this.gbGestorFamilias.ResumeLayout(false);
            this.gbGestorFamilias.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbGestorFamilias;
        private System.Windows.Forms.DataGridView dtgFamilias;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridView dtgPatentesSinAsignar;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label lblPatentesActuales;
        private System.Windows.Forms.Label lblPatentesSinAsignar;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
    }
}