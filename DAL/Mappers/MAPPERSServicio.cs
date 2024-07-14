using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSServicio
    {
        private MAPPERSServicio() { }
        private static MAPPERSServicio instance;

        public static MAPPERSServicio GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSServicio();
            }
            return instance;
        }
        public List<BE.Servicio> Map(DataTable table)
        {
            List<BE.Servicio> servicios = new List<BE.Servicio>();
            

            foreach (DataRow item in table.Rows)
            {
                servicios.Add(new BE.Servicio()
                {
                    ID_Servicio = item.Field<int>("ID_Servicio"),
                    HorarioSalida = item.Field<DateTime>("Hora_Cabecera_Principal"),
                    HorarioLlegada = item.Field<DateTime>("Hora_Cabecera_Retorno"),
                    Coche = item.Field<int>("Interno"),
                    LegajoEmpleado = item.Field<int>("Legajo"),
                    Linea = item.Field<int>("ID_Linea")

                });
            }
            return servicios;
        }
    }
}
