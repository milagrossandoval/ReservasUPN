using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;
using System.Data.Objects;

namespace ReservasUPN.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        #region Singleton
        private UsuarioDAO() { }

        private static readonly UsuarioDAO _instance = new UsuarioDAO();
        public static UsuarioDAO Instance
        { get { return _instance; } }
        #endregion

        public BE.Adapters.Usuario BuscarAlumno(string codigo)
        {
            BE.Adapters.Usuario rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                int idTipoUsuario = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.ALUMNO);
                List<BE.Adapters.Usuario> resultado = (from x in reposit.AlumnosRegulares
                                                       where x.codigo == codigo
                                                       select new BE.Adapters.Usuario
                                                       {
                                                           Codigo = x.codigo,
                                                           NombreCompleto = x.nombreCompleto,
                                                           IdSede = x.sede,
                                                           NombreSede = x.sedeNombre,
                                                           IdTipoUsuario = idTipoUsuario,
                                                           TipoUsuario = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_ALUMNO }
                                                       }
                                                      ).ToList();

                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;
        }


        public BE.Adapters.Usuario BuscarEgresado(string codigo)
        {
            BE.Adapters.Usuario rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                int idTipoUsuario = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.EGRESADO);
                List<BE.Adapters.Usuario> resultado = (from x in reposit.AlumnosEgresados
                                                       where x.codigo == codigo
                                                       select new BE.Adapters.Usuario
                                                       {
                                                           Codigo = x.codigo,
                                                           NombreCompleto = x.nombreCompleto,
                                                           IdSede = x.sede,
                                                           NombreSede = x.sedeNombre,
                                                           IdTipoUsuario = idTipoUsuario,
                                                           TipoUsuario = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_EGRESADO }
                                                       }
                                                      ).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;    
        }

        public BE.Adapters.Usuario BuscarDocente(string codigo)
        {
            BE.Adapters.Usuario rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                int idTipoUsuario = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.DOCENTE);
                List<BE.Adapters.Usuario> resultado = (from x in reposit.PA_SELECT_DOCENTES_X_CODIGO(codigo)
                                                      select new BE.Adapters.Usuario{
                                                          Codigo = x.Codigo,
                                                          NombreCompleto = x.NombreCompleto,
                                                          IdSede = x.sede,
                                                          NombreSede = x.sedeNombre,
                                                          IdTipoUsuario = idTipoUsuario,
                                                          TipoUsuario = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_DOCENTE }
                                                      }).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;    
        }

        public BE.Adapters.Usuario BuscarUsuario(string codigo)
        {
            BE.Adapters.Usuario rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                List<BE.Modelos.Usuario> usuarios = new List<Usuario>();
                usuarios.Add(Buscar(codigo));

                List<BE.Adapters.Usuario> resultado = (from x in usuarios
                                                         join y in reposit.UsuarioTipo on x.tipoUsuario equals y.id
                                                         where y.estado == true
                                                         select new BE.Adapters.Usuario {
                                                             Codigo = x.codigo,
                                                             NombreCompleto = x.nombreCompleto,
                                                             IdTipoUsuario = x.tipoUsuario,
                                                             TipoUsuario = new UsuarioTipo { id = x.tipoUsuario, nombre = y.nombre }
                                                         }).ToList();

                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                    Sede sedeUsuario = SedeDAO.Instance.Buscar(usuarios.First().codigoSede);
                    rpta.IdSede = sedeUsuario.id;
                    rpta.NombreSede = sedeUsuario.nombre;
                }
            }
            return rpta;
        }

        public BE.Modelos.Usuario Buscar(string codigo)
        {
            BE.Modelos.Usuario rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                List<BE.Modelos.Usuario> resultado = (from x in reposit.Usuario
                                                       where x.codigo == codigo && x.estado == true
                                                       select x).ToList();
                if (resultado.Count() == 1) {
                    rpta = resultado.First();
                }
            }
            return rpta;

        }

    }
}
