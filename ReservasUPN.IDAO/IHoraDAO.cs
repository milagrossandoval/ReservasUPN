using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IHoraDAO
    {
        List<BE.Modelos.Hora> Listar(string tipohora);
    }
}
