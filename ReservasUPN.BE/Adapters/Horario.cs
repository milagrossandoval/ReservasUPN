using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.BE.Adapters
{
    public class Horario : BE.Modelos.RecursoHorario
    {
        public int Id { get; set; }
        public string DesHora { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
    }
}
