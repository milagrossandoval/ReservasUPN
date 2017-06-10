using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE;

namespace ReservasUPN.IDAO
{
    public interface ITipoRecursoDAO
    {
        List<PA_GET_TIPO_RECURSOS_Result> listar(int sede);
    }
}
