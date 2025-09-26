using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using System.Data;
using CapaNegocio;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;

namespace CapaWeb.reportes
{
    public partial class ReporteVencimiento : System.Web.UI.Page
    {
        private DataTable dt;
        //private ReportCargo RPT;

        protected void Page_Load(object sender, EventArgs e)
        {
            string obj = "";

            if (txtBuscar.Text.Length > 0 ){
            obj = txtBuscar.Text;
            }
            if(obj.Length == 0){
                obj = "2041";
            }


            ReportVencimiento rpt = new ReportVencimiento();

          
            if (rpt != null)
            {
                if (rpt.IsLoaded)
                {
                    rpt.Close();
                    rpt.Dispose();
                }
            }

            CNMovimientos car = new CNMovimientos();
            dt = car.ReporteVencimientos(obj);
            rpt.SetDatabaseLogon("sa", "B1Admin");
            rpt.SetDataSource(this.dt);
            CrystalReportViewer1.ReportSource = rpt;

           // ActualizarReport("0001-228184");
            
            //}
            //try
            //{
            //    CNCargos car = new CNCargos();
            //    dt = car.ListarCargosById(Convert.ToInt32(txtBuscar.Text));
            //    RPT.SetDatabaseLogon("sa", "B1Admin");
            //    RPT.SetDataSource(dt);
            //    CrystalReportViewer1.ReportSource = this.RPT;
            //}
            //catch (Exception ex)
            //{ Intellisoft.Project.Util.Log.RegistrarIncidencia(ex); 
            //}
        }



        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            //reportes.ReportVencimiento rpt = new ReportVencimiento();          
            //CNMovimientos car = new CNMovimientos();
            //dt = car.ReporteVencimientos(txtBuscar.Text);
            //rpt.SetDatabaseLogon("sa", "B1Admin");
            //rpt.SetDataSource(this.dt);
            //CrystalReportViewer1.ReportSource = rpt;

            try
            {
                reportes.ReportVencimiento rpt = new ReportVencimiento();
                rpt.SetDatabaseLogon("sa", "B1Admin");
                rpt.SetParameterValue(0, txtBuscar.Text);
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
            //CrystalReportViewer1.();
            //reportes.ReportCargo rpt = new ReportCargo();
            //rpt.PrintToPrinter(1, true, 0, 0); 

            reportes.ReportCargo report = new reportes.ReportCargo();
            report.Load(HttpContext.Current.Server.MapPath("~/reportes/ReportCargo.rpt"));
            report.SetDatabaseLogon("sa", "B1Admin", "192.168.1.2", "GMI_JCWEB_WTD");
            report.PrintToPrinter(1, false, 0, 0);
        }
    }
}