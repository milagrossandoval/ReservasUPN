using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.BE.Adapters
{
    public class Reserva:BE.Modelos.Reserva
    {
        public string NombreRecurso { get; set; }
        public bool Continuar { get; set; }
        public string Foto { get; set; }
    }
}
