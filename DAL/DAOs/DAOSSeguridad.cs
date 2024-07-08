using SQLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DAL.DAOs.DAOSPasaron;

namespace DAL.DAOs
{

    public class DAOSSeguridad
    {

        #region SingletonSeguridad, ConnectionString y Querys
        private DAOSSeguridad() { }
        private static DAOs.DAOSSeguridad instance;

        public static DAOs.DAOSSeguridad GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSSeguridad();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;



        #endregion

        #region digitos verificadores


        public int CalcularDVV(string tabla)
        {
            string command1 = "select SUM(DVH) from " + tabla;

            string command2 = "update DVV set DVV = " + SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteScalar(command1) + " where tabla = '" + tabla + "'";
            return SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(command2);
        }

     /*   public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            string command = "update " + t + " set DVH = " + DVH + " where " + codtabla + " = " + cod;

            DataSet mds = new DataSet();
            return SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(command);
        }*/

        public int CalcularNumero(string s)
        {
            int calculo = 0;
            for (int i = 1; i < s.Length; i++)
            {
                calculo += (int)s[i];
            }
            return calculo;
        }
        public int CalcularNumero(int n)
        {
            string t = n.ToString();
            int calculo = 0;

            for (int i = 0; i < t.Length; i++)
            {
                calculo += int.Parse(t[i].ToString());
            }
            return calculo;

        }


        public int VerificarDigitosVerificadores(string tabla)
        {
            int suma = 0;

            DataSet mds = new DataSet();
            int mds2;
            switch (tabla)
            {
                case "Empleado":
                    string commanddv = "select * from empleado";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string queryEmpleado ="update "+ tabla + " set DVH = "+ DVHEmpleado(r) + " where " + primaryKeyColumn + "=" + r["Legajo"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(queryEmpleado);
                            
                            suma += DVHEmpleado(r);
                        }
                    }
                    break;
                case "Usuario":
                    string queryUsuario = "select * from Usuario";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryUsuario);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHUsuario(r) + " where " + primaryKeyColumn + "=" + r["ID_Usuario"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHUsuario(r);
                        }
                    }
                    break;
                default:
                    break;
            }
            return suma;
        }
    
        public int DVHEmpleado(DataRow d)
        {
            int dvh;
            dvh = CalcularNumero(int.Parse(d["Legajo"].ToString()))*1 + CalcularNumero(d["Nombre"].ToString())*2 +
                CalcularNumero(d["apellido"].ToString())*3 + CalcularNumero(d["DNI"].ToString())*4 +
                CalcularNumero(d["Direccion"].ToString())*5 + CalcularNumero(d["Telefono"].ToString())*6 +
                CalcularNumero(d["FechaIngreso"].ToString())*7 + CalcularNumero(d["ID_Linea"].ToString())*8 + 
                CalcularNumero(d["ID_Servicio"].ToString())*9;
            return dvh;

        }

        public int DVHUsuario(DataRow d)
        {
            int dvh = 0;

            dvh += CalcularNumero(SafeIntParse(d["ID_Usuario"].ToString())) * 1;
            dvh += CalcularNumero(d["Nombre"]?.ToString() ?? "") * 2;
            dvh += CalcularNumero(d["Apellido"]?.ToString() ?? "") * 3;
            dvh += CalcularNumero(d["DNI"]?.ToString() ?? "") * 4;
            dvh += CalcularNumero(d["Nick"]?.ToString() ?? "") * 5;
            dvh += CalcularNumero(d["Mail"]?.ToString() ?? "") * 6;
            dvh += CalcularNumero(d["Contraseña"]?.ToString() ?? "") * 7;
            dvh += CalcularNumero(SafeIntParse(d["Contador_Int_Fallidos"].ToString())) * 8;
            dvh += CalcularNumero(d["Estado"]?.ToString() ?? "") * 9;

            return dvh;
            /*
            int dvh;
            dvh = CalcularNumero(int.Parse(d["ID_Usuario"].ToString())) * 1 + CalcularNumero(d["Nombre"].ToString()) * 2 +
                CalcularNumero(d["Apellido"].ToString()) * 3
                + CalcularNumero(d["DNI"].ToString()) * 4 +
                CalcularNumero(d["Nick"].ToString()) * 5 + CalcularNumero(d["Mail"].ToString()) * 6 +
                CalcularNumero(d["Contraseña"].ToString()) * 7 + CalcularNumero(int.Parse(d["Contador_Int_Fallidos"].ToString())) * 8 +
                CalcularNumero(d["Estado"].ToString()) * 9;
            return dvh;    */
        }

        private int SafeIntParse(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                // Manejo de casos donde la conversión falla. Podrías lanzar una excepción o manejarlo de otra manera.
                return 0; // O cualquier valor que consideres adecuado para indicar un fallo en la conversión.
            }
        }
        //aca agregar los otros dvh

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
            return this.ComprobarContraseña(unencriptado, passencriptada);
            
        }

        public int ComprobarContraseña(string un, string pass)
        {
            string command = "Select cod_usuario from usuario where nombredeusuario = '" + un + "' and contraseña = '" + pass + "';";

            DataSet mds = SqlHelper.GetInstance(connectionString).ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                return 1;
            }
            else return 0;
        }

        #endregion

     

        

       



    }
}