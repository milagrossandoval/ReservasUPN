using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class UsuarioTipoDAO : IUsuarioTipoDAO
    {

        #region Singleton
        private UsuarioTipoDAO() { }

        private static readonly UsuarioTipoDAO _instance = new UsuarioTipoDAO();
        public static UsuarioTipoDAO Instance
        { get { return _instance; } }
        #endregion

        public List<UsuarioTipo> Listar()
        {
            List<UsuarioTipo> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.UsuarioTipo
                        where x.id != 100
                        select x).ToList();
            }
            return rpta;
        }

        public bool Eliminar(int id)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var usuarioTipo = (from x in reposit.UsuarioTipo
                              where x.id == id
                              select x).First();
                usuarioTipo.estado = false;
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Actualizar(UsuarioTipo obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var usuarioTipo = (from x in reposit.UsuarioTipo
                                   where x.id == obj.id
                                   select x).First();
                usuarioTipo.nombre = obj.nombre;
                usuarioTipo.estado = obj.estado;
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Grabar(UsuarioTipo obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToUsuarioTipo(obj);
                return reposit.SaveChanges() == 1;
            }
        }
    }
}
