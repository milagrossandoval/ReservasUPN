using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IAulaDAO
    {
        List<BE.Modelos.Aula> Listar(int sede);
        List<BE.Modelos.PA_SELECT_HORARIO_X_AULA_Result> BuscarHoraio(string aula);
    }
}
