using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.BE.Adapters
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public int IdTipoUsuario { get; set; }
        public UsuarioTipo TipoUsuario { get; set; }
        public int IdSede { get; set; }
        public string NombreSede { get; set; }
        //public Sede Sede { get; set; }
        public List<Sede> LstSedes { get; set; }

        public static readonly string TIPO_ALUMNO = "Alumno";
        public static readonly string TIPO_EGRESADO = "Egresado";
        public static readonly string TIPO_DOCENTE = "Docente";
        public static readonly int INIT_ID = 100;

    }
}
