using BE;
using DAL;
using DAL.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSeguridad
    {
        DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();
        BE.Empleado BEEmpleado = new BE.Empleado();



        #region Digitos Verificadores
        public int CalcularDVV(string tabla)
        {
           return DALSeguridad.CalcularDVV(tabla);
        }

        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            return DALSeguridad.InsertarDVH(DVH, cod, t, codtabla);
        }

        public int VerificarDigitosVerificadores(string tabla)
        {
            return DALSeguridad.VerificarDigitosVerificadores(tabla);
        }

        #endregion


        #region Encriptar y Desencriptar

        public string EncriptarCamposReversible(string cadenaen)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadenaen));
        }

        public string DesencriptarCamposReversible(string cadenades)
        {
            if (cadenades == null)
            {
                return "";
            }
            else
            {
                return Encoding.Unicode.GetString(Convert.FromBase64String(cadenades));
            }
        }


        public static string EncriptarCamposIrreversible(string str)
        {
            str = str + "matias";
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public int CompararContraseña(string un, string pass)
        {
            string passencriptada = EncriptarCamposIrreversible(pass);
            string unencriptado = EncriptarCamposReversible(un);
            //SeguridadDAL sdal = new SeguridadDAL();
            //return sdal.ComprobarContraseña(unencriptado, passencriptada);
            return 0;
        }

        #endregion





        /*
                public bool BuscarEnBitacora()
                {
                    throw new NotImplementedException();
                }

                public bool RegistrarEnBitacora()
                {
                    throw new NotImplementedException();
                }

                public bool DescargarBitacora()
                {
                    throw new NotImplementedException();
                }



                public bool GenerarContraseñaAleatoria()
                {
                    throw new NotImplementedException();
                }

                public bool GenerarTxtContraseña()
                {
                    throw new NotImplementedException();
                }

                public bool ValidarPatentes()
                {
                    throw new NotImplementedException();
                }
        */

    }
}