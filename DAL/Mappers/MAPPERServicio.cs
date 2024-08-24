using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERServicio
    {
        private MAPPERServicio() { }
        private static MAPPERServicio instance;

        public static MAPPERServicio GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERServicio();
            }
            return instance;
        }
        public List<BE.Servicio> Map(DataTable table)
        {
            List<BE.Servicio> servicios = new List<BE.Servicio>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                servicios.Add(new BE.Servicio()
                {
                    ID_Servicio = item.Field<int>("ID_Servicio"),
                    HorarioSalida=item.Field<DateTime>("Hora_Cabecera_Principal"),
                    HorarioLlegada = item.Field<DateTime>("Hora_Cabecera_Retorno"),
                    LegajoEmpleado =item.Field<int>("Legajo"),
                    Coche = item.Field<int>("Interno"),
                   // NombreEmpleado = item.Field<string>("Nombre"),
                    //ApellidoEmpleado =item.Field<string>("Apellido"),
                   
                   
                }); ;
            }
            return servicios;
        }
    }
}
