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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarNuevaContraseña
            // 
            this.btnGenerarNuevaContraseña.Location = new System.Drawing.Point(115, 103);
            this.btnGenerarNuevaContraseña.Name = "btnGenerarNuevaContraseña";
            this.btnGenerarNuevaContraseña.Size = new System.Drawing.Size(109, 37);
            this.btnGenerarNuevaContraseña.TabIndex = 0;
            this.btnGenerarNuevaContraseña.Text = "Generar Nueva Contraseña";
            this.btnGenerarNuevaContraseña.UseVisualStyleBackColor = true;
            this.btnGenerarNuevaContraseña.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(115, 62);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(141, 20);
            this.txtMail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese su Mail";
            // 
            // UIGenerarNuevaContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 175);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}