using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoHorarioDAO
    {
        bool Grabar(List<BE.Modelos.RecursoHorario> lista);
        List<BE.Modelos.RecursoHorario> Buscar(int recursoid);
    }
}
