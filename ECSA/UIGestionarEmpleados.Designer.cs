namespace ECSA
{
    partial class UIGestionarEmpleados
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
            this.components = new System.ComponentModel.Container();
            this.dtgEmpleados = new System.Windows.Forms.DataGridView();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.btnCrearEmpleado = new System.Windows.Forms.Button();
            this.btnModificarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.gbGestorEmpleados = new System.Windows.Forms.GroupBox();
            this.btnRecuperarEmlpeado = new System.Windows.Forms.Button();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblFechaDeIngreo = new System.Windows.Forms.Label();
            this.txtFechadeIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblLinea = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.txtBuscarEmpleado = new System.Windows.Forms.TextBox();
            this.lblBuscarEmpleado = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados)).BeginInit();
            this.gbGestorEmpleados.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgEmpleados
            // 
            this.dtgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmpleados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgEmpleados.Location = new System.Drawing.Point(1, 74);
            this.dtgEmpleados.Name = "dtgEmpleados";
            this.dtgEmpleados.RowHeadersVisible = false;
            this.dtgEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmpleados.Size = new System.Drawing.Size(634, 364);
            this.dtgEmpleados.TabIndex = 0;
            this.dtgEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEmpleados_CellDoubleClick);
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(305, 29);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarEmpleado.TabIndex = 1;
            this.btnBuscarEmpleado.Text = "Buscar";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // btnCrearEmpleado
            // 
            this.btnCrearEmpleado.Location = new System.Drawing.Point(6, 311);
            this.btnCrearEmpleado.Name = "btnCrearEmpleado";
            this.btnCrearEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnCrearEmpleado.TabIndex = 2;
            this.btnCrearEmpleado.Text = "Crear";
            this.btnCrearEmpleado.UseVisualStyleBackColor = true;
            this.btnCrearEmpleado.Click += new System.EventHandler(this.btnCrearEmpleado_Click);
            // 
            // btnModificarEmpleado
            // 
            this.btnModificarEmpleado.Location = new System.Drawing.Point(126, 311);
            this.btnModificarEmpleado.Name = "btnModificarEmpleado";
            this.btnModificarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnModificarEmpleado.TabIndex = 3;
            this.btnModificarEmpleado.Text = "Modificar";
            this.btnModificarEmpleado.UseVisualStyleBackColor = true;
            this.btnModificarEmpleado.Click += new System.EventHandler(this.btnModificarEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(242, 311);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarEmpleado.TabIndex = 4;
            this.btnEliminarEmpleado.Text = "Eliminar";
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(27, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(27, 55);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(27, 88);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 7;
            this.lblDNI.Text = "DNI";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(27, 118);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(27, 157);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(158, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(126, 48);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(158, 20);
            this.txtApellido.TabIndex = 11;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(126, 81);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(158, 20);
            this.txtDNI.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(126, 118);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(158, 20);
            this.txtDireccion.TabIndex = 13;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(126, 157);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(158, 20);
            this.txtTelefono.TabIndex = 14;
            // 
            // gbGestorEmpleados
            // 
            this.gbGestorEmpleados.Controls.Add(this.btnRecuperarEmlpeado);
            this.gbGestorEmpleados.Controls.Add(this.lblLegajo);
            this.gbGestorEmpleados.Controls.Add(this.txtLegajo);
            this.gbGestorEmpleados.Controls.Add(this.lblFechaDeIngreo);
            this.gbGestorEmpleados.Controls.Add(this.txtFechadeIngreso);
            this.gbGestorEmpleados.Controls.Add(this.lblLinea);
            this.gbGestorEmpleados.Controls.Add(this.label7);
            this.gbGestorEmpleados.Controls.Add(this.cmbLinea);
            this.gbGestorEmpleados.Controls.Add(this.lblNombre);
            this.gbGestorEmpleados.Controls.Add(this.btnEliminarEmpleado);
            this.gbGestorEmpleados.Controls.Add(this.txtTelefono);
            this.gbGestorEmpleados.Controls.Add(this.btnModificarEmpleado);
            this.gbGestorEmpleados.Controls.Add(this.txtNombre);
            this.gbGestorEmpleados.Controls.Add(this.btnCrearEmpleado);
            this.gbGestorEmpleados.Controls.Add(this.lblTelefono);
            this.gbGestorEmpleados.Controls.Add(this.txtDireccion);
            this.gbGestorEmpleados.Controls.Add(this.lblApellido);
            this.gbGestorEmpleados.Controls.Add(this.txtDNI);
            this.gbGestorEmpleados.Controls.Add(this.lblDireccion);
            this.gbGestorEmpleados.Controls.Add(this.txtApellido);
            this.gbGestorEmpleados.Controls.Add(this.lblDNI);
            this.gbGestorEmpleados.Location = new System.Drawing.Point(641, 74);
            this.gbGestorEmpleados.Name = "gbGestorEmpleados";
            this.gbGestorEmpleados.Size = new System.Drawing.Size(335, 390);
            this.gbGestorEmpleados.TabIndex = 15;
            this.gbGestorEmpleados.TabStop = false;
            this.gbGestorEmpleados.Text = "Gestor de Empleados";
            // 
            // btnRecuperarEmlpeado
            // 
            this.btnRecuperarEmlpeado.Location = new System.Drawing.Point(242, 341);
            this.btnRecuperarEmlpeado.Name = "btnRecuperarEmlpeado";
            this.btnRecuperarEmlpeado.Size = new System.Drawing.Size(75, 43);
            this.btnRecuperarEmlpeado.TabIndex = 22;
            this.btnRecuperarEmlpeado.Text = "Recuperar Empleado";
            this.btnRecuperarEmlpeado.UseVisualStyleBackColor = true;
            this.btnRecuperarEmlpeado.Click += new System.EventHandler(this.btnRecuperarEmlpeado_Click);
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(21, 280);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(39, 13);
            this.lblLegajo.TabIndex = 21;
            this.lblLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(126, 273);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(100, 20);
            this.txtLegajo.TabIndex = 20;
            // 
            // lblFechaDeIngreo
            // 
            this.lblFechaDeIngreo.AutoSize = true;
            this.lblFechaDeIngreo.Location = new System.Drawing.Point(21, 248);
            this.lblFechaDeIngreo.Name = "lblFechaDeIngreo";
            this.lblFechaDeIngreo.Size = new System.Drawing.Size(90, 13);
            this.lblFechaDeIngreo.TabIndex = 19;
            this.lblFechaDeIngreo.Text = "Fecha de Ingreso";
            // 
            // txtFechadeIngreso
            // 
            this.txtFechadeIngreso.Location = new System.Drawing.Point(117, 242);
            this.txtFechadeIngreso.Name = "txtFechadeIngreso";
            this.txtFechadeIngreso.Size = new System.Drawing.Size(200, 20);
            this.txtFechadeIngreso.TabIndex = 18;
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Location = new System.Drawing.Point(27, 203);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(33, 13);
            this.lblLinea.TabIndex = 17;
            this.lblLinea.Text = "Linea";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 16;
            // 
            // cmbLinea
            // 
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(126, 200);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(121, 21);
            this.cmbLinea.TabIndex = 15;
            // 
            // txtBuscarEmpleado
            // 
            this.txtBuscarEmpleado.Location = new System.Drawing.Point(97, 29);
            this.txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            this.txtBuscarEmpleado.Size = new System.Drawing.Size(202, 20);
            this.txtBuscarEmpleado.TabIndex = 15;
            // 
            // lblBuscarEmpleado
            // 
            this.lblBuscarEmpleado.AutoSize = true;
            this.lblBuscarEmpleado.Location = new System.Drawing.Point(-2, 36);
            this.lblBuscarEmpleado.Name = "lblBuscarEmpleado";
            this.lblBuscarEmpleado.Size = new System.Drawing.Size(93, 13);
            this.lblBuscarEmpleado.TabIndex = 16;
            this.lblBuscarEmpleado.Text = "Buscar Empleado:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UIGestionarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 476);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblBuscarEmpleado);
            this.Controls.Add(this.txtBuscarEmpleado);
            this.Controls.Add(this.gbGestorEmpleados);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.dtgEmpleados);
            this.Name = "UIGestionarEmpleados";
            this.Text = "GestionarEmpleados";
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados)).EndInit();
            this.gbGestorEmpleados.ResumeLayout(false);
            this.gbGestorEmpleados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgEmpleados;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.Button btnCrearEmpleado;
        private System.Windows.Forms.Button btnModificarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.GroupBox gbGestorEmpleados;
        private System.Windows.Forms.TextBox txtBuscarEmpleado;
        private System.Windows.Forms.Label lblBuscarEmpleado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label lblFechaDeIngreo;
        private System.Windows.Forms.DateTimePicker txtFechadeIngreso;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnRecuperarEmlpeado;
        private System.Windows.Forms.Button button1;
    }
}