using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface ICrud<T>
    {
        bool Crear(T objAgregar);
        List<T> Listar();
        List<T> Listar(int id);
        bool Actualizar(T objActualizar);
        bool Eliminar(T objEliminar);
    }
}
