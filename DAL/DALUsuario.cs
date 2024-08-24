using BE;
using DAL.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUsuario:BE.ICrud<BE.Usuario>
    {
        
    
        public bool Modificar(BE.Usuario objActualizar)
        {
            return DAOs.DAOSUsuario.GetInstance().Modificar(objActualizar.Nombre, objActualizar.Apellido, objActualizar.Nick, objActualizar.Mail, objActualizar.DNI, objActualizar.ID_Usuario);
        }

        public bool Crear(BE.Usuario objAgregar)
        {
            return DAOs.DAOSUsuario.GetInstance().Agregar(objAgregar.Nombre, objAgregar.Apellido, objAgregar.Nick, objAgregar.Mail, objAgregar.DNI, objAgregar.Contraseña, objAgregar.CII);
        }

        public bool Eliminar(BE.Usuario objEliminar)
        {
            return DAOs.DAOSUsuario.GetInstance().Eliminar(objEliminar.ID_Usuario);
        }

        public List<BE.Usuario> Listar()
        {
            return DAOs.DAOSUsuario.GetInstance().Listar();
        }

        public List<BE.Usuario> Buscar(int ID_Usuario)
        {
            return DAOs.DAOSUsuario.GetInstance().Buscar(ID_Usuario);
        }

        public List<BE.Usuario> Buscar(string Nick)
        {
            return DAOs.DAOSUsuario.GetInstance().Buscar(Nick);
        }

        public BE.Usuario BuscarNick(string nick)
        {
            return DAOSUsuario.GetInstance().BuscarNick(nick);
        }

        public List<BE.Usuario> BuscarContraseña(string contraseña)
        {
            return DAOSUsuario.GetInstance().BuscarContraseña(contraseña);
        }


        public int SumarIntento(BE.Usuario usuariolog)
        {
            return DAOSUsuario.GetInstance().SumarIntento(usuariolog); 
        }
        
         public bool ContadorIngresos0(BE.Usuario usuariolog)
        {
            return DAOSUsuario.GetInstance().ContadorIngresos0(usuariolog.ID_Usuario);
        }

        public bool BloquearUsuario(int ID_Usuario)
        {
            return DAOSUsuario.GetInstance().BloquearUsuario(ID_Usuario);
        }

        
        public bool DesbloquearUsuario(int ID_Usuario)
        {
            return DAOSUsuario.GetInstance().DesbloquearUsuario(ID_Usuario);
        }


        public List<BE.Familia> AsignarFamilia(int id_Usuario, int id_Familia)
        {
            return DAOSUsuario.GetInstance().AsignarFamilia(id_Usuario, id_Familia);
        }

        public List<BE.Familia> QuitarFamilia(int id_Usuario, int id_Familia)
        {
            return DAOSUsuario.GetInstance().QuitarFamilia(id_Usuario, id_Familia);
        }

        public bool CambiarContraseña(int idUsuario, string nuevaContraseña)
        {
            return DAOSUsuario.GetInstance().CambiarContraseña(idUsuario, nuevaContraseña);
        }

        public List<BE.Usuario> ValidarNick(string Nick)
        {
            return DAOSUsuario.GetInstance().ValidarNick(Nick);
        }
        public List<BE.Usuario> ValidarDNI(string DNI)
        {
            return DAOSUsuario.GetInstance().ValidarDNI(DNI);
        }
        public List<BE.Usuario> ValidarMail(string Mail)
        {
            return DAOSUsuario.GetInstance().ValidarMail(Mail);
        }

    }
}
