using BE;
using DAL;
using DAL.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
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
        private static Random random = new Random();


        #region Digitos Verificadores
        public int CalcularDVV(string tabla)
        {
           return DALSeguridad.CalcularDVV(tabla);
        }

/*        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            return DALSeguridad.InsertarDVH(DVH, cod, t, codtabla);
        }*/

        public int VerificarDigitosVerificadores(string tabla)
        {
            return DALSeguridad.VerificarDigitosVerificadores(tabla);
        }

        #endregion


        #region Encriptar y Desencriptar

        public string EncriptarCamposReversible(string cadenaen)
        {
            return DALSeguridad.EncriptarCamposReversible(cadenaen);
        }

       
        public string DesencriptarCamposReversible(string cadenades)
        {
            return DALSeguridad.DesencriptarCamposReversible(cadenades);
          
        }

        public static string EncriptarCamposIrreversible(string str)
        {
            return DALSeguridad.EncriptarCamposIrreversible(str);
        }

       

        /*

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
               */
        #endregion

        #region Generar Clave
        public string GenerarClave(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder resultado = new StringBuilder(longitud);

            for (int i = 0; i < longitud; i++)
            {
                resultado.Append(caracteresPermitidos[random.Next(caracteresPermitidos.Length)]);
            }

            return resultado.ToString();
        }
        public static void GuardarClaveEnArchivo(string clave)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaArchivo = Path.Combine(rutaEscritorio, "claves.txt");

            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine(clave);
            }

            Console.WriteLine($"Clave guardada en: {rutaArchivo}");
        }

        #endregion


        public bool BuscarEnBitacora()
        {
            throw new NotImplementedException();
        }

        public BE.Bitacora RegistrarEnBitacora(int i, string NickUsuarioLogin, int ID_Usuario)
        {
            return DALSeguridad.RegistrarEnBitacora(i, NickUsuarioLogin, ID_Usuario);
        }

        public bool DescargarBitacora()
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> Listar()
        {
            return DALSeguridad.Listar();
        }
        
         public List<Bitacora> ListarCrit3()
        {
            return DALSeguridad.ListarCrit3();
        }
                /*
                



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