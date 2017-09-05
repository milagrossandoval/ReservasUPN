using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class HoraDAO : IHoraDAO
    {

        #region Singleton
        private HoraDAO() { }

        private static readonly HoraDAO _instance = new HoraDAO();
        public static HoraDAO Instance
        { get { return _instance; } }
        #endregion

        public List<BE.Modelos.Hora> Listar(string tipohora)
        {
            List<BE.Modelos.Hora> rpta;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                rpta = (from x in reposit.Hora
                        where x.s_hor_tipo == tipohora
                        select x).ToList();
            }
            return rpta;
        }
    }
}
