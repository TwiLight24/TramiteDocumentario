using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;

namespace CapaWeb.reportes
{
    public partial class ReporteCargoRechazo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int obj = 0;
            if (Session["Cargo"] != null)
            {
                obj = Convert.ToInt32(Session["Cargo"].ToString());
            }
            if (txtBuscar.Text.Length > 0)
            {
                obj = Convert.ToInt32(txtBuscar.Text);
            }
            if (obj == 0)
            {
                obj = 5;
            }

            ReportCargoRechazo rpt = new ReportCargoRechazo();
            rpt.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1");
            rpt.SetParameterValue(0, obj);
            CrystalReportViewer1.ReportSource = rpt;


        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            string obj = txtBuscar.Text;
            reportes.ReportCargoRechazo rpt = new ReportCargoRechazo();
            rpt.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1");
            rpt.SetParameterValue(0, obj);
            CrystalReportViewer1.ReportSource = rpt;

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            //CrystalReportViewer1.();
            //reportes.ReportCargo rpt = new ReportCargo();
            //rpt.PrintToPrinter(1, true, 0, 0); 
            string obj = txtBuscar.Text;
            reportes.ReportCargoRechazo report = new reportes.ReportCargoRechazo();
            report.Load(HttpContext.Current.Server.MapPath("~/reportes/ReportCargoRechazo.rpt"));
            report.SetDatabaseLogon("Desarrollo", "Gm1D35aApl1");
            report.SetParameterValue(0, obj);
            report.PrintToPrinter(1, false, 0, 0);
        }
    }
}