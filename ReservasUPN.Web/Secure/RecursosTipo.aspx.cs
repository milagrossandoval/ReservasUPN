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
using ReservasUPN.IBL;

namespace ReservasUPN.Web.Secure
{
    public partial class RecursosTipo : PageAdapter
    {
        private IRecursoTipoBL recursotipobl = new RecursoTipoBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CmbSedes.DataSource = new SedeBL().ListarxUsuario(Usuario);
                CmbSedes.DataBind();
            }
        }

        protected void RgTipos_InsertCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            string a_descripcion = (string)values["descripcion"];
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            bool a_estado = (bool)values["estado"];
            int a_sede = int.Parse(CmbSedes.SelectedValue);

            BE.Modelos.RecursoTipo obj = new BE.Modelos.RecursoTipo { descripcion = a_descripcion , tipoHora = a_tipo, sede = a_sede, estado = a_estado };
            try
            {
                recursotipobl.Grabar(obj);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("unique index 'IX_RecursoTipo'"))
                {
                    alerta("La descripción ingresada ya existe.");
                    return;
                }
            }

        }

        protected void RgTipos_UpdateCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            string a_descripcion = (string)values["descripcion"];
            int a_tipo = int.Parse(((RadComboBox)e.Item.FindControl("CmbTipos")).SelectedValue);
            bool a_estado = (bool)values["estado"];
            int a_sede = int.Parse(CmbSedes.SelectedValue);

            BE.Modelos.RecursoTipo obj = new BE.Modelos.RecursoTipo {id=a_id, descripcion = a_descripcion, tipoHora = a_tipo, sede = a_sede, estado = a_estado };
            recursotipobl.Grabar(obj);
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

    }
}