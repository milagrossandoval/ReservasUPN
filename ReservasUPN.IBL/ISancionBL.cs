using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IBL
{
    public interface ISancionBL
    {
        bool Grabar(BE.Modelos.Sancion obj);
        bool Actualizar(BE.Modelos.Sancion obj);
        List<BE.Adapters.Sancion> Listar(string sede, bool inactivos);
        bool Eliminar(int id);
        //List<BE.Modelos.SancionDetalle> ListarDetalle(int idsancion);
        //List<BE.Modelos.RecursoTipo> ListarDetalleRecursoTipo(int idsancion);
        BE.Modelos.Sancion Buscar(string usuario, DateTime fecha, int idtiporecurso);
        List<BE.Modelos.RecursoTipo> BuscarDetalle(int id);
    }
}
