using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDAL
    {
        DAL.DALDAL DALDAL = new DAL.DALDAL();
        public void RealizarBKP(string path)
        {
            DALDAL.RealizarBKP(path);
        }

        public void RealizarRestore(string path)
        {
            DALDAL.RealizarRestore(path);
        }

        public bool VerificarIntegridad()
        {
            return DALDAL.VerificarIntegridad();
        }
        public void RepararIntegridad()
        {
            DALDAL.RepararIntegridad();
        }



    }
}
