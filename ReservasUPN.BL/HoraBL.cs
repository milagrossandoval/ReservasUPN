using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class HoraBL : IHoraBL
    {

        IHoraDAO horaDAO = HoraDAO.Instance;
        
        public List<BE.Modelos.Hora> Listar(string tipohora)
        {
            return horaDAO.Listar(tipohora);
        }
    }
}
