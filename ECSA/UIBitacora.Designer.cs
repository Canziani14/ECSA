namespace ECSA
{
    partial class UIBitacora
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
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.DateDesde = new System.Windows.Forms.DateTimePicker();
            this.DateHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblBuscarUsuario = new System.Windows.Forms.Label();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.dtgBitacora = new System.Windows.Forms.DataGridView();
            this.btnDescargarBitacora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(137, 31);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(69, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Fecha desde";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(389, 97);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DateDesde
            // 
            this.DateDesde.Location = new System.Drawing.Point(207, 24);
            this.DateDesde.Name = "DateDesde";
            this.DateDesde.Size = new System.Drawing.Size(200, 20);
            this.DateDesde.TabIndex = 3;
            // 
            // DateHasta
            // 
            this.DateHasta.Location = new System.Drawing.Point(500, 25);
            this.DateHasta.Name = "DateHasta";
            this.DateHasta.Size = new System.Drawing.Size(200, 20);
            this.DateHasta.TabIndex = 4;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(428, 30);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(66, 13);
            this.lblHasta.TabIndex = 5;
            this.lblHasta.Text = "Fecha hasta";
            // 
            // lblBuscarUsuario
            // 
            this.lblBuscarUsuario.AutoSize = true;
            this.lblBuscarUsuario.Location = new System.Drawing.Point(295, 78);
            this.lblBuscarUsuario.Name = "lblBuscarUsuario";
            this.lblBuscarUsuario.Size = new System.Drawing.Size(79, 13);
            this.lblBuscarUsuario.TabIndex = 6;
            this.lblBuscarUsuario.Text = "Buscar Usuario";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Location = new System.Drawing.Point(380, 71);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarUsuario.TabIndex = 7;
            // 
            // dtgBitacora
            // 
            this.dtgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBitacora.Location = new System.Drawing.Point(12, 130);
            this.dtgBitacora.Name = "dtgBitacora";
            this.dtgBitacora.Size = new System.Drawing.Size(806, 308);
            this.dtgBitacora.TabIndex = 8;
            // 
            // btnDescargarBitacora
            // 
            this.btnDescargarBitacora.Location = new System.Drawing.Point(366, 442);
            this.btnDescargarBitacora.Name = "btnDescargarBitacora";
            this.btnDescargarBitacora.Size = new System.Drawing.Size(114, 32);
            this.btnDescargarBitacora.TabIndex = 9;
            this.btnDescargarBitacora.Text = "Descargar Bitacora";
            this.btnDescargarBitacora.UseVisualStyleBackColor = true;
            this.btnDescargarBitacora.Click += new System.EventHandler(this.btnDescargarBitacora_Click);
            // 
            // UIBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 486);
            this.Controls.Add(this.btnDescargarBitacora);
            this.Controls.Add(this.dtgBitacora);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.lblBuscarUsuario);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.DateHasta);
            this.Controls.Add(this.DateDesde);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblDesde);
            this.Name = "UIBitacora";
            this.Text = "UIBitacora";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker DateDesde;
        private System.Windows.Forms.DateTimePicker DateHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.DataGridView dtgBitacora;
        private System.Windows.Forms.Button btnDescargarBitacora;
    }
}