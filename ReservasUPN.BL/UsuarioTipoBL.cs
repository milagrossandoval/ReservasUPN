using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class UsuarioTipoBL : IUsuarioTipoBL
    {
        private IUsuarioTipoDAO usuariotipodao = UsuarioTipoDAO.Instance;

        public List<BE.Modelos.UsuarioTipo> Listar()
        {
            return usuariotipodao.Listar();
        }
        
        public bool Eliminar(int id)
        {
            return usuariotipodao.Eliminar(id);
        }

        public bool Actualizar(BE.Modelos.UsuarioTipo obj)
        {
            return usuariotipodao.Actualizar(obj);
        }

        public bool Grabar(BE.Modelos.UsuarioTipo obj)
        {
            return usuariotipodao.Grabar(obj);
        }

        public List<BE.Modelos.UsuarioTipo> ListarPropios()
        {
            List<BE.Modelos.UsuarioTipo> rpta = new List<BE.Modelos.UsuarioTipo>();
            rpta.Add(new BE.Modelos.UsuarioTipo { id = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.ALUMNO), nombre = BE.Adapters.Usuario.TIPO_ALUMNO });
            rpta.Add(new BE.Modelos.UsuarioTipo { id = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.EGRESADO), nombre = BE.Adapters.Usuario.TIPO_EGRESADO });
            rpta.Add(new BE.Modelos.UsuarioTipo { id = Convert.ToInt16(BE.Enumeraciones.TipoUsuario.DOCENTE), nombre = BE.Adapters.Usuario.TIPO_DOCENTE });
            return rpta;
        }

        public List<BE.Modelos.UsuarioTipo> ListarTodos()
        {
            List<BE.Modelos.UsuarioTipo> rpta = ListarPropios();
            rpta.AddRange(usuariotipodao.Listar());
            return rpta;
        }
    }
}
