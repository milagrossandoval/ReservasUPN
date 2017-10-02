using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.IBL;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;
using ReservasUPN.BE.Modelos;
using Telerik.Web.UI;
using ReservasUPN.Util;

namespace ReservasUPN.Web.Secure
{
    public partial class MisReservas : PageAdapter
    {
        IReservaBL reservabl = new ReservaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
                DpFecha.SelectedDate = DateTime.Today;
            }
            else {
                RgHorario.Rebind();
            }
        }

        protected void CmbSedes_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CmbTiposRecurso.DataBind();
        }

        protected void CmbTiposRecurso_DataBound(object sender, EventArgs e)
        {
            CmbTiposRecurso.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));
        }

        protected void CmbTiposRecurso_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value != "0")
            {
                int idtiporecurso = Convert.ToInt32(e.Value);
                RecursoTipo recursotipo = new RecursoTipoBL().Buscar(idtiporecurso);
                HfTipoHora.Value = recursotipo.tipoHora.ToString();                
            }
            else
            {
                HfTipoHora.Value = string.Empty;
            }
            RgHorario.Rebind();
        }

        protected void DpFecha_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            RgHorario.Rebind();
        }

        protected void RgHorario_DataBound(object sender, EventArgs e)
        {
            if (RgHorario.MasterTableView.Items.Count > 0)
            {

                DateTime fechaSeleccionada = DpFecha.SelectedDate.Value;
                int diaSemana = (int)fechaSeleccionada.DayOfWeek;
                DateTime fechaDia, fechaLunes, fechaDomingo;
                fechaLunes = DateTime.MinValue;
                fechaDomingo = DateTime.MaxValue;
                List<DateTime> fechasSemana = new List<DateTime>();
                for (int i = 1; i <= 7; i++)
                {
                    fechaDia = fechaSeleccionada.AddDays(i - diaSemana);
                    fechasSemana.Add(fechaDia);
                    if (i == 1) { fechaLunes = fechaDia; }
                    if (i == 7) { fechaDomingo = fechaDia; }
                }

                int idtiporecurso = Convert.ToInt32(CmbTiposRecurso.SelectedValue);
                List<BE.Adapters.Reserva> reservas = reservabl.ListarActivas(Usuario.codigo, idtiporecurso, fechaLunes, fechaDomingo);
                List<BE.Adapters.Reserva> reservasxhora;
                foreach (GridDataItem item in RgHorario.MasterTableView.Items)
                {
                    int hora = Convert.ToInt32(item.GetDataKeyValue("n_hor_codigo"));
                    RadButton btn;
                    
                    for (int i = 1; i <= 7; i++)
                    {
                        reservasxhora = (from x in reservas
                                         where x.diaSemana == i
                                         && x.hora == hora
                                         select x).ToList();
                        int j = 0;
                        foreach (BE.Adapters.Reserva r in reservasxhora)
                        {

                            j++;
                            btn = new RadButton
                            {
                                ID = "BtnCancelar" + j,
                                Text = r.NombreRecurso,
                                CommandArgument = r.id.ToString(),
                                CommandName = "Cancelar",
                                OnClientClicking = "BtnCancelar_OnClientClicking",
                                RegisterWithScriptManager = true
                            };
                            btn.Icon.PrimaryIconUrl = "../assets/images/delete.png";
                            item[FechaUtil.DiaSemana(i)].Controls.Add(btn);
                        }

                    }
                }
            }
        }

        protected void RgHorario_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Cancelar") {
                int idreserva = Convert.ToInt32(e.CommandArgument);
                bool rpta = reservabl.Cancelar(idreserva);
                if (rpta) {
                    RgHorario.Rebind();
                    Alerta("Se canceló la reserva indicada");
                }
            }
        }

    }
}