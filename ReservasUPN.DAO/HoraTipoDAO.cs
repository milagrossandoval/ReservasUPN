using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class HoraTipoDAO : IHoraTipoDAO
    {
        #region Singleton
        private HoraTipoDAO() { }

        private static readonly HoraTipoDAO _instance = new HoraTipoDAO();
        public static HoraTipoDAO Instance
        { get { return _instance; } }
        #endregion

        public List<HoraTipo> Listar()
        {
            List<HoraTipo> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.HoraTipo
                        where x.estado == true
                        select x).ToList();
            }
            return rpta;
        }
    }
}
