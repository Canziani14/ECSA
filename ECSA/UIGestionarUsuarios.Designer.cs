namespace ECSA
{
    partial class UIGestionarUsuarios
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
            this.dtgUsuarios = new System.Windows.Forms.DataGridView();
            this.eCSADataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.btnDesbloquearUsuario = new System.Windows.Forms.Button();
            this.btnBloquearUsuario = new System.Windows.Forms.Button();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eCSADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbGestorUsuarios = new System.Windows.Forms.GroupBox();
            this.txtIDUsuario = new System.Windows.Forms.TextBox();
            this.lblidUsuario = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.dtgFamiliaActual = new System.Windows.Forms.DataGridView();
            this.gbGestorFamiliasPorUsuario = new System.Windows.Forms.GroupBox();
            this.lblSinAsignar = new System.Windows.Forms.Label();
            this.lblAsignadas = new System.Windows.Forms.Label();
            this.dtgFamiliasSinAsignar = new System.Windows.Forms.DataGridView();
            this.lblBuscarUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCSADataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCSADataSetBindingSource)).BeginInit();
            this.gbGestorUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliaActual)).BeginInit();
            this.gbGestorFamiliasPorUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliasSinAsignar)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgUsuarios
            // 
            this.dtgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsuarios.Location = new System.Drawing.Point(12, 69);
            this.dtgUsuarios.Name = "dtgUsuarios";
            this.dtgUsuarios.Size = new System.Drawing.Size(461, 208);
            this.dtgUsuarios.TabIndex = 0;
            this.dtgUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUsuarios_CellDoubleClick);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(6, 168);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnCrearUsuario.TabIndex = 1;
            this.btnCrearUsuario.Text = "Crear";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(186, 168);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarUsuario.TabIndex = 2;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(95, 168);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnModificarUsuario.TabIndex = 3;
            this.btnModificarUsuario.Text = "Modificar";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Location = new System.Drawing.Point(339, 30);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(57, 23);
            this.btnBuscarUsuario.TabIndex = 7;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // btnDesbloquearUsuario
            // 
            this.btnDesbloquearUsuario.Location = new System.Drawing.Point(145, 209);
            this.btnDesbloquearUsuario.Name = "btnDesbloquearUsuario";
            this.btnDesbloquearUsuario.Size = new System.Drawing.Size(116, 23);
            this.btnDesbloquearUsuario.TabIndex = 8;
            this.btnDesbloquearUsuario.Text = "Desbloquear Usuario";
            this.btnDesbloquearUsuario.UseVisualStyleBackColor = true;
            this.btnDesbloquearUsuario.Click += new System.EventHandler(this.btnDesbloquearUsuario_Click);
            // 
            // btnBloquearUsuario
            // 
            this.btnBloquearUsuario.Location = new System.Drawing.Point(37, 209);
            this.btnBloquearUsuario.Name = "btnBloquearUsuario";
            this.btnBloquearUsuario.Size = new System.Drawing.Size(97, 23);
            this.btnBloquearUsuario.TabIndex = 9;
            this.btnBloquearUsuario.Text = "Bloquear Usuario";
            this.btnBloquearUsuario.UseVisualStyleBackColor = true;
            this.btnBloquearUsuario.Click += new System.EventHandler(this.btnBloquearUsuario_Click);
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataMember = "Usuario";
            // 
            // gbGestorUsuarios
            // 
            this.gbGestorUsuarios.Controls.Add(this.txtIDUsuario);
            this.gbGestorUsuarios.Controls.Add(this.lblidUsuario);
            this.gbGestorUsuarios.Controls.Add(this.txtDNI);
            this.gbGestorUsuarios.Controls.Add(this.lblDNI);
            this.gbGestorUsuarios.Controls.Add(this.txtMail);
            this.gbGestorUsuarios.Controls.Add(this.lblMail);
            this.gbGestorUsuarios.Controls.Add(this.txtNick);
            this.gbGestorUsuarios.Controls.Add(this.lblNick);
            this.gbGestorUsuarios.Controls.Add(this.txtApellido);
            this.gbGestorUsuarios.Controls.Add(this.lblApellido);
            this.gbGestorUsuarios.Controls.Add(this.txtNombre);
            this.gbGestorUsuarios.Controls.Add(this.lblNombre);
            this.gbGestorUsuarios.Controls.Add(this.btnCrearUsuario);
            this.gbGestorUsuarios.Controls.Add(this.btnBloquearUsuario);
            this.gbGestorUsuarios.Controls.Add(this.btnModificarUsuario);
            this.gbGestorUsuarios.Controls.Add(this.btnDesbloquearUsuario);
            this.gbGestorUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.gbGestorUsuarios.Location = new System.Drawing.Point(488, 29);
            this.gbGestorUsuarios.Name = "gbGestorUsuarios";
            this.gbGestorUsuarios.Size = new System.Drawing.Size(281, 248);
            this.gbGestorUsuarios.TabIndex = 10;
            this.gbGestorUsuarios.TabStop = false;
            this.gbGestorUsuarios.Text = "Gestor de Usuarios";
            // 
            // txtIDUsuario
            // 
            this.txtIDUsuario.Enabled = false;
            this.txtIDUsuario.Location = new System.Drawing.Point(70, 14);
            this.txtIDUsuario.Name = "txtIDUsuario";
            this.txtIDUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtIDUsuario.TabIndex = 21;
            // 
            // lblidUsuario
            // 
            this.lblidUsuario.AutoSize = true;
            this.lblidUsuario.Location = new System.Drawing.Point(6, 17);
            this.lblidUsuario.Name = "lblidUsuario";
            this.lblidUsuario.Size = new System.Drawing.Size(60, 13);
            this.lblidUsuario.TabIndex = 20;
            this.lblidUsuario.Text = "ID_Usuario";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(70, 93);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 19;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(6, 96);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 18;
            this.lblDNI.Text = "DNI";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(70, 142);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(164, 20);
            this.txtMail.TabIndex = 17;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(6, 145);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 16;
            this.lblMail.Text = "Mail";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(70, 119);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(100, 20);
            this.txtNick.TabIndex = 15;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(6, 122);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(29, 13);
            this.lblNick.TabIndex = 14;
            this.lblNick.Text = "Nick";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(70, 64);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 13;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 66);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(70, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 11;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 43);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Location = new System.Drawing.Point(118, 30);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(215, 20);
            this.txtBuscarUsuario.TabIndex = 18;
            // 
            // dtgFamiliaActual
            // 
            this.dtgFamiliaActual.AutoGenerateColumns = false;
            this.dtgFamiliaActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFamiliaActual.DataSource = this.eCSADataSetBindingSource1;
            this.dtgFamiliaActual.Location = new System.Drawing.Point(19, 46);
            this.dtgFamiliaActual.Name = "dtgFamiliaActual";
            this.dtgFamiliaActual.Size = new System.Drawing.Size(217, 210);
            this.dtgFamiliaActual.TabIndex = 19;
            this.dtgFamiliaActual.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFamiliaActual_CellDoubleClick);
            // 
            // gbGestorFamiliasPorUsuario
            // 
            this.gbGestorFamiliasPorUsuario.Controls.Add(this.lblSinAsignar);
            this.gbGestorFamiliasPorUsuario.Controls.Add(this.lblAsignadas);
            this.gbGestorFamiliasPorUsuario.Controls.Add(this.dtgFamiliasSinAsignar);
            this.gbGestorFamiliasPorUsuario.Controls.Add(this.dtgFamiliaActual);
            this.gbGestorFamiliasPorUsuario.Location = new System.Drawing.Point(119, 283);
            this.gbGestorFamiliasPorUsuario.Name = "gbGestorFamiliasPorUsuario";
            this.gbGestorFamiliasPorUsuario.Size = new System.Drawing.Size(539, 256);
            this.gbGestorFamiliasPorUsuario.TabIndex = 21;
            this.gbGestorFamiliasPorUsuario.TabStop = false;
            this.gbGestorFamiliasPorUsuario.Text = "Gestor de Familias por Usuario";
            // 
            // lblSinAsignar
            // 
            this.lblSinAsignar.AutoSize = true;
            this.lblSinAsignar.Location = new System.Drawing.Point(390, 30);
            this.lblSinAsignar.Name = "lblSinAsignar";
            this.lblSinAsignar.Size = new System.Drawing.Size(60, 13);
            this.lblSinAsignar.TabIndex = 24;
            this.lblSinAsignar.Text = "Sin Asignar";
            // 
            // lblAsignadas
            // 
            this.lblAsignadas.AutoSize = true;
            this.lblAsignadas.Location = new System.Drawing.Point(97, 30);
            this.lblAsignadas.Name = "lblAsignadas";
            this.lblAsignadas.Size = new System.Drawing.Size(56, 13);
            this.lblAsignadas.TabIndex = 23;
            this.lblAsignadas.Text = "Asignadas";
            // 
            // dtgFamiliasSinAsignar
            // 
            this.dtgFamiliasSinAsignar.AutoGenerateColumns = false;
            this.dtgFamiliasSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFamiliasSinAsignar.DataSource = this.eCSADataSetBindingSource1;
            this.dtgFamiliasSinAsignar.Location = new System.Drawing.Point(304, 46);
            this.dtgFamiliasSinAsignar.Name = "dtgFamiliasSinAsignar";
            this.dtgFamiliasSinAsignar.Size = new System.Drawing.Size(217, 207);
            this.dtgFamiliasSinAsignar.TabIndex = 20;
            this.dtgFamiliasSinAsignar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFamiliasSinAsignar_CellDoubleClick);
            // 
            // lblBuscarUsuario
            // 
            this.lblBuscarUsuario.AutoSize = true;
            this.lblBuscarUsuario.Location = new System.Drawing.Point(33, 35);
            this.lblBuscarUsuario.Name = "lblBuscarUsuario";
            this.lblBuscarUsuario.Size = new System.Drawing.Size(82, 13);
            this.lblBuscarUsuario.TabIndex = 22;
            this.lblBuscarUsuario.Text = "Buscar Usuario:";
            // 
            // UIGestionarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 538);
            this.Controls.Add(this.lblBuscarUsuario);
            this.Controls.Add(this.gbGestorFamiliasPorUsuario);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.gbGestorUsuarios);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.dtgUsuarios);
            this.Name = "UIGestionarUsuarios";
            this.Text = "GestionarUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCSADataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCSADataSetBindingSource)).EndInit();
            this.gbGestorUsuarios.ResumeLayout(false);
            this.gbGestorUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliaActual)).EndInit();
            this.gbGestorFamiliasPorUsuario.ResumeLayout(false);
            this.gbGestorFamiliasPorUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFamiliasSinAsignar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgUsuarios;
     
        private System.Windows.Forms.BindingSource usuarioBindingSource;
  
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.BindingSource eCSADataSetBindingSource1;
        private System.Windows.Forms.BindingSource eCSADataSetBindingSource;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.Button btnDesbloquearUsuario;
        private System.Windows.Forms.Button btnBloquearUsuario;
        private System.Windows.Forms.GroupBox gbGestorUsuarios;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.DataGridView dtgFamiliaActual;
        private System.Windows.Forms.GroupBox gbGestorFamiliasPorUsuario;
        private System.Windows.Forms.DataGridView dtgFamiliasSinAsignar;
        private System.Windows.Forms.Label lblBuscarUsuario;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtIDUsuario;
        private System.Windows.Forms.Label lblidUsuario;
        private System.Windows.Forms.Label lblSinAsignar;
        private System.Windows.Forms.Label lblAsignadas;
    }
}