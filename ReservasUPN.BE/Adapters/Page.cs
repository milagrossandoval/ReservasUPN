using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.BE.Adapters
{
    public class Page : System.Web.UI.Page
    {
        public Usuario Usuario {
            get
            {
                return (Usuario)Session["user"];
            }
        }

        public string Codigo
        {
            get
            {
                return Usuario.Codigo;
            }
        }

        public List<Sede> Sedes
        {
            get
            {
                return Usuario.LstSedes;
            }
        }

    }
}
