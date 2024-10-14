﻿using BE;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;


namespace DAL
{
    public class DALSeguridad
    {

        #region Digitos Verificadores
        public int CalcularDVV(string tabla)
        {
           return DAOSSeguridad.GetInstance().CalcularDVV(tabla);
        }


        public int VerificarDigitosVerificadores(string tabla)
        {
            return DAOSSeguridad.GetInstance().VerificarDigitosVerificadores(tabla);
        }

        #endregion


        #region Encriptar y Desencriptar

        public string EncriptarCamposReversible(string cadenaen)
        {
            string encript=Convert.ToBase64String(Encoding.Unicode.GetBytes(cadenaen));
            return encript;
        }





        public string DesencriptarCamposReversible(string cadenades)
        {
            // Validación inicial para cadenas nulas o vacías
            if (string.IsNullOrEmpty(cadenades))
            {
                return ""; // Retorna una cadena vacía si la entrada es nula o vacía
            }

            // Limpieza de la cadena (elimina espacios en blanco, si los hay)
            cadenades = cadenades.Trim();

            // Agregar un log para verificar el contenido
            Console.WriteLine($"Cadena antes de convertir: {cadenades}");

            // Validación de longitud para Base-64
            if (cadenades.Length % 4 != 0)
            {
                throw new FormatException("La longitud de la cadena Base-64 no es válida.");
            }

            // Validación de caracteres inválidos
            if (cadenades.Any(c => !char.IsLetterOrDigit(c) && c != '+' && c != '/' && c != '='))
            {
                throw new FormatException("La cadena contiene caracteres no válidos para Base-64.");
            }

            try
            {
                // Desencriptar utilizando la codificación adecuada
                byte[] bytes = Convert.FromBase64String(cadenades);
                string desencript = Encoding.Unicode.GetString(bytes);
                return desencript; // Retorna el resultado desencriptado
            }
            catch (FormatException ex)
            {
                // Captura errores de formato en la conversión Base-64
                throw new FormatException("Error al intentar convertir la cadena Base-64.", ex);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro tipo de excepción
                throw new Exception("Error inesperado al desencriptar la cadena.", ex);
            }
        }



        /*
          public string DesencriptarCamposReversible(string cadenades)
          {
              if (cadenades == null)
              {
                  return "";
              }
              else
              {
                  string desencript= Encoding.Unicode.GetString(Convert.FromBase64String(cadenades));
                  return desencript;
              }

          }*/


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



        #endregion

        #region Bitacora


        public BE.Bitacora RegistrarEnBitacora(int i, string NickUsuarioLogin, int ID_Usuario)
        {
            return DAOSSeguridad.GetInstance().RegistrarEnBitacora(i, NickUsuarioLogin, ID_Usuario);
        }

        public List<Bitacora> BuscarEnBitacora(string fechaDesde, string fechaHasta, string nick)
        {
            return DAOSSeguridad.GetInstance().BuscarEnBitacora(fechaDesde, fechaHasta, nick);
        }


        public bool DescargarBitacora()
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> Listar()
        {
            return DAOs.DAOSSeguridad.GetInstance().Listar();
        }
        
        public List<Bitacora> ListarCrit3()
        {
            return DAOs.DAOSSeguridad.GetInstance().ListarCrit3();
        }
        #endregion

        public bool ValidarPatentes(int idUsuario, int idPatente)
        {
           return  DAOs.DAOSSeguridad.GetInstance().ValidarPatentes(idUsuario, idPatente);
        }

       /* public bool ValidarPatentes(int idUsuario, int idPatente, int id_Familia)
        {
            return DAOs.DAOSSeguridad.GetInstance().ValidarPatentes(idUsuario, idPatente, id_Familia);
        }*/

        public bool TienePatentesExclusivas(int usuarioId)
        {
            return DAOs.DAOSSeguridad.GetInstance().TienePatentesExclusivas(usuarioId);
        }




    }
}