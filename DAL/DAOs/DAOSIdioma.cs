using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs
{
    internal class DAOSIdioma
    {
        private DAOSIdioma() { }
        private static DAOs.DAOSIdioma instance;

        public static DAOs.DAOSIdioma GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSIdioma();
            }
            return instance;
        }




        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        string QuerySelect = "select * from Idioma";

        public List<BE.Idioma> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSIdioma.GetInstance().Map(table);
        }













    }
}
