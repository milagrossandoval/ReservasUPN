using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoTipoHorarioDAO
    {
        bool Grabar(List<BE.Modelos.RecursoTipoHorario> lista);
        List<BE.Modelos.RecursoTipoHorario> Buscar(int tiporecursoid);
    }
}
