using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReservasUPN.BE.Modelos;
using Telerik.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Configuration;

namespace ReservasUPN.Web.App_Code
{
    public class PageAdapter : System.Web.UI.Page
    {
        public BE.Adapters.Usuario Usuario
        {
            get
            {
                return (BE.Adapters.Usuario)Session["usuario"];
            }
        }

        public string Codigo
        {
            get
            {
                return Usuario.codigo;
            }
        }

        public List<Sede> Sedes
        {
            get
            {
                return Usuario.LstSedes;
            }
        }

        public void Alerta(string mensaje)
        {
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "alert('" + mensaje + "')", true);
        }

        public void EstiloSubmit(string clientid)
        {
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "Estilo", "EstiloSubmit('" + clientid + "');", true);
        }

        //public void confirmacion(string mensaje, string titulo, int ancho, int alto, string js) {
        //    RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "Confirmacion", "radconfirm('" + mensaje+ "', "+js+", "+ancho+", "+alto+", null, '"+ titulo +"', ''); return false;", true);
            
        //}

        public void ConfigurarReporteServidor(ReportViewer rv, string nombreRDL, string nombreRPT, ReportParameterCollection parametros)
        {

            rv.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = rv.ServerReport;
            rv.ServerReport.DisplayName = nombreRPT;
            serverReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ServidorReportes"]);
            serverReport.ReportPath = ConfigurationManager.AppSettings["RutaReportes"] + nombreRDL;

            rv.ServerReport.SetParameters(parametros);

        }

    
    }
}