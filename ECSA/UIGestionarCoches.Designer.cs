namespace ECSA
{
    partial class UIGestionarCoches
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
            this.btnCrearCoche = new System.Windows.Forms.Button();
            this.btnEliminarCoche = new System.Windows.Forms.Button();
            this.btnBuscarCoche = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(319, 362);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearCoche
            // 
            this.btnCrearCoche.Location = new System.Drawing.Point(16, 136);
            this.btnCrearCoche.Name = "btnCrearCoche";
            this.btnCrearCoche.Size = new System.Drawing.Size(75, 23);
            this.btnCrearCoche.TabIndex = 1;
            this.btnCrearCoche.Text = "Crear";
            this.btnCrearCoche.UseVisualStyleBackColor = true;
            // 
            // btnEliminarCoche
            // 
            this.btnEliminarCoche.Location = new System.Drawing.Point(126, 136);
            this.btnEliminarCoche.Name = "btnEliminarCoche";
            this.btnEliminarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCoche.TabIndex = 2;
            this.btnEliminarCoche.Text = "Eliminar";
            this.btnEliminarCoche.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCoche
            // 
            this.btnBuscarCoche.Location = new System.Drawing.Point(12, 25);
            this.btnBuscarCoche.Name = "btnBuscarCoche";
            this.btnBuscarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCoche.TabIndex = 3;
            this.btnBuscarCoche.Text = "Buscar";
            this.btnBuscarCoche.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCrearCoche);
            this.groupBox1.Controls.Add(this.btnEliminarCoche);
            this.groupBox1.Location = new System.Drawing.Point(359, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 200);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Coches";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Patente";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(75, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Interno";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(93, 28);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(90, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // UIGestionarCoches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 450);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscarCoche);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UIGestionarCoches";
            this.Text = "GestionarCoches";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCrearCoche;
        private System.Windows.Forms.Button btnEliminarCoche;
        private System.Windows.Forms.Button btnBuscarCoche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}