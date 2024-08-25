using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.DAOs;
using System.Net.NetworkInformation;

namespace BLL
{
    public class BLL_ABM_Usuario : BE.ICrud<BE.Usuario>
    {
        DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
        DAL.DALPatente DALPatente = new DAL.DALPatente();
        DAL.DALSeguridad DALSeguridad = new DAL.DALSeguridad();
        BLL.BLLSeguridad BLLSeguridad = new BLL.BLLSeguridad();

        #region ABM-Listar-Buscar Empelado
        public bool Modificar(Usuario objActualizar)
        {
            return DALUsuario.Modificar(objActualizar);
        }

        public bool Crear(Usuario objAgregar)
        {
            return DALUsuario.Crear(objAgregar);
        }

        public bool Eliminar(Usuario objEliminar)
        {
            return DALUsuario.Eliminar(objEliminar);
        }

        public List<Usuario> Listar()
        {
            return DALUsuario.Listar();
        }

        public List<Usuario> Buscar(int ID_Usuario)
        {
            return DALUsuario.Buscar(ID_Usuario);
        }

        public List<Usuario> Buscar(string Nick)
        {
            return DALUsuario.Buscar(Nick);
        }
        #endregion

        public BE.Usuario BuscarNick(string nick)
        {

            return DALUsuario.BuscarNick(nick);
        }

        public List<BE.Usuario> BuscarContraseña(string contraseña)
        {

            return DALUsuario.BuscarContraseña(contraseña);

        }

        public int SumarIntento(BE.Usuario usuariolog)
        {
            return DALUsuario.SumarIntento(usuariolog);
        }

        public bool BloquearUsuario(int ID_Usuario)
        {
            return DALUsuario.BloquearUsuario(ID_Usuario);
        }
        
        public bool DesbloquearUsuario(int ID_Usuario)
        {
            return DALUsuario.DesbloquearUsuario(ID_Usuario);
        }
        
        public bool ContadorIngresos0(BE.Usuario usuariolog)
        {
            return DALUsuario.ContadorIngresos0(usuariolog);
        }

        public List<BE.Familia> AsignarFamilia(int id_Usuario,int id_Familia)
        {
            return DALUsuario.AsignarFamilia(id_Usuario, id_Familia);
        }

        public List<BE.Familia> QuitarFamilia(int id_Usuario, int id_Familia)
        {
            return DALUsuario.QuitarFamilia(id_Usuario, id_Familia);
        }

        public bool CambiarContraseña(int idUsuario, string nuevaContraseña)
        {
            return DALUsuario.CambiarContraseña(idUsuario, nuevaContraseña);
        }

        public List<BE.Usuario> ValidarNick(string Nick)
        {
            return DALUsuario.ValidarNick(Nick);
        }
        public List<BE.Usuario> ValidarDNI(string DNI)
        {
            return DALUsuario.ValidarDNI(DNI);
        }
        public List<BE.Usuario> ValidarMail(string Mail)
        {
            return DALUsuario.ValidarMail(Mail);
        }

        public Iterator<Patente> ObtenerPatentesPorUsuario(string usuarioId)
        {
            return DALPatente.ObtenerPatentesPorUsuario(usuarioId);
        }

        public List<Traduccion> ListarTraduccionesXIdioma(int idIdioma)
        {
            return DALUsuario.ListarTraduccionesXIdioma(idIdioma);
        }

    }
}
