using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface IHoraBL
    {
        List<BE.Modelos.Hora> Listar(string tipohora);
    }
}
