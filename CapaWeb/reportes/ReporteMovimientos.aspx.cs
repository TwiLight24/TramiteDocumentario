using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;

namespace CapaWeb.reportes
{
    public partial class ReporteMovimientos : System.Web.UI.Page
    {
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string obj = "";

            if (txtBuscar.Text.Length > 0)
            {
                obj = txtBuscar.Text;
            }
            if (obj.Length == 0)
            {
                obj = "F001-541";
            }

            reportes.ReportMovimientos rpt = new ReportMovimientos();

            CNMovimientos car = new CNMovimientos();
            dt = car.ReporteMovimientos(obj);
            rpt.SetDatabaseLogon("sa", "B1Admin");
            rpt.SetDataSource(this.dt);
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            reportes.ReportMovimientos rpt = new ReportMovimientos();

            CNMovimientos car = new CNMovimientos();
            dt = car.ReporteMovimientos(txtBuscar.Text);
            rpt.SetDatabaseLogon("sa", "B1Admin");
            rpt.SetDataSource(this.dt);
            
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}