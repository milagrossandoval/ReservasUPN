using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;
using ReservasUPN.IBL;
using Telerik.Web.UI;
using System.Drawing;

namespace ReservasUPN.Web.Secure
{
    public partial class Seguimiento : PageAdapter
    {
        IHoraBL horabl = new HoraBL();
        IReservaBL reservabl = new ReservaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
        }

        protected void CmbTiposRecurso_DataBound(object sender, EventArgs e)
        {
            CmbTiposRecurso.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ActualizarReservas();
        }

        private void ActualizarReservas() {
            string tipohora = HfTipoHora.Value;
            
            BE.Modelos.Hora horaActual = horabl.HoraActual(tipohora);
            if (horaActual != null)
            {
                HfHoraActual.Value = horaActual.n_hor_codigo.ToString();
                LblHoraActual.Text = "Horario: " + horaActual.s_hor_descripcion;
            }
            else {
                HfHoraActual.Value = "0";
                LblHoraActual.Text = "Horario: -";
            }
            RgActual.Rebind();

            BE.Modelos.Hora horaSiguiente = horabl.HoraSiguiente(tipohora);
            if (horaSiguiente != null)
            {
                HfHoraSiguiente.Value = horaSiguiente.n_hor_codigo.ToString();
                LblHoraSiguiente.Text = "Horario: " + horaSiguiente.s_hor_descripcion;
            }
            else {
                HfHoraSiguiente.Value = "0";
                LblHoraSiguiente.Text = "Horario: -";
            }
            RgSiguiente.Rebind();
        }

        protected void CmbTiposRecurso_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BE.Modelos.RecursoTipo recursotipo = new RecursoTipoBL().Buscar(Convert.ToInt32(e.Value));
            HfTipoHora.Value = recursotipo.tipoHora.ToString();
            ActualizarReservas();
        }

        protected void RgActual_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Asistencia") {
                int id = Convert.ToInt32( ((GridDataItem)e.Item).GetDataKeyValue("id"));
                reservabl.CambiarAsistencia(id);
                RgActual.Rebind();
            }
        }

        protected void RgActual_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                RadButton BtnAsistir = (RadButton)item.FindControl("BtnAsistir");
                Object oAsistencia = item.GetDataKeyValue("asistencia");
                if (oAsistencia == null)
                    oAsistencia = false;
                bool asistencia = Convert.ToBoolean(oAsistencia);
                if (asistencia)
                {
                    BtnAsistir.Text = "No asistió";
                    BtnAsistir.ForeColor = Color.Red;
                }
                else
                {
                    BtnAsistir.Text = "Asistió";
                    BtnAsistir.ForeColor = Color.Black;
                }
            }
           
        }


    }
}