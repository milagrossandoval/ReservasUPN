using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.Web.App_Code;
using ReservasUPN.BL;
using Telerik.Web.UI;
using System.Collections;
using ReservasUPN.BE.Adapters;
using ReservasUPN.IBL;
using ReservasUPN.BE.Modelos;

namespace ReservasUPN.Web.Secure
{
    public partial class Recursos : PageAdapter
    {
        private IRecursoBL recursobl = new RecursoBL();
        private IRecursoTipoHorarioBL recursotipohorariobl = new RecursoTipoHorarioBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
        }

        protected void CmbTipos_OnDataBound(object sender, EventArgs e)
        {
            RadComboBox CmbTipos = (RadComboBox)sender;
            string tipo = ((HiddenField)CmbTipos.Parent.FindControl("HfTipo")).Value;
            try
            {

                CmbTipos.SelectedValue = tipo;
            }
            catch (Exception ex)
            {
            }
        }

        protected void RgRecursos_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            string a_codigo = (string)(editableItem.GetDataKeyValue("codigo"));
            string a_descripcion = (string)values["descripcion"];
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            string a_caracteristicas = (string)values["caracteristicas"];
            bool a_estado = (bool)values["estado"];
            BE.Modelos.Recurso obj = new BE.Modelos.Recurso {id = a_id, codigo = a_codigo, descripcion = a_descripcion, tipoRecurso = a_tipo, caracteristicas = a_caracteristicas, estado = a_estado };
            recursobl.Actualizar(obj);
        }

        protected void RgRecursos_InsertCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            string a_codigo = (string)values["codigo"];
            string a_descripcion = (string)values["descripcion"];
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            string a_caracteristicas = (string)values["caracteristicas"];
            bool a_estado = (bool)values["estado"];

            BE.Modelos.Recurso obj = new BE.Modelos.Recurso { codigo = a_codigo, descripcion = a_descripcion, tipoRecurso = a_tipo, caracteristicas = a_caracteristicas, estado = a_estado };
            int id = recursobl.Grabar(obj);

            List<RecursoTipoHorario> horarioDefecto = recursotipohorariobl.Buscar(a_tipo);
            if (horarioDefecto.Count > 0) {
                HfNuevoRecurso.Value = id.ToString();
                HfNuevoRecursoTipo.Value = a_tipo.ToString();
                WinConfirmacion.VisibleOnPageLoad = true;
            }    
            
        }

        protected void RgRecursos_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "InitInsert":
                    ((GridBoundColumn)RgRecursos.MasterTableView.GetColumnSafe("codigo")).ReadOnly = false;
                    break;
                case "Edit":
                    ((GridBoundColumn)RgRecursos.MasterTableView.GetColumnSafe("codigo")).ReadOnly = true;
                    break;
            }
        }


        protected void TabConfirmacion_OnTabClick(object sender, RadTabStripEventArgs e)
        {
            if (e.Tab.Text == "Si")
            {
                int tiporecursoid = int.Parse(HfNuevoRecursoTipo.Value);
                int recursoid = int.Parse(HfNuevoRecurso.Value);
                List<BE.Modelos.RecursoTipoHorario> horarioTipo = recursotipohorariobl.Buscar(tiporecursoid);
                List<BE.Modelos.RecursoHorario> horarioRecurso = new List<RecursoHorario>();

                horarioTipo.ForEach(h => horarioRecurso.Add(new BE.Modelos.RecursoHorario
                {
                    recurso = recursoid,
                    hora = h.hora,
                    lunes = h.lunes,
                    martes = h.martes,
                    miercoles = h.miercoles,
                    jueves = h.jueves,
                    viernes = h.viernes,
                    sabado = h.sabado,
                    domingo = h.domingo
                }));

                new RecursoHorarioBL().Grabar(horarioRecurso);
                
            }
            WinConfirmacion.VisibleOnPageLoad = false;
        }

        protected void RgRecursos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
            {
                GridEditableItem editItem = (GridEditableItem)e.Item;
                TextBox txtbx = (TextBox)editItem["caracteristicas"].Controls[0];
                txtbx.MaxLength = 500;
                txtbx.Width = 300;
                txtbx.TextMode = TextBoxMode.MultiLine;
            }
        }

        protected void RgRecursos_ExcelExportCellFormatting(object sender, ExcelExportCellFormattingEventArgs e)
        {
            if (e.FormattedColumn.UniqueName == "Editar")
            {
                //CheckBox chk = (CheckBox)e.Cell.Controls[0];
                e.Cell.Text = "";
            }
            else if (e.FormattedColumn.UniqueName == "estado")
            {
                GridDataItem item = ((GridDataItem)(e.Cell.Controls[0].NamingContainer));
                bool estado = (bool) item.GetDataKeyValue("estado");
                e.Cell.Text = estado ? "Activo" : "Inactivo";
            }
        }
    }
}