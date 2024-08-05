using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSUsuario_Familia
    {
        private MAPPERSUsuario_Familia() { }
        private static MAPPERSUsuario_Familia instance;

        public static MAPPERSUsuario_Familia GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSUsuario_Familia();
            }
            return instance;
        }
        public List<BE.Familia> Map(DataTable table)
        {
            List<BE.Familia> familias = new List<BE.Familia>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();
            

            foreach (DataRow item in table.Rows)
            {

                familias.Add(new BE.Familia()
                {
                    ID_Familia = item.Table.Columns.Contains("ID_Familia") && !item.IsNull("ID_Familia") ? item.Field<int>("ID_Familia") : 0,
                    Descripcion = item.Table.Columns.Contains("Descripcion") && !item.IsNull("Descripcion") ? item.Field<string>("Descripcion") : string.Empty,
                    ID_Patente = item.Table.Columns.Contains("ID_Patente") && !item.IsNull("ID_Patente") ? item.Field<int>("ID_Patente") : 0
                });

            }
            return familias;
        }
    }
}
