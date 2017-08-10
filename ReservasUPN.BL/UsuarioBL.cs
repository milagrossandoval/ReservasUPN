using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.BL
{
    public class UsuarioBL : IUsuarioBL
    {

        private IUsuarioDAO usuarioDAO = UsuarioDAO.Instance;
        private ISedeDAO sedeDAO = SedeDAO.Instance;

        public BE.Adapters.Usuario Buscar(string codigo)
        {
            BE.Adapters.Usuario rpta = null;

            PA_SELECT_ALUMNOS_REGULARES_X_CODIGO_Result alumno = usuarioDAO.BuscarAlumno(codigo);

            if (alumno != null) {
                rpta = new BE.Adapters.Usuario()
                {
                    Codigo = alumno.CODIGO,
                    NombreCompleto = alumno.NOMBRECOMPLETO,
                    IdTipoUsuario = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.ALUMNO),
                    TipoUsuario = new UsuarioTipo() { id = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.ALUMNO), nombre = BE.Adapters.Usuario.TIPO_ALUMNO },
                    IdSede = alumno.SEDE,
                    Sede = new Sede() { id = alumno.SEDE, nombre = alumno.SEDENOMBRE }
                };                
                return rpta;
            }
            
            PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO_Result egresado = usuarioDAO.BuscarEgresado(codigo);

            if (egresado != null)
            {
                rpta = new BE.Adapters.Usuario()
                {
                    Codigo = egresado.CODIGO,
                    NombreCompleto = egresado.NOMBRECOMPLETO,
                    IdTipoUsuario = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.EGRESADO),
                    TipoUsuario = new UsuarioTipo() { id = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.EGRESADO), nombre = BE.Adapters.Usuario.TIPO_EGRESADO },
                    IdSede = egresado.SEDE,
                    Sede = new Sede() { id = egresado.SEDE, nombre = egresado.SEDENOMBRE }
                };
                return rpta;
            }
            
            PA_SELECT_DOCENTES_X_CODIGO_Result docente = usuarioDAO.BuscarDocente(codigo);

            if (docente != null)
            {
                rpta = new BE.Adapters.Usuario()
                {
                    Codigo = docente.Codigo,
                    NombreCompleto = docente.NombreCompleto,
                    IdTipoUsuario = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.DOCENTE),
                    TipoUsuario = new UsuarioTipo() { id = Convert.ToInt32(BE.Enumeraciones.TipoUsuario.DOCENTE), nombre = BE.Adapters.Usuario.TIPO_DOCENTE },
                    IdSede = docente.sede,
                    Sede = new Sede() { id = docente.sede, nombre = docente.sedeNombre }
                };
                return rpta;
            }
            
            PA_SELECT_USUARIOS_X_CODIGO_Result usuario = usuarioDAO.BuscarUsuario(codigo);

            if (usuario != null)
            {
                Sede sedeUsuario = sedeDAO.Buscar(usuario.codigoSede);
                rpta = new BE.Adapters.Usuario()
                {
                    Codigo = usuario.codigo,
                    NombreCompleto = usuario.nombreCompleto,
                    IdTipoUsuario = usuario.tipoUsuario,
                    TipoUsuario = new UsuarioTipo() { id = usuario.tipoUsuario, nombre = usuario.nombreTipo },
                    IdSede = sedeUsuario.id,
                    Sede = sedeUsuario
                };
                return rpta;
            }
            
            throw new Exception("EL USUARIO NO ESTÁ DISPONIBLE PARA EL SISTEMA");
            
        }
    }
}
