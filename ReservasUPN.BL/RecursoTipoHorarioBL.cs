using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class RecursoTipoHorarioBL : IRecursoTipoHorarioBL
    {
        IRecursoTipoHorarioDAO recursotipohorarioDAO = RecursoTipoHorarioDAO.Instance;
        
        public bool Grabar(List<BE.Modelos.RecursoTipoHorario> lista)
        {
            return recursotipohorarioDAO.Grabar(lista);
        }

        public List<BE.Modelos.RecursoTipoHorario> Buscar(int tiporecursoid)
        {
            return recursotipohorarioDAO.Buscar(tiporecursoid);
        }
    }
}
