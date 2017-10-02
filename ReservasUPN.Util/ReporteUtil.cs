using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Configuration;

namespace ReservasUPN.Util
{
    public class ReporteUtil
    {
        public static void ConfigurarReporteServidor(ReportViewer rv, string nombreReporte, ReportParameterCollection parametros) {

            rv.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = rv.ServerReport;

            serverReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ServidorReportes"]);
            serverReport.ReportPath = ConfigurationManager.AppSettings["ServidorReportes"] + nombreReporte;

            rv.ServerReport.SetParameters(parametros);

        }
    }
}
