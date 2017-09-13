using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class RecursoTipoHoraDAO : IRecursoTipoHoraDAO
    {

        #region Singleton
        private RecursoTipoHoraDAO() { }

        private static readonly RecursoTipoHoraDAO _instance = new RecursoTipoHoraDAO();
        public static RecursoTipoHoraDAO Instance
        { get { return _instance; } }
        #endregion

        public List<BE.Modelos.RecursoTipoHora> Listar(int idrecursotipo)
        {
            List<BE.Modelos.RecursoTipoHora> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.RecursoTipoHora
                            where x.recursoTipo == idrecursotipo
                            select x).ToList();
            }
            return rpta;
        }

        public bool Actualizar(List<RecursoTipoHora> lista)
        {
            int i = 0;
            foreach (RecursoTipoHora obj in lista) {
                using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
                {
                    var rec = (from x in reposit.RecursoTipoHora
                               where x.usuarioTipo == obj.usuarioTipo && x.recursoTipo == obj.recursoTipo
                               select x);
                    if (rec.Count() == 0)
                    {
                        reposit.AddToRecursoTipoHora(obj);
                    }
                    else {
                        rec.First().nroHoras = obj.nroHoras;
                    }
                    i += reposit.SaveChanges();
                }
            }
            return i==lista.Count;
        }


        public RecursoTipoHora Buscar(int idrecursotipo, int idtipousuario)
        {
            BE.Modelos.RecursoTipoHora rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res = (from x in reposit.RecursoTipoHora
                           where x.recursoTipo == idrecursotipo && x.usuarioTipo == idtipousuario
                           select x);
                if (res.Count() == 1) {
                    rpta = res.First(); 
                }
            }
            return rpta;
        }
    }
}
