using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE;
using System.Data.Objects;
using ReservasUPN.IDAO;

namespace ReservasUPN.DAO
{
    public class TipoRecursoDAO : ITipoRecursoDAO
    {
        #region Singleton
        private TipoRecursoDAO() { }

        private static readonly TipoRecursoDAO _instance = new TipoRecursoDAO();
        public static TipoRecursoDAO Instance
        { get { return _instance; } }
        #endregion

        public List<PA_GET_TIPO_RECURSOS_Result> listar(int sede)
        {
            List<PA_GET_TIPO_RECURSOS_Result> rpta = null;
            using (BD_RESERVASEntities1 reposit = new BD_RESERVASEntities1())
            {
                rpta = reposit.PA_GET_TIPO_RECURSOS(sede).ToList();
            }
            return rpta;
        }

    }
}
