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

        private BE.Adapters.Usuario BuscarUsuariosEnTodosOrigenes(string codigo) {
            BE.Adapters.Usuario rpta = null;
            //Alumnos
            rpta = usuarioDAO.BuscarAlumno(codigo);
            if (rpta != null) { return rpta; }
            //Egresados
            rpta = usuarioDAO.BuscarEgresado(codigo);
            if (rpta != null) { return rpta; }
            //Docentes
            rpta = usuarioDAO.BuscarAlumno(codigo);
            if (rpta != null) { return rpta; }
            //Usuarios
            rpta = usuarioDAO.BuscarUsuario(codigo);
            if (rpta != null) { return rpta; }

            return null;
        }

        public BE.Adapters.Usuario Buscar(string codigo)
        {
            BE.Adapters.Usuario rpta = BuscarUsuariosEnTodosOrigenes(codigo);

            if (rpta != null) {
                rpta.LstSedes = new SedeBL().ListarxUsuario(rpta);
                return rpta;
            }
            
            throw new Exception("EL USUARIO NO ESTÁ DISPONIBLE PARA EL SISTEMA");
            
        }

        public BE.Modelos.Usuario BuscarUsuario(string codigo)
        {
            return usuarioDAO.Buscar(codigo);
        }


        public bool Grabar(Usuario obj)
        {
            return usuarioDAO.Grabar(obj);
        }

        public bool Actualizar(Usuario obj)
        {
            return usuarioDAO.Actualizar(obj);
        }

        public List<BE.Adapters.Usuario> Listar(string codigoSede)
        {
            return usuarioDAO.Listar(codigoSede);
        }
    }
}
