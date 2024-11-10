namespace ECSA
{
    partial class UIInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIInicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnGestionarFamilias = new System.Windows.Forms.Button();
            this.btnGestionarPatentes = new System.Windows.Forms.Button();
            this.btnGestionarLineas = new System.Windows.Forms.Button();
            this.btnBKP = new System.Windows.Forms.Button();
            this.btnGestionarUsuarios = new System.Windows.Forms.Button();
            this.btnGestionarEmpleados = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnCambiarContra = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnAlertas = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnGestionarFamilias);
            this.panel1.Controls.Add(this.btnGestionarPatentes);
            this.panel1.Controls.Add(this.btnGestionarLineas);
            this.panel1.Controls.Add(this.btnBKP);
            this.panel1.Controls.Add(this.btnGestionarUsuarios);
            this.panel1.Controls.Add(this.btnGestionarEmpleados);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 658);
            this.panel1.TabIndex = 1;
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnReportes, "Seleccione para ingresar al Modulo de Reportes");
            this.btnReportes.Location = new System.Drawing.Point(0, 354);
            this.btnReportes.Name = "btnReportes";
            this.helpProvider1.SetShowHelp(this.btnReportes, true);
            this.btnReportes.Size = new System.Drawing.Size(115, 46);
            this.btnReportes.TabIndex = 9;
            this.btnReportes.Text = "Generar Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnGestionarFamilias
            // 
            this.btnGestionarFamilias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarFamilias.FlatAppearance.BorderSize = 0;
            this.btnGestionarFamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnGestionarFamilias, "Seleccione para ingresar al Modulo de Familias. Desde aqui podra asignar o quitar" +
        " familias a los usuarios del sistema");
            this.btnGestionarFamilias.Location = new System.Drawing.Point(0, 308);
            this.btnGestionarFamilias.Name = "btnGestionarFamilias";
            this.helpProvider1.SetShowHelp(this.btnGestionarFamilias, true);
            this.btnGestionarFamilias.Size = new System.Drawing.Size(115, 46);
            this.btnGestionarFamilias.TabIndex = 8;
            this.btnGestionarFamilias.Text = "Gestionar Familias";
            this.btnGestionarFamilias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarFamilias.UseVisualStyleBackColor = true;
            this.btnGestionarFamilias.Click += new System.EventHandler(this.btnGestionarFamilias_Click);
            // 
            // btnGestionarPatentes
            // 
            this.btnGestionarPatentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarPatentes.FlatAppearance.BorderSize = 0;
            this.btnGestionarPatentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnGestionarPatentes, "Seleccione para ingresar al Modulo de Patentes. Desde aqui podra asignar o quitar" +
        " patentes a los usuarios del sistema");
            this.btnGestionarPatentes.Location = new System.Drawing.Point(0, 262);
            this.btnGestionarPatentes.Name = "btnGestionarPatentes";
            this.helpProvider1.SetShowHelp(this.btnGestionarPatentes, true);
            this.btnGestionarPatentes.Size = new System.Drawing.Size(115, 46);
            this.btnGestionarPatentes.TabIndex = 7;
            this.btnGestionarPatentes.Text = "Gestionar Patentes";
            this.btnGestionarPatentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarPatentes.UseVisualStyleBackColor = true;
            this.btnGestionarPatentes.Click += new System.EventHandler(this.btnGestionarPatentes_Click);
            // 
            // btnGestionarLineas
            // 
            this.btnGestionarLineas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarLineas.FlatAppearance.BorderSize = 0;
            this.btnGestionarLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnGestionarLineas, "Seleccione para ingresar al Modulo de Lineas. Desde aqui podra crear, modificar, " +
        "o eliminar Lineas del sistema. Tambien podra Gestionar los servicios y los coche" +
        "s de la linea");
            this.btnGestionarLineas.Location = new System.Drawing.Point(0, 216);
            this.btnGestionarLineas.Name = "btnGestionarLineas";
            this.helpProvider1.SetShowHelp(this.btnGestionarLineas, true);
            this.btnGestionarLineas.Size = new System.Drawing.Size(115, 46);
            this.btnGestionarLineas.TabIndex = 4;
            this.btnGestionarLineas.Text = "Gestionar Lineas";
            this.btnGestionarLineas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarLineas.UseVisualStyleBackColor = true;
            this.btnGestionarLineas.Click += new System.EventHandler(this.btnGestionarLineas_Click);
            // 
            // btnBKP
            // 
            this.btnBKP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBKP.FlatAppearance.BorderSize = 0;
            this.btnBKP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnBKP, "Seleccione para ingresar al Modulo de BackUp/Restore. Desde aqui podra generar un" +
        " BackUp o generar un Restore");
            this.btnBKP.Location = new System.Drawing.Point(0, 170);
            this.btnBKP.Name = "btnBKP";
            this.helpProvider1.SetShowHelp(this.btnBKP, true);
            this.btnBKP.Size = new System.Drawing.Size(115, 46);
            this.btnBKP.TabIndex = 3;
            this.btnBKP.Text = "Gestionar BackUp";
            this.btnBKP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBKP.UseVisualStyleBackColor = true;
            this.btnBKP.Click += new System.EventHandler(this.btnBKP_Click);
            // 
            // btnGestionarUsuarios
            // 
            this.btnGestionarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGestionarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnGestionarUsuarios, "Seleccione para ingresar al Modulo de Usuarios. Desde aqui podra crear, modificar" +
        ", o eliminar usuarios del sistema");
            this.btnGestionarUsuarios.Location = new System.Drawing.Point(0, 124);
            this.btnGestionarUsuarios.Name = "btnGestionarUsuarios";
            this.helpProvider1.SetShowHelp(this.btnGestionarUsuarios, true);
            this.btnGestionarUsuarios.Size = new System.Drawing.Size(115, 46);
            this.btnGestionarUsuarios.TabIndex = 2;
            this.btnGestionarUsuarios.Text = "Gestionar Usuarios";
            this.btnGestionarUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionarUsuarios.Click += new System.EventHandler(this.btnGestionarUsuarios_Click_1);
            // 
            // btnGestionarEmpleados
            // 
            this.btnGestionarEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarEmpleados.FlatAppearance.BorderSize = 0;
            this.btnGestionarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnGestionarEmpleados, "Seleccione para ingresar al Modulo de Empleados. Desde aqui podra crear, modifica" +
        "r, o eliminar empleados del sistema");
            this.btnGestionarEmpleados.Location = new System.Drawing.Point(0, 78);
            this.btnGestionarEmpleados.Name = "btnGestionarEmpleados";
            this.helpProvider1.SetShowHelp(this.btnGestionarEmpleados, true);
            this.btnGestionarEmpleados.Size = new System.Drawing.Size(115, 46);
            this.btnGestionarEmpleados.TabIndex = 1;
            this.btnGestionarEmpleados.Text = "Gestionar Empleados";
            this.btnGestionarEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarEmpleados.UseVisualStyleBackColor = true;
            this.btnGestionarEmpleados.Click += new System.EventHandler(this.GestionarEmpleados_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 78);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCerrarSesion);
            this.panel2.Controls.Add(this.btnCambiarContra);
            this.panel2.Controls.Add(this.btnBitacora);
            this.panel2.Controls.Add(this.btnAlertas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1199, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 658);
            this.panel2.TabIndex = 3;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnCerrarSesion, "Cierra la sesion del usuario");
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 588);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.helpProvider1.SetShowHelp(this.btnCerrarSesion, true);
            this.btnCerrarSesion.Size = new System.Drawing.Size(70, 35);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnCambiarContra
            // 
            this.btnCambiarContra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCambiarContra.FlatAppearance.BorderSize = 0;
            this.btnCambiarContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnCambiarContra, "Cambia la contraseña del usuario");
            this.btnCambiarContra.Location = new System.Drawing.Point(0, 623);
            this.btnCambiarContra.Name = "btnCambiarContra";
            this.helpProvider1.SetShowHelp(this.btnCambiarContra, true);
            this.btnCambiarContra.Size = new System.Drawing.Size(70, 35);
            this.btnCambiarContra.TabIndex = 4;
            this.btnCambiarContra.Text = "Cambiar contraseña";
            this.btnCambiarContra.UseVisualStyleBackColor = true;
            this.btnCambiarContra.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBitacora.FlatAppearance.BorderSize = 0;
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnBitacora, "Seleccione para ingresar al Modulo de Bitacora. Desde aqui podra auditar los movi" +
        "mientos realizados por los usuarios en el sistema");
            this.btnBitacora.Location = new System.Drawing.Point(0, 23);
            this.btnBitacora.Name = "btnBitacora";
            this.helpProvider1.SetShowHelp(this.btnBitacora, true);
            this.btnBitacora.Size = new System.Drawing.Size(70, 35);
            this.btnBitacora.TabIndex = 2;
            this.btnBitacora.Text = "Consultar Bitacora";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnAlertas
            // 
            this.btnAlertas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlertas.FlatAppearance.BorderSize = 0;
            this.btnAlertas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.btnAlertas, "Seleccione para ingresar al Modulo de Alertas Criticas. Desde aqui podra ver las " +
        "alertas con nivel de criticidad 3");
            this.btnAlertas.Location = new System.Drawing.Point(0, 0);
            this.btnAlertas.Name = "btnAlertas";
            this.helpProvider1.SetShowHelp(this.btnAlertas, true);
            this.btnAlertas.Size = new System.Drawing.Size(70, 23);
            this.btnAlertas.TabIndex = 0;
            this.btnAlertas.Text = "Ver Alertas";
            this.btnAlertas.UseVisualStyleBackColor = true;
            this.btnAlertas.Click += new System.EventHandler(this.btnAlertas_Click);
            // 
            // UIInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 658);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UIInicio";
            this.Text = "ECSA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIInicio_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGestionarEmpleados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGestionarLineas;
        private System.Windows.Forms.Button btnBKP;
        private System.Windows.Forms.Button btnGestionarUsuarios;
        private System.Windows.Forms.Button btnGestionarPatentes;
        private System.Windows.Forms.Button btnGestionarFamilias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnAlertas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnCambiarContra;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

