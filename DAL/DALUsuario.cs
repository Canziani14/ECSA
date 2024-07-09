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
            return DAOs.DAOSUsuario.GetInstance().Agregar(objAgregar.Nombre, objAgregar.Apellido, objAgregar.Nick, objAgregar.Mail, objAgregar.DNI, objAgregar.Contraseña);
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

        public bool BloquearUsuario(int ID_Usuario)
        {
            return DAOSUsuario.GetInstance().BloquearUsuario(ID_Usuario);
        }

        
        public bool DesbloquearUsuario(int ID_Usuario)
        {
            return DAOSUsuario.GetInstance().DesbloquearUsuario(ID_Usuario);
        }

    }
}
