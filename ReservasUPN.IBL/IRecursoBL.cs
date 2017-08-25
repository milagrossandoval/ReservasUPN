using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;
using ReservasUPN.BE.Adapters;

namespace ReservasUPN.IBL
{
    public interface IRecursoBL
    {
        bool Grabar(ReservasUPN.BE.Modelos.Recurso obj);
        bool Actualizar(ReservasUPN.BE.Modelos.Recurso obj);
        List<BE.Adapters.Recurso> Listar(int idSede);        
    }
}
