using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;
using Telerik.Web.UI;
using ReservasUPN.IBL;

namespace ReservasUPN.Web.Secure
{
    public partial class HorasDisponibles : PageAdapter
    {

        IRecursoTipoHoraBL recursotipohorabl = new RecursoTipoHoraBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
                CmbSedes.SelectedIndex = 0;
            }
        }

        //protected void CmbTiposRecurso_DataBound(object sender, EventArgs e)
        //{
        //    CmbTiposRecurso.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("--Seleccione--","0"));
        //}

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            List<BE.Modelos.RecursoTipoHora> listaupd = new List<BE.Modelos.RecursoTipoHora>();
            int a_idrecurso, a_idtipousuario, a_nrohoras;
            TextBox TxtNroHoras;
            foreach (GridDataItem item in RgHoras.MasterTableView.Items)
            {
                a_idrecurso = Convert.ToInt32(item.GetDataKeyValue("id"));
                foreach (GridDataItem ditem in item.ChildItem.NestedTableViews[0].Items)
                {
                    a_idtipousuario = (int)ditem.GetDataKeyValue("usuarioTipo");
                    TxtNroHoras = (TextBox)ditem.FindControl("TxtNroHoras");
                    a_nrohoras = string.IsNullOrEmpty(TxtNroHoras.Text.Trim()) ? 0 : int.Parse(TxtNroHoras.Text);
                    listaupd.Add(new BE.Modelos.RecursoTipoHora
                    {
                        recursoTipo = a_idrecurso,
                        usuarioTipo = a_idtipousuario,
                        nroHoras = a_nrohoras
                    });
                }
            }
            
            bool rpta = recursotipohorabl.Actualizar(listaupd);
            if (rpta)
            {
                alerta("Se registró con éxito");
            }
            else
            {
                alerta("Error al registrar");
            }
        }

        protected void RgHoras_DataBound(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = RgHoras.MasterTableView.Items.Count > 0;
        }

        protected void RgHoras_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            switch (e.DetailTableView.Name)
            {
                case "Detalle":
                    {
                        int idtiporecurso = Convert.ToInt32( dataItem.GetDataKeyValue("id"));
                        e.DetailTableView.DataSource = recursotipohorabl.Listar(idtiporecurso);
                        break;
                    }
            }
        }


    }
}