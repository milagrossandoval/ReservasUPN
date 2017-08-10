using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class SedeDAO : ISedeDAO
    {

        #region Singleton
        private SedeDAO() { }

        private static readonly SedeDAO _instance = new SedeDAO();
        public static SedeDAO Instance
        { get { return _instance; } }
        #endregion

        public BE.Modelos.Sede Buscar(string nombre)
        {
            BE.Modelos.Sede rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                List<BE.Modelos.Sede> resultado = reposit.PA_SELECT_SEDE_X_NOMBRE(nombre).ToList();
                if (resultado.Count == 1)
                {
                    rpta = resultado.First();
                }
            }
            return rpta;  
        }
    }
}
