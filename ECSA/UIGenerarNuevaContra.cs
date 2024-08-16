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

        public UIGenerarNuevaContra()
        {
            InitializeComponent();
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
                    MessageBox.Show("Nueva contraseña generada con éxito");
                }
                else
                {
                    MessageBox.Show("Hubo un error al generar la contraseña.");
                }

                
            }
        }


    }
}
