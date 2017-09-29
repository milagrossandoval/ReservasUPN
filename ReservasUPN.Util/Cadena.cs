using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservasUPN.Util
{
    public class Cadena
    {
        public static string ListRecursoTipoToStringDes(List<BE.Modelos.RecursoTipo> lista)
        {
            StringBuilder sb = new StringBuilder();
            foreach (BE.Modelos.RecursoTipo rt in lista)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(rt.descripcion);
            }
            return sb.ToString();
        }

        public static string ListRecursoTipoToStringId(List<BE.Modelos.RecursoTipo> lista)
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

    }
}
