namespace ECSA
{
    partial class UIGestionarLinea
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCrearLinea = new System.Windows.Forms.Button();
            this.btnModificarLinea = new System.Windows.Forms.Button();
            this.btnEliminarLinea = new System.Windows.Forms.Button();
            this.btnGestionarCoches = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(194, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.Location = new System.Drawing.Point(42, 76);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(75, 23);
            this.btnCrearLinea.TabIndex = 1;
            this.btnCrearLinea.Text = "Crear";
            this.btnCrearLinea.UseVisualStyleBackColor = true;
            // 
            // btnModificarLinea
            // 
            this.btnModificarLinea.Location = new System.Drawing.Point(153, 76);
            this.btnModificarLinea.Name = "btnModificarLinea";
            this.btnModificarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnModificarLinea.TabIndex = 2;
            this.btnModificarLinea.Text = "Modificar";
            this.btnModificarLinea.UseVisualStyleBackColor = true;
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.Location = new System.Drawing.Point(98, 115);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLinea.TabIndex = 3;
            this.btnEliminarLinea.Text = "Eliminar";
            this.btnEliminarLinea.UseVisualStyleBackColor = true;
            // 
            // btnGestionarCoches
            // 
            this.btnGestionarCoches.Location = new System.Drawing.Point(89, 159);
            this.btnGestionarCoches.Name = "btnGestionarCoches";
            this.btnGestionarCoches.Size = new System.Drawing.Size(102, 23);
            this.btnGestionarCoches.TabIndex = 4;
            this.btnGestionarCoches.Text = "Gestionar Coches";
            this.btnGestionarCoches.UseVisualStyleBackColor = true;
            this.btnGestionarCoches.Click += new System.EventHandler(this.btnGestionarCoches_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnModificarLinea);
            this.groupBox1.Controls.Add(this.btnGestionarCoches);
            this.groupBox1.Controls.Add(this.btnCrearLinea);
            this.groupBox1.Controls.Add(this.btnEliminarLinea);
            this.groupBox1.Location = new System.Drawing.Point(233, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Lineas";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // UIGestionarLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 246);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UIGestionarLinea";
            this.Text = "GestionarLinea";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCrearLinea;
        private System.Windows.Forms.Button btnModificarLinea;
        private System.Windows.Forms.Button btnEliminarLinea;
        private System.Windows.Forms.Button btnGestionarCoches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}