using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface IUsuarioDAO
    {
        BE.Adapters.Usuario BuscarAlumno(string codigo);
        BE.Adapters.Usuario BuscarEgresado(string codigo);
        BE.Adapters.Usuario BuscarDocente(string codigo);
        BE.Adapters.Usuario BuscarUsuario(string codigo);
        BE.Modelos.Usuario Buscar(string codigo);
    }
}
