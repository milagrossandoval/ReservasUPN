using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IHoraTipoDAO
    {
        List<BE.Modelos.HoraTipo> Listar();
    }
}
