using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface IRecursoHorarioBL
    {
        bool Grabar(List<BE.Modelos.RecursoHorario> lista);
        List<BE.Modelos.RecursoHorario> Buscar(int recursoid);
    }
}
