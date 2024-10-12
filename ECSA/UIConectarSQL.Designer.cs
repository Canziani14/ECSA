namespace ECSA
{
    partial class UIConectarSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIConectarSQL));
            this.btnAbrirArchivoSQL = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Encriptar = new System.Windows.Forms.Button();
            this.txtConectionStrnig = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtResultadoEncriptado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirArchivoSQL
            // 
            this.btnAbrirArchivoSQL.Location = new System.Drawing.Point(70, 97);
            this.btnAbrirArchivoSQL.Name = "btnAbrirArchivoSQL";
            this.btnAbrirArchivoSQL.Size = new System.Drawing.Size(143, 41);
            this.btnAbrirArchivoSQL.TabIndex = 0;
            this.btnAbrirArchivoSQL.Text = "Seleccionar Archivo / Select File";
            this.btnAbrirArchivoSQL.UseVisualStyleBackColor = true;
            this.btnAbrirArchivoSQL.Click += new System.EventHandler(this.btnAbrirArchivoSQL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(83, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Encriptar
            // 
            this.Encriptar.Location = new System.Drawing.Point(106, 257);
            this.Encriptar.Name = "Encriptar";
            this.Encriptar.Size = new System.Drawing.Size(60, 35);
            this.Encriptar.TabIndex = 2;
            this.Encriptar.Text = "Encriptar";
            this.Encriptar.UseVisualStyleBackColor = true;
            this.Encriptar.Click += new System.EventHandler(this.Encriptar_Click);
            // 
            // txtConectionStrnig
            // 
            this.txtConectionStrnig.Location = new System.Drawing.Point(35, 231);
            this.txtConectionStrnig.Name = "txtConectionStrnig";
            this.txtConectionStrnig.Size = new System.Drawing.Size(208, 20);
            this.txtConectionStrnig.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(53, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(172, 59);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Ingrese el Conection String que quiere encriptar / Enter the Connection String yo" +
    "u want to encrypt";
            // 
            // txtResultadoEncriptado
            // 
            this.txtResultadoEncriptado.Location = new System.Drawing.Point(35, 299);
            this.txtResultadoEncriptado.Name = "txtResultadoEncriptado";
            this.txtResultadoEncriptado.Size = new System.Drawing.Size(208, 20);
            this.txtResultadoEncriptado.TabIndex = 5;
            // 
            // UIConectarSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 340);
            this.Controls.Add(this.txtResultadoEncriptado);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtConectionStrnig);
            this.Controls.Add(this.Encriptar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAbrirArchivoSQL);
            this.Name = "UIConectarSQL";
            this.Text = "UIConectarSQL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirArchivoSQL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Encriptar;
        private System.Windows.Forms.TextBox txtConectionStrnig;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtResultadoEncriptado;
    }
}