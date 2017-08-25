using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface IUsuarioTipoBL
    {
        List<UsuarioTipo> Listar();
        bool Eliminar(int id);
        bool Actualizar(UsuarioTipo obj);
        bool Grabar(UsuarioTipo obj);
        List<UsuarioTipo> ListarPropios();
        List<UsuarioTipo> ListarTodos();
    }
}
