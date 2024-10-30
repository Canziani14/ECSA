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

        #region Bitacora
        public List<Bitacora> BuscarEnBitacora(string fechaDesde, string fechaHasta, string nick)
        {
            return DALSeguridad.BuscarEnBitacora(fechaDesde, fechaHasta, nick);
        }

        public BE.Bitacora RegistrarEnBitacora(int i, string NickUsuarioLogin, int ID_Usuario)
        {
            return DALSeguridad.RegistrarEnBitacora(i, NickUsuarioLogin, ID_Usuario);
        }

       

        public List<Bitacora> Listar()
        {
            return DALSeguridad.Listar();
        }
        
         public List<Bitacora> ListarCrit3()
        {
            return DALSeguridad.ListarCrit3();
        }

        #endregion


        #region validaciones eliminar/bloquear usuario
        public bool TienePatenteUnica(int idUsuario)
        {
            return DALSeguridad.TienePatenteUnica(idUsuario);
        }

        public bool TieneFamiliaConPatenteUnica(int idUsuario)
        {
            return DALSeguridad.TieneFamiliaConPatenteUnica(idUsuario);
        }
        #endregion


        #region validacion familia
        public bool FamiliaContienePatenteUnicaParaUsuario(int idUsuario, int idFamilia)
        {
            return DALSeguridad.FamiliaContienePatenteUnicaParaUsuario(idUsuario, idFamilia);
        }
        public bool PuedeEliminarFamilia(int idFamilia)
        {
            return DALSeguridad.PuedeEliminarFamilia(idFamilia);
        }

        public bool PuedeEliminarPatenteDeFamilia2(int idPatente, int idUsuario)
        {
           
                return DALSeguridad.PuedeEliminarPatenteDeFamilia2(idPatente, idUsuario); 
        }

        public bool PuedeEliminarPatente(int idUsuario, int idPatente)
        {

            return DALSeguridad.PuedeEliminarPatente(idUsuario, idPatente);
        }

        

        public bool UsuarioQuedariaConPatentesSinFamilia(int idPatente, int idUsuario)
        {

                return DALSeguridad.UsuarioQuedariaConPatentesSinFamilia(idPatente, idUsuario);

        }
        
        public bool FamiliaTendriaPatenteSinUsuario(int idUsuario, int idFamilia)
        {

            return DALSeguridad.FamiliaTendriaPatenteSinUsuario(idUsuario, idFamilia);

        }

        

        #endregion

        #region Validar Patentes
        public bool PuedeEliminarPatenteDeUsuario(int idUsuario, int idPatente)
        {
            return DALSeguridad.PuedeEliminarPatenteDeUsuario(idUsuario, idPatente);
        }

        public bool PuedeEliminarPatenteDeFamilia(int idFamilia, int idPatente)
        {
            return DALSeguridad.PuedeEliminarPatenteDeFamilia(idFamilia, idPatente);
        }

        public bool VerificarOtrasAsignacionesDePatente(int id_Patente, int id_Familia)
        {
            return DALSeguridad.VerificarOtrasAsignacionesDePatente(id_Patente, id_Familia);
        }

     

        #endregion




    }
}