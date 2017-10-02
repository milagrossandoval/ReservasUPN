using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReservasUPN.BL;
using Telerik.Web.UI;
using System.Collections;
using ReservasUPN.Web.App_Code;

namespace ReservasUPN.Web.Secure
{
    public partial class Usuarios : PageAdapter
    {
        private UsuarioBL usuariobl = new UsuarioBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
        }

        protected void RgUsuarios_InsertCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            string a_codigo = (string)values["codigo"];
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            bool a_estado = (bool)values["estado"];

            BE.Modelos.Usuario obj = new BE.Modelos.Usuario { codigo = a_codigo, tipoUsuario = a_tipo, estado = a_estado };
            usuariobl.Grabar(obj);

        }

        protected void RgUsuarios_UpdateCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            string a_codigo = (string)(editableItem.GetDataKeyValue("codigo"));
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            bool a_estado = (bool)values["estado"];

            if (a_codigo == Usuario.codigo) 
            {
                if (!a_estado) {
                    Alerta("No se puede deshabilitar su mismo usuario");
                    return;
                }
            }

            BE.Modelos.Usuario obj = new BE.Modelos.Usuario { id = a_id, codigo = a_codigo, tipoUsuario = a_tipo, estado = a_estado };
            usuariobl.Actualizar(obj);
        }

        protected void CmbTipos_OnDataBound(object sender, EventArgs e)
        {
            RadComboBox CmbTipos = (RadComboBox)sender;
            string tipo = ((HiddenField)CmbTipos.Parent.FindControl("HfTipo")).Value;
            try{
                
                CmbTipos.SelectedValue = tipo;
            }
            catch (Exception ex) { 
            }
        }

        protected void RgUsuarios_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName) {
                case "InitInsert":
                    ((GridBoundColumn)RgUsuarios.MasterTableView.GetColumnSafe("codigo")).ReadOnly = false;
                    break;
                case "Edit":
                    ((GridBoundColumn)RgUsuarios.MasterTableView.GetColumnSafe("codigo")).ReadOnly = true;
                    break;
            }
        }


        
    }
}