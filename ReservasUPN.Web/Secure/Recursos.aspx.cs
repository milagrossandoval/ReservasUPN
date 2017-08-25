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

namespace ReservasUPN.Web.Secure
{
    public partial class Recursos : PageAdapter
    {
        private RecursoBL recursobl = new RecursoBL();

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

            //if (a_codigo ==)
            //{
            //    if (!a_estado)
            //    {
            //        alerta("No se puede deshabilitar el mismo recurso");
            //        return;
            //    }
            //}

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
            recursobl.Grabar(obj);
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
    }
}