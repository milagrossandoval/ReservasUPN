using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;
using ReservasUPN.IBL;

namespace ReservasUPN.Web.Secure
{
    public partial class Historial : PageAdapter
    {
        IReservaBL reservabl = new ReservaBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }

            int sede = Convert.ToInt32(CmbSedes.SelectedValue);
            RgReservas.DataSource = reservabl.Listar(Usuario.codigo, sede);
            RgReservas.DataBind();
            
        }


    }
}