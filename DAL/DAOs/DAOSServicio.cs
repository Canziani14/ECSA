using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.DAOs
{
    internal class DAOSServicio : ICrud<BE.Servicio>
    {

        private DAOSServicio() { }
        private static DAOs.DAOSServicio instance;

        public static DAOs.DAOSServicio GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSServicio();
            }
            return instance;
        }




        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;

        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Servicio]";



        public List<Servicio> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Servicio objAgregar)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Servicio objEliminar)
        {
            throw new NotImplementedException();
        }

        public List<Servicio> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERServicio.GetInstance().Map(table);
        }

        public bool Modificar(Servicio objActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
