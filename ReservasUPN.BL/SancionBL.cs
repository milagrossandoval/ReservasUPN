using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.IBL;
using ReservasUPN.IDAO;
using ReservasUPN.DAO;
using ReservasUPN.Util;

namespace ReservasUPN.BL
{
    public class SancionBL : ISancionBL
    {
        private ISancionDAO sancionDAO = SancionDAO.Instance;

        public bool Grabar(BE.Modelos.Sancion obj)
        {
            return sancionDAO.Grabar(obj, RecursoTipoUtil.ListToStringId(obj.RecursoTipo.ToList()));
        }

        public bool Actualizar(BE.Modelos.Sancion obj)
        {
            return sancionDAO.Actualizar(obj, RecursoTipoUtil.ListToStringId(obj.RecursoTipo.ToList()));  
        }

        public List<BE.Adapters.Sancion> Listar(string sede, bool inactivos)
        {
            List<BE.Adapters.Sancion> rpta;
            if (inactivos)
                rpta = sancionDAO.Listar(sede);
            else
                rpta = sancionDAO.ListarActivos(sede);

            rpta.ForEach(s => s.Detalle = Util.RecursoTipoUtil.ListToStringDes(BuscarDetalle(s.id)));

            return rpta;
        }

        public bool Eliminar(int id)
        {
            return sancionDAO.Eliminar(id);
        }

        public List<BE.Modelos.RecursoTipo> BuscarDetalle(int id)
        {
            return sancionDAO.BuscarDetalle(id);
        }


        public BE.Modelos.Sancion Buscar(string usuario, DateTime fecha, int idtiporecurso)
        {
            return sancionDAO.Buscar(usuario, fecha, idtiporecurso);
        }
    }
}
