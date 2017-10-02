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

namespace ReservasUPN.Web.Secure
{
    public partial class RecursosHorario : PageAdapter
    {

        private IRecursoHorarioBL recursohorarioBL = new RecursoHorarioBL();
        private IRecursoTipoHorarioBL recursotipohorarioBL = new RecursoTipoHorarioBL();
        //private IHorarioBL horarioBL = new HorarioBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
            EstiloSubmit(BtnGuardar.ClientID);
        }

        protected void ChkDefault_CheckedChanged(object sender, EventArgs e)
        {
            CmbRecursos.Enabled = !ChkDefault.Checked;
        }
        
        protected void CmbSedes_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CmbTiposRecurso.DataBind();
            CmbRecursos.DataBind();
        }

        protected void CmbTiposRecurso_DataBound(object sender, EventArgs e)
        {
            CmbTiposRecurso.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));
        }

        protected void CmbRecursos_DataBound(object sender, EventArgs e)
        {
            CmbRecursos.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Seleccione ---", "0"));
        }

        protected void CmbTiposRecurso_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ChkDefault.Checked) {
                if (CmbTiposRecurso.SelectedValue != "0")
                {
                    RgHorario.Rebind();
                }
            }
        }

        protected void CmbRecursos_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!ChkDefault.Checked)
            {
                if (CmbRecursos.SelectedValue != "0")
                {
                    RgHorario.Rebind();
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<BE.Modelos.RecursoHorario> horarioRecurso = null;
            List<BE.Modelos.RecursoTipoHorario> horarioRecursoTipo = null;
            
            if(ChkDefault.Checked){
                horarioRecursoTipo = new List<BE.Modelos.RecursoTipoHorario>();
            }else{
                horarioRecurso = new List<BE.Modelos.RecursoHorario>();
            }
            
            CheckBox ChkLunes, ChkMartes, ChkMiercoles, ChkJueves, ChkViernes, ChkSabado, ChkDomingo;
            int idhora;
            foreach (GridDataItem item in RgHorario.Items) {
                idhora = (int)item.GetDataKeyValue("hora");
                ChkLunes = (CheckBox)item.FindControl("ChkLunes");
                ChkMartes = (CheckBox)item.FindControl("ChkMartes");
                ChkMiercoles = (CheckBox)item.FindControl("ChkMiercoles");
                ChkJueves = (CheckBox)item.FindControl("ChkJueves");
                ChkViernes = (CheckBox)item.FindControl("ChkViernes");
                ChkSabado = (CheckBox)item.FindControl("ChkSabado");
                ChkDomingo = (CheckBox)item.FindControl("ChkDomingo");
                
                if(ChkDefault.Checked){
                    horarioRecursoTipo.Add(new BE.Modelos.RecursoTipoHorario { 
                                    tiporecurso = int.Parse( CmbTiposRecurso.SelectedValue ),
                                    hora = idhora,
                                    lunes = ChkLunes.Checked,
                                    martes = ChkMartes.Checked,
                                    miercoles = ChkMiercoles.Checked,
                                    jueves = ChkJueves.Checked,
                                    viernes = ChkViernes.Checked,
                                    sabado = ChkSabado.Checked,
                                    domingo = ChkDomingo.Checked,
                                });
                }else{
                    horarioRecurso.Add(new BE.Modelos.RecursoHorario { 
                                    recurso = int.Parse( CmbRecursos.SelectedValue ),
                                    hora = idhora,
                                    lunes = ChkLunes.Checked,
                                    martes = ChkMartes.Checked,
                                    miercoles = ChkMiercoles.Checked,
                                    jueves = ChkJueves.Checked,
                                    viernes = ChkViernes.Checked,
                                    sabado = ChkSabado.Checked,
                                    domingo = ChkDomingo.Checked,
                                });
                }
                
            }

            bool rpta;
            if (ChkDefault.Checked)
            {
                rpta = recursotipohorarioBL.Grabar(horarioRecursoTipo);
                WinConfirmacion.VisibleOnPageLoad = true;
            }
            else {
                rpta = recursohorarioBL.Grabar(horarioRecurso);
            }

            //if (rpta) {
            //    WinConfirmacion.VisibleOnPageLoad = true;
            //}

        }

        protected void RgHorario_DataBound(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = RgHorario.Items.Count > 0;
        }

        protected void TabConfirmacion_OnTabClick(object sender, RadTabStripEventArgs e)
        {
            if (e.Tab.Text=="Si")
            {   
                int tiporecurso = int.Parse(CmbTiposRecurso.SelectedValue);
                List<BE.Adapters.Recurso> recursos = new RecursoBL().Listar(tiporecurso);
                List<BE.Modelos.RecursoTipoHorario> horarioTipo = recursotipohorarioBL.Buscar(tiporecurso);
                List<BE.Modelos.RecursoHorario> horarioRecurso = new List<BE.Modelos.RecursoHorario>();
                    
                foreach (BE.Adapters.Recurso r in recursos) {
                    horarioRecurso.Clear();
                    horarioTipo.ForEach(h => horarioRecurso.Add(new BE.Modelos.RecursoHorario { 
                                                                    recurso = r.id,
                                                                    hora = h.hora,
                                                                    lunes = h.lunes,
                                                                    martes = h.martes,
                                                                    miercoles = h.miercoles,
                                                                    jueves = h.jueves,
                                                                    viernes = h.viernes,
                                                                    sabado = h.sabado,
                                                                    domingo = h.domingo
                                                                }));

                    recursohorarioBL.Grabar(horarioRecurso);
                }
            }
            WinConfirmacion.VisibleOnPageLoad = false;
        }         

    }
}