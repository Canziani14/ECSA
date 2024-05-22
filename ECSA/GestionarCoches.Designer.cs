namespace ECSA
{
    partial class GestionarCoches
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(161, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(429, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearCoche
            // 
            this.btnCrearCoche.Location = new System.Drawing.Point(36, 75);
            this.btnCrearCoche.Name = "btnCrearCoche";
            this.btnCrearCoche.Size = new System.Drawing.Size(75, 23);
            this.btnCrearCoche.TabIndex = 1;
            this.btnCrearCoche.Text = "Crear";
            this.btnCrearCoche.UseVisualStyleBackColor = true;
            // 
            // btnEliminarCoche
            // 
            this.btnEliminarCoche.Location = new System.Drawing.Point(36, 128);
            this.btnEliminarCoche.Name = "btnEliminarCoche";
            this.btnEliminarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCoche.TabIndex = 2;
            this.btnEliminarCoche.Text = "Eliminar";
            this.btnEliminarCoche.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCoche
            // 
            this.btnBuscarCoche.Location = new System.Drawing.Point(640, 156);
            this.btnBuscarCoche.Name = "btnBuscarCoche";
            this.btnBuscarCoche.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCoche.TabIndex = 3;
            this.btnBuscarCoche.Text = "Buscar";
            this.btnBuscarCoche.UseVisualStyleBackColor = true;
            // 
            // GestionarCoches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarCoche);
            this.Controls.Add(this.btnEliminarCoche);
            this.Controls.Add(this.btnCrearCoche);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GestionarCoches";
            this.Text = "GestionarCoches";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCrearCoche;
        private System.Windows.Forms.Button btnEliminarCoche;
        private System.Windows.Forms.Button btnBuscarCoche;
    }
}