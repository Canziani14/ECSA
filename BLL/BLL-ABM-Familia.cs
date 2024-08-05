using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ABM_Familia : BE.ICrud<BE.Familia>
    {
        DAL.DALFamilia DALFamilia = new DAL.DALFamilia();
        public List<Familia> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Familia objAgregar)
        {
            return DALFamilia.Crear(objAgregar);
        }

        public bool Eliminar(Familia objEliminar)
        {
            return DALFamilia.Eliminar(objEliminar);
        }

        public List<Familia> Listar()
        {
            return DALFamilia.Listar();
        }

        public List<Familia> ListarActuales(int id_Familia)
        {
            return DALFamilia.ListarActuales(id_Familia);
        }

        public List<Familia> ListarSinAsignar(int id_Familia)
        {
            return DALFamilia.ListarSinAsignar(id_Familia);
        }

        public bool Modificar(Familia objActualizar)
        {
            return DALFamilia.Modificar(objActualizar);
        }
        public List<Patente> ListarSinAsignarXFamilia(int id_familia, int id_patente)
        {
            return DALFamilia.ListarSinAsignarXFamilia(id_familia, id_patente);
        }
        public List<Patente> ListarActualesXFamilia(int id_familia, int id_patente)
        {
            return DALFamilia.ListarActualesXFamilia(id_familia, id_patente);
        }


        public bool AsignarXFamilia(int id_Usuario, int id_Patente)
        {
            return DALFamilia.AsignarXFamilia(id_Usuario, id_Patente);
        }
        public bool QuitarXFamilia(int id_familia, int id_Patente)
        {
            return DALFamilia.QuitarXFamilia(id_familia, id_Patente);
        }
    }
}
