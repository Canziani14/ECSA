﻿namespace ECSA
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirArchivoSQL
            // 
            this.btnAbrirArchivoSQL.Location = new System.Drawing.Point(65, 88);
            this.btnAbrirArchivoSQL.Name = "btnAbrirArchivoSQL";
            this.btnAbrirArchivoSQL.Size = new System.Drawing.Size(100, 34);
            this.btnAbrirArchivoSQL.TabIndex = 0;
            this.btnAbrirArchivoSQL.Text = "Seleccionar Archivo";
            this.btnAbrirArchivoSQL.UseVisualStyleBackColor = true;
            this.btnAbrirArchivoSQL.Click += new System.EventHandler(this.btnAbrirArchivoSQL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // UIConectarSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 141);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAbrirArchivoSQL);
            this.Name = "UIConectarSQL";
            this.Text = "UIConectarSQL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirArchivoSQL;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}