using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Adapters;

namespace ReservasUPN.IBL
{
    public interface IUsuarioBL
    {
        Usuario Buscar(string codigo);
    }
}
