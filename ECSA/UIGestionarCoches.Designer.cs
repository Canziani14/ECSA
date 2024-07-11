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
            this.dtgCoches = new System.Windows.Forms.DataGridView();
            this.btnCrearCoche = new System.Windows.Forms.Button();
            this.btnEliminarCoche = new System.Windows.Forms.Button();
            this.btnBuscarCoche = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoches)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCoches
            // 
            this.dtgCoches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCoches.Location = new System.Drawing.Point(3, 76);
            this.dtgCoches.Name = "dtgCoches";
            this.dtgCoches.Size = new System.Drawing.Size(238, 362);
            this.dtgCoches.TabIndex = 0;
            // 
            // btnCrearCoche
            // 
            this.btnCrearCoche.Location = new System.Drawing.Point(16, 136);
            this.btnCrearCoche.Name = "btnCrearCoche";
            this.btnCrearCoche.Size = new System.Drawing.Size(75, 23);
            this.btnCrearCoche.TabIndex = 1;
            this.btnCrearCoche.Text = "Crear";
            this.btnCrearCoche.UseVisualStyleBackColor = true;
            this.btnCrearCoche.Click += new System.EventHandler(this.btnCrearCoche_Click);
            // 
            // btnEliminarCoche
            // 
            this.btnEliminarCoche.Location = new System.Drawing.Point(126, 136);
            this.btnEliminarCoche.Name = "btnEliminarCoche";
            this.btnEliminarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCoche.TabIndex = 2;
            this.btnEliminarCoche.Text = "Eliminar";
            this.btnEliminarCoche.UseVisualStyleBackColor = true;
            this.btnEliminarCoche.Click += new System.EventHandler(this.btnEliminarCoche_Click);
            // 
            // btnBuscarCoche
            // 
            this.btnBuscarCoche.Location = new System.Drawing.Point(179, 34);
            this.btnBuscarCoche.Name = "btnBuscarCoche";
            this.btnBuscarCoche.Size = new System.Drawing.Size(62, 23);
            this.btnBuscarCoche.TabIndex = 3;
            this.btnBuscarCoche.Text = "Buscar";
            this.btnBuscarCoche.UseVisualStyleBackColor = true;
            this.btnBuscarCoche.Click += new System.EventHandler(this.btnBuscarCoche_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCrearCoche);
            this.groupBox1.Controls.Add(this.btnEliminarCoche);
            this.groupBox1.Location = new System.Drawing.Point(257, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 200);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestor de Coches";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Linea a asignar";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(102, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(71, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Patente";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(102, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Interno";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(83, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(90, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Buscar Interno:";
            // 
            // UIGestionarCoches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscarCoche);
            this.Controls.Add(this.dtgCoches);
            this.Name = "UIGestionarCoches";
            this.Text = "GestionarCoches";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCoches)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCoches;
        private System.Windows.Forms.Button btnCrearCoche;
        private System.Windows.Forms.Button btnEliminarCoche;
        private System.Windows.Forms.Button btnBuscarCoche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}