using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPatente
    {
        DAL.DALPatente DALPatente = new DAL.DALPatente();
        public bool Asignar(int id_Usuario, int id_Patente)
        {
            return DALPatente.Asignar(id_Usuario,id_Patente);
        }
      

        public bool Quitar(int id_Usuario, int id_Patente)
        {
            return DALPatente.Quitar(id_Usuario,id_Patente);
        }
        

        public List<Patente> ListarActuales(int id_usuario)
        {
            return DALPatente.ListarActuales(id_usuario);
        }
        

        public List<Patente> ListarSinAsignar(int id_usuario)
        {
            return DALPatente.ListarSinAsignar(id_usuario);
        }
      


    }
}
