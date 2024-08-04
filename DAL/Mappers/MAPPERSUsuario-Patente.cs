using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSUsuario_Patente
    {
        private MAPPERSUsuario_Patente() { }
        private static MAPPERSUsuario_Patente instance;

        public static MAPPERSUsuario_Patente GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSUsuario_Patente();
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
                    ID_Patente = item.Field<int>("ID_Patente"),
                    //ID_Usuario = item.Field<int>("ID_Usuario"),
                    Descripcion = item.Field<string>("Descripcion"),

                });
            }
            return patentes;
        }
    }
}
