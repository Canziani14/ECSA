using BE;
using DAL;
using DAL.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSeguridad
    {
        DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();
        BE.Empleado BEEmpleado = new BE.Empleado();


        public int CalcularDVV(string tabla)
        {
           return DALSeguridad.CalcularDVV(tabla);
        }

        public int InsertarDVH(Int64 DVH, int cod, string t, string codtabla)
        {
            return DALSeguridad.InsertarDVH(DVH, cod, t, codtabla);
        }

        public int VerificarDigitosVerificadores(string tabla)
        {
            return DALSeguridad.VerificarDigitosVerificadores(tabla);
        }


        /*
                public bool BuscarEnBitacora()
                {
                    throw new NotImplementedException();
                }

                public bool RegistrarEnBitacora()
                {
                    throw new NotImplementedException();
                }

                public bool DescargarBitacora()
                {
                    throw new NotImplementedException();
                }

                public bool DesencriptarCamposReversible()
                {
                    throw new NotImplementedException();
                }

                public bool EncriptarCamposIrreversible()
                {
                    throw new NotImplementedException();
                }

                public bool EncriptarCamposReversible()
                {
                    throw new NotImplementedException();
                }

                public bool GenerarContraseñaAleatoria()
                {
                    throw new NotImplementedException();
                }

                public bool GenerarTxtContraseña()
                {
                    throw new NotImplementedException();
                }

                public bool ValidarPatentes()
                {
                    throw new NotImplementedException();
                }
        */
    }
}
