
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using System.Data;
using CapaNegocio;


using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;

namespace CapaWeb.reportes
{
    public partial class ReporteCargo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    Cargar();
                }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/reportes/Report1.rdlc");

            dsCargo dsEmployees = GetData();

            ReportDataSource datasource = new ReportDataSource("dsCargo", dsEmployees.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private dsCargo GetData()
        {
            string obj = "0";
            if (Session["Cargo"] != null)
            {
                obj = (Session["Cargo"].ToString());
            }
            if (txtBuscar.Text.Length > 0)
            {
                obj = (txtBuscar.Text);
            }
            if (obj == "0")
            {
                obj = "5";
            }

            SqlCommand cmd = new SqlCommand("USP_REPORTE_CARGO " + obj);

            using (SqlConnection con = new SqlConnection("server=192.168.1.2;database=GMI_JCWEB_WTD;User ID=sa;Password=B1Admin;Persist Security Info=True;"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;

                    using (dsCargo dsEmployees = new dsCargo())
                    {
                        sda.Fill(dsEmployees, "DataTable1");
                        return dsEmployees;
                    }
                }
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            //CrystalReportViewer1.();
            //reportes.ReportCargo rpt = new ReportCargo();
            //rpt.PrintToPrinter(1, true, 0, 0); 

            //reportes.ReportCargo report = new reportes.ReportCargo();
            //report.Load(HttpContext.Current.Server.MapPath("~/reportes/ReportCargo.rpt"));
            //report.SetDatabaseLogon("sa", "B1Admin", "192.168.1.2", "GMI_JCWEB_WTD");
            //report.PrintToPrinter(1, false, 0, 0);
        }
    }
}