using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;

namespace ReservasUPN.Web
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = "60454";
            UsuarioBL bl = new UsuarioBL();
            try
            {
                var rpta = bl.Buscar(usuario);
                Response.Write(rpta.NombreCompleto + " - " + rpta.TipoUsuario.nombre + " - " + rpta.Sede.nombre);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //Response.Write(rpta.NombreCompleto + " - " + rpta.TipoUsuario.nombre + " - " + rpta.Sede.nombre);
            
        }
    }
}