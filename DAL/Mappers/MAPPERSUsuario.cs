using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class MAPPERSUsuario
    {
        private MAPPERSUsuario() { }
        private static MAPPERSUsuario instance;

        public static MAPPERSUsuario GetInstance()
        {
            if (instance == null)
            {
                instance = new MAPPERSUsuario();
            }
            return instance;
        }
        public List<BE.Usuario> Map(DataTable table)
        {
            List<BE.Usuario> usuario = new List<BE.Usuario>();
            DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();

            foreach (DataRow item in table.Rows)
            {
                usuario.Add(new BE.Usuario()
                {
                    ID_Usuario = item.Field<int>("ID_Usuario"),
                    Nombre = DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Nombre")),
                    Apellido = DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Apellido")),
                    DNI = DALSeguridad.DesencriptarCamposReversible(item.Field<string>("DNI")),
                    Nick = DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Nick")),
                    Mail = DALSeguridad.DesencriptarCamposReversible(item.Field<string>("Mail")),
                    Contraseña = item.Field<string>("Contraseña"),
                    Estado = item.IsNull("Estado") ? false : item.Field<bool>("Estado"),
                    Eliminado = item.IsNull("Eliminado") ? false : item.Field<bool>("Eliminado")

                });
            }
            return usuario;
        }

    }
}
