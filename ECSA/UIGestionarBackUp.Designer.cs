namespace ECSA
{
    partial class UIGestionarBackUp
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
            this.btnBKP = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBKP
            // 
            this.btnBKP.Location = new System.Drawing.Point(105, 41);
            this.btnBKP.Name = "btnBKP";
            this.btnBKP.Size = new System.Drawing.Size(102, 23);
            this.btnBKP.TabIndex = 0;
            this.btnBKP.Text = "Realizar BackUp";
            this.btnBKP.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(105, 102);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(102, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Realizar Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // UIGestionarBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 190);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBKP);
            this.Name = "UIGestionarBackUp";
            this.Text = "GestionarBackUp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBKP;
        private System.Windows.Forms.Button btnRestore;
    }
}