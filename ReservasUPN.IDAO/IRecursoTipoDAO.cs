using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface IRecursoTipoDAO
    {
        bool Grabar(BE.Modelos.RecursoTipo obj);
        bool Actualizar(BE.Modelos.RecursoTipo obj);
        List<BE.Modelos.RecursoTipo> Listar(int idSede);
        List<BE.Modelos.RecursoTipo> ListarActivos(int idSede);
        RecursoTipo Buscar(int id);
    }
}
