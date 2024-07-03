using SQLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            string command = "update " + t + " set DVH = " + DVH + " where " + codtabla + " = " + cod;

            DataSet mds = new DataSet();
            return SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(command);
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
                        foreach (DataRow r in mds.Tables[0].Rows)
                        {
                            string commanddv2 ="update "+ tabla + " set DVH = "+ DVHEmpleado(r) + "where Legajo=" + r["Legajo"];
                            mds2 = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteNonQuery(commanddv2);
                            
                            suma += DVHEmpleado(r);
                        }
                    }
                    break;
                default:
                    break;
            }
            return suma;
        }
        /*
        List<int> lst = new List<int>();

        DataSet mds = new DataSet();

        switch (tabla)
        {
            case "Empleado":
                string commanddv = "select * from empleado";
                mds = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataSet(commanddv);

                if (mds.Tables.Count > 0 && mds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in mds.Tables[0].Rows)
                    {
                        lst.Add(DVHEmpleado(r));
                    }

                }


                break;
            default: break;
        }
        return lst;
    }*/

        public int DVHEmpleado(DataRow d)
        {
            int dvh;
            dvh = CalcularNumero(int.Parse(d["Legajo"].ToString())) + CalcularNumero(d["Nombre"].ToString()) + CalcularNumero(d["apellido"].ToString());
            return dvh;

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


            #endregion



        }
    }
}