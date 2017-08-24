using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BE.Adapters;

namespace ReservasUPN.Web.Secure
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private Usuario usuario = new Usuario();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (BE.Adapters.Usuario)Session["usuario"];
            lblUsuario.Text = usuario.NombreCompleto;
            lblTipo.Text = " - [" + usuario.Tipo.nombre + "]";
        }
    }
}