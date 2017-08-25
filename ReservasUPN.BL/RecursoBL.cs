using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class RecursoBL : IRecursoBL
    {
        private IRecursoDAO recursoDAO = RecursoDAO.Instance;

        public bool Grabar(BE.Modelos.Recurso obj)
        {
            return recursoDAO.Grabar(obj);
        }

        public bool Actualizar(BE.Modelos.Recurso obj)
        {
            return recursoDAO.Actualizar(obj);
        }

        public List<BE.Adapters.Recurso> Listar(int idSede)
        {
            return recursoDAO.Listar(idSede);
        }
    }
}
