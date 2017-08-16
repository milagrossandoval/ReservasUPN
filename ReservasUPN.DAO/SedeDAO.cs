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

        public Sede Buscar(string nombre)
        {
            Sede rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                var sedes = from s in reposit.Sede
                            where s.nombre == nombre && s.estado == true
                            select s;
                if (sedes.Count() == 1)
                {
                    rpta = sedes.First();
                }
            }
            return rpta;
        }


        public Sede Buscar(int id)
        {
            Sede rpta = null;
            using (BD_UPNSACEntities reposit = new BD_UPNSACEntities())
            {
                var sedes = from s in reposit.Sede
                            where s.id == id && s.estado == true
                           select s;
                if (sedes.Count() == 1)
                {
                    rpta = sedes.First();
                }
            }
            return rpta;
        }

        public List<Sede> ListarxUsuario(string usuario)
        {
            List<Sede> rpta = null;            
            using (BD_ADMUSERSEntities reposit = new BD_ADMUSERSEntities()) {
                rpta = (from x in reposit.PA_AU_CONSULTAR_SEDES_DISPONIBLES_X_USUARIO(usuario)
                        select new Sede { id = x.n_sede_id, nombre = x.s_sed_codigo, descripcion = x.s_sed_nombre }).ToList();
            }
            return rpta;
        }

    }
}
