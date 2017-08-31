using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;

namespace ReservasUPN.BL
{
    public class SancionBL : ISancionBL
    {
        private ISancionDAO sancionDAO = SancionDAO.Instance;
        private ISancionDetalleDAO detalleDAO = SancionDetalleDAO.Instance;

        public bool Grabar(BE.Modelos.Sancion obj)
        {
            List<BE.Modelos.SancionDetalle> detalle = obj.SancionDetalle.ToList();
            int lastid = sancionDAO.Grabar(obj);
            detalle.ForEach(i => i.sancion = lastid);
            return detalleDAO.Grabar(detalle);
        }

        public bool Actualizar(BE.Modelos.Sancion obj)
        {
            List<BE.Modelos.SancionDetalle> detalle = obj.SancionDetalle.ToList();
            int id = obj.id;
            sancionDAO.Actualizar(obj);
            detalleDAO.Eliminar(id);
            return detalleDAO.Grabar(detalle);           
        }

        public List<BE.Adapters.Sancion> Listar(string sede, bool inactivos)
        {
            if (inactivos)
                return sancionDAO.Listar(sede);
            return sancionDAO.ListarActivos(sede);
        }

        public bool Eliminar(int id)
        {
            detalleDAO.Eliminar(id);
            return sancionDAO.Eliminar(id);
        }

        public List<BE.Modelos.SancionDetalle> ListarDetalle(int idsancion)
        {
            return detalleDAO.Listar(idsancion);
        }

        public List<BE.Modelos.RecursoTipo> ListarDetalleRecursoTipo(int idsancion)
        {
            return detalleDAO.ListarRecursoTipo(idsancion);
        }

        
    }
}
