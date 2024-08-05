using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSFamilia_Patente
    {
        private MAPPERSFamilia_Patente() { }
        private static MAPPERSFamilia_Patente instance;

        public static MAPPERSFamilia_Patente GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSFamilia_Patente();
            }
            return instance;
        }
        public List<BE.Patente> Map(DataTable table)
        {
            List<BE.Patente> patentes = new List<BE.Patente>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                patentes.Add(new BE.Patente()
                {
                    //ID_Familia = item.Field<int>("ID_Familia"),
                    ID_Patente = item.Field<int>("ID_Patente"),
                    Descripcion = item.Field<string>("Descripcion"),

                });
            }
            return patentes;
        }
    }
}
