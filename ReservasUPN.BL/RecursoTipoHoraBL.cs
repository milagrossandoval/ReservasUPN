using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.DAO;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.BL
{
    public class RecursoTipoHoraBL : IRecursoTipoHoraBL
    {

        IRecursoTipoHoraDAO recursotipohoradao = RecursoTipoHoraDAO.Instance;

        public List<BE.Adapters.RecursoTipoHora> Listar(int idrecursotipo)
        {
            List<BE.Adapters.RecursoTipoHora> rpta = null;
            if (idrecursotipo == 0)
                return new List<BE.Adapters.RecursoTipoHora>();

            rpta = (from x in new UsuarioTipoBL().ListarPropios()
                    join y in recursotipohoradao.Listar(idrecursotipo) on x.id equals y.usuarioTipo into ys
                    from y in ys.DefaultIfEmpty()
                    select new BE.Adapters.RecursoTipoHora { 
                        usuarioTipo = x.id, 
                        NombreTipoUsuario = x.nombre, 
                        nroHoras = (y == null ? 0 : y.nroHoras.Value), 
                        recursoTipo = idrecursotipo }).ToList();

            return rpta;
        }

        public bool Actualizar(List<RecursoTipoHora> lista)
        {
            return recursotipohoradao.Actualizar(lista);
        }
    }
}
