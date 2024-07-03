using BE;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.DAOs.DAOSPasaron;
using DAL.DAOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DAL
{
    public class DALSeguridad
    {

        public int CalcularDVV(string tabla)
        {
           return DAOSSeguridad.GetInstance().CalcularDVV(tabla);
        }

        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            return DAOSSeguridad.GetInstance().InsertarDVH(DVH, cod, t, codtabla);
        }

        public int VerificarDigitosVerificadores(string tabla)
        {
            return DAOSSeguridad.GetInstance().VerificarDigitosVerificadores(tabla);
        }




    }
}