using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Adapters;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface IUsuarioBL
    {
         BE.Adapters.Usuario Buscar(string codigo);
         BE.Modelos.Usuario BuscarUsuario(string codigo);
    }
}
