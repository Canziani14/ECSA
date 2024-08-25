namespace ECSA
{
    partial class UIAlertas
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
            this.dtgAlertas = new System.Windows.Forms.DataGridView();
            this.lblAlertasCriticidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAlertas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAlertas
            // 
            this.dtgAlertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAlertas.Location = new System.Drawing.Point(12, 45);
            this.dtgAlertas.Name = "dtgAlertas";
            this.dtgAlertas.Size = new System.Drawing.Size(387, 303);
            this.dtgAlertas.TabIndex = 0;
            // 
            // lblAlertasCriticidad
            // 
            this.lblAlertasCriticidad.AutoSize = true;
            this.lblAlertasCriticidad.Location = new System.Drawing.Point(9, 29);
            this.lblAlertasCriticidad.Name = "lblAlertasCriticidad";
            this.lblAlertasCriticidad.Size = new System.Drawing.Size(165, 13);
            this.lblAlertasCriticidad.TabIndex = 1;
            this.lblAlertasCriticidad.Text = "Alertas con alto nivel de criticidad";
            // 
            // UIAlertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 360);
            this.Controls.Add(this.lblAlertasCriticidad);
            this.Controls.Add(this.dtgAlertas);
            this.Name = "UIAlertas";
            this.Text = "UIAlertas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgAlertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgAlertas;
        private System.Windows.Forms.Label lblAlertasCriticidad;
    }
}