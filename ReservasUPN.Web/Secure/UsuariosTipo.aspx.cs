using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.ComponentModel;
using System.Data;
using ReservasUPN.BE.Modelos;
using System.Collections;
using ReservasUPN.BL;
using ReservasUPN.Web.App_Code;

namespace ReservasUPN.Web.Secure
{
    public partial class UsuariosTipo : PageAdapter
    {

        private UsuarioTipoBL usuariotipobl = new UsuarioTipoBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RgTipos_InsertCommand(object source, GridCommandEventArgs e) { 
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            string a_nombre = (string)values["nombre"];
            bool a_estado = (bool)values["estado"];

            UsuarioTipo obj = new UsuarioTipo {nombre = a_nombre, estado = a_estado };
            usuariotipobl.Grabar(obj);

        }

        protected void RgTipos_UpdateCommand(object source, GridCommandEventArgs e) {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            string a_nombre = (string)values["nombre"];
            bool a_estado = (bool)values["estado"];

            UsuarioTipo obj = new UsuarioTipo { id = a_id, nombre = a_nombre, estado = a_estado };
            usuariotipobl.Actualizar(obj);
        }


    }
}