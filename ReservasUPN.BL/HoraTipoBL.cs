using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class HoraTipoBL : IHoraTipoBL
    {
        private IHoraTipoDAO horatipodao = HoraTipoDAO.Instance;

        public List<BE.Modelos.HoraTipo> Listar()
        {
            return horatipodao.Listar();
        }
    }
}
