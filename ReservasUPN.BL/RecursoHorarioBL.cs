using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class RecursoHorarioBL : IRecursoHorarioBL
    {

        IRecursoHorarioDAO recursohorarioDAO = RecursoHorarioDAO.Instance;
        
        public bool Grabar(List<BE.Modelos.RecursoHorario> lista)
        {
            return recursohorarioDAO.Grabar(lista);
        }

        public List<BE.Modelos.RecursoHorario> Buscar(int recursoid)
        {
            return recursohorarioDAO.Buscar(recursoid);
        }
    }
}
