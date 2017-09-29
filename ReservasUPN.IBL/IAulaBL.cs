using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface IAulaBL
    {
        List<BE.Modelos.Aula> Listar(int sede);
        List<BE.Modelos.PA_SELECT_HORARIO_X_AULA_Result> BuscarHorario(string aula);
    }
}
