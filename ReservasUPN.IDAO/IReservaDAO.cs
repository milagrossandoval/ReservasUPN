using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface IReservaDAO
    {
        int HorasUtilizadas(string usuario, int idtiporecurso, DateTime fecha);
        bool Grabar(List<BE.Modelos.Reserva> reservas);
        bool Cancelar(int id);
        List<BE.Adapters.Reserva> Listar(string usuario, int sede);
        List<BE.Modelos.Reserva> Listar(int recurso, DateTime inicio, DateTime fin);
        BE.Modelos.Reserva Buscar(int recurso, DateTime fecha, int hora);
        List<BE.Adapters.Reserva> ListarActivas(string usuario, int tiporecurso, DateTime fechaInicio, DateTime fechaFin);
    }
}
