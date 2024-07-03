using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    internal class DALPasaron
    {
        /*
        public string commanddv { get; set; }
        public int calculo { get; set; }
        public List<usuario> ComprobarNombreDeUsuario(string un)
        {
            List<usuario> lstusuario = new List<usuario>();
            string command = "Select cod_usuario, nombre, apellido,nombredeusuario, cod_estado, contraseña, DNI, celular, correo, contador from usuario where nombredeusuario = '" + un + "' and cod_estado != 9";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    usuario u = new usuario();
                    ValorizarUsuario(u, d);
                    lstusuario.Add(u);
                }

            }

            return lstusuario;
        }
        public int SumarIntento(int i, int cu)
        {
            string command = "update usuario set contador = " + i + " where cod_usuario = " + cu + ";";
            DAO mdao = new DAO();
            return mdao.ExecuteNonQuery(command);
        }
        public int BloquearUsuario(int cu)
        {
            string command = "update usuario set cod_estado = 16 where cod_usuario = " + cu + ";";
            DAO mdao = new DAO();
            return mdao.ExecuteNonQuery(command);
        }
        public static void ValorizarUsuario(usuario u, DataRow d)
        {
            u.cod = int.Parse(d["cod_usuario"].ToString());
            u.nombre = d["nombre"].ToString();
            u.apellido = d["apellido"].ToString();
            u.nombredeusuario = d["nombredeusuario"].ToString();
            u.estado = int.Parse(d["cod_estado"].ToString());
            u.contraseña = d["contraseña"].ToString();
            u.DNI = d["DNI"].ToString();
            u.celular = d["celular"].ToString();
            u.correo = d["correo"].ToString();
            u.contador = int.Parse(d["contador"].ToString());

        }
        public int ComprobarContraseña(string un, string pass)
        {
            string command = "Select cod_usuario from usuario where nombredeusuario = '" + un + "' and contraseña = '" + pass + "';";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                return 1;
            }
            else return 0;
        }
        public List<Trabajo> ListarTrabajos(DateTime d)
        {
            string command = "select cod_trabajo, a.fecha_inicio as fecha, a.titulo, b.nombre, b.apellido, c.detalle, a.monto from trabajo as a join cliente as b on b.cod_cliente = a.cod_cliente right join estado as c on c.cod_estado = a.cod_estado where a.fecha_inicio <= '" + d.Year + "-" + d.Month + "-" + d.Day + " 23:59:59' and a.cod_estado = 5;";
            List<Trabajo> lsttrabajo = new List<Trabajo>();
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    Trabajo t = new Trabajo();
                    ValorizarTrabajo(t, r);
                    lsttrabajo.Add(t);
                }

            }

            return lsttrabajo;
        }

        public static void ValorizarTrabajo(Trabajo t, DataRow r)
        {
            DateTime f = (DateTime)r["fecha"];
            t.cod = int.Parse(r["cod_trabajo"].ToString());
            t.fecha = f.Day + "-" + f.Month + "-" + f.Year;
            t.monto = int.Parse(r["monto"].ToString());
            t.titulo = r["titulo"].ToString();
            t.nombre_cliente = r["nombre"].ToString();
            t.apellido_cliente = r["apellido"].ToString();
            t.estado = r["detalle"].ToString();
        }
        public static void ValorizarTrabajo2(Trabajo t, DataRow r)
        {
            t.cod = int.Parse(r["cod_trabajo"].ToString());
            t.fecha_inicio = Convert.ToDateTime(r["fecha"]);
            t.monto = int.Parse(r["monto"].ToString());
            t.titulo = r["titulo"].ToString();
            t.nombre_cliente = r["nombre"].ToString();
            t.apellido_cliente = r["apellido"].ToString();
            t.estado = r["detalle"].ToString();
        }
        public void GuardarEnBitacora(string detalle, int user, int c)
        {
            string command = "insert into Bitacora (detalle, responsable, cod_criticidad) values ('" + detalle + "', " + user + ", " + c + ")SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            DAO mdao = new DAO();
            int i = mdao.ExecuteScalar(command);
            command = "select cod_bitacora, detalle, responsable, cast(cast(fecha_hora as numeric) as int) as fecha, cod_criticidad from bitacora where cod_bitacora =" + i;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHBitacora(r), i, "bitacora", "cod_bitacora");
                }
            }
            CalcularDVV("Bitacora");
        }

        public List<int> VerificarDigitosVerificadores(string tabla)
        {
            List<int> lst = new List<int>();
            DAO mdao = new DAO();
            DataSet mds = new DataSet();

            switch (tabla)
            {
                case "Usuario":
                    commanddv = "select cod_usuario, nombre, apellido, nombredeusuario, estado, contraseña, DNI, celular, correo, fecha_inicio, contador from usuario";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHusuario(r));
                        }

                    }


                    break;
                case "PatentexUsuario":
                    commanddv = "select cod_familiaxPatente, cod_patente, cod_familia from PatentexUsuario";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHPatentexUsuario(r));
                        }

                    }
                    break;
                case "FamiliaxUsuario":
                    commanddv = "select * from FamiliaxUsuario";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHFamiliaxUsuario(r));
                        }

                    }
                    break;
                case "FamiliaxPatente":
                    commanddv = "select * from FamiliaxPatente";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHFamiliaxPatente(r));
                        }

                    }
                    break;
                case "Trabajo":
                    commanddv = "select * from trabajo";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHtrabajo(r));
                        }

                    }
                    break;
                case "Bitacora":
                    commanddv = "select cod_bitacora, detalle, responsable, fecha_, criticidad from bitacora";
                    mds = mdao.ExecuteDataSet(commanddv);

                    if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            lst.Add(DVHBitacora(r));
                        }

                    }
                    break;
                default:
                    break;
            }
            return lst;

        }
        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            string command = "update " + t + " set DVH = " + DVH + " where " + codtabla + " = " + cod;
            DAO mdao = new DAO();
            DataSet mds = new DataSet();
            return mdao.ExecuteNonQuery(command);
        }
        public int DVHBitacora(DataRow d)
        {
            int dvh;
            dvh = CalcularNumero(int.Parse(d["cod_bitacora"].ToString())) * 1 + CalcularNumero((d["detalle"].ToString())) * 2 + CalcularNumero(int.Parse(d["responsable"].ToString())) * 3 + CalcularNumero(d["fecha"].ToString()) * 4 + CalcularNumero(int.Parse(d["cod_criticidad"].ToString())) * 5;
            return dvh;
        }
        public int DVHusuario(DataRow d)
        {
            int dvh;
            dvh = CalcularNumero(int.Parse(d["cod_usuario"].ToString())) * 1 + CalcularNumero(d["nombre"].ToString()) * 2 + CalcularNumero(d["apellido"].ToString()) * 3 + CalcularNumero(d["nombredeusuario"].ToString()) * 4 + CalcularNumero(d["contraseña"].ToString()) * 5 + CalcularNumero(d["DNI"].ToString()) * 6 + CalcularNumero(d["celular"].ToString()) * 7 + +CalcularNumero(d["correo"].ToString()) * 8 + CalcularNumero(int.Parse(d["cod_estado"].ToString())) * 9 + +CalcularNumero(d["fecha_inicio"].ToString()) * 10 + CalcularNumero(d["contador"].ToString()) * 11;
            return dvh;
        }
        public int DVHPatentexUsuario(DataRow d)
        {
            int dvh = CalcularNumero(int.Parse(d["cod_patentexusuario"].ToString())) * 1 + CalcularNumero(int.Parse(d["cod_patente"].ToString())) * 2 + CalcularNumero(int.Parse(d["cod_usuario"].ToString())) * 3 + CalcularNumero(int.Parse(d["cod_estado"].ToString())) * 4;
            return dvh;
        }
        public int DVHFamiliaxUsuario(DataRow d)
        {
            int dvh = CalcularNumero(int.Parse(d["cod_familiaxUsuario"].ToString())) * 1 + CalcularNumero(int.Parse(d["cod_usuario"].ToString())) * 2 + CalcularNumero(int.Parse(d["cod_familia"].ToString())) * 3 + CalcularNumero(int.Parse(d["cod_estado"].ToString())) * 4;
            return dvh;
        }
        public int DVHFamiliaxPatente(DataRow d)
        {
            int dvh = CalcularNumero(int.Parse(d["cod_familiaxpatente"].ToString())) * 1 + CalcularNumero(int.Parse(d["cod_familia"].ToString())) * 2 + CalcularNumero(int.Parse(d["cod_patente"].ToString())) * 3;
            return dvh;
        }
        public int DVHtrabajo(DataRow d)
        {
            int dvh;
            dvh = CalcularNumero(int.Parse(d["cod_trabajo"].ToString())) * 1 + CalcularNumero(int.Parse(d["fecha"].ToString())) * 2 + CalcularNumero(d["titulo"].ToString()) * 3 + CalcularNumero(int.Parse(d["cod_cliente"].ToString())) * 4 + CalcularNumero(int.Parse(d["cod_estado"].ToString())) * 5 + CalcularNumero(int.Parse(d["monto"].ToString())) * 6;
            return dvh;
        }

        public int CalcularDVV(string tabla)
        {
            string command1 = "select SUM(DVH) from " + tabla;
            DAO mdao = new DAO();
            string command2 = "update DVV set DVV = " + mdao.ExecuteScalar(command1) + " where tabla = '" + tabla + "'";
            return mdao.ExecuteNonQuery(command2);
        }
        public List<patente> BuscarPatentexUsuario(int u)
        {
            List<patente> lstp = new List<patente>();
            string command = "select cod_patente, cod_usuario from patentexusuario where cod_estado = 17 and cod_usuario = " + u;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    patente p = new patente();
                    ValorizarPatentexusuario(r, p);
                    lstp.Add(p);
                }
            }
            return lstp;
        }
        public static void ValorizarPatente(DataRow r, patente p)
        {
            p.codigo = int.Parse(r["cod_patente"].ToString());
            p.detalle = r["nombre"].ToString();
        }
        public static void ValorizarPatentexusuario(DataRow r, patente p)
        {
            p.codigo = int.Parse(r["cod_patente"].ToString());
        }
        public List<patente> MostrarPatentes()
        {
            List<patente> lstp = new List<patente>();
            string command = "select cod_patente, nombre from patente";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    patente p = new patente();
                    ValorizarPatente(r, p);
                    lstp.Add(p);
                }
            }
            return lstp;
        }

        public List<patente> ValidarPatentexUsuario(int u)
        {
            List<patente> lstp = new List<patente>();
            string command = "select * from patentexusuario where cod_estado = 17 and cod_usuario = " + u;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    patente p = new patente();
                    ValorizarPatentexusuario(r, p);
                    lstp.Add(p);
                }
            }
            return lstp;

        }
        public void EliminarPatentexUsuario(int p, int u)
        {
            string command = "update patentexusuario set cod_estado = 14  where cod_usuario = " + u + " and cod_patente = " + p;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_patentexusuario, cod_patente, cod_usuario, cod_estado, DVH from patentexusuario where cod_patente = " + p + " and cod_usuario = " + u;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHPatentexUsuario(r), int.Parse(r["cod_patentexusuario"].ToString()), "patentexusuario", "cod_patentexusuario");
                }
            }
            CalcularDVV("patentexusuario");
        }
        public int ValidarExistePatente(int p, int u)
        {
            string command = "select count(cod_patente) from patentexusuario where cod_patente = " + p + " and cod_usuario = " + u;
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public void ActivarPatentexUsuario(int p, int u)
        {
            DAO mdao = new DAO();
            string command = "update patentexusuario set cod_estado = 17 where cod_patente = " + p + " and cod_usuario = " + u;
            mdao.ExecuteNonQuery(command);
            command = "select cod_patentexusuario, cod_patente, cod_usuario, cod_estado, DVH from patentexusuario where cod_patente = " + p + " and cod_usuario = " + u;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHPatentexUsuario(r), int.Parse(r["cod_patentexusuario"].ToString()), "patentexusuario", "cod_patentexusuario");
                }
            }
            CalcularDVV("patentexusuario");
        }
        public int ValidarPatenteUnica(int p, int cod_usuario)
        {
            string command = "select count(cod_patente) from patentexusuario as pxu inner join usuario as u on u.cod_usuario = pxu.cod_usuario where u.cod_estado = 1 and cod_patente = " + p + " and pxu.cod_estado = 17 and u.cod_usuario != " + cod_usuario;
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarPatenteUnica2(int p, int cod_usuario)
        {
            string command = "select count(cod_patente) from patentexusuario as pxu inner join usuario as u on u.cod_usuario = pxu.cod_usuario where u.cod_estado = 1 and cod_patente = " + p + " and pxu.cod_estado = 17";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public void AsignarPatente(int p, int u)
        {
            string command = "insert into patentexusuario (cod_patente, cod_usuario, cod_estado) values(" + p + "," + u + ", 17)SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            DAO mdao = new DAO();
            int i = mdao.ExecuteScalar(command);
            command = "select cod_patentexusuario, cod_patente, cod_usuario, cod_estado from patentexusuario where cod_patentexusuario = " + i;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHPatentexUsuario(r), i, "patentexusuario", "cod_patentexusuario");
                }
            }
            CalcularDVV("patentexusuario");
        }

        public int CalcularNumero(string s)
        {
            calculo = 0;
            for (int i = 1; i < s.Length; i++)
            {
                calculo += (int)s[i];
            }
            return calculo;
        }
        public int CalcularNumero(int n)
        {
            string t = n.ToString();
            calculo = 0;

            for (int i = 0; i < t.Length; i++)
            {
                calculo += int.Parse(t[i].ToString());
            }
            return calculo;
        }
        public int ValidarFamiliaUnica(string p, int cp)
        {
            int i = 0;
            string command = "select count(fxp.cod_patente) as c from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where cod_patente in (" + p + ") and f.cod_estado = 8 group by fxp.cod_familia";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    if (int.Parse(d["c"].ToString()) == cp)
                    {
                        i = 1; //Ya existe una familia igual
                    }
                }
            }
            return i;

        }
        public int GuardarFamilia(string n)
        {
            string command = "insert into familia (nombre, cod_estado) values ('" + n + "', 8)SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);

        }
        public void GuardarFamiliaxPatente(int ps, int cf)
        {
            string command = "insert into familiaxpatente (cod_familia, cod_patente, cod_estado) values (" + cf + ", " + ps + ", 19)SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            DAO mdao = new DAO();
            int i = mdao.ExecuteScalar(command);
            command = "select cod_familiaxpatente, cod_familia, cod_patente from familiaxpatente where cod_familiaxpatente = " + i;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHFamiliaxPatente(d), i, "familiaxpatente", "cod_familiaxpatente");
                }
            }
            CalcularDVV("familiaxpatente");
        }
        public List<cliente> ListarClientes()
        {
            List<cliente> lstc = new List<cliente>();
            string command = "select nombre, apellido from cliente where cod_estado = 4";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    cliente c = new cliente();
                    ValorizarCliente(d, c);
                    lstc.Add(c);

                }
            }
            return lstc;
        }
        public static void ValorizarCliente(DataRow r, cliente c)
        {
            c.nombre = r["nombre"].ToString();
            c.apellido = r["apellido"].ToString();
        }

        public void GuardarTrabajo(Trabajo t)
        {
            string command = "insert into trabajo (titulo, cod_cliente, cod_estado, monto) values ('" + t.titulo + "', " + t.cod_cliente + ",5, " + t.monto + ")SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
            DAO mdao = new DAO();
            int i = mdao.ExecuteScalar(command);
            command = "select cod_trabajo, cast(cast(fecha_inicio as numeric) as int) as fecha, titulo, cod_cliente, cod_estado, monto from trabajo where cod_trabajo = " + i;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHtrabajo(d), i, "trabajo", "cod_trabajo");
                }
            }
            CalcularDVV("trabajo");
        }

        public int BuscarCodCliente(string na)
        {
            string command = "select cod_cliente from cliente where cod_estado = 4 and CONCAT(nombre,' ',apellido) = '" + na + "'";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);

        }
        public int ValidarConexionBD(string cs)
        {
            DAO mdao = new DAO();
            return mdao.ValidarConexionBD(cs);
        }
        public List<patente> ValidarPatentesEnFormulario(string p, int u)
        {
            List<patente> lstp = new List<patente>();
            string command = "select cod_patente from PatentexUsuario where cod_patente in (" + p + ") and cod_usuario = " + u;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    patente pat = new patente();
                    ValorizarPatentexusuario(d, pat);
                    lstp.Add(pat);
                }
            }
            return lstp;
        }
        public List<patente> ValidarPatenteFamiliaEnFormulario(string p, int u)
        {
            List<patente> lstp = new List<patente>();
            string command = "select cod_patente from FamiliaxPatente as fxp inner join FamiliaxUsuario as fxu on fxp.cod_familia = fxu.cod_familia inner join Familia as f on f.cod_familia = fxu.cod_familia where fxp.cod_patente in ( " + p + " ) and fxu.cod_usuario = " + u + " and f.cod_estado = 8";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    patente pat = new patente();
                    ValorizarPatentexusuario(d, pat);
                    lstp.Add(pat);
                }
            }
            return lstp;
        }

        public int ValidarIntegridad(string tabla)
        {
            int flag = 0;
            DAO mdao = new DAO();
            int cod;
            string command = "";
            switch (tabla)
            {
                case "Bitacora":
                    command = "select cod_bitacora, detalle, cast(cast(fecha_hora as numeric) as int) as fecha, responsable, cod_criticidad, DVH from Bitacora";
                    break;
                case "Usuario":
                    command = "select cod_usuario, nombre, apellido, nombredeusuario, contraseña, DNI, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador, DVH from usuario";
                    break;
                case "PatentexUsuario":
                    command = "select cod_patentexusuario, cod_patente, cod_usuario, cod_estado, DVH from patentexusuario";
                    break;
                case "FamiliaxUsuario":
                    command = "select cod_FamiliaxUsuario, cod_familia, cod_usuario, cod_estado, DVH from FamiliaxUsuario";
                    break;
                case "FamiliaxPatente":
                    command = "select cod_FamiliaxPatente, cod_familia, cod_patente, DVH from FamiliaxPatente";
                    break;
                case "Trabajo":
                    command = "select cod_Trabajo, cast(cast(fecha_inicio as numeric) as int) as fecha, titulo, cod_cliente, cod_estado, monto, DVH from Trabajo";
                    break;

                default:
                    break;
            }

            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    switch (tabla)
                    {
                        case "Usuario":
                            if (DVHusuario(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_usuario"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHusuario(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        case "PatentexUsuario":
                            if (DVHPatentexUsuario(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_PatentexUsuario"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHPatentexUsuario(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        case "FamiliaxUsuario":
                            if (DVHFamiliaxUsuario(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_FamiliaxUsuario"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHFamiliaxUsuario(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        case "FamiliaxPatente":
                            if (DVHFamiliaxPatente(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_FamiliaxPatente"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHFamiliaxPatente(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        case "Trabajo":
                            if (DVHtrabajo(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_trabajo"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHtrabajo(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        case "Bitacora":
                            if (DVHBitacora(d) != int.Parse(d["DVH"].ToString()))
                            {
                                cod = int.Parse(d["cod_bitacora"].ToString());
                                GuardarEnBitacora(EncriptarReversible("Error en registro " + cod + " en tabla " + tabla), 0, 1);
                                RepararIntegridad(tabla, DVHBitacora(d), cod);
                                CalcularDVV(tabla);
                                flag = 1;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return flag;
        }

        public void RepararIntegridad(string tabla, int dvh, int cod)
        {
            string command = "update " + tabla + " set DVH = " + dvh + " where cod_" + tabla + " = " + cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);

        }
        public string EncriptarReversible(string cadenaen)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadenaen));
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
        public void CrearUsuario(string n, string ap, string nu, string dni, string ce, string co, string con)
        {
            DAO mdao = new DAO();
            int cod = mdao.ExecuteScalar("insert into usuario (nombre, apellido, nombredeusuario, contraseña, DNI, celular, correo, cod_estado, contador) values ('" + EncriptarReversible(n) + "','" + EncriptarReversible(ap) + "','" + EncriptarReversible(nu) + "','" + EncriptarIrreversible(con) + "','" + dni + "','" + ce + "','" + co + "',1,0)SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]");
            DataSet mds = mdao.ExecuteDataSet("select cod_usuario, nombre, apellido, nombredeusuario, contraseña, DNI, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador from usuario where cod_usuario = " + cod);

            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHusuario(r), cod, "usuario", "cod_usuario");
                }
            }
            CalcularDVV("usuario");
        }

        public void RealizarBackup(string n)
        {
            string command = $"BACKUP DATABASE [ReCompeticion] TO " + n;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
        }
        public void RealizarRestore(string a)
        {
            //string command = $"USE [master] ALTER DATABASE[ReCompeticion] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE[ReCompeticion] FROM DISK = N'" + a + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5 ALTER DATABASE[ReCompeticion] SET MULTI_USER";
            string command = $"USE [master] ALTER DATABASE ReCompeticion SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE ReCompeticion FROM " + a;
            command += " WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 5 ALTER DATABASE ReCompeticion SET MULTI_USER";
            DAO mdao = new DAO();
            mdao.ExecuteNonQueryMaster(command);
        }

        public List<bitacora> BuscarEnBitacora(String command)
        {
            List<bitacora> lstb = new List<bitacora>();
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    bitacora b = new bitacora();
                    ValorizarBitacora(r, b);
                    lstb.Add(b);
                }

            }

            return lstb;
        }

        public void ValorizarBitacora(DataRow r, bitacora b)
        {
            b.fecha = r["fecha"].ToString();
            b.detalle = r["detalle"].ToString();
            b.crit = r["criticidad"].ToString();
            b.resp = r["nombrecompleto"].ToString();
        }

        public void FinalizarTrabajo(string cod)
        {
            string command = "update trabajo set cod_estado = 6 where cod_trabajo = " + cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_trabajo, cast(cast(fecha_inicio as numeric) as int) as fecha, titulo, cod_cliente, cod_estado, monto from trabajo where cod_trabajo = " + cod;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHtrabajo(d), int.Parse(cod), "trabajo", "cod_trabajo");
                }
            }
            CalcularDVV("trabajo");

        }
        public void EliminarTrabajo(string cod)
        {
            string command = "update trabajo set cod_estado = 3 where cod_trabajo = " + cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_trabajo, cast(cast(fecha_inicio as numeric) as int) as fecha, titulo, cod_cliente, cod_estado, monto from trabajo where cod_trabajo = " + cod;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHtrabajo(d), int.Parse(cod), "trabajo", "cod_trabajo");
                }
            }
            CalcularDVV("trabajo");
        }

        public List<Trabajo> ListarTrabajosAbonados()
        {
            List<Trabajo> lstt = new List<Trabajo>();
            string command = "select cod_trabajo, a.titulo, b.nombre, b.apellido, a.fecha_inicio as fecha, c.detalle, a.monto from trabajo as a join cliente as b on b.cod_cliente = a.cod_cliente right join estado as c on c.cod_estado = a.cod_estado where a.cod_estado = 6";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    Trabajo t = new Trabajo();
                    ValorizarTrabajo2(t, d);
                    lstt.Add(t);

                }
            }

            return lstt;
        }

        public void FacturarTrabajoAbonado(List<Trabajo> lstt)
        {
            DAO mdao = new DAO();
            string command = "";
            foreach (Trabajo t in lstt)
            {
                command = "update trabajo set cod_estado = 7 where cod_trabajo = " + t.cod;
                mdao.ExecuteNonQuery(command);
                command = "select cod_trabajo, cast(cast(fecha_inicio as numeric) as int) as fecha, titulo, cod_cliente, cod_estado, monto from trabajo where cod_trabajo = " + t.cod;
                DataSet mds = mdao.ExecuteDataSet(command);
                foreach (DataRow d in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHtrabajo(d), int.Parse(d["cod_trabajo"].ToString()), "trabajo", "cod_trabajo");
                }

            }
            CalcularDVV("trabajo");
        }

        public List<familia> TraerFamilias()
        {
            List<familia> lstf = new List<familia>();
            string command = "select nombre from Familia where cod_estado = 8";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            foreach (DataRow d in mds.Tables[0].Rows)
            {
                lstf.Add(new familia { nombre = d["nombre"].ToString() });
            }
            return lstf;
        }

        public List<patente> TraerPatentesxFamilia(string nombre)
        {
            string command = "select p.nombre as nombrepatente, p.cod_patente as codigo from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia inner join Patente as p on p.cod_patente = fxp.cod_patente where f.nombre = '" + nombre + "'";
            List<patente> lstp = new List<patente>();
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            foreach (DataRow d in mds.Tables[0].Rows)
            {
                lstp.Add(new patente { codigo = int.Parse(d["codigo"].ToString()), asignada = true, detalle = d["nombrepatente"].ToString() });
            }
            command = "select cod_patente as codigo, nombre as nombrepatente from patente where cod_patente not in (select fxp.cod_patente from FamiliaxPatente as fxp inner join Familia as f on f.cod_familia = fxp.cod_familia where f.nombre = '" + nombre + "')";
            DataSet mds2 = mdao.ExecuteDataSet(command);
            foreach (DataRow d2 in mds2.Tables[0].Rows)
            {
                lstp.Add(new patente { codigo = int.Parse(d2["codigo"].ToString()), asignada = false, detalle = d2["nombrepatente"].ToString() });
            }

            return lstp;
        }

        public int ExistePatenteFamilia(string command)
        {
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);

        }
        public void QuitarAsignarCrearPatentedeFamilia(string command)
        {
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
        }
        public void EliminarFamilia(string nombre)
        {
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery("update familia set cod_estado = 13 where nombre = '" + nombre + "'");
            string command = "select cod_familia from familia where nombre = '" + nombre + "'";
            int cod_familia = mdao.ExecuteScalar(command);
            command = "update familiaxusuario set cod_estado = 15 where cod_familia = " + cod_familia;
            mdao.ExecuteNonQuery(command);
            command = "select cod_familiaxusuario, cod_familia, cod_usuario, cod_estado from familiaxusuario where cod_familia = " + cod_familia;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHFamiliaxUsuario(r), int.Parse(r["cod_familiaxusuario"].ToString()), "familiaxusuario", "cod_familiaxusuario");
                }
                CalcularDVV("familiaxusuario");
            }
        }

        public List<comentario> ListarComentario(string cod_trabajo)
        {
            List<comentario> lstc = new List<comentario>();
            string command = "select c.cod_comentario as cod, c.cod_trabajo, c.detalle as detail, c.fecha_hora as fecha, u.nombre as nombre, u.apellido as apellido from comentario as c inner join usuario as u on u.cod_usuario = c.cod_usuario where c.cod_estado = 20 and c.cod_trabajo = " + cod_trabajo;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            foreach (DataRow d in mds.Tables[0].Rows)
            {
                comentario c = new comentario();
                ValorizarComentario(d, c);
                lstc.Add(c);
            }
            return lstc;
        }

        public void ValorizarComentario(DataRow d, comentario c)
        {

            DateTime f = (DateTime)d["fecha"];
            c.codigo = int.Parse(d["cod"].ToString());
            c.detalle = d["detail"].ToString();
            c.fecha = f.Day + "-" + f.Month + "-" + f.Year;
            c.nombredeusuario = d["nombre"].ToString() + " " + d["apellido"].ToString();
        }

        public void AgregarComentario(string cod_trabajo, string detalle, int cod_usuario)
        {
            string command = "insert into comentario (cod_trabajo, detalle, cod_usuario, cod_estado) values (" + cod_trabajo + ", '" + detalle + "', " + cod_usuario + ", 20)";
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);

        }
        public void EliminarComentario(string cod_trabajo)
        {
            string command = "update comentario set cod_estado = 21 where cod_comentario = " + cod_trabajo;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);

        }

        public void CambiarContraseña(int cod, string pass)
        {
            string command = "update usuario set contraseña = '" + pass + "' where cod_usuario =" + cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_usuario, nombre, apellido, nombredeusuario, contraseña, DNI, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador from usuario where cod_usuario = " + cod;
            DataSet mds = mdao.ExecuteDataSet(command);

            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHusuario(r), cod, "usuario", "cod_usuario");
                }
            }
            CalcularDVV("usuario");
        }

        public int ValidarContraseñaActual(int cod, string pass)
        {
            string command = "select COUNT(cod_usuario) from Usuario where contraseña = '" + pass + "' and cod_usuario = " + cod;
            DAO mdao = new DAO();
            if (mdao.ExecuteScalar(command) == 1)
            {
                return 0; //exito
            }
            else
            {
                return 1; //error
            }

        }
        public List<familia> ListarFamiliasActivasporUsuario(string cod_usuario)
        {
            List<familia> lstf = new List<familia>();
            string command = "select fxu.cod_familia from FamiliaxUsuario as fxu inner join Usuario as u on u.cod_usuario = fxu.cod_usuario where fxu.cod_estado = 22 and u.cod_usuario = '" + cod_usuario + "'";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    familia f = new familia() { cod = int.Parse(r["cod_familia"].ToString()) };
                    lstf.Add(f);
                }
            }
            return lstf;
        }
        public List<familia> ListarFamiliasActivas()
        {
            List<familia> lstf = new List<familia>();
            string command = "select cod_familia, nombre from familia where cod_estado = 8";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    familia f = new familia() { cod = int.Parse(r["cod_familia"].ToString()), nombre = r["nombre"].ToString() };
                    lstf.Add(f);
                }
            }
            return lstf;
        }
        public void AsignarFamiliaUsuario(string command)
        {
            DAO mdao = new DAO();
            int codfxu = mdao.ExecuteScalar(command);
            command = "select cod_familiaxusuario, cod_familia, cod_usuario, cod_estado from familiaxusuario where cod_familiaxusuario = " + codfxu;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHFamiliaxUsuario(r), codfxu, "familiaxusuario", "cod_familiaxusuario");
                }
                CalcularDVV("familiaxusuario");
            }

        }
        public void AsignarFamiliaUsuario2(int cod_familia, string cod_usuario, string instruccion)
        {
            string command = "";
            switch (instruccion)
            {
                case "activar":
                    command = "update familiaxusuario set cod_estado = 22 where cod_familia = " + cod_familia + " and cod_usuario = " + cod_usuario;
                    break;
                case "desactivar":
                    command = "update familiaxusuario set cod_estado = 15 where cod_familia = " + cod_familia + " and cod_usuario = " + cod_usuario;
                    break;
                default:
                    break;
            }
            DAO mdao = new DAO();
            mdao.ExecuteScalar(command);
            command = "select cod_familiaxusuario, cod_familia, cod_usuario, cod_estado from familiaxusuario where cod_familia = " + cod_familia + " and cod_usuario = " + cod_usuario;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHFamiliaxUsuario(r), int.Parse(r["cod_familiaxusuario"].ToString()), "familiaxusuario", "cod_familiaxusuario");
                }
                CalcularDVV("familiaxusuario");
            }

        }
        public int Existefamiliaxusuario(string commnd)
        {
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(commnd);
        }
        public List<patente> TraerPatentesxFamilia(int cod_familia)
        {
            List<patente> lstp = new List<patente>();
            string command = "select cod_patente from FamiliaxPatente where cod_familia = " + cod_familia;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    patente p = new patente();
                    p.codigo = int.Parse(r["cod_patente"].ToString());
                    lstp.Add(p);
                }
            }
            return lstp;
        }

        public int ValidarPatenteUnicaenFamilia(string nombre, int cod_patente)
        {
            string command = "select COUNT(fxu.cod_usuario) as cantidad from FamiliaxPatente as fxp inner join FamiliaxUsuario fxu on fxu.cod_familia = fxp.cod_familia inner join familia as f on f.cod_familia = fxu.cod_familia inner join usuario as u on u.cod_usuario = fxu.cod_usuario where u.cod_estado = 1 and f.nombre = '" + nombre + "' and fxp.cod_patente = " + cod_patente;
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarPatenteUnicaenFamilia2(int cod_familia, int cod_patente, int u) //no tocar
        {
            string command = "select COUNT(fxu.cod_usuario) as cantidad from FamiliaxPatente as fxp inner join FamiliaxUsuario fxu on fxu.cod_familia = fxp.cod_familia inner join familia as f on f.cod_familia = fxu.cod_familia inner join usuario as u on u.cod_usuario = fxu.cod_usuario where fxu.cod_estado = 22 and fxp.cod_patente = " + cod_patente + "and f.cod_familia not in(select cod_familia from familiaxusuario where cod_familia = " + cod_familia + " and cod_usuario = " + u + ")";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarPatenteUnicaenFamilia(int cod_familia, int cod_patente)
        {
            string command = "select COUNT(fxu.cod_usuario) as cantidad from FamiliaxPatente as fxp inner join FamiliaxUsuario fxu on fxu.cod_familia = fxp.cod_familia where fxp.cod_familia = " + cod_familia + " and fxp.cod_patente = " + cod_patente;
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }

        public int ValidarPatenteUnicaEnFamiliaAsignada(int cod_patente)
        {
            string command = "select COUNT(fxu.cod_usuario) from FamiliaxPatente as fxp inner join FamiliaxUsuario as fxu on fxp.cod_familia = fxu.cod_familia inner join Familia as f on f.cod_familia = fxu.cod_familia inner join usuario as u on u.cod_usuario = fxu.cod_usuario where fxu.cod_estado= 22 and u.cod_estado = 1 and fxp.cod_patente = " + cod_patente + " and f.cod_estado = 8";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarNombreDeUsuario(string nu)
        {
            string command = "select count(cod_usuario) from usuario where cod_estado = 1 and nombredeusuario = '" + nu + "'";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarCelular(string cel)
        {
            string command = "select count(cod_usuario) from usuario where cod_estado = 1 and celular = '" + cel + "'";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public int ValidarCorreo(string co)
        {
            string command = "select count(cod_usuario) from usuario where cod_estado = 1 and correo = '" + co + "'";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public void GuardarDatosUsuario(usuario u)
        {
            string command = "update usuario set nombre = '" + u.nombre + "', apellido = '" + u.apellido + "', nombredeusuario = '" + u.nombredeusuario + "', DNI = '" + u.DNI + "', celular = '" + u.celular + "', correo = '" + u.correo + "' where cod_usuario = " + u.cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_usuario, nombre, apellido, nombredeusuario, contraseña, dni, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador from usuario where nombredeusuario = '" + u.nombredeusuario + "'";
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count == 1)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHusuario(r), int.Parse(r["cod_usuario"].ToString()), "usuario", "cod_usuario");
                }
            }
            CalcularDVV("usuario");
        }
        public List<usuario> TraerUsuarios()
        {
            string command = "select u.cod_usuario, u.nombre, u.apellido, u.nombredeusuario, u.DNI, u.celular, u.correo, e.detalle as estado from usuario as u inner join estado as e on e.cod_estado = u.cod_estado where u.cod_estado != 9";
            List<usuario> lstu = new List<usuario>();
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    usuario u = new usuario();
                    u.cod = int.Parse(r["cod_usuario"].ToString());
                    u.nombredeusuario = r["nombredeusuario"].ToString();
                    u.nombre = r["nombre"].ToString();
                    u.apellido = r["apellido"].ToString();
                    u.celular = r["celular"].ToString();
                    u.correo = r["correo"].ToString();
                    u.DNI = r["DNI"].ToString();
                    u.detalle_estado = r["estado"].ToString();
                    lstu.Add(u);

                }
            }
            return lstu;
        }
        public void BloquearDesbloquearEliminar(string command, string cod)
        {
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
            command = "select cod_usuario, nombre, apellido, nombredeusuario, contraseña, dni, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador from usuario where cod_usuario = " + cod;
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    InsertarDVH(DVHusuario(r), int.Parse(cod), "usuario", "cod_usuario");

                }
            }
            CalcularDVV("usuario");
        }
        public void DesbloquearUsuario(string correo, string pass)
        {
            DAO mdao = new DAO();
            string command = "update usuario set cod_estado = 1 where correo = '" + correo + "'";
            mdao.ExecuteNonQuery(command);

            command = "select cod_usuario, nombre, apellido, nombredeusuario, contraseña, dni, celular, correo, cod_estado, cast(cast(fecha_inicio as numeric) as int) as fecha_inicio, contador from usuario where cod_estado = 1 and correo = '" + correo + "'";
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    CambiarContraseña(int.Parse(r["cod_usuario"].ToString()), EncriptarIrreversible(pass));
                }
            }
            CalcularDVV("usuario");
        }
        public List<cliente> BuscarClientes(string nombre)
        {
            List<cliente> lstc = new List<cliente>();
            string command = "select cod_cliente, nombre, apellido, correo, DNI, CUIT, celular, direccion from cliente where cod_estado = 4 and nombre = '" + nombre + "'";
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    cliente c = new cliente();
                    ValorizarCliente2(r, c);
                    lstc.Add(c);
                }
            }
            return lstc;

        }
        public void ValorizarCliente2(DataRow r, cliente c)
        {
            c.cod = int.Parse(r["cod_cliente"].ToString());
            c.nombre = r["nombre"].ToString();
            c.apellido = r["apellido"].ToString();
            c.correo = r["correo"].ToString();
            c.DNI = r["DNI"].ToString();
            c.celular = r["celular"].ToString();
            c.direccion = r["direccion"].ToString();
        }
        public void RegistrarCliente(cliente c)
        {
            string command = "insert into cliente (nombre, apellido, correo, DNI, CUIT, celular, direccion, cod_estado) values ('" + c.nombre + "', '" + c.apellido + "', '" + c.correo + "', '" + c.DNI + "', '" + c.CUIT + "', '" + c.celular + "', '" + c.direccion + "', 4)";
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
        }
        public void EditarCliente(cliente c)
        {
            string command = "update cliente set nombre = '" + c.nombre + "', apellido = '" + c.apellido + "', correo = '" + c.correo + "', DNI = '" + c.DNI + "', CUIT = '" + c.CUIT + "', celular = '" + c.celular + "', direccion = '" + c.direccion + "' where cod_cliente = " + c.cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
        }
        public void EliminarCliente(string cod)
        {
            string command = "update cliente set cod_estado = 12 where cod_cliente = " + cod;
            DAO mdao = new DAO();
            mdao.ExecuteNonQuery(command);
        }
        public int EliminarUsuarioConPatentesUnicas(string cod_usuario, int cod_patente)
        {
            string command = "select count(cod_patente) from PatentexUsuario where cod_estado = 17 and cod_patente = " + cod_patente + " and cod_usuario not in (select cod_usuario from PatentexUsuario where cod_usuario = " + cod_usuario + ")";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);

        }
        public int EliminarUsuarioconFamiliaPatenteUnica(int cod_familia)
        {
            string command = "select count(cod_usuario) from FamiliaxUsuario where cod_estado = 22 and cod_familia = " + cod_familia;
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);
        }
        public List<int> BuscarFamiliasConPatente(int cod_patente, string cod_usuario)
        {
            List<int> lstf = new List<int>();
            string command = "select fxu.cod_familia from FamiliaxPatente as fxp inner join FamiliaxUsuario as fxu on fxu.cod_familia = fxp.cod_familia inner join familia as f on f.cod_familia = fxp.cod_familia where f.cod_estado = 8 and fxu.cod_usuario = " + cod_usuario + " and fxp.cod_patente = " + cod_patente;
            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataSet(command);
            if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in mds.Tables[0].Rows)
                {
                    lstf.Add(int.Parse(r["cod_familia"].ToString()));
                }
            }
            return lstf;
        }
        public int ValidarNombreDeFamiliaUnico(string nombre)
        {
            string command = "select count(cod_familia) from familia where nombre = '" + nombre + "'";
            DAO mdao = new DAO();
            return mdao.ExecuteScalar(command);

        }


    */
    }
}
