using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDAL
    {
        public void RealizarBKP(string path)
        {
            DAOs.DAOSDal.GetInstance().RealizarBKP(path);
        }

        public void RealizarRestore(string path)
        {
            DAOs.DAOSDal.GetInstance().RealizarRestore(path);
        }
    }
}
