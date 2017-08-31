using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface ISancionDetalleDAO
    {
        bool Grabar(List<BE.Modelos.SancionDetalle> detalle);
        List<SancionDetalle> Listar(int idsancion);
        bool Eliminar(int idsancion);
        List<BE.Modelos.RecursoTipo> ListarRecursoTipo(int idsancion);
    }
}
