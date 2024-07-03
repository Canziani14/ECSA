using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class BLLPasaron
    {
        /*
        public class BLLSeguridad
        {
            public string EncriptarReversible(string cadenaen)
            {
                return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadenaen));
            }
            public string Desencriptar(string cadenades)
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
            public static string EncriptarIrreversible(string str)
            {
                str = str + "vanina";
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }

            public List<usuario> ComprobarNombreDeUsuario(string nu)
            {
                string unencriptado = EncriptarReversible(nu);
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ComprobarNombreDeUsuario(unencriptado);
            }
            public int CompararContraseña(string un, string pass)
            {
                string passencriptada = EncriptarIrreversible(pass);
                string unencriptado = EncriptarReversible(un);
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ComprobarContraseña(unencriptado, passencriptada);
            }
            public void GuardarEnBitacora(int i, int us)
            {
                bitacora b = new bitacora();
                SeguridadDAL sdal = new SeguridadDAL();
                b.responsable = us;
                int criticidad = 0;
                switch (i)
                {
                    case 1:
                        b.detalle = "Contraseña actual incorrecta en cambio de contraseña ";
                        criticidad = 3;
                        break;
                    case 2:
                        b.detalle = "Cambio de contraseña";
                        criticidad = 3;
                        break;
                    case 3:
                        b.detalle = "Conexión fallida con la base de datos";
                        criticidad = 1;
                        break;
                    case 5:
                        b.detalle = "Reparación de integridad";
                        criticidad = 1;
                        break;
                    case 6:
                        b.detalle = "Conexión fallida con la base de datos en modo seguro";
                        criticidad = 1;
                        break;
                    case 7:
                        b.detalle = "Conexión con la base de datos en modo seguro";
                        criticidad = 3;
                        break;
                    case 8:
                        b.detalle = "Inicio de sesión con usuario bloqueado";
                        criticidad = 2;
                        break;
                    case 9:
                        b.detalle = "Inicio de sesión con credenciales incorrectas";
                        criticidad = 2;
                        break;
                    case 10:
                        b.detalle = "Bloqueo de usuario con contraseña incorrecta";
                        criticidad = 2;
                        break;
                    case 11:
                        b.detalle = "Ingreso a la sesión";
                        criticidad = 3;
                        break;
                    case 12:
                        b.detalle = "Recupero de contraseña";
                        criticidad = 3;
                        break;
                    case 13:
                        b.detalle = "Cierre de sesión";
                        criticidad = 3;
                        break;
                    case 14:
                        b.detalle = "Modificación de datos de cliente";
                        criticidad = 2;
                        break;
                    case 15:
                        b.detalle = "Cliente eliminado";
                        criticidad = 1;
                        break;
                    case 16:
                        b.detalle = "Nuevo cliente";
                        criticidad = 2;
                        break;
                    case 17:
                        b.detalle = "Nuevo trabajo";
                        criticidad = 2;
                        break;
                    case 18:
                        b.detalle = "Trabajo eliminado";
                        criticidad = 2;
                        break;
                    case 19:
                        b.detalle = "Modificación de datos del trabajo";
                        criticidad = 3;
                        break;
                    case 20:
                        b.detalle = "Modificación de datos de alerta";
                        criticidad = 3;
                        break;
                    case 21:
                        b.detalle = "Alerta eliminada";
                        criticidad = 2;
                        break;
                    case 22:
                        b.detalle = "Nueva alerta";
                        criticidad = 3;
                        break;
                    case 23:
                        b.detalle = "Facturación de trabajo";
                        criticidad = 2;
                        break;
                    case 24:
                        b.detalle = "Modificación de datos de usuario";
                        criticidad = 2;
                        break;
                    case 25:
                        b.detalle = "Correo ya asignado a otro usuario";
                        criticidad = 3;
                        break;
                    case 26:
                        b.detalle = "Nombre de usuario ya asignado a otro usuario";
                        criticidad = 3;
                        break;
                    case 27:
                        b.detalle = "Nuevo comentario";
                        criticidad = 3;
                        break;
                    case 28:
                        b.detalle = "Usuario eliminado";
                        criticidad = 1;
                        break;
                    case 29:
                        b.detalle = "Solicitud de eliminación de usuario con patentes únicas";
                        criticidad = 2;
                        break;
                    case 30:
                        b.detalle = "Nuevo usuario";
                        criticidad = 2;
                        break;
                    case 31:
                        b.detalle = "Modificación de datos personales";
                        criticidad = 3;
                        break;
                    case 32:
                        b.detalle = "Asignación patente";
                        criticidad = 2;
                        break;
                    case 33:
                        b.detalle = "Asignación de familia";
                        criticidad = 2;
                        break;
                    case 34:
                        b.detalle = "Backup";
                        criticidad = 1;
                        break;
                    case 35:
                        b.detalle = "Backup fallido";
                        criticidad = 1;
                        break;
                    case 36:
                        b.detalle = "Restore";
                        criticidad = 1;
                        break;
                    case 37:
                        b.detalle = "Restore fallido";
                        criticidad = 1;
                        break;
                    case 38:
                        b.detalle = "Consulta en bitácora";
                        criticidad = 3;
                        break;
                    case 39:
                        b.detalle = "Nueva familia";
                        criticidad = 3;
                        break;
                    case 40:
                        b.detalle = "Solicitud de eliminación de familia asignada a usuario con patentes únicas perteneciente a familia a eliminar";
                        criticidad = 2;
                        break;
                    case 41:
                        b.detalle = "Familia eliminada";
                        criticidad = 2;
                        break;
                    case 42:
                        b.detalle = "Solicitud de eliminación de patente en usuario con patente única";
                        criticidad = 2;
                        break;
                    case 43:
                        b.detalle = "Eliminación de patente de usuario";
                        criticidad = 2;
                        break;
                    case 44:
                        b.detalle = "Solicitud de eliminación de familia en usuario con patente única perteneciente a la familia a eliminar";
                        criticidad = 2;
                        break;
                    case 45:
                        b.detalle = "Usuario bloqueado";
                        criticidad = 2;
                        break;
                    case 46:
                        b.detalle = "Usuario desbloqueado";
                        criticidad = 2;
                        break;

                    default:
                        break;
                }
                sdal.GuardarEnBitacora(EncriptarReversible(b.detalle), us, criticidad);


            }
            public int SumarIntento(int i, int cu)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.SumarIntento(i, cu);
            }
            public int BloquearUsuario(int cu)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.BloquearUsuario(cu);
            }
            public List<Trabajo> MostrarTrabajos(DateTime d)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarTrabajos(d);
            }
            public List<patente> BuscarPatentexUsuario(int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.BuscarPatentexUsuario(u);
            }
            public List<patente> MostrarPatentes()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.MostrarPatentes();
            }
            public List<patente> ValidarPatentexUsuario(int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarPatentexUsuario(u);
            }

            public int EliminarPatente(int p, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int patentes = sdal.ValidarPatenteUnica(p, u);
                patentes += sdal.ValidarPatenteUnicaEnFamiliaAsignada(p);
                if (patentes < 1) //si no hay otro usuario con la misma patente
                {
                    return 1;
                }
                else
                {
                    sdal.EliminarPatentexUsuario(p, u);
                    return 0;
                }

            }
            public int AsignaPatente(int p, int u, int user)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                if (sdal.ValidarExistePatente(p, u) == 1)
                {
                    sdal.ActivarPatentexUsuario(p, u);
                    sdal.GuardarEnBitacora(EncriptarReversible("Eliminación de patente " + p + " a usuario " + u), user, 2);
                    return 0;
                }
                else
                {
                    sdal.AsignarPatente(p, u);
                    sdal.GuardarEnBitacora(EncriptarReversible("Asignación de patente " + p + " a usuario " + u), user, 2);
                    return 1;
                }
            }
            public void GuardarFamilia(List<int> patentes, int cp, string n)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int flag = 0;
                string p = "";
                int cf;
                foreach (int ps in patentes)
                {
                    if (flag == 0)
                    {
                        p += ps.ToString();
                        flag = 1;
                    }
                    else
                    {
                        p += ", " + ps.ToString();
                    }
                }
                if (sdal.ValidarFamiliaUnica(p, cp) == 0)
                {
                    cf = sdal.GuardarFamilia(EncriptarReversible(n));
                    foreach (int ps in patentes)
                    {
                        sdal.GuardarFamiliaxPatente(ps, cf);
                    }
                }
            }
            public List<cliente> ListarClientes()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarClientes();
            }
            public void GuardarTrabajo(Trabajo t, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.GuardarTrabajo(t);
                sdal.GuardarEnBitacora(EncriptarReversible("Nuevo trabajo: " + t.titulo), u, 3);
            }

            public int BuscarCodCliente(string na)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.BuscarCodCliente(na);
            }

            public int ValidarConexionBD(String cs)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int cod = sdal.ValidarConexionBD(Desencriptar(cs));
                if (cod == 0)
                {
                    GuardarEnBitacora(6, 0);
                }
                else
                {
                    GuardarEnBitacora(7, 0);
                }

                return cod;
            }
            public int ValidarConexionBDMS(String cs)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarConexionBD(cs);
            }
            public List<patente> ValidarPatentesEnFormulario(string p, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarPatentesEnFormulario(p, u);
            }
            public List<patente> ValidarPatenteFamiliaEnFormulario(string p, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarPatenteFamiliaEnFormulario(p, u);
            }
            public int ValidarIntegridad()
            {
                int flag = 0;
                SeguridadDAL sdal = new SeguridadDAL();
                flag += sdal.ValidarIntegridad("Usuario");
                flag += sdal.ValidarIntegridad("PatentexUsuario");
                flag += sdal.ValidarIntegridad("FamiliaxUsuario");
                flag += sdal.ValidarIntegridad("FamiliaxPatente");
                flag += sdal.ValidarIntegridad("Trabajo");
                flag += sdal.ValidarIntegridad("Bitacora");
                if (flag > 0)
                {
                    GuardarEnBitacora(5, 0);
                }
                return flag;
            }
            public void GuardarEnBitacora(string detalle, int user, int c)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.GuardarEnBitacora(detalle, user, c);
            }

            public void RealizarBackup(int cod, int p, string carpeta, string ruta)
            {
                string command = "";
                string d = "Backup" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                for (int i = 0; i < p; i++)
                {
                    if (i == 0) //es el primero 
                    {
                        command += "DISK = 'C:\\" + carpeta + "\\" + d + (i + 1) + ".bak'";
                    }
                    else
                    {
                        command += ", DISK = 'C:\\" + carpeta + "\\" + d + (i + 1) + ".bak'";
                    }

                }
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.RealizarBackup(command);
                GuardarEnBitacora(34, cod);
            }
            public void RealizarRestore(List<string> lsta, int u)
            {
                string command = "";
                for (int i = 0; i < lsta.Count; i++)
                {
                    if (i == 0) //es el primero
                    {
                        command += "DISK = N'" + lsta[i] + "'";
                    }
                    else
                    {
                        command += ", DISK = N'" + lsta[i] + "'";
                    }

                }
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.RealizarRestore(command);
                GuardarEnBitacora(36, u);

            }

            public List<bitacora> BuscarEnBitacora(String respondable, int criticidad, DateTime desde, DateTime hasta, int u)
            {
                string command = "";


                if (respondable == "Sistema")
                {
                    command = "select b.fecha_hora as fecha, b.detalle as detalle, c.detalle as criticidad, CAST(b.responsable as varchar(50)) as nombrecompleto from Bitacora as b inner join Criticidad as c on c.cod_criticidad = b.cod_criticidad where b.fecha_hora between '" + desde.Year + "-" + desde.Month + "-" + desde.Day + " 00:00:00' and '" + hasta.Year + "-" + hasta.Month + "-" + hasta.Day + " 23:59:59' and b.responsable = 0";
                }
                if (respondable == "Todos los usuarios")
                {
                    command = "select b.fecha_hora as fecha, b.detalle as detalle, c.detalle as criticidad, CONCAT(u.nombre, ' ', u.apellido) as nombrecompleto from Bitacora as b inner join Criticidad as c on c.cod_criticidad = b.cod_criticidad inner join Usuario as u on u.cod_usuario = b.responsable where b.fecha_hora between '" + desde.Year + "-" + desde.Month + "-" + desde.Day + " 00:00:00' and '" + hasta.Year + "-" + hasta.Month + "-" + hasta.Day + " 23:59:59' and CONCAT(u.nombre, ' ', u.apellido) like '%%'";

                }
                if (respondable != "Sistema" && respondable != "Todos los usuarios")
                {
                    command = "select b.fecha_hora as fecha, b.detalle as detalle, c.detalle as criticidad, CONCAT(u.nombre, ' ', u.apellido) as nombrecompleto from Bitacora as b inner join Criticidad as c on c.cod_criticidad = b.cod_criticidad inner join Usuario as u on u.cod_usuario = b.responsable where b.fecha_hora between '" + desde.Year + "-" + desde.Month + "-" + desde.Day + " 00:00:00' and '" + hasta.Year + "-" + hasta.Month + "-" + hasta.Day + " 23:59:59' and CONCAT(u.nombre, ' ', u.apellido) like '%" + EncriptarNombredeUsuario(respondable) + "%'";

                }
                if (criticidad != 0)
                {
                    command += "and b.cod_criticidad = " + criticidad;
                }
                SeguridadDAL sdal = new SeguridadDAL();
                GuardarEnBitacora(38, u);
                return sdal.BuscarEnBitacora(command);

            }
            public string EncriptarNombredeUsuario(string r)
            {
                string encriptado = "";
                string[] palabras = r.Split(' ');
                for (int i = 0; i <= palabras.Length - 1; i++)
                {
                    encriptado += EncriptarReversible(palabras[i]);
                    if (i != palabras.Length - 1)
                    {
                        encriptado += " ";
                    }
                }

                return encriptado;
            }

            public void FinalizarTrabajo(string cod)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.FinalizarTrabajo(cod);
            }
            public void EliminarTrabajo(string cod, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.EliminarTrabajo(cod);
                sdal.GuardarEnBitacora(EncriptarReversible("Trabajo " + cod + " eliminado"), u, 3);
            }
            public void FacturarTrabajoAbonado(List<Trabajo> lstt, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.FacturarTrabajoAbonado(lstt);
                GuardarEnBitacora(23, u);
            }
            public List<Trabajo> ListarTrabajosAbonados()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarTrabajosAbonados();
            }
            public List<familia> TraerFamilias()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.TraerFamilias();
            }

            public List<patente> TraerPatentesxFamilia(string nombre)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.TraerPatentesxFamilia(EncriptarReversible(nombre));
            }

            public void ActualizarFamilia(List<patente> lstf, string cod_familia)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                foreach (patente p in lstf)
                {
                    if (sdal.ExistePatenteFamilia("select COUNT(cod_patente) from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where cod_patente = " + p.codigo + " and f.nombre = '" + EncriptarReversible(cod_familia) + "' and fxp.cod_estado = 19") == 1) //existe y esta activa?
                    {
                        //si la desasigne
                        if (p.asignada == false)
                        {
                            sdal.QuitarAsignarCrearPatentedeFamilia("update FamiliaxPatente set cod_estado = 18 from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where fxp.cod_patente = " + p.codigo + " and f.nombre = '" + EncriptarReversible(cod_familia) + "'");


                        }
                    }
                    if (sdal.ExistePatenteFamilia("select COUNT(cod_patente) from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where cod_patente = " + p.codigo + " and f.nombre = '" + EncriptarReversible(cod_familia) + "' and fxp.cod_estado = 18") == 1) //existe y no activa?
                    {
                        //si la asigne
                        if (p.asignada == true)
                        {
                            sdal.QuitarAsignarCrearPatentedeFamilia("update FamiliaxPatente set cod_estado = 19 from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where fxp.cod_patente = " + p.codigo + " and and f.nombre = '" + EncriptarReversible(cod_familia) + "'");

                        }
                    }
                    if (sdal.ExistePatenteFamilia("select COUNT(cod_patente) from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where cod_patente = " + p.codigo + " and f.nombre = '" + EncriptarReversible(cod_familia) + "' and fxp.cod_estado in (18, 19)") == 0) //si no existe
                    {
                        //si la asigne
                        if (p.asignada == true)
                        {
                            sdal.GuardarFamiliaxPatente(p.codigo, sdal.ExistePatenteFamilia("select cod_familia from familia where nombre = '" + EncriptarReversible(cod_familia) + "'"));
                        }
                    }
                }
            }
            public void EliminarFamilia(string nombre)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.EliminarFamilia(EncriptarReversible(nombre));
            }
            public List<comentario> ListarComentario(string cod_trabajo)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarComentario(cod_trabajo);
            }

            public void AgregarComentario(string cod_trabajo, string detalle, int cod_usuario)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.AgregarComentario(cod_trabajo, detalle, cod_usuario);
                sdal.GuardarEnBitacora(EncriptarReversible("Nuevo comentario en trabajo " + cod_trabajo), cod_usuario, 3);
            }
            public void EliminarComentario(string cod_trabajo)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.EliminarComentario(cod_trabajo);
            }
            public void CambiarContraseña(int cod, string pass)
            {
                string passencriptada = EncriptarIrreversible(pass);
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.CambiarContraseña(cod, passencriptada);
                GuardarEnBitacora(2, cod);
            }
            public int ValidarContraseñaActual(int cod, string pass)
            {
                string passencriptada = EncriptarIrreversible(pass);
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarContraseñaActual(cod, passencriptada);

            }

            public List<familia> ListarFamiliasActivasporUsuario(string cod_usuario)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarFamiliasActivasporUsuario(cod_usuario);
            }
            public List<familia> ListarFamiliasActivas()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ListarFamiliasActivas();
            }

            public void AsignarDesasignarFamilia(List<familia> lstf, string cod_usuario, int user)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                foreach (familia f in lstf)
                {
                    if (f.asignada == true) //si asigne la patente
                    {
                        //si aun no esta creada la inserto
                        int cod_estado = sdal.Existefamiliaxusuario("select cod_estado from FamiliaxUsuario where cod_usuario = " + cod_usuario + " and cod_familia = " + f.cod);
                        switch (cod_estado)
                        {
                            case 15: //descativada
                                sdal.AsignarFamiliaUsuario2(f.cod, cod_usuario, "activar");
                                sdal.GuardarEnBitacora(EncriptarReversible("Asignación de familia " + f.cod + " a usuario " + cod_usuario), user, 2);
                                break;
                            case 22: //activa
                                break;
                            case 0: //no esta creada
                                sdal.AsignarFamiliaUsuario("insert into familiaxusuario (cod_familia, cod_usuario, cod_estado) values (" + f.cod + ", " + cod_usuario + ", 22)SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]");
                                sdal.GuardarEnBitacora(EncriptarReversible("Asignación de familia " + f.cod + " a usuario " + cod_usuario), user, 2);
                                break;
                            default:
                                break;
                        }
                    }
                    if (f.asignada == false) //si NO esta asignada
                    {
                        //valido que se pueda aliminar

                        //y existe activa.. 
                        if (sdal.Existefamiliaxusuario("select count(cod_familia) from FamiliaxUsuario where cod_estado = 22 and cod_usuario = " + cod_usuario + " and cod_familia = " + f.cod) == 1)
                        {
                            //la desactivo
                            sdal.AsignarFamiliaUsuario2(f.cod, cod_usuario, "desactivar");
                            sdal.GuardarEnBitacora(EncriptarReversible("Eliminación de familia " + f.cod + " a usuario " + cod_usuario), user, 2);

                        }
                    }
                }
            }
            public List<patente> BuscarPatentesporFamilia(int cod_familia)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.TraerPatentesxFamilia(cod_familia);
            }

            public int ValidarPatentexFamiliaUnica(string nombre, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int patentes = 0;
                int flag = 0;
                foreach (patente p in sdal.TraerPatentesxFamilia(EncriptarReversible(nombre)))
                {
                    patentes = 0;
                    patentes += sdal.ValidarPatenteUnicaenFamilia(EncriptarReversible(nombre), p.codigo);
                    patentes += sdal.ValidarPatenteUnica(p.codigo, u);
                    if (patentes < 2)
                    {
                        flag = 1;
                    }
                }
                if (flag == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public int ValidarPatentexFamiliaUnica(patente p, int cod_familia, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int patentes = 0;
                patentes += sdal.ValidarPatenteUnicaenFamilia(cod_familia, p.codigo);
                patentes += sdal.ValidarPatenteUnica2(p.codigo, u);
                if (patentes < 2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public int ValidarPatentexFamiliaUnica2(patente p, int cod_familia, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int patentes = 0;
                int flag = 0;
                patentes = sdal.ValidarPatenteUnicaenFamilia2(cod_familia, p.codigo, u);
                patentes += sdal.ValidarPatenteUnica2(p.codigo, u);
                if (patentes < 1)
                {
                    flag = 1;
                }
                return flag;
            }
            public int ValidarNombreDeUsuario(string nu, int u)
            {
                string nombre = EncriptarReversible(nu);
                SeguridadDAL sdal = new SeguridadDAL();
                int i = sdal.ValidarNombreDeUsuario(nombre);
                if (i == 1)
                {
                    GuardarEnBitacora(26, u);
                }
                return i;
            }
            public int ValidarCelular(string cel)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarCelular(cel);
            }
            public int ValidarCorreo(string co, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int i = sdal.ValidarCorreo(co);
                if (i == 1)
                {
                    GuardarEnBitacora(25, u);
                }
                return i;
            }
            public usuario TraerDatosExclusivos(int cod)
            {
                usuarioDAL udal = new usuarioDAL();
                usuario u = new usuario();
                u = udal.TraerDatosExclusivos(cod);
                u.nombredeusuario = Desencriptar(u.nombredeusuario);
                return u;
            }

            public void GuardarDatosUsuario(string nu, string n, string a, string cel, string co, string dni, int cod)
            {
                usuario u = new usuario();
                u.cod = cod;
                u.nombredeusuario = EncriptarReversible(nu);
                u.nombre = EncriptarReversible(n);
                u.apellido = EncriptarReversible(a);
                u.celular = cel;
                u.correo = co;
                u.DNI = dni;
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.GuardarDatosUsuario(u);
                GuardarEnBitacora(24, cod);
            }
            public List<usuario> TraerUsuarios()
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.TraerUsuarios();
            }

            public void BloquearDesbloquearEliminar(string p, string cod, int u)
            {
                string command = "";
                string bitacora = "";
                int criticidad = 0;
                if (p == "Usuario activo") //bloqueo
                {
                    command = "update usuario set cod_estado = 16 where cod_usuario = " + cod;
                    bitacora = "Usuario " + cod + " bloqueado";
                    criticidad = 2;
                }
                if (p == "Usuario bloqueado") //desbloqueo
                {
                    command = "update usuario set cod_estado = 1 where cod_usuario = " + cod;
                    bitacora = "Usuario " + cod + " desbloqueado";
                    criticidad = 2;
                }
                if (p == "eliminar")//elimino
                {
                    command = "update usuario set cod_estado = 9 where cod_usuario = " + cod;
                    bitacora = "Usuario " + cod + " eliminado";
                    criticidad = 3;
                }
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.BloquearDesbloquearEliminar(command, cod);
                sdal.GuardarEnBitacora(EncriptarReversible(bitacora), u, criticidad);
            }

            public List<cliente> BuscarClientes(string nombre)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.BuscarClientes(nombre);
            }
            public void RegistrarCliente(cliente c, int user)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.RegistrarCliente(c);
                sdal.GuardarEnBitacora(EncriptarReversible("Nuevo cliente: " + c.nombre + " " + c.apellido), user, 2);
            }
            public void EditarCliente(cliente c, int user)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.EditarCliente(c);
                sdal.GuardarEnBitacora(EncriptarReversible("Modificación de datos de cliente " + c.cod), user, 2);
            }
            public void EliminarCliente(string cod, int user)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                sdal.EliminarCliente(cod);
                sdal.GuardarEnBitacora(EncriptarReversible("Cliente " + cod + " eliminado"), user, 3);
            }
            public int EliminarUsuarioConPatentesUnicas(string cod_usuario, int u)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                int flag = 0;
                for (int i = 1; i <= 29; i++)
                {
                    if (sdal.EliminarUsuarioConPatentesUnicas(cod_usuario, i) == 0)
                    {
                        if (EliminarUsuarioconFamiliaPatenteUnica(cod_usuario, i) == 1)
                        {
                            GuardarEnBitacora(29, u);
                            flag = 1;
                        }

                    }

                }
                return flag;
            }
            public int EliminarUsuarioconFamiliaPatenteUnica(string cod_usuario, int cod_patente)
            {
                int flag = 0;
                SeguridadDAL sdal = new SeguridadDAL();
                foreach (int f in sdal.BuscarFamiliasConPatente(cod_patente, cod_usuario))
                {
                    if (sdal.EliminarUsuarioconFamiliaPatenteUnica(f) > 2)
                    {
                        flag = 1;
                    }
                }
                return flag;
            }
            public int ValidarNombreDeFamiliaUnico(string nombre)
            {
                SeguridadDAL sdal = new SeguridadDAL();
                return sdal.ValidarNombreDeFamiliaUnico(EncriptarReversible(nombre));
            }
        }
    */
    }
}
