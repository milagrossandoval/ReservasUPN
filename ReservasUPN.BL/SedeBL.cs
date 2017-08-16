using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;
using ReservasUPN.BE.Adapters;

namespace ReservasUPN.BL
{
    public class SedeBL : ISedeBL
    {

        private ISedeDAO sedeDAO = SedeDAO.Instance;
        
        public BE.Modelos.Sede Buscar(int id)
        {
            return sedeDAO.Buscar(id);
        }

        public BE.Modelos.Sede Buscar(string nombre)
        {
            return sedeDAO.Buscar(nombre);
        }

        public List<BE.Modelos.Sede> ListarxUsuario(Usuario usuario)
        {
            List<BE.Modelos.Sede> rpta;
            if (usuario.IdTipoUsuario < BE.Adapters.Usuario.INIT_ID) //Para los alumnos, egresados, docentes
            {
                BE.Modelos.Sede sede = sedeDAO.Buscar(usuario.IdSede);
                rpta = new List<BE.Modelos.Sede>();
                rpta.Add(sede);
            }
            else // Para los tipos de usuario del sistema
            {                
                rpta = sedeDAO.ListarxUsuario(usuario.Codigo);
            }
            return rpta;
        }
    }
}
