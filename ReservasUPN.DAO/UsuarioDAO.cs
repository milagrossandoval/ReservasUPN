using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;
using System.Data.Objects;
using System.Collections;

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
                                                           codigo = x.codigo,
                                                           NombreCompleto = x.nombreCompleto,
                                                           IdSede = x.sede,
                                                           NombreSede = x.sedeNombre,
                                                           tipoUsuario = idTipoUsuario,
                                                           Tipo = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_ALUMNO }
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
                                                           codigo = x.codigo,
                                                           NombreCompleto = x.nombreCompleto,
                                                           IdSede = x.sede,
                                                           NombreSede = x.sedeNombre,
                                                           tipoUsuario = idTipoUsuario,
                                                           Tipo = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_EGRESADO }
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
                                                       select new BE.Adapters.Usuario
                                                       {
                                                           codigo = x.Codigo,
                                                           NombreCompleto = x.NombreCompleto,
                                                           IdSede = x.sede,
                                                           NombreSede = x.sedeNombre,
                                                           tipoUsuario = idTipoUsuario,
                                                           Tipo = new UsuarioTipo { id = idTipoUsuario, nombre = BE.Adapters.Usuario.TIPO_DOCENTE }
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
            List<BE.Adapters.Usuario> resultado = new List<BE.Adapters.Usuario>();
            
            using (BD_RESERVASEntities reservas = new BD_RESERVASEntities())
            {
                
                resultado = (from usuario in reservas.Usuario
                            join tipo in reservas.UsuarioTipo on usuario.tipoUsuario equals tipo.id
                            where tipo.estado == true && usuario.codigo == codigo
                            select new BE.Adapters.Usuario { 
                                id = usuario.id,
                                codigo = usuario.codigo,
                                estado = usuario.estado,
                                tipoUsuario = tipo.id,
                                Tipo = tipo
                            }).ToList();
            }  
            using (BD_ADMUSERSEntities intranet = new BD_ADMUSERSEntities())
            {

                resultado = (from usuario in resultado
                           join usuarioint in intranet.USUARIO on usuario.codigo equals usuarioint.login
                            select new BE.Adapters.Usuario
                            {
                                id = usuario.id,
                                codigo = usuario.codigo,
                                estado = usuario.estado,
                                tipoUsuario = usuario.tipoUsuario,
                                Tipo = usuario.Tipo,
                                NombreCompleto = usuarioint.username,
                                NombreSede = usuarioint.sedePredeterminada
                            }).ToList();
            }       
            using (BD_UPNSACEntities upnsac = new BD_UPNSACEntities())
            {
                resultado = (from usuario in resultado
                           join sede in upnsac.Sede on usuario.NombreSede equals sede.nombre
                           select new BE.Adapters.Usuario
                           {
                               id = usuario.id,
                               codigo = usuario.codigo,
                               estado = usuario.estado,
                               tipoUsuario = usuario.tipoUsuario,
                               Tipo = usuario.Tipo,
                               NombreCompleto = usuario.NombreCompleto,
                               NombreSede = sede.descripcion,
                               IdSede = sede.id
                           }).ToList();

                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
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
                if (resultado.Count() == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;

        }

        public bool Grabar(BE.Modelos.Usuario obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToUsuario(obj);
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Actualizar(BE.Modelos.Usuario obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var usuario = (from x in reposit.Usuario
                               where x.id == obj.id
                               select x).First();
                usuario.tipoUsuario = obj.tipoUsuario;
                usuario.estado = obj.estado;
                return reposit.SaveChanges() == 1;
            }
        }

        public List<BE.Adapters.Usuario> Listar(string codigoSede)
        {
            List<BE.Adapters.Usuario> rpta;

            using (BD_RESERVASEntities reservas = new BD_RESERVASEntities())
            {

                rpta = (from usuario in reservas.Usuario
                        join tipo in reservas.UsuarioTipo on usuario.tipoUsuario equals tipo.id
                        where usuario.tipoUsuario != 100
                        select new BE.Adapters.Usuario
                        {
                            id = usuario.id,
                            codigo = usuario.codigo,
                            estado = usuario.estado,
                            tipoUsuario = tipo.id,
                            Tipo = tipo
                        }).ToList();
            }
            using (BD_ADMUSERSEntities intranet = new BD_ADMUSERSEntities())
            {

                rpta = (from usuario in rpta
                        join usuarioint in intranet.USUARIO on usuario.codigo equals usuarioint.login
                        where usuarioint.sedePredeterminada == codigoSede
                             select new BE.Adapters.Usuario
                             {
                                 id = usuario.id,
                                 codigo = usuario.codigo,
                                 estado = usuario.estado,
                                 tipoUsuario = usuario.tipoUsuario,
                                 Tipo = usuario.Tipo,
                                 NombreCompleto = usuarioint.username,
                                 NombreSede = usuarioint.sedePredeterminada
                             }).ToList();
            }
            using (BD_UPNSACEntities upnsac = new BD_UPNSACEntities())
            {
                rpta = (from usuario in rpta
                             join sede in upnsac.Sede on usuario.NombreSede equals sede.nombre
                             select new BE.Adapters.Usuario
                             {
                                 id = usuario.id,
                                 codigo = usuario.codigo,
                                 estado = usuario.estado,
                                 tipoUsuario = usuario.tipoUsuario,
                                 Tipo = usuario.Tipo,
                                 NombreCompleto = usuario.NombreCompleto,
                                 NombreSede = sede.descripcion,
                                 IdSede = sede.id
                             }).ToList();

            }
            return rpta;

        }
    }
}
