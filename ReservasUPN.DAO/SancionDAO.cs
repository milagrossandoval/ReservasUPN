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

        //public bool Grabar(BE.Modelos.Sancion obj)
        //{
        //    using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
        //    {
        //        reposit.AddToSancion(obj);
        //        return reposit.SaveChanges()>0;
        //    }
        //}

        public bool Grabar(BE.Modelos.Sancion obj, string detalle)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.PA_SANCION_INSERT(obj.usuario, obj.motivo, obj.fechainicio, obj.fechafin, detalle);
                return true;
            }
        }

        //public bool Actualizar(BE.Modelos.Sancion obj)
        //{
        //    using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
        //    {
        //        var sancion = (from x in reposit.Sancion
        //                       where x.id == obj.id
        //                       select x).First();
        //        sancion.usuario = obj.usuario;
        //        sancion.motivo = obj.motivo;
        //        sancion.fechainicio = obj.fechainicio;
        //        sancion.fechafin = obj.fechafin;
        //        sancion.RecursoTipo = obj.RecursoTipo;
                
        //        return reposit.SaveChanges() == 1;
        //    }
        //}

        public bool Actualizar(BE.Modelos.Sancion obj, string detalle)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                reposit.PA_SANCION_UPDATE(obj.id, obj.usuario, obj.motivo, obj.fechainicio, obj.fechafin, detalle);
                return true;
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
                            //RecursoTipo = x.RecursoTipo
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
                            //RecursoTipo = x.RecursoTipo
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
                sancion.RecursoTipo.Clear();
                return reposit.SaveChanges() == 1;
            }
        }

        public List<BE.Modelos.RecursoTipo> BuscarDetalle(int id)
        {
            List<BE.Modelos.RecursoTipo> rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var sancion = (from x in reposit.Sancion
                                where x.id == id
                               select x);
                if (sancion.Count() > 0) {
                    rpta = new List<RecursoTipo>();
                    sancion.First().RecursoTipo.ToList().ForEach(rt => rpta.Add(rt));
                }
                
            }
            return rpta;
        }


        public Sancion Buscar(string usuario, DateTime fecha, int idtiporecurso)
        {
            BE.Modelos.Sancion rpta = null;
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var res = reposit.PA_SANCION_BUSCAR(usuario,fecha,idtiporecurso).ToList();
                if (res.Count == 1) {
                    rpta = res.First();
                }
            }
            return rpta;
        }
    }
}
