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

namespace ReservasUPN.Web.Secure
{
    public partial class Sanciones : System.Web.UI.Page
    {
        private ISancionBL sancionbl = new SancionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void RgSanciones_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_usuario = Convert.ToInt32(values["usuario"]);
            string a_motivo = (string)values["motivo"];
            DateTime a_fechainicio = Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaInicio2")).DbSelectedDate);
            DateTime a_fechafin = Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaFin2")).DbSelectedDate);
            bool a_estado = (bool)values["estado"];

            BE.Modelos.Sancion obj = new BE.Modelos.Sancion { usuario = a_usuario, motivo = a_motivo, fechainicio = a_fechainicio, fechafin = a_fechafin, estado = a_estado };
            sancionbl.Grabar(obj);
        }

        protected void RgSanciones_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            int a_id = (int)(editableItem.GetDataKeyValue("id"));
            int a_usuario = (int)(editableItem.GetDataKeyValue("usuario"));
            string a_motivo = (string)values["motivo"];
            DateTime a_fechainicio = Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaInicio2")).DbSelectedDate);
            DateTime a_fechafin = Convert.ToDateTime(((RadDatePicker)e.Item.FindControl("txtFechaFin2")).DbSelectedDate);
            bool a_estado = (bool)values["estado"];


            BE.Modelos.Sancion obj = new BE.Modelos.Sancion {id = a_id, usuario = a_usuario, motivo = a_motivo, fechainicio = a_fechainicio, fechafin = a_fechafin, estado = a_estado };
            sancionbl.Actualizar(obj);
        }
    }
}