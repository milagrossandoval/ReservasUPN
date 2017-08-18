﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoTipoDAO
    {
        bool Grabar(BE.Modelos.RecursoTipo obj);
        bool Actualizar(BE.Modelos.RecursoTipo obj);
        List<BE.Modelos.RecursoTipo> Listar(int idSede);
    }
}
