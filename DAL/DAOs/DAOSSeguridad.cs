using BE;
using DAL.Mappers;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DAL.DAOs
{

    public class DAOSSeguridad
    {

        #region SingletonSeguridad, ConnectionString
        public DAOSSeguridad() { }
        private static DAOs.DAOSSeguridad instance;

        public static DAOs.DAOSSeguridad GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSSeguridad();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        DAL.DALSeguridad DALSeguridad = new DALSeguridad();
        


        string QuerySelect = "select * from bitacora order by Fecha desc";
        string QuerySelectCrit3 = "select * from Bitacora where criticidad = 3 order by 2 desc";

        #endregion


        #region digitos verificadores

        public int CalcularDVV(string tabla)
        {
            int dvvCalculado = 0;
            string command1 = $"SELECT SUM(DVH) FROM {tabla}";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(command1, connection))
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    dvvCalculado = Convert.ToInt32(result);
                }
            }

            // Actualizar el DVV en la tabla DVV
            string command2 = "UPDATE DVV SET DVV = @DVV WHERE Tabla = @Tabla";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(command2, connection))
            {
                command.Parameters.AddWithValue("@DVV", dvvCalculado);
                command.Parameters.AddWithValue("@Tabla", tabla);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return dvvCalculado;
        }

        public int CalcularNumero(string s)
        {
            int calculo = 0;
            for (int i = 0; i < s.Length; i++)
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
                    string commanddv = "select * from Empleado";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string queryEmpleado = "update " + tabla + " set DVH = " + DVHEmpleado(r) + " where " + primaryKeyColumn + "=" + r["Legajo"];
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

                case "Familia_Patente":
                    string queryFamiliaPatente = "select * from Familia_Patente";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryFamiliaPatente);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHFamiliaPatente(r) + " where " + primaryKeyColumn + "=" + r["ID_Familia"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);
                            suma += DVHFamiliaPatente(r);
                        }
                    }
                    break;

                case "Bitacora":
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

                case "Usuario_Familia":
                    string queryUsuarioFamilia = "select * from Usuario_Familia";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryUsuarioFamilia);

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

                case "Usuario_Patente":
                    string queryUsuarioPatente = "select * from Usuario_Patente";
                    mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(queryUsuarioPatente);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        string primaryKeyColumn = mds.Tables[0].Columns[0].ColumnName;
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 = "update " + tabla + " set DVH = " + DVHPatenteUsuario(r) + " where " + primaryKeyColumn + "=" + r["ID_Usuario"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);
                            suma += DVHPatenteUsuario(r);
                        }
                    }
                    break;

                default:
                    throw new ArgumentException($"Tabla desconocida: {tabla}");
            }

            return suma;
        }

        // Métodos para calcular el DVH de cada tabla

        public int DVHBitacora(DataRow r)
        {
            string concatenar = (r["ID_Bitacora"]?.ToString() ?? "") +
                                (r["Fecha"]?.ToString() ?? "") +
                                (r["Descripcion"]?.ToString() ?? "") +
                                (r["Criticidad"]?.ToString() ?? "") +
                                (r["ID_Usuario"]?.ToString() ?? "") +
                                (r["NickUsuarioLogin"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHCoche(DataRow r)
        {
            string concatenar = (r["Interno"]?.ToString() ?? "") +
                                (r["Patente"]?.ToString() ?? "") +
                                (r["ID_Linea"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHEmpleado(DataRow r)
        {
            string concatenar = (r["Legajo"]?.ToString() ?? "") +
                                (r["Nombre"]?.ToString() ?? "") +
                                (r["Apellido"]?.ToString() ?? "") +
                                (r["DNI"]?.ToString() ?? "") +
                                (r["Direccion"]?.ToString() ?? "") +
                                (r["Telefono"]?.ToString() ?? "") +
                                (r["FechaIngreso"]?.ToString() ?? "") +
                                (r["ID_Linea"]?.ToString() ?? "") +
                                (r["Eliminado"].ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHFamiliaPatente(DataRow r)
        {
            string concatenar = (r["ID_Familia"]?.ToString() ?? "") +
                                (r["ID_Patente"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHLinea(DataRow r)
        {
            string concatenar = (r["ID_Linea"]?.ToString() ?? "") +
                                (r["Nombre_Linea"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHUsuario(DataRow r)
        {
            string concatenar = r["ID_Usuario"].ToString() + r["Nombre"].ToString() +
                                r["Apellido"].ToString() + r["DNI"].ToString() +
                                r["Nick"].ToString() + r["Mail"].ToString() +
                                r["Contraseña"].ToString() + r["Contador_Int_Fallidos"].ToString() +
                                r["Estado"].ToString() +
                                r["Eliminado"].ToString();

            return CalcularNumero(concatenar);
        }
        public int DVHServicio(DataRow r)
        {
            string concatenar = (r["ID_Servicio"]?.ToString() ?? "") +
                                (r["Hora_Cabecera_Principal"]?.ToString() ?? "") +
                                (r["Hora_Cabecera_Retorno"]?.ToString() ?? "") +
                                (r["Legajo"]?.ToString() ?? "") +
                                (r["Interno"]?.ToString() ?? "") +
                                (r["ID_Linea"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHFamiliaUsuario(DataRow r)
        {
            string concatenar = (r["ID_Usuario"]?.ToString() ?? "") +
                                (r["ID_Familia"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }

        public int DVHPatenteUsuario(DataRow r)
        {
            string concatenar = (r["ID_Usuario"]?.ToString() ?? "") +
                                (r["ID_Patente"]?.ToString() ?? "");

            return CalcularNumero(concatenar);
        }


        
        #endregion



        #region Encriptar y Desencriptar


        public string EncriptarCamposReversible(string cadenaen)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadenaen));
        }

        public string DesencriptarCamposReversible(string cadenades)
        {
            if (string.IsNullOrEmpty(cadenades))
            {
                return string.Empty; // Retornar vacío si la cadena es nula o vacía.
            }

            // Imprimir la cadena antes de intentar desencriptar
            Console.WriteLine($"Cadena a desencriptar: {cadenades}");

            try
            {
                // Verificar si la longitud es válida para Base64.
                if (cadenades.Length % 4 != 0)
                {
                    throw new FormatException("Longitud no válida para una cadena Base64.");
                }

                // Intentar convertir a bytes.
                byte[] bytes = Convert.FromBase64String(cadenades);

                // Convertir bytes a string.
                string result = Encoding.UTF8.GetString(bytes);

                // Limpiar caracteres nulos que puedan aparecer.
                result = result.Replace("\0", string.Empty);

                return result;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error de formato al desencriptar: {ex.Message}");
                return string.Empty; // O lanzar una excepción si es necesario.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al desencriptar: {ex.Message}");
                return string.Empty; // O lanzar una excepción si es necesario.
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


        #region Bitacora
        public BE.Bitacora RegistrarEnBitacora(int i, string NickUsuarioLogin, int ID_Usuario)
        {

            BE.Bitacora BEBitacora = new BE.Bitacora();
            BEBitacora.NickUsuarioLogin = NickUsuarioLogin;
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
                case 37:
                    BEBitacora.Descripcion = "Recuperacion de Usuario";
                    BEBitacora.Criticidad = 3;
                    break;
                case 38:
                    BEBitacora.Descripcion = "Recuperacion de Empleado";
                    BEBitacora.Criticidad = 3;
                    break;
                case 39:
                    BEBitacora.Descripcion = "Intento de inicio de sesion con usuario eliminado";
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
                string query = "INSERT INTO Bitacora (ID_Usuario, Criticidad, Fecha, Descripcion,NickUsuarioLogin ) VALUES (@ID_Usuario, @Criticidad, @Fecha, @Descripcion, @NickUsuarioLogin)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Usuario", bitacora.ID_Usuario);
                    command.Parameters.AddWithValue("@Criticidad", bitacora.Criticidad);
                    command.Parameters.AddWithValue("@Fecha", bitacora.Fecha);
                    command.Parameters.AddWithValue("@Descripcion", bitacora.Descripcion);
                    command.Parameters.AddWithValue("@NickUsuarioLogin", bitacora.NickUsuarioLogin);

                    connection.Open();
                    int rowwsaffect = command.ExecuteNonQuery();
                    VerificarDigitosVerificadores("Bitacora");
                    CalcularDVV("Bitacora");

                    return bitacora;
                }
            }
        }


        public List<BE.Bitacora> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSBitacora.GetInstance().Map(table);
        }


        public List<BE.Bitacora> ListarCrit3()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectCrit3);


            return Mappers.MAPPERSBitacora.GetInstance().Map(table);
        }


        public List<Bitacora> BuscarEnBitacora(string fechaDesde, string fechaHasta, string NickUsuarioLogin)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Bitacora WHERE 1=1";

                if (!string.IsNullOrEmpty(fechaDesde) && !string.IsNullOrEmpty(fechaHasta))
                {
                    sql += " AND fecha BETWEEN @FechaDesde AND @FechaHasta";
                }

                if (!string.IsNullOrEmpty(NickUsuarioLogin))
                {
                    sql += " AND NickUsuarioLogin = @NickUsuarioLogin";
                }

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (!string.IsNullOrEmpty(fechaDesde) && !string.IsNullOrEmpty(fechaHasta))
                    {
                        command.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        command.Parameters.AddWithValue("@FechaHasta", fechaHasta);
                    }

                    if (!string.IsNullOrEmpty(NickUsuarioLogin))
                    {
                        command.Parameters.AddWithValue("@NickUsuarioLogin", NickUsuarioLogin);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Usa el mapper para convertir el DataTable a una lista de Bitacora
                    bitacoras = MAPPERSBitacora.GetInstance().Map(table);
                }

            }

            return bitacoras;
        }
        #endregion


        #region Validaciones U F P

        #region validaciones eliminar/bloquear usuario
        //Validar si el usuario tiene una patente única
        public bool TienePatenteUnica(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /* string query = @"
             SELECT COUNT(*)
             FROM Usuario_Patente up
             WHERE up.ID_Patente IN (
                 SELECT up1.ID_Patente
                 FROM Usuario_Patente up1
                 GROUP BY up1.ID_Patente
                 HAVING COUNT(up1.ID_Usuario) = 1
             )
             AND up.ID_Usuario = @idUsuario";
                */
                string query = @"
                SELECT COUNT(*)
                FROM Usuario_Patente up
                WHERE up.ID_Usuario = @idUsuario
                AND up.ID_Patente IN (
                    SELECT up1.ID_Patente
                    FROM Usuario_Patente up1
                    GROUP BY up1.ID_Patente
                    HAVING COUNT(up1.ID_Usuario) = 1
                )";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Si el conteo es mayor a 0, significa que el usuario tiene una patente única
                return count > 0;
            }
        }


        //Validar si el usuario tiene una familia con patentes únicas
        public bool TieneFamiliaConPatenteUnica(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /* string query = @"
             SELECT COUNT(*)
             FROM Familia_Patente fp
             JOIN Usuario_Familia uf ON fp.ID_Familia = uf.ID_Familia
             WHERE uf.ID_Usuario = @idUsuario
             AND fp.ID_Patente IN (
                 SELECT up.ID_Patente
                 FROM Usuario_Patente up
                 GROUP BY up.ID_Patente
                 HAVING COUNT(up.ID_Usuario) = 1
             )";*/
                string query = @"
                    SELECT COUNT(*)
                    FROM Familia_Patente fp
                    JOIN Usuario_Familia uf ON fp.ID_Familia = uf.ID_Familia
                    WHERE uf.ID_Usuario = @idUsuario
                    AND fp.ID_Patente IN (
                        SELECT up.ID_Patente
                        FROM Usuario_Patente up
                        GROUP BY up.ID_Patente
                        HAVING COUNT(up.ID_Usuario) = 1
                        )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Si el conteo es mayor a 0, significa que el usuario tiene una familia con patente única
                return count > 0;
            }
        }

        #endregion

        #region validacion familia
        public bool FamiliaContienePatenteUnicaParaUsuario(int idUsuario, int idFamilia)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM Familia_Patente fp
            JOIN Usuario_Patente up ON fp.ID_Patente = up.ID_Patente
            WHERE fp.ID_Familia = @idFamilia
              AND up.ID_Usuario = @idUsuario
              AND NOT EXISTS (
                  SELECT 1
                  FROM Usuario_Patente up2
                  WHERE up2.ID_Patente = fp.ID_Patente
                    AND up2.ID_Usuario <> @idUsuario
              )";



            

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@idFamilia", idFamilia);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Si el conteo es mayor a 0, significa que la familia contiene una patente única para el usuario
                return count > 0;
            }
        }

     


        public bool UsuarioQuedariaConPatentesSinFamilia(int idUsuario, int idFamilia)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM Usuario_Patente up
            WHERE up.ID_Usuario = @idUsuario
            AND NOT EXISTS (
                SELECT 1
                FROM Familia_Patente fp
                JOIN Usuario_Familia uf ON fp.ID_Familia = uf.ID_Familia
                WHERE fp.ID_Patente = up.ID_Patente
                AND uf.ID_Usuario = @idUsuario
                AND fp.ID_Familia <> @idFamilia
            )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@idFamilia", idFamilia);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Si el conteo es mayor a 0, el usuario quedaría con patentes sin familia asignada al eliminar esta familia
                return count > 0;
            }
        }

        public bool FamiliaTendriaPatenteSinUsuario(int idUsuario, int idFamilia)
        {
            // Verificar si la cadena de conexión está configurada
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("La cadena de conexión no está configurada.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*)
            FROM Familia_Patente fp
            LEFT JOIN Usuario_Patente up ON fp.ID_Patente = up.ID_Patente AND up.ID_Usuario <> @idUsuario
            WHERE fp.ID_Familia = @idFamilia
            GROUP BY fp.ID_Patente
            HAVING COUNT(up.ID_Usuario) = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@idFamilia", idFamilia);

                connection.Open();
                object result = command.ExecuteScalar();

                // Verificar si el resultado es null antes de convertirlo
                int count = (result != null) ? Convert.ToInt32(result) : 0;
                connection.Close();

                // Retornar verdadero si la familia tendría una patente sin ningún usuario
                return count > 0;
            }
        }




        public bool PuedeEliminarFamilia(int idFamilia)
        {
            // Validar que el idFamilia no sea nulo o menor que 0
            if (idFamilia <= 0)
            {
                throw new ArgumentException("El idFamilia debe ser un valor válido.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Comprobar que la cadena de conexión no es nula o vacía
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada.");
                }

                string query = @"
                SELECT COUNT(*)
                FROM Familia_Patente fp
                JOIN Usuario_Patente up ON fp.ID_Patente = up.ID_Patente
                WHERE fp.ID_Familia = @idFamilia
                GROUP BY fp.ID_Patente
                HAVING COUNT(DISTINCT up.ID_Usuario) = 1
                AND MIN(up.ID_Usuario) IN (
                    SELECT ID_Usuario
                    FROM Usuario_Familia fu
                    WHERE fu.ID_Familia = @idFamilia
                )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFamilia", idFamilia);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar(); // Obtiene el resultado

                    // Verificar si el resultado es null antes de convertirlo
                    int count = (result != null) ? Convert.ToInt32(result) : 0;

                    return count == 0; // Permite la eliminación solo si no hay patentes únicas
                }
                catch (SqlException ex)
                {
                    // Manejo de excepciones SQL, podrías registrar el error
                    throw new InvalidOperationException("Error al ejecutar la consulta.", ex);
                }
                catch (Exception ex)
                {
                    // Manejo de otras excepciones
                    throw new InvalidOperationException("Ocurrió un error inesperado.", ex);
                }
                finally
                {
                    // Asegúrate de cerrar la conexión si no se cierra automáticamente
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }





        #endregion

        #region Validar Patentes

        public bool PuedeEliminarPatente(int idUsuario, int idPatente)
        {
            // Verifica cuántos usuarios tienen la patente
            int countUsuarios = 0;

            // Consulta para contar usuarios que tienen la patente, excluyendo al que está intentando eliminar
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario_patente WHERE id_patente = @idPatente AND id_usuario <> @idUsuario";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPatente", idPatente);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    connection.Open();
                    countUsuarios = (int)command.ExecuteScalar();
                }
            }

            // Si no hay otros usuarios con la patente, no se puede eliminar
            if (countUsuarios == 0)
            {
                return false; // El usuario es el único propietario
            }

            return true; // Puede eliminar la patente
        }




        public bool PuedeEliminarPatenteDeUsuario(int idPatente, int idUsuario)
        {
            if (idPatente <= 0 || idUsuario <= 0)
            {
                throw new ArgumentException("El idPatente y el idUsuario deben ser valores válidos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            DECLARE @CountPatentesFamilia INT;
            DECLARE @CountFamiliasUsuario INT;

            -- Contar cuántas patentes tiene asignadas la familia
            SELECT @CountPatentesFamilia = COUNT(*) 
            FROM Familia_Patente 
            WHERE ID_Familia = (SELECT ID_Familia FROM Usuario_Familia WHERE ID_Usuario = @idUsuario);

            -- Contar cuántos usuarios están asociados con la familia
            SELECT @CountFamiliasUsuario = COUNT(*)
            FROM Usuario_Familia
            WHERE ID_Familia = (SELECT ID_Familia FROM Usuario_Familia WHERE ID_Usuario = @idUsuario);

            -- 1. Verificar si la familia no está asignada a ningún usuario
            IF @CountFamiliasUsuario = 0
            BEGIN
                SELECT 0; -- No permitir eliminación de la patente
            END
            -- 2. Verificar si la familia aún tiene patentes asignadas
            ELSE IF @CountPatentesFamilia > 0
            BEGIN
                SELECT 0; -- No permitir eliminación de la patente
            END
            -- 3. Permitir eliminación si no hay conflicto
            ELSE
            BEGIN
                SELECT 1; -- Permitir eliminación
            END";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPatente", idPatente);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int permit = (result != null) ? Convert.ToInt32(result) : 0;

                    // Retornar verdadero si se permite la eliminación, falso en caso contrario
                    return permit == 1; // 1 indica que se puede eliminar
                }
                catch (SqlException ex)
                {
                    throw new InvalidOperationException("Error al ejecutar la consulta.", ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }


        
        public bool PuedeEliminarPatenteDeFamilia2(int idPatente, int idUsuario)
        {
            if (idPatente <= 0 || idUsuario <= 0)
            {
                throw new ArgumentException("El idPatente y el idUsuario deben ser valores válidos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            -- Verificar si la familia asociada a la patente está asignada al usuario
            SELECT COUNT(*) 
            FROM Usuario_Familia AS uf
            JOIN Familia_Patente AS fp ON uf.ID_Familia = fp.ID_Familia
            WHERE fp.ID_Patente = @idPatente AND uf.ID_Usuario = @idUsuario;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPatente", idPatente);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Retorna verdadero si el usuario está asociado a la familia de la patente
                }
                catch (SqlException ex)
                {
                    throw new InvalidOperationException("Error al ejecutar la consulta.", ex);
                }
            }
        }

        public bool PuedeEliminarPatenteDeFamilia(int idUsuario, int idPatente)
        {
            if (idUsuario <= 0 || idPatente <= 0)
            {
                throw new ArgumentException("Los IDs deben ser valores válidos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT COUNT(DISTINCT uf.ID_Usuario)
                    FROM Usuario_Familia uf
                    JOIN Familia_Patente fp ON uf.ID_Familia = fp.ID_Familia
                    WHERE fp.ID_Patente = @idPatente AND uf.ID_Usuario != @idUsuario;
                    ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPatente", idPatente);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Retorna verdadero si hay otros usuarios con la patente
                }
                catch (SqlException ex)
                {
                    throw new InvalidOperationException("Error al ejecutar la consulta.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public bool VerificarOtrasAsignacionesDePatente(int idPatente, int idFamilia)
        {
            int usuariosConPatente = ContarUsuariosConPatente(idPatente);
            int familiasConPatente = ContarFamiliasConPatente(idPatente, idFamilia);

            return usuariosConPatente > 0 || familiasConPatente > 1;
        }

        public int ContarUsuariosConPatente(int idPatente)
        {
            int cantidadUsuarios = 0;
            string query = @"SELECT COUNT(*) FROM usuario_patente 
                     WHERE id_patente = @idPatente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idPatente", idPatente);

                connection.Open();
                cantidadUsuarios = (int)command.ExecuteScalar();
            }

            return cantidadUsuarios;
        }

        public int ContarFamiliasConPatente(int idPatente, int idFamiliaActual)
        {
            int cantidadFamilias = 0;
            string query = @"SELECT COUNT(*) FROM familia_patente 
                     WHERE id_patente = @idPatente AND id_familia <> @idFamiliaActual";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idPatente", idPatente);
                command.Parameters.AddWithValue("@idFamiliaActual", idFamiliaActual);

                connection.Open();
                cantidadFamilias = (int)command.ExecuteScalar();
            }

            return cantidadFamilias;
        }





        /*
        public bool PuedeEliminarPatenteDeFamilia(int idFamilia, int idPatente)
        {
            // Validar que los ID no sean nulos o menores que 0
            if (idFamilia <= 0)
            {
                throw new ArgumentException("El idFamilia debe ser un valor válido.");
            }

            if (idPatente <= 0)
            {
                throw new ArgumentException("El idPatente debe ser un valor válido.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Comprobar que la cadena de conexión no sea nula o vacía
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("La cadena de conexión no está configurada.");
                }
                string query = @"
                SELECT COUNT(DISTINCT up.ID_Usuario)
                FROM Usuario_Patente up
                WHERE up.ID_Patente = @idPatente
                ";

              

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFamilia", idFamilia);
                command.Parameters.AddWithValue("@idPatente", idPatente);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar(); // Obtiene el resultado

                    // Verificar si el resultado es null antes de convertirlo
                    int count = (result != null) ? Convert.ToInt32(result) : 0;

                    // Si el conteo es 0, significa que no hay otros usuarios asignados a esta patente,
                    // lo que indica que no se puede eliminar de la familia.
                    return count > 0; // Retorna verdadero si hay otros usuarios asignados
                }
                catch (SqlException ex)
                {
                    // Manejo de excepciones SQL, podrías registrar el error
                    throw new InvalidOperationException("Error al ejecutar la consulta.", ex);
                }
                catch (Exception ex)
                {
                    // Manejo de otras excepciones
                    throw new InvalidOperationException("Ocurrió un error inesperado.", ex);
                }
                finally
                {
                    // Asegúrate de cerrar la conexión si no se cierra automáticamente
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }*/





        #endregion




        #endregion




    }

}

    


