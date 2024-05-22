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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(202, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(432, 186);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCrearLinea
            // 
            this.btnCrearLinea.Location = new System.Drawing.Point(33, 38);
            this.btnCrearLinea.Name = "btnCrearLinea";
            this.btnCrearLinea.Size = new System.Drawing.Size(75, 23);
            this.btnCrearLinea.TabIndex = 1;
            this.btnCrearLinea.Text = "Crear";
            this.btnCrearLinea.UseVisualStyleBackColor = true;
            // 
            // btnModificarLinea
            // 
            this.btnModificarLinea.Location = new System.Drawing.Point(33, 101);
            this.btnModificarLinea.Name = "btnModificarLinea";
            this.btnModificarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnModificarLinea.TabIndex = 2;
            this.btnModificarLinea.Text = "Modificar";
            this.btnModificarLinea.UseVisualStyleBackColor = true;
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.Location = new System.Drawing.Point(33, 171);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLinea.TabIndex = 3;
            this.btnEliminarLinea.Text = "Eliminar";
            this.btnEliminarLinea.UseVisualStyleBackColor = true;
            // 
            // btnGestionarCoches
            // 
            this.btnGestionarCoches.Location = new System.Drawing.Point(665, 209);
            this.btnGestionarCoches.Name = "btnGestionarCoches";
            this.btnGestionarCoches.Size = new System.Drawing.Size(102, 23);
            this.btnGestionarCoches.TabIndex = 4;
            this.btnGestionarCoches.Text = "Gestionar Coches";
            this.btnGestionarCoches.UseVisualStyleBackColor = true;
            // 
            // UIGestionarLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGestionarCoches);
            this.Controls.Add(this.btnEliminarLinea);
            this.Controls.Add(this.btnModificarLinea);
            this.Controls.Add(this.btnCrearLinea);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UIGestionarLinea";
            this.Text = "GestionarLinea";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCrearLinea;
        private System.Windows.Forms.Button btnModificarLinea;
        private System.Windows.Forms.Button btnEliminarLinea;
        private System.Windows.Forms.Button btnGestionarCoches;
    }
}