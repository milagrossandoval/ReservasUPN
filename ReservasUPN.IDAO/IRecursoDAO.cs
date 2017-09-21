using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoDAO
    {
        int Grabar(BE.Modelos.Recurso obj);
        bool Actualizar(BE.Modelos.Recurso obj);
        List<BE.Adapters.Recurso> ListarxSede(int idSede);
        List<BE.Adapters.Recurso> Listar(int idtiporecurso);
        BE.Adapters.Recurso Buscar(int idrecurso);
    }
}
