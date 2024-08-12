using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFamilia : BE.ICrud<BE.Familia>

    {
        public List<Familia> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Familia objAgregar)
        {
            return DAOs.DAOSFamilia.GetInstance().Agregar(objAgregar.Descripcion );
        }

        public bool Eliminar(Familia objEliminar)
        {
            return DAOs.DAOSFamilia.GetInstance().Eliminar(objEliminar.ID_Familia);
        }

        public List<Familia> Listar()
        {
            return DAOs.DAOSFamilia.GetInstance().Listar();
        }

        public List<Familia> ListarActuales(int id_Familia)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarActuales(id_Familia);
        }

        public List<Familia> ListarSinAsignar(int id_Familia)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarSinAsignar(id_Familia);
        }

        public bool Modificar(Familia objActualizar)
        {
            return DAOs.DAOSFamilia.GetInstance().Modificar(objActualizar.Descripcion, objActualizar.ID_Familia);
        }

        public List<Patente> ListarSinAsignarXFamilia(int id_familia, int id_patente)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarSinAsignarXFamilia(id_familia, id_patente);
        }
        public List<Patente> ListarActualesXFamilia(int id_familia, int id_patente)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarActualesXFamilia(id_familia, id_patente);
        }

        public bool AsignarXFamilia(int id_Usuario, int id_Patente)
        {
            return DAOs.DAOSFamilia.GetInstance().AsignarXFamilia(id_Usuario, id_Patente);
        }
        public bool QuitarXFamilia(int id_familia, int id_Patente)
        {
            return DAOs.DAOSFamilia.GetInstance().QuitarXFamilia(id_familia, id_Patente);
        }


        public List<Familia> ListarFamiliasActualesXUsuario(int ID_Usuario)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarFamiliasActualesXUsuario(ID_Usuario);
        }

        public List<Familia> ListarFamiliasSinAsignarXUsuario(int ID_Usuario)
        {
            return DAOs.DAOSFamilia.GetInstance().ListarFamiliasSinAsignarXUsuario(ID_Usuario);
        }

        public List<Familia> ValidarNombreFamilia(string nombre)
        {
            return DAOs.DAOSFamilia.GetInstance().ValidarNombreFamilia(nombre);
        }


    }
}
    