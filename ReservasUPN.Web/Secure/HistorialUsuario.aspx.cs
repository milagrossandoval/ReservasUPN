using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.IBL;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;

namespace ReservasUPN.Web.Secure
{
    public partial class HistorialUsuario : PageAdapter
    {
        IReservaBL reservabl = new ReservaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }

        }

        protected void BtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            var rpta = new UsuarioBL().Buscar(TxtUsuario.Text);
            if (rpta != null)
            {
                if (rpta.IdSede == int.Parse(CmbSedes.SelectedValue))
                {
                    HfUsuario.Value = rpta.codigo;
                    LblUsuario.Text = rpta.NombreCompleto;
                    ImgFoto.Visible = true;
                    BE.Modelos.Sede sede = new SedeBL().Buscar(int.Parse(CmbSedes.SelectedValue));
                    ImgFoto.ImageUrl = Util.Imagen.RutaFoto(sede.nombre, rpta.codigo);
                    RgReservas.Visible = true;
                    RgReservas.Rebind();

                }
            }
            else
            {
                HfUsuario.Value = string.Empty;
                LblUsuario.Text = string.Empty;
                ImgFoto.Visible = false;
                RgReservas.Visible = false;
                alerta("No se encontró el usuario");

            }
        }

        protected void RgReservas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RgReservas.DataSource = reservabl.Listar(HfUsuario.Value, int.Parse(CmbSedes.SelectedValue));
        }
    }
}