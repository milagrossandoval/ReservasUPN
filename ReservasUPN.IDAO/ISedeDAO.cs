using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface ISedeDAO
    {
        Sede Buscar(string codigo);
    }
}
