﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECSA
{
    public partial class UILogin : Form
    {
        public UILogin()
        {
            InitializeComponent();
        }

        private void btnGenerarNuevaClave_Click(object sender, EventArgs e)
        {
            UIGenerarNuevaContra uIGenerarNuevaContra = new UIGenerarNuevaContra();
            uIGenerarNuevaContra.MdiParent = this;
            uIGenerarNuevaContra.Show();
        }
    }
}
