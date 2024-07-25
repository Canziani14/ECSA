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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.DateDesde = new System.Windows.Forms.DateTimePicker();
            this.DateHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.dtgBitacora = new System.Windows.Forms.DataGridView();
            this.btnDescargarBitacora = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha desde";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(264, 101);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DateDesde
            // 
            this.DateDesde.Location = new System.Drawing.Point(82, 28);
            this.DateDesde.Name = "DateDesde";
            this.DateDesde.Size = new System.Drawing.Size(200, 20);
            this.DateDesde.TabIndex = 3;
            // 
            // DateHasta
            // 
            this.DateHasta.Location = new System.Drawing.Point(375, 29);
            this.DateHasta.Name = "DateHasta";
            this.DateHasta.Size = new System.Drawing.Size(200, 20);
            this.DateHasta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Location = new System.Drawing.Point(255, 75);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarUsuario.TabIndex = 7;
            // 
            // dtgBitacora
            // 
            this.dtgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBitacora.Location = new System.Drawing.Point(12, 130);
            this.dtgBitacora.Name = "dtgBitacora";
            this.dtgBitacora.Size = new System.Drawing.Size(569, 308);
            this.dtgBitacora.TabIndex = 8;
            // 
            // btnDescargarBitacora
            // 
            this.btnDescargarBitacora.Location = new System.Drawing.Point(241, 444);
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
            this.ClientSize = new System.Drawing.Size(593, 486);
            this.Controls.Add(this.btnDescargarBitacora);
            this.Controls.Add(this.dtgBitacora);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateHasta);
            this.Controls.Add(this.DateDesde);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Name = "UIBitacora";
            this.Text = "UIBitacora";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker DateDesde;
        private System.Windows.Forms.DateTimePicker DateHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.DataGridView dtgBitacora;
        private System.Windows.Forms.Button btnDescargarBitacora;
    }
}