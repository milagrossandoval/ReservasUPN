using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReservasUPN.BE.Modelos;
using Telerik.Web.UI;

namespace ReservasUPN.Web.App_Code
{
    public class PageAdapter : System.Web.UI.Page
    {
        public BE.Adapters.Usuario Usuario
        {
            get
            {
                return (BE.Adapters.Usuario)Session["usuario"];
            }
        }

        public string Codigo
        {
            get
            {
                return Usuario.codigo;
            }
        }

        public List<Sede> Sedes
        {
            get
            {
                return Usuario.LstSedes;
            }
        }

        public void alerta(string mensaje)
        {
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "alert('" + mensaje + "')", true);
        }

        public void notificaciom(string mensaje, int tipo)
        {
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "Notificacion", "notificar('" + mensaje + "')", true);
        }

    
    }
}