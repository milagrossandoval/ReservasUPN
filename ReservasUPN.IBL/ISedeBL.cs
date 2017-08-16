using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface ISedeBL
    {
        Sede Buscar(int id);
        Sede Buscar(string nombre);
        List<Sede> ListarxUsuario(BE.Adapters.Usuario usuario);
    }
}
