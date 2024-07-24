using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALIdioma
    {
        public List<BE.Idioma> Listar()
        {
            return DAOs.DAOSIdioma.GetInstance().Listar();
        }
    }
}
