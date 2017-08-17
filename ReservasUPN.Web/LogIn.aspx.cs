using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.Web
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Leer de la cookie de la intranet
            var usuario = "das";
            //var usuario = "47915";
            //var usuario = "60454";

            UsuarioBL usuariobl = new UsuarioBL();
            try
            {
                var rpta = usuariobl.Buscar(usuario);
                Session["usuario"] = rpta;
                //Redireccionar a la página 
                Response.Redirect("Secure/Default.aspx");
                //Response.Write(rpta.NombreCompleto + " - " + rpta.TipoUsuario.nombre + " - " + rpta.NombreSede);
            }
            catch (Exception ex)
            {
                //Mostrar el mensaje en una página de error
                MvLogin.ActiveViewIndex = 1;
                Response.Write(ex.Message);
            }
            
            
        }
    }
}