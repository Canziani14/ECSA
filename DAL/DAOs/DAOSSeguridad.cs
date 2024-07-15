using BE;
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
using System.Windows.Input;
using static DAL.DAOs.DAOSPasaron;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DAL.DAOs
{

    public class DAOSSeguridad
    {

        #region SingletonSeguridad, ConnectionString
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

        DAL.DALSeguridad DALSeguridad = new DALSeguridad();

        #endregion

        #region digitos verificadores


        public int CalcularDVV(string tabla)
        {
            string command1 = "select SUM(DVH) from " + tabla;

            string command2 = "update DVV set DVV = " + SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteScalar(command1) + " where tabla = '" + tabla + "'";
            return SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(command2);
        }
     
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
                case "Linea":
                    string queryLinea = "select * from Linea";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryLinea);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHLinea(r) + " where " + primaryKeyColumn + "=" + r["ID_Linea"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHLinea(r);
                        }
                    }
                    break;
                case "Servicio":
                    string queryServicio = "select * from Servicio";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryServicio);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHServicio(r) + " where " + primaryKeyColumn + "=" + r["ID_Servicio"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHServicio(r);
                        }
                    }
                    break;
                case "Coche":
                    string queryCoche = "select * from Coche";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryCoche);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHCoche(r) + " where " + primaryKeyColumn + "=" + r["Interno"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHCoche(r);
                        }
                    }
                    break;
                    //ver
                case "Patente-Usuario":
                    string queryPatenteUsuario = "select * from Patente-Usuario";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryPatenteUsuario);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHPatenteUsuario(r) + " where " + primaryKeyColumn + "=" + r["ID_PatenteUsuario"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHPatenteUsuario(r);
                        }
                    }
                    break;
                    //ver
                case "Familia-Patente":
                    string queryFamiliaPatente = "select * from Familia-Patente";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryFamiliaPatente);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHFamiliaPatente(r) + " where " + primaryKeyColumn + "=" + r["ID_Usuario"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHFamiliaPatente(r);
                        }
                    }
                    break;
                case "Familia-Usuario":
                    //ver
                    string queryFamiliaUsuario = "select * from Familia-Usuario";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryFamiliaUsuario);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHFamiliaUsuario(r) + " where " + primaryKeyColumn + "=" + r["ID_Usuario"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHFamiliaUsuario(r);
                        }
                    }
                    break;
                case "Bitacora":
                    //ver
                    string queryBitacora = "select * from Bitacora";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryBitacora);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHBitacora(r) + " where " + primaryKeyColumn + "=" + r["ID_Bitacora"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);

                            suma += DVHBitacora(r);
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

        
        public int DVHBitacora(DataRow d)
        {
            int dvh = 0;

            dvh += CalcularNumero(SafeIntParse(d["ID_Bitacora"].ToString())) * 1;
            dvh += CalcularNumero(d["Fecha"]?.ToString() ?? "") * 2;
            dvh += CalcularNumero(d["Descripcion"]?.ToString() ?? "") * 3;
            dvh += CalcularNumero(d["Criticidad"]?.ToString() ?? "") * 4;
            dvh += CalcularNumero(d["ID_usuario"]?.ToString() ?? "") * 5;
            
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
              
        }

        public int DVHLinea(DataRow d)
        {
            int dvh = 0;

            dvh += CalcularNumero(SafeIntParse(d["ID_Linea"].ToString())) * 1;
            dvh += CalcularNumero(d["Nombre_Linea"]?.ToString() ?? "") * 2;
            return dvh;
        }
        public int DVHServicio(DataRow d)
        {
            int dvh = 0;

            dvh += CalcularNumero(SafeIntParse(d["ID_Servicio"].ToString())) * 1;
            dvh += CalcularNumero(d["Hora_Cabecera_Principal"]?.ToString() ?? "") * 2;
            dvh += CalcularNumero(d["Hora_Cabecera_Retorno"]?.ToString() ?? "") * 3;
            dvh += CalcularNumero(d["Legajo"]?.ToString() ?? "") * 4;
            dvh += CalcularNumero(d["Interno"]?.ToString() ?? "") * 5;
            return dvh;
        }
        public int DVHCoche(DataRow d)
        {
            int dvh = 0;

           
            dvh += CalcularNumero(d["Patente"]?.ToString() ?? "") * 1;
            dvh += CalcularNumero(d["Interno"]?.ToString() ?? "") * 2;
            return dvh;
        }

        public int DVHPatenteUsuario(DataRow d)
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
        }
        public int DVHFamiliaPatente(DataRow d)
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
        }
        public int DVHFamiliaUsuario(DataRow d)
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



        public BE.Bitacora RegistrarEnBitacora(int i, int ID_Usuario)
        {
            
            BE.Bitacora BEBitacora = new BE.Bitacora();
            BEBitacora.ID_Usuario = ID_Usuario;
            BEBitacora.Criticidad = 0;
            BEBitacora.Fecha = DateTime.Now;
            

            switch (i)
            {
                case 1:
                    BEBitacora.Descripcion = "Inicio de sesión";
                    BEBitacora.Criticidad = 1;
                    break;
                case 2:
                    BEBitacora.Descripcion = "Contraseña incorrecta en inicio de sesión";
                    BEBitacora.Criticidad = 2;
                    break;
                case 3:
                    BEBitacora.Descripcion = "Usuario bloqueado";
                    BEBitacora.Criticidad = 3;
                    break;
                case 4:
                    BEBitacora.Descripcion = "Intento de inicio de sesión con usuario bloqueado";
                    BEBitacora.Criticidad = 3;
                    break;
                case 5:
                    BEBitacora.Descripcion = "Crear usuario";
                    BEBitacora.Criticidad = 2;
                    break;
                case 6:
                    BEBitacora.Descripcion = "Modificar usuario";
                    BEBitacora.Criticidad = 2;
                    break;
                case 7:
                    BEBitacora.Descripcion = "Eliminar usuario";
                    BEBitacora.Criticidad = 3;
                    break;
                case 8:
                    BEBitacora.Descripcion = "Bloquear usuario";
                    BEBitacora.Criticidad = 3;
                    break;
                case 9:
                    BEBitacora.Descripcion = "Desbloquear usuario";
                    BEBitacora.Criticidad = 3;
                    break;
                case 10:
                    BEBitacora.Descripcion = "Asignar familia";
                    BEBitacora.Criticidad = 3;
                    break;
                case 11:
                    BEBitacora.Descripcion = "Quitar familia";
                    BEBitacora.Criticidad = 3;
                    break;
                case 12:
                    BEBitacora.Descripcion = "Crear familia";
                    BEBitacora.Criticidad = 3;
                    break;
                case 13:
                    BEBitacora.Descripcion = "Eliminar familia";
                    BEBitacora.Criticidad = 3;
                    break;
                case 14:
                    BEBitacora.Descripcion = "Modificar familia";
                    BEBitacora.Criticidad = 3;
                    break;
                case 15:
                    BEBitacora.Descripcion = "Crear empleados";
                    BEBitacora.Criticidad = 1;
                    break;
                case 16:
                    BEBitacora.Descripcion = "Modificar empleado";
                    BEBitacora.Criticidad = 1;
                    break;
                case 17:
                    BEBitacora.Descripcion = "Eliminar empleados";
                    BEBitacora.Criticidad = 3;
                    break;
                case 18:
                    BEBitacora.Descripcion = "Crear línea";
                    BEBitacora.Criticidad = 1;
                    break;
                case 19:
                    BEBitacora.Descripcion = "Modificar línea";
                    BEBitacora.Criticidad = 2;
                    break;
                case 20:
                    BEBitacora.Descripcion = "Eliminar línea";
                    BEBitacora.Criticidad = 3;
                    break;
                case 21:
                    BEBitacora.Descripcion = "Crear coche";
                    BEBitacora.Criticidad = 2;
                    break;
                case 22:
                    BEBitacora.Descripcion = "Eliminar coche";
                    BEBitacora.Criticidad = 3;
                    break;
                case 23:
                    BEBitacora.Descripcion = "Modificar servicio";
                    BEBitacora.Criticidad = 2;
                    break;
                case 24:
                    BEBitacora.Descripcion = "Eliminar servicios";
                    BEBitacora.Criticidad = 3;
                    break;
                case 25:
                    BEBitacora.Descripcion = "Crear servicios";
                    BEBitacora.Criticidad = 2;
                    break;
                case 26:
                    BEBitacora.Descripcion = "Asignar conductor al servicio";
                    BEBitacora.Criticidad = 1;
                    break;
                case 27:
                    BEBitacora.Descripcion = "Asignar patente";
                    BEBitacora.Criticidad = 3;
                    break;
                case 28:
                    BEBitacora.Descripcion = "Quitar patente";
                    BEBitacora.Criticidad = 3;
                    break;
                case 29:
                    BEBitacora.Descripcion = "Cerrar sesión";
                    BEBitacora.Criticidad = 1;
                    break;
                case 30:
                    BEBitacora.Descripcion = "Cambiar contraseña";
                    BEBitacora.Criticidad = 1;
                    break;
                case 31:
                    BEBitacora.Descripcion = "Generar nueva contraseña";
                    BEBitacora.Criticidad = 1;
                    break;
                case 32:
                    BEBitacora.Descripcion = "Conectar con base de datos";
                    BEBitacora.Criticidad = 2;
                    break;
                case 33:
                    BEBitacora.Descripcion = "Verificar integridad de la base de datos";
                    BEBitacora.Criticidad = 2;
                    break;
                case 34:
                    BEBitacora.Descripcion = "Reparar integridad";
                    BEBitacora.Criticidad = 3;
                    break;
                case 35:
                    BEBitacora.Descripcion = "Realizar backup";
                    BEBitacora.Criticidad = 3;
                    break;
                case 36:
                    BEBitacora.Descripcion = "Realizar restore";
                    BEBitacora.Criticidad = 3;
                    break;
                default:
                    BEBitacora.Descripcion = "Acción desconocida";
                    BEBitacora.Criticidad = 0;
                    break;
            }

            string descripcionEncriptada = EncriptarCamposReversible(BEBitacora.Descripcion);
            BEBitacora.Descripcion = descripcionEncriptada;




            
            
            
            return GuardarBitacora(BEBitacora); 
          
        }


        public BE.Bitacora GuardarBitacora(BE.Bitacora bitacora)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bitacora (ID_Usuario, Criticidad, Fecha, Descripcion) VALUES (@ID_Usuario, @Criticidad, @Fecha, @Descripcion)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Usuario", bitacora.ID_Usuario);
                    command.Parameters.AddWithValue("@Criticidad", bitacora.Criticidad);
                    command.Parameters.AddWithValue("@Fecha", bitacora.Fecha);
                    command.Parameters.AddWithValue("@Descripcion", bitacora.Descripcion);

                    connection.Open();
                    int rowwsaffect=command.ExecuteNonQuery();
                    VerificarDigitosVerificadores("Bitacora");
                    CalcularDVV("Bitacora");
                    
                    return bitacora;
                }
            }
        }










    }

}
