namespace ECSA
{
    partial class UICambiarContraseña
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
            this.lblIngreseActual = new System.Windows.Forms.Label();
            this.lblIngreseNueva = new System.Windows.Forms.Label();
            this.lblConfirmarNueva = new System.Windows.Forms.Label();
            this.btnCambiarContra = new System.Windows.Forms.Button();
            this.txtContraseñaActual = new System.Windows.Forms.TextBox();
            this.txtContraseñaNueva = new System.Windows.Forms.TextBox();
            this.txtConfirmacionContraseñaNueva = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIngreseActual
            // 
            this.lblIngreseActual.AutoSize = true;
            this.lblIngreseActual.Location = new System.Drawing.Point(43, 53);
            this.lblIngreseActual.Name = "lblIngreseActual";
            this.lblIngreseActual.Size = new System.Drawing.Size(132, 13);
            this.lblIngreseActual.TabIndex = 0;
            this.lblIngreseActual.Text = "Ingrese Contraseña Actual";
            // 
            // lblIngreseNueva
            // 
            this.lblIngreseNueva.AutoSize = true;
            this.lblIngreseNueva.Location = new System.Drawing.Point(43, 84);
            this.lblIngreseNueva.Name = "lblIngreseNueva";
            this.lblIngreseNueva.Size = new System.Drawing.Size(134, 13);
            this.lblIngreseNueva.TabIndex = 1;
            this.lblIngreseNueva.Text = "Ingrese Contraseña Nueva";
            // 
            // lblConfirmarNueva
            // 
            this.lblConfirmarNueva.AutoSize = true;
            this.lblConfirmarNueva.Location = new System.Drawing.Point(41, 118);
            this.lblConfirmarNueva.Name = "lblConfirmarNueva";
            this.lblConfirmarNueva.Size = new System.Drawing.Size(140, 13);
            this.lblConfirmarNueva.TabIndex = 2;
            this.lblConfirmarNueva.Text = "Confirme Contraseña Nueva";
            // 
            // btnCambiarContra
            // 
            this.btnCambiarContra.Location = new System.Drawing.Point(119, 153);
            this.btnCambiarContra.Name = "btnCambiarContra";
            this.btnCambiarContra.Size = new System.Drawing.Size(122, 38);
            this.btnCambiarContra.TabIndex = 3;
            this.btnCambiarContra.Text = "Cambiar Contraseña";
            this.btnCambiarContra.UseVisualStyleBackColor = true;
            this.btnCambiarContra.Click += new System.EventHandler(this.btnCambiarContra_Click);
            // 
            // txtContraseñaActual
            // 
            this.txtContraseñaActual.Location = new System.Drawing.Point(181, 50);
            this.txtContraseñaActual.Name = "txtContraseñaActual";
            this.txtContraseñaActual.Size = new System.Drawing.Size(100, 20);
            this.txtContraseñaActual.TabIndex = 4;
            // 
            // txtContraseñaNueva
            // 
            this.txtContraseñaNueva.Location = new System.Drawing.Point(183, 81);
            this.txtContraseñaNueva.Name = "txtContraseñaNueva";
            this.txtContraseñaNueva.Size = new System.Drawing.Size(100, 20);
            this.txtContraseñaNueva.TabIndex = 5;
            // 
            // txtConfirmacionContraseñaNueva
            // 
            this.txtConfirmacionContraseñaNueva.Location = new System.Drawing.Point(183, 115);
            this.txtConfirmacionContraseñaNueva.Name = "txtConfirmacionContraseñaNueva";
            this.txtConfirmacionContraseñaNueva.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmacionContraseñaNueva.TabIndex = 6;
            // 
            // UICambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 203);
            this.Controls.Add(this.txtConfirmacionContraseñaNueva);
            this.Controls.Add(this.txtContraseñaNueva);
            this.Controls.Add(this.txtContraseñaActual);
            this.Controls.Add(this.btnCambiarContra);
            this.Controls.Add(this.lblConfirmarNueva);
            this.Controls.Add(this.lblIngreseNueva);
            this.Controls.Add(this.lblIngreseActual);
            this.Name = "UICambiarContraseña";
            this.Text = "UICambiarContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIngreseActual;
        private System.Windows.Forms.Label lblIngreseNueva;
        private System.Windows.Forms.Label lblConfirmarNueva;
        private System.Windows.Forms.Button btnCambiarContra;
        private System.Windows.Forms.TextBox txtContraseñaActual;
        private System.Windows.Forms.TextBox txtContraseñaNueva;
        private System.Windows.Forms.TextBox txtConfirmacionContraseñaNueva;
    }
}