using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IDAO;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.DAO
{
    public class SancionDetalleDAO : ISancionDetalleDAO
    {
        
        #region Singleton
        private SancionDetalleDAO() { }

        private static readonly SancionDetalleDAO _instance = new SancionDetalleDAO();
        public static SancionDetalleDAO Instance
        { get { return _instance; } }
        #endregion

        public bool Grabar(List<BE.Modelos.SancionDetalle> detalle)
        {
            try
            {
                using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
                {
                    detalle.ForEach(d => reposit.AddToSancionDetalle(new SancionDetalle { sancion = d.sancion, tiporecurso = d.tiporecurso }));
                    return reposit.SaveChanges() > 0;
                }
            }
            catch (Exception ex) { return true; }
        }

        public List<BE.Modelos.SancionDetalle> Listar(int idsancion)
        {
            List<BE.Modelos.SancionDetalle> rpta = null;

            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                rpta = (from x in reposit.SancionDetalle
                        where x.sancion == idsancion
                        select x
                        ).ToList();
            }

            return rpta;
        }

        public List<BE.Modelos.RecursoTipo> ListarRecursoTipo(int idsancion)
        {
            List<BE.Modelos.RecursoTipo> rpta = null;

            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                int idAula = Convert.ToInt16(BE.Enumeraciones.TipoRecurso.AULA);
                var res = (from x in reposit.SancionDetalle
                        join y in reposit.RecursoTipo on x.tiporecurso equals y.id into ys
                        from y in ys.DefaultIfEmpty()
                        where x.sancion == idsancion && (y ==null ? true : y.estado)
                        select new {x.tiporecurso, 
                                    descripcion = (y == null ? BE.Adapters.Recurso.TIPO_AULA : y.descripcion)
                                    }
                        ).ToList();
                rpta = new List<RecursoTipo>();
                res.ForEach(d => rpta.Add(new RecursoTipo{ id=d.tiporecurso, descripcion=d.descripcion }));
            }

            return rpta;
        }

        public bool Eliminar(int idsancion)
        {
            using (BD_RESERVASEntities reposit = new BD_RESERVASEntities())
            {
                var rs = (from x in reposit.SancionDetalle
                          where x.sancion == idsancion
                          select x);
                foreach (BE.Modelos.SancionDetalle detalle in rs) {
                    reposit.SancionDetalle.DeleteObject(detalle);
                }
                reposit.SaveChanges();
                return true;
            }
        }
    }
}
