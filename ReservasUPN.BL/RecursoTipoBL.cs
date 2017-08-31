using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class RecursoTipoBL : IRecursoTipoBL
    {
        private IRecursoTipoDAO recursoTipoDAO = RecursoTipoDAO.Instance;

        public bool Grabar(BE.Modelos.RecursoTipo obj)
        {
            return recursoTipoDAO.Grabar(obj);
        }

        public bool Actualizar(BE.Modelos.RecursoTipo obj)
        {
            return recursoTipoDAO.Actualizar(obj);
        }

        public List<BE.Modelos.RecursoTipo> Listar(int idSede)
        {
            return recursoTipoDAO.Listar(idSede);
        }
        
        public List<BE.Modelos.RecursoTipo> ListarActivos(int idSede)
        {
            return recursoTipoDAO.ListarActivos(idSede);
        }

        public List<BE.Modelos.RecursoTipo> ListarTodos(int idSede)
        {
            List<BE.Modelos.RecursoTipo> rpta = ListarActivos(idSede);
            rpta.Add(new BE.Modelos.RecursoTipo
            {
                id = Convert.ToInt16(BE.Enumeraciones.TipoRecurso.AULA),
                descripcion = BE.Adapters.Recurso.TIPO_AULA,
                sede = idSede,
                tipoHora = BE.Adapters.Recurso.TIPO_HORA_AULA,
                estado = true
            });
            return rpta;
        }

        public List<BE.Modelos.RecursoTipo> ListarTodos(string codSede)
        {
            int idSede = new SedeBL().Buscar(codSede).id;
            return ListarTodos(idSede);
        }

    }
}
