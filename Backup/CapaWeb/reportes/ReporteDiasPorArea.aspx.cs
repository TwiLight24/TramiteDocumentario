using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace CapaWeb.reportes
{
    public partial class ReporteDiasPorArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtFecIni.Text.Length > 0 && txtFecFin.Text.Length > 0)
            {
                DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
                DateTime FecFin = Convert.ToDateTime(txtFecFin.Text);
                reportes.ReportDiasPorArea rpt = new ReportDiasPorArea();
                rpt.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1");
                rpt.SetParameterValue(0, FecIni);
                rpt.SetParameterValue(1, FecFin);
                rpt.Load(Server.MapPath("~/reportes/ReportDiasPorArea.rpt"));
                CrystalReportViewer1.ReportSource = rpt;
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
                DateTime FecFin = Convert.ToDateTime(txtFecFin.Text);
                reportes.ReportDiasPorArea rpt = new ReportDiasPorArea();
                rpt.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1");
                rpt.SetParameterValue(0, FecIni);
                rpt.SetParameterValue(1, FecFin);
                rpt.Load(Server.MapPath("~/reportes/ReportDiasPorArea.rpt"));
                CrystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            reportes.ReportDiasPorArea rpt = new ReportDiasPorArea();
            rpt.Load(HttpContext.Current.Server.MapPath("~/reportes/ReportDiasPorArea.rpt"));
            rpt.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1", "192.168.1.3", "GMI_JCWEB_WTD");
            rpt.PrintToPrinter(1, false, 0, 0);
        }
    }
}