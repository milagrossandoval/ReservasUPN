using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.IBL;
using ReservasUPN.BL;
using Telerik.Web.UI;
using System.Collections;
using ReservasUPN.Web.App_Code;

namespace ReservasUPN.Web.Secure
{
    public partial class Sanciones : PageAdapter
    {
        private ISancionBL sancionbl = new SancionBL();
        private IRecursoTipoBL recursotipobl = new RecursoTipoBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
        }

        protected void RgSanciones_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            string a_usuario = (string)values["usuario"];
            string a_motivo = (string)values["motivo"];
            DateTime a_fechainicio = Convert.ToDateTime(values["fechainicio"]);
            DateTime a_fechafin = Convert.ToDateTime(values["fechafin"]);
            CheckBoxList ChblTiposRecurso = (CheckBoxList)e.Item.FindControl("ChblTiposRecurso");
            
            BE.Modelos.Sancion obj = new BE.Modelos.Sancion { 
                                                    usuario = a_usuario, 
                                                    motivo = a_motivo, 
                                                    fechainicio = a_fechainicio, 
                                                    fechafin = a_fechafin, 
                                                    estado = true
                                                    };

            
            (from i in ChblTiposRecurso.Items.Cast<ListItem>()
             where i.Selected
             select 
             new BE.Modelos.RecursoTipo
             {
                 id = int.Parse(i.Value)
             }).ToList().ForEach(i => obj.RecursoTipo.Add(i));
            sancionbl.Grabar(obj);
        }

        protected void RgSanciones_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            string a_usuario = (string)(editableItem.GetDataKeyValue("usuario"));
            string a_motivo = (string)values["motivo"];
            DateTime a_fechainicio = Convert.ToDateTime(values["fechainicio"]); //Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaInicio")).DbSelectedDate);
            DateTime a_fechafin = Convert.ToDateTime(values["fechafin"]);  //Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaFin")).DbSelectedDate);
            CheckBoxList ChblTiposRecurso = (CheckBoxList)e.Item.FindControl("ChblTiposRecurso");

            BE.Modelos.Sancion obj = new BE.Modelos.Sancion { id = a_id, usuario = a_usuario, motivo = a_motivo, fechainicio = a_fechainicio, fechafin = a_fechafin };
            
            (from i in ChblTiposRecurso.Items.Cast<ListItem>()
             where i.Selected
             select int.Parse(i.Value)
            ).ToList().ForEach(i => obj.RecursoTipo.Add(new BE.Modelos.RecursoTipo { id = i }));

            sancionbl.Actualizar(obj);
        }

        protected void RgSanciones_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            int a_id = (int)(((GridDataItem)e.Item).GetDataKeyValue("id"));
            sancionbl.Eliminar(a_id);
        }

        protected void RgSanciones_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "InitInsert":
                    ((GridBoundColumn)RgSanciones.MasterTableView.GetColumnSafe("usuario")).ReadOnly = false;
                    break;
                case "Edit":
                    ((GridBoundColumn)RgSanciones.MasterTableView.GetColumnSafe("usuario")).ReadOnly = true;
                    break;
            }
        }

        protected void ChblTiposRecurso_DataBound(object sender, EventArgs e)
        {
            CheckBoxList ChblTiposRecurso = (CheckBoxList)sender;
            string strSancion = ((HiddenField)ChblTiposRecurso.Parent.FindControl("HfIdSancion")).Value;
            if (!string.IsNullOrEmpty(strSancion))
            {
                int idsancion = int.Parse(strSancion);

                List<BE.Modelos.RecursoTipo> detalle = sancionbl.BuscarDetalle(idsancion);
                //List<BE.Modelos.RecursoTipo> detalle = sancionbl.ListarDetalleRecursoTipo(idsancion);
                
                (from i in ChblTiposRecurso.Items.Cast<ListItem>()
                 join x in detalle on Convert.ToInt32(i.Value) equals x.id
                select i).ToList().ForEach(i => i.Selected = true);
            }
            
        }

        protected void RgSanciones_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                RadComboBox CmbTipos = (RadComboBox)e.Item.FindControl("CmbTipos");
                int idsancion = (int)(((GridDataItem)e.Item).GetDataKeyValue("id"));
                //CmbTipos.DataSource = sancionbl.ListarDetalleRecursoTipo(idSancion);
                CmbTipos.DataSource = sancionbl.BuscarDetalle(idsancion);
                CmbTipos.DataBind();
            }
        }

    }
}