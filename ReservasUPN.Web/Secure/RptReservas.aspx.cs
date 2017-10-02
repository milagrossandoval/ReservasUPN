using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.Web.App_Code;
using Microsoft.Reporting.WebForms;
using ReservasUPN.BL;

namespace ReservasUPN.Web.Secure
{
    public partial class RptReservas : PageAdapter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
                DpInicio.SelectedDate = DateTime.Today;
                DpFin.SelectedDate = DateTime.Today;
            }
        }

        protected void BtnReporte_Click(object sender, EventArgs e)
        {

            ReportViewer1.Visible = true;

            List<BE.Modelos.RecursoTipo> tipos = new List<BE.Modelos.RecursoTipo>();

            (from i in CblTipos.Items.Cast<ListItem>()
             where i.Selected
             select
             new BE.Modelos.RecursoTipo
             {
                 id = int.Parse(i.Value),
                 descripcion = i.Text
             }).ToList().ForEach(i => tipos.Add(i));

            string sede = CmbSedes.SelectedValue;
            DateTime fechainicio = DpInicio.SelectedDate.Value;
            DateTime fechafin = DpFin.SelectedDate.Value;
            string tiporec = Util.RecursoTipoUtil.ListToStringId(tipos);
            string recurso = TxtRecurso.Text;
            string usuario = TxtCodUsuario.Text;
            string nomusuario = TxtNomUsuario.Text;
            string asistencia = CmbAsistencia.SelectedValue;
            string estado = CmbEstado.SelectedValue;
            string usuariores = TxtCodUsuarioRes.Text;
            string nomusuariores = TxtNomUsuarioRes.Text;
            string nombresede = CmbSedes.Text;
            string tiporecdes = Util.RecursoTipoUtil.ListToStringDes(tipos);
            string asistenciades = CmbAsistencia.Text;
            string estadodes = CmbEstado.Text;
            string usuariogen = Usuario.NombreCompleto;

            ReportParameterCollection parametros = new ReportParameterCollection();

            parametros.Add(new ReportParameter("P_SEDE",sede));
            parametros.Add(new ReportParameter("P_FINICIO", fechainicio.ToString("dd/MM/yyyy")));
            parametros.Add(new ReportParameter("P_FFIN", fechafin.ToString("dd/MM/yyyy")));

            parametros.Add(new ReportParameter("P_TIPOREC", tiporec));
            parametros.Add(new ReportParameter("P_RECURSO", recurso));
            parametros.Add(new ReportParameter("P_USUARIO", usuario));
            parametros.Add(new ReportParameter("P_NOMUSUARIO", nomusuario));

            parametros.Add(new ReportParameter("P_ASISTENCIA", asistencia));
            parametros.Add(new ReportParameter("P_ESTADO", estado));
            parametros.Add(new ReportParameter("P_USUARIORES", usuariores));
            parametros.Add(new ReportParameter("P_NOMUSUARIORES", nomusuariores));

            parametros.Add(new ReportParameter("P_NOMBRESEDE", nombresede));
            parametros.Add(new ReportParameter("P_TIPORECDES", tiporecdes));
            parametros.Add(new ReportParameter("P_ASISTENCIADES", asistenciades));
            parametros.Add(new ReportParameter("P_ESTADODES", estadodes));
            parametros.Add(new ReportParameter("P_USUARIOGEN", usuariogen));

            ConfigurarReporteServidor(ReportViewer1, "RptReservas","Reporte de Reservas", parametros);

            ReportViewer1.ServerReport.Refresh();

        }

        protected void CblTipos_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem item in CblTipos.Items) {
                item.Selected = true;
            }
        }
    }
}