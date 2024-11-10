using BE;
using BLL;
using System;
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
    public partial class UIGenerarNuevaContra : Form
    {
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();
        BE.Usuario usuarioLog = new BE.Usuario();
        BLL_ABM_Usuario BLLUsuario = new BLL_ABM_Usuario();
        BE.Usuario BEUsuario = new BE.Usuario();

        public UIGenerarNuevaContra(List<Traduccion> traducciones)
        {
            InitializeComponent();


            #region idioma

            foreach (var traduccion in traducciones)
            {
                switch (traduccion.ID_Traduccion)
                {
                    case 126:
                        lblIngreseMail.Text = traduccion.Descripcion;
                        break;
                    case 50:
                        btnGenerarNuevaContraseña.Text = traduccion.Descripcion;
                        break;                   
                }
            }

            #endregion


        }



        private void btnGenerarNuevaContraseña_Click(object sender, EventArgs e)
        {
            List<BE.Usuario> usuarios = BLLUsuario.ValidarMail(BLLSeguridad.EncriptarCamposReversible(txtMail.Text));
            BE.Usuario usuario = usuarios.SingleOrDefault();

            if (usuarios.Count>0)
            {
                
                int longitudClave = 12; // Puedes cambiar la longitud de la clave aquí
                string claveGenerada = BLLSeguridad.GenerarClave(longitudClave);
                Console.WriteLine($"Clave generada: {claveGenerada}");
                BLLSeguridad.GuardarClaveEnArchivo(claveGenerada);
                string contraseña = BLLSeguridad.EncriptarCamposIrreversible(claveGenerada);
                string nick =usuario.Nick;
                int id_Usuario = usuario.ID_Usuario;

                bool actualizacionExitosa = BLLUsuario.CambiarContraseña(id_Usuario, contraseña);

                if (actualizacionExitosa)
                {
                    BLLSeguridad.RegistrarEnBitacora(31, nick, id_Usuario);
                    string pdfEspañol = "Nueva contraseña generada con éxito";
                    string pdfIngles = "New password successfully generated";
                    if (btnGenerarNuevaContraseña.Text == "Generate New Password")
                    {
                        UINotificacion UINoti = new UINotificacion(pdfIngles, 2)
                        {
                            StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                            TopMost = true // Siempre visible encima de otras ventanas
                        };
                        UINoti.ShowDialog(); // Mostrar como diálog
                    }
                    else
                    {
                        UINotificacion UINoti = new UINotificacion(pdfEspañol, 1)
                        {
                            StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                            TopMost = true // Siempre visible encima de otras ventanas
                        };
                        UINoti.ShowDialog(); // Mostrar como diálogo modal
                    }

                    
                }
                else
                {
           
                    string pdfEspañol = "Hubo un error al generar la contraseña.";
                    string pdfIngles = "There was an error generating the password.";
                    if (btnGenerarNuevaContraseña.Text == "Generate New Password")
                    {
                        UINotificacion UINoti = new UINotificacion(pdfIngles, 2)
                        {
                            StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                            TopMost = true // Siempre visible encima de otras ventanas
                        };
                        UINoti.ShowDialog(); // Mostrar como diálog
                    }
                    else
                    {
                        UINotificacion UINoti = new UINotificacion(pdfEspañol, 1)
                        {
                            StartPosition = FormStartPosition.CenterScreen, // Centrado en pantalla
                            TopMost = true // Siempre visible encima de otras ventanas
                        };
                        UINoti.ShowDialog(); // Mostrar como diálogo modal
                    }
                }

                
            }
        }


    }
}
