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

        public int Grabar(BE.Modelos.Sancion obj)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.AddToSancion(obj);
                reposit.SaveChanges();
            }
            return obj.id;
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
                return reposit.SaveChanges() == 1;
            }
        }

        public List<BE.Adapters.Sancion> Listar(string sede)
        {
            List<BE.Adapters.Sancion> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.Sancion
                        where x.estado
                        select new BE.Adapters.Sancion { 
                            estado = x.estado,
                            fechafin = x.fechafin,
                            fechainicio = x.fechainicio,
                            id = x.id,
                            motivo = x.motivo,
                            usuario = x.usuario
                        }).ToList();
                
            }
            using (BD_ADMUSERSEntities reposit = new BD_ADMUSERSEntities())
            {
                rpta = (from x in rpta
                        join u in reposit.USUARIO on x.usuario equals u.login
                        where u.sedePredeterminada == sede
                        select new BE.Adapters.Sancion { 
                            estado = x.estado,
                            fechafin = x.fechafin,
                            fechainicio = x.fechainicio,
                            id = x.id,
                            motivo = x.motivo,
                            usuario = x.usuario,
                            NombreUsuario = u.username
                        }).ToList();                
            }
                                   
            return rpta;
        }

        public List<BE.Adapters.Sancion> ListarActivos(string sede)
        {
            List<BE.Adapters.Sancion> rpta;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.Sancion
                        where x.fechafin > DateTime.Today && x.estado 
                        select new BE.Adapters.Sancion
                        {
                            estado = x.estado,
                            fechafin = x.fechafin,
                            fechainicio = x.fechainicio,
                            id = x.id,
                            motivo = x.motivo,
                            usuario = x.usuario
                        }).ToList();

            }
            using (BD_ADMUSERSEntities reposit = new BD_ADMUSERSEntities())
            {
                rpta = (from x in rpta
                        join u in reposit.USUARIO on x.usuario equals u.login
                        where u.sedePredeterminada == sede
                        select new BE.Adapters.Sancion
                        {
                            estado = x.estado,
                            fechafin = x.fechafin,
                            fechainicio = x.fechainicio,
                            id = x.id,
                            motivo = x.motivo,
                            usuario = x.usuario,
                            NombreUsuario = u.username
                        }).ToList();
            }
            return rpta;
        }
        
        public bool Eliminar(int id)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var sancion = (from x in reposit.Sancion
                               where x.id == id
                               select x).First();
                sancion.estado = false;

                return reposit.SaveChanges() == 1;
            }
        }
    }
}
