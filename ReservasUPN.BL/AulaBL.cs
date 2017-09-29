using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class AulaBL : IAulaBL
    {

        private IAulaDAO auladao = AulaDAO.Instance;
        
        public List<BE.Modelos.Aula> Listar(int sede)
        {
            return auladao.Listar(sede);
        }

        public List<BE.Modelos.PA_SELECT_HORARIO_X_AULA_Result> BuscarHorario(string aula)
        {
            return auladao.BuscarHoraio(aula);
        }



    }
}
