using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.BE.Adapters
{
    public class Sancion : BE.Modelos.Sancion
    {
        public string NombreUsuario { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }
        //public string TipoUsuario { get; set; }
    }
}
