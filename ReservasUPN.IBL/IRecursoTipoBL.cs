using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface IRecursoTipoBL
    {
        List<RecursoTipo> Listar(int idSede);
        bool Actualizar(RecursoTipo obj);
        bool Grabar(RecursoTipo obj);
        List<BE.Modelos.RecursoTipo> ListarActivos(int idSede);
        List<BE.Modelos.RecursoTipo> ListarTodos(string codSede);
        List<BE.Modelos.RecursoTipo> ListarTodos(int idSede);
        List<BE.Modelos.RecursoTipo> Listar(string codSede);
        RecursoTipo Buscar(int id);
    }
}
