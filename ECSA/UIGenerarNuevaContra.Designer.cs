namespace ECSA
{
    partial class UIGenerarNuevaContra
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
            this.btnGenerarNuevaContraseña = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblIngreseMail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarNuevaContraseña
            // 
            this.btnGenerarNuevaContraseña.Location = new System.Drawing.Point(122, 57);
            this.btnGenerarNuevaContraseña.Name = "btnGenerarNuevaContraseña";
            this.btnGenerarNuevaContraseña.Size = new System.Drawing.Size(109, 37);
            this.btnGenerarNuevaContraseña.TabIndex = 0;
            this.btnGenerarNuevaContraseña.Text = "Generar Nueva Contraseña";
            this.btnGenerarNuevaContraseña.UseVisualStyleBackColor = true;
            this.btnGenerarNuevaContraseña.Click += new System.EventHandler(this.btnGenerarNuevaContraseña_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(109, 31);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(141, 20);
            this.txtMail.TabIndex = 1;
            // 
            // lblIngreseMail
            // 
            this.lblIngreseMail.AutoSize = true;
            this.lblIngreseMail.Location = new System.Drawing.Point(12, 38);
            this.lblIngreseMail.Name = "lblIngreseMail";
            this.lblIngreseMail.Size = new System.Drawing.Size(78, 13);
            this.lblIngreseMail.TabIndex = 2;
            this.lblIngreseMail.Text = "Ingrese su Mail";
            // 
            // UIGenerarNuevaContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 119);
            this.Controls.Add(this.lblIngreseMail);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.btnGenerarNuevaContraseña);
            this.Name = "UIGenerarNuevaContra";
            this.Text = "UIGenerarNuevaContra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarNuevaContraseña;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblIngreseMail;
    }
}