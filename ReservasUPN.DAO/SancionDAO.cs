using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class SancionDAO : ISancionDAO
    {
        #region Singleton
        private SancionDAO() { }

        private static readonly SancionDAO _instance = new SancionDAO();
        public static SancionDAO Instance
        { get { return _instance; } }
        #endregion


        public bool Grabar(BE.Modelos.Sancion obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToSancion(obj);
                return reposit.SaveChanges() == 1;
            }
        }

        public bool Actualizar(BE.Modelos.Sancion obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var sancion = (from x in reposit.Sancion
                               where x.id == obj.id
                               select x).First();
                sancion.usuario = obj.usuario;
                sancion.motivo = obj.motivo;
                sancion.fechainicio = obj.fechainicio;
                sancion.fechafin = obj.fechafin;
                sancion.estado = obj.estado;
                return reposit.SaveChanges() == 1;
            }
        }

        public List<Sancion> Listar()
        {
            List<Sancion> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.Sancion
                        select x).ToList();
            }
            return rpta;
        }
    }
}
