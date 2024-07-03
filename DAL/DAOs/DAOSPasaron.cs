using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs
{
    internal class DAOSPasaron
    {
        public class DAO
        {
            /*
                        SqlConnection mcon = new SqlConnection();
                        public DAO()
                        {
                            StreamReader sr = new StreamReader("C:\\Program Files\\Taller de Competicion\\TallerdeCompeticionSetup\\Recursos\\YwBvAG4AZQBjAHQAaQBvAG4AcwB0AHIAaQBuAGcA.txt");
                            mcon.ConnectionString = Desencriptar(sr.ReadLine());
                            mcon.Close();
                            sr.Close();
                        }
                        public DataSet ExecuteDataSet(string mcommand)
                        {
                            try
                            {
                                SqlDataAdapter mda = new SqlDataAdapter(mcommand, mcon);
                                DataSet mds = new DataSet();

                                mda.Fill(mds);
                                return mds;
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                            finally
                            {
                                if (mcon.State != ConnectionState.Closed)
                                    mcon.Close();
                            }

                        }
                        public int ValidarConexionBD(string cs)
                        {
                            try
                            {
                                SqlConnection sqlc = new SqlConnection(cs);
                                sqlc.Open();
                                return 1;
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                            finally
                            {
                                if (mcon.State != ConnectionState.Closed)
                                {
                                    mcon.Close();
                                }

                            }
                        }

                        public int ExecuteNonQueryMaster(string mcommand)
                        {
                            SqlConnection mconn = new SqlConnection();
                            mconn.ConnectionString = mcon.ConnectionString.Replace("ReCompeticion", "master");

                            try
                            {
                                SqlCommand mcom = new SqlCommand(mcommand, mconn);
                                mconn.Open();
                                return mcom.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                            finally
                            {
                                if (mcon.State != ConnectionState.Closed)
                                    mcon.Close();
                            }

                        }
                        public int ExecuteNonQuery(string mcommand)
                        {
                            try
                            {
                                SqlCommand mcom = new SqlCommand(mcommand, mcon);
                                mcon.Open();
                                return mcom.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                            finally
                            {
                                if (mcon.State != ConnectionState.Closed)
                                    mcon.Close();
                            }

                        }

                        public int ExecuteScalar(string mcommand)
                        {
                            int i = 0;
                            try
                            {
                                SqlCommand mcom = new SqlCommand(mcommand, mcon);
                                mcon.Open();
                                i = Convert.ToInt32(mcom.ExecuteScalar());
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                            finally
                            {
                                if (mcon.State != ConnectionState.Closed)
                                    mcon.Close();
                            }
                            return i;

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
                    }*/
        }
    }
}

