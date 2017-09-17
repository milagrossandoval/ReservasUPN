using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class ReservaBL : IReservaBL
    {

        IReservaDAO reservadao = ReservaDAO.Instance;

        public int HorasUtilizadas(string usuario, int idtiporecurso, DateTime fecha)
        {
            return reservadao.HorasUtilizadas(usuario, idtiporecurso, fecha);
        }

        public List<BE.Adapters.Reserva> ListarActivas(string usuario, int tiporecurso, DateTime fechaInicio, DateTime fechaFin)
        {
            return reservadao.ListarActivas(usuario, tiporecurso, fechaInicio, fechaFin);
        }

        public List<BE.Modelos.Reserva> Listar(int recurso, DateTime inicio, DateTime fin)
        {
            return reservadao.Listar(recurso, inicio, fin);
        }

        public bool Grabar(List<BE.Modelos.Reserva> reservas)
        {
            foreach (BE.Modelos.Reserva r in reservas)
            {
                if (reservadao.Buscar(r.recurso, r.fecha, r.hora) != null) {
                    throw new Exception("Ya se realizó una reserva en el horario seleccionado");
                }
            }
            return reservadao.Grabar(reservas);
        }

        public bool Cancelar(int id)
        {
            return reservadao.Cancelar(id);
        }


        public List<BE.Adapters.Reserva> Listar(string usuario, int sede)
        {
            return reservadao.Listar(usuario, sede);
        }
    }
}
