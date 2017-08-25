using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface IRecursoTipoHoraBL
    {
        List<BE.Adapters.RecursoTipoHora> Listar(int idrecursotipo);
        bool Actualizar(List<RecursoTipoHora> lista);
    }
}
