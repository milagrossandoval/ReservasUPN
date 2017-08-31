using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface ISancionDAO
    {
        int Grabar(BE.Modelos.Sancion obj);
        bool Actualizar(BE.Modelos.Sancion obj);
        List<BE.Adapters.Sancion> Listar(string sede);
        List<BE.Adapters.Sancion> ListarActivos(string sede);
        bool Eliminar(int id);        
    }
}
