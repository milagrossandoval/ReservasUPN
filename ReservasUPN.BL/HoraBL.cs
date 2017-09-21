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

        public BE.Modelos.Hora HoraActual(string tipohora)
        {
            return horaDAO.Buscar(DateTime.Now.TimeOfDay, tipohora);
        }

        public BE.Modelos.Hora HoraSiguiente(string tipohora)
        {
            return horaDAO.Buscar(DateTime.Now.AddMinutes(int.Parse(tipohora)).TimeOfDay, tipohora);
        }

    }
}
