using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface ISancionDAO
    {
        bool Grabar(BE.Modelos.Sancion obj);
        bool Actualizar(BE.Modelos.Sancion obj);
        List<BE.Modelos.Sancion> Listar();
    }
}
