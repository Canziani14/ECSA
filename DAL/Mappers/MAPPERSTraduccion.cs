using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSTraduccion
    {
        private MAPPERSTraduccion() { }
        private static MAPPERSTraduccion instance;

        public static MAPPERSTraduccion GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSTraduccion();
            }
            return instance;
        }
        public List<BE.Traduccion> Map(DataTable table)
        {
            List<BE.Traduccion> traducciones = new List<BE.Traduccion>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                traducciones.Add(new BE.Traduccion()
                {
                    ID_Idioma = item.Field<int>("ID_Idioma"),
                    Descripcion = item.Field<string>("Descripcion"),
                    ID_Traduccion= item.Field<int>("ID_Traduccion"),

                });
            }
            return traducciones;
        }

    }
}

