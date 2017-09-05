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

        private string ListToString(List<BE.Modelos.RecursoTipo> lista)
        {
            StringBuilder sb = new StringBuilder();
            foreach (BE.Modelos.RecursoTipo rt in lista)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",");
                }
                sb.Append(rt.id);
            }
            return sb.ToString();
        }

        public bool Grabar(BE.Modelos.Sancion obj)
        {
            return sancionDAO.Grabar(obj, ListToString(obj.RecursoTipo.ToList()));
        }

        public bool Actualizar(BE.Modelos.Sancion obj)
        {
            return sancionDAO.Actualizar(obj, ListToString(obj.RecursoTipo.ToList()));  
        }

        public List<BE.Adapters.Sancion> Listar(string sede, bool inactivos)
        {
            if (inactivos)
                return sancionDAO.Listar(sede);
            return sancionDAO.ListarActivos(sede);
        }

        public bool Eliminar(int id)
        {
            return sancionDAO.Eliminar(id);
        }

        public List<BE.Modelos.RecursoTipo> BuscarDetalle(int id)
        {
            return sancionDAO.BuscarDetalle(id);
        }
    }
}
