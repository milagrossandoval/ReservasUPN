﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;
using System.Data.Entity;

namespace ReservasUPN.BE.Adapters
{
    public class Recurso : BE.Modelos.Recurso
    {
        public string NombreTipoRecurso { get; set; }
    }
}
