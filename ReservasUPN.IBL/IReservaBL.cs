using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IBL
{
    public interface IReservaBL
    {
        int HorasUtilizadas(string usuario, int idtiporecurso, DateTime fecha);
        List<Reserva> Listar(int recurso, DateTime inicio, DateTime fin);
        bool Grabar(List<BE.Modelos.Reserva> reservas);
        bool Cancelar(int id);
        List<BE.Adapters.Reserva> ListarActivas(string usuario, int tiporecurso, DateTime fechaInicio, DateTime fechaFin);
        List<BE.Adapters.Reserva> Listar(string usuario, int sede);
    }
}
