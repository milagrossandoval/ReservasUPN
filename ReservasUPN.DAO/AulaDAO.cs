using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;
using ReservasUPN.IDAO;

namespace ReservasUPN.DAO
{
    public class AulaDAO : IAulaDAO
    {
        #region Singleton
        private AulaDAO() { }

        private static readonly AulaDAO _instance = new AulaDAO();
        public static AulaDAO Instance
        { get { return _instance; } }
        #endregion

        public List<BE.Modelos.Aula> Listar(int sede)
        {
            List<BE.Modelos.Aula> rpta;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                rpta = (from x in reposit.Aula
                        where x.sede == sede
                        select x).ToList();
            }
            return rpta;
        }

        public List<BE.Modelos.PA_SELECT_HORARIO_X_AULA_Result> BuscarHoraio(string aula)
        {
            List<BE.Modelos.PA_SELECT_HORARIO_X_AULA_Result> rpta;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                rpta = reposit.PA_SELECT_HORARIO_X_AULA(aula).ToList();
            }
            return rpta;
        }
    }
}
