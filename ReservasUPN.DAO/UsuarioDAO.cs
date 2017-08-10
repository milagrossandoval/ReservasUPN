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

        public PA_SELECT_ALUMNOS_REGULARES_X_CODIGO_Result BuscarAlumno(string codigo)
        {
            PA_SELECT_ALUMNOS_REGULARES_X_CODIGO_Result rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                List<PA_SELECT_ALUMNOS_REGULARES_X_CODIGO_Result> resultado = reposit.PA_SELECT_ALUMNOS_REGULARES_X_CODIGO(codigo).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;
        }


        public PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO_Result BuscarEgresado(string codigo)
        {
            PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO_Result rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                List<PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO_Result> resultado = reposit.PA_SELECT_ALUMNOS_EGRESADOS_X_CODIGO(codigo).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;    
        }

        public PA_SELECT_DOCENTES_X_CODIGO_Result BuscarDocente(string codigo)
        {
            PA_SELECT_DOCENTES_X_CODIGO_Result rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                List<PA_SELECT_DOCENTES_X_CODIGO_Result> resultado = reposit.PA_SELECT_DOCENTES_X_CODIGO(codigo).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;    
        }

        public PA_SELECT_USUARIOS_X_CODIGO_Result BuscarUsuario(string codigo)
        {
            PA_SELECT_USUARIOS_X_CODIGO_Result rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                List<PA_SELECT_USUARIOS_X_CODIGO_Result> resultado = reposit.PA_SELECT_USUARIOS_X_CODIGO(codigo).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;
        }
    }
}
