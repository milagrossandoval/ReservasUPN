﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE;

namespace ReservasUPN.IBL
{
    public interface ITipoRecursoBL
    {
        List<PA_GET_TIPO_RECURSOS_Result> listar(int sede);
    }
}