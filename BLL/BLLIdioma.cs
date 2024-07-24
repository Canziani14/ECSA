using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLIdioma
    {
        DAL.DALIdioma DALIdioma = new DAL.DALIdioma();
        public List<Idioma> Listar()
        {
            return DALIdioma.Listar();
        }
    }
}
