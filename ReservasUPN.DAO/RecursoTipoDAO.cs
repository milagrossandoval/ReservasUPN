using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class RecursoTipoDAO : IRecursoTipoDAO
    {
        #region Singleton
        private RecursoTipoDAO() { }

        private static readonly RecursoTipoDAO _instance = new RecursoTipoDAO();
        public static RecursoTipoDAO Instance
        { get { return _instance; } }
        #endregion

        public List<RecursoTipo> Listar(int idSede)
        {
            List<RecursoTipo> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.RecursoTipo
                        where x.sede == idSede
                        select x).ToList();
            }
            return rpta;
        }

        public bool Eliminar(int id)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var recursoTipo = (from x in reposit.RecursoTipo
                                   where x.id == id
                                   select x).First();
                recursoTipo.estado = false;
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Actualizar(RecursoTipo obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var recursoTipo = (from x in reposit.RecursoTipo
                                   where x.id == obj.id
                                   select x).First();
                recursoTipo.sede = obj.sede;
                recursoTipo.descripcion = obj.descripcion;
                recursoTipo.tipoHora = obj.tipoHora;
                recursoTipo.estado = obj.estado;
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Grabar(RecursoTipo obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToRecursoTipo(obj);
                return reposit.SaveChanges() == 1;
            }
        }

    }
}
