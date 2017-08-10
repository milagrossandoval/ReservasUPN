using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.IDAO
{
    public interface IUsuarioDAO
    {
        PA_SELECT_ALUMNOS_REGULARES_X_CODIGO_Result BuscarAlumno(string codigo);
        PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO_Result BuscarEgresado(string codigo);
        PA_SELECT_DOCENTES_X_CODIGO_Result BuscarDocente(string codigo);
        PA_SELECT_USUARIOS_X_CODIGO_Result BuscarUsuario(string codigo);
    }
}
