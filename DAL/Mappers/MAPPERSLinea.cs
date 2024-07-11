using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSLinea
    {
        private MAPPERSLinea() { }
        private static MAPPERSLinea instance;

        public static MAPPERSLinea GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSLinea();
            }
            return instance;
        }
        public List<BE.Linea> Map(DataTable table)
        {
            List<BE.Linea> Lineas = new List<BE.Linea>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                Lineas.Add(new BE.Linea()
                {
                    ID_Linea = item.Field<int>("ID_Linea"),
                    NumeroDeLinea =DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Nombre_Linea")),

                });
            }
            return Lineas;
        }


    }
}
