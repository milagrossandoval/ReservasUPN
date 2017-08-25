using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface ISancionBL
    {
        bool Grabar(ReservasUPN.BE.Modelos.Sancion obj);
        bool Actualizar(ReservasUPN.BE.Modelos.Sancion obj);
        List<ReservasUPN.BE.Modelos.Sancion> Listar();        
    }
}
