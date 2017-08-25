using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoDAO
    {
        bool Grabar(BE.Modelos.Recurso obj);
        bool Actualizar(BE.Modelos.Recurso obj);
        List<BE.Adapters.Recurso> Listar(int idSede);
    }
}
