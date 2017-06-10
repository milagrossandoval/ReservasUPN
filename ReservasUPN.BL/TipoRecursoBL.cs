using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.BE;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class TipoRecursoBL : ITipoRecursoBL
    {
        private ITipoRecursoDAO tipoRecursoDAO = TipoRecursoDAO.Instance;

        public List<PA_GET_TIPO_RECURSOS_Result> listar(int sede) {
            return tipoRecursoDAO.listar(sede);
        }
    }
}
