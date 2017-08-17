using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;
using System.Data.Entity;

namespace ReservasUPN.BE.Adapters
{
    public class Usuario : BE.Modelos.Usuario
    {
        public string NombreCompleto { get; set; }
        public int IdSede { get; set; }        
        public string NombreSede { get; set; }
        public UsuarioTipo Tipo { get; set; }
        //public Sede Sede { get; set; }
        public List<Sede> LstSedes { get; set; }

        public static readonly string TIPO_ALUMNO = "Alumno";
        public static readonly string TIPO_EGRESADO = "Egresado";
        public static readonly string TIPO_DOCENTE = "Docente";
        public static readonly int INIT_ID = 100;

    }
}
