using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSCoche
    {
        private MAPPERSCoche() { }
        private static MAPPERSCoche instance;

        public static MAPPERSCoche GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSCoche();
            }
            return instance;
        }
        public List<BE.Coche> Map(DataTable table)
        {
            List<BE.Coche> coches = new List<BE.Coche>();
            DAL.DALCoche DALCoche = new DAL.DALCoche();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                coches.Add(new BE.Coche()
                {
                    Interno = item.Field<int>("ID_Linea"),
                    Patente=DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Patente")),
                    DVH = item.Field<int>("DVH")


                });
            }
            return coches;
        }
    }
}
