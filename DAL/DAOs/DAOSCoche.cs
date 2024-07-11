using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAOs
{
    internal class DAOSCoche : ICrud<BE.Coche>
    {
        private DAOSCoche() { }
        private static DAOs.DAOSCoche instance;

        public static DAOs.DAOSCoche GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.DAOSCoche();
            }
            return instance;
        }

        public bool Crear(Coche objAgregar)
        {
            throw new NotImplementedException();
        }

        public List<Coche> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);


            return Mappers.MAPPERSCoche.GetInstance().Map(table);
        }

        public List<Coche> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Coche objActualizar)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Coche objEliminar)
        {
            throw new NotImplementedException();
        }

        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Coche]";



        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;



















    }
}
