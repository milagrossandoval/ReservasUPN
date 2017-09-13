using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.IDAO
{
    public interface IRecursoTipoHoraDAO
    {
        List<BE.Modelos.RecursoTipoHora> Listar(int idrecursotipo);
        bool Actualizar(List<BE.Modelos.RecursoTipoHora> lista);
        BE.Modelos.RecursoTipoHora Buscar(int idrecursotipo, int idtipousuario);
    }
}
