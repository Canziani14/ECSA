using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSBitacora
    {
        private MAPPERSBitacora() { }
        private static MAPPERSBitacora instance;

        public static MAPPERSBitacora GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSBitacora();
            }
            return instance;
        }
        public List<BE.Bitacora> Map(DataTable table)
        {
            List<BE.Bitacora> bitacoras = new List<BE.Bitacora>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                bitacoras.Add(new BE.Bitacora()
                {
                    ID_Bitacora = item.Field<int>("ID_Bitacora"),
                    Descripcion= DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Descripcion")),
                    Fecha = item.Field<DateTime>("Fecha"),
                    Criticidad = item.Field<int>("Criticidad"),
                    ID_Usuario = item.Field<int>("ID_Usuario"),
                    NickUsuarioLogin= item.Field<string>("NickUsuarioLogin")
                });
            }
            return bitacoras;
        }
    }
}
