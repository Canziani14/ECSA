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
        public List<BE.Idioma> Map(DataTable table)
        {
            List<BE.Idioma> idiomas = new List<BE.Idioma>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                idiomas.Add(new BE.Idioma()
                {
                    ID_Idioma = item.Field<int>("ID_Idioma"),
                    Descripcion = item.Field<string>("Descripcion"),

                });
            }
            return idiomas;
        }
    }
}
