using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface IHorarioBL
    {
        List<BE.Adapters.Horario> Buscar(int idtiporecurso, int idrecurso, bool defecto);
    }
}
