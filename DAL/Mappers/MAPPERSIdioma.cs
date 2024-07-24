using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSIdioma
    {
        private MAPPERSIdioma() { }
        private static MAPPERSIdioma instance;

        public static MAPPERSIdioma GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSIdioma();
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
