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
    public partial class ReporteFinanzasPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (txtBuscar.Text.Length > 0)
            //{
            //    //obj = Convert.ToInt32(txtBuscar.Text);
            //    try
            //    {
            //        reportes.ReportFinanzasPagos rpt = new ReportFinanzasPagos();
            //        rpt.SetDatabaseLogon("sa", "B1Admin");
            //        rpt.SetParameterValue(0, Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario);
            //        rpt.SetParameterValue(1, txtBuscar.Text);
            //        CrystalReportViewer1.ReportSource = rpt;
            //    }
            //    catch (Exception ex)
            //    {
            //        Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            //        Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            //    }
            //}
            if (!IsPostBack)
            {
                Cargar();
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    reportes.ReportFinanzasPagos rpt = new ReportFinanzasPagos();
            //    rpt.SetDatabaseLogon("sa", "B1Admin");
            //    rpt.SetParameterValue(0, Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario);
            //    rpt.SetParameterValue(1, txtBuscar.Text);
            //    CrystalReportViewer1.ReportSource = rpt;
            //}
            //catch (Exception ex)
            //{
            //    Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            //    Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            //}
            Cargar();
        }

        private void Cargar()
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/reportes/Report2.rdlc");

            dsPagoFi dsEmployees = GetData();

            ReportDataSource datasource = new ReportDataSource("dsPagoFi", dsEmployees.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private dsPagoFi GetData()
        {
            SqlCommand cmd = new SqlCommand("USP_Reporte_FacturasPorPagar " + Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario + ",'" + txtBuscar.Text + "'");

            using (SqlConnection con = new SqlConnection("server=192.168.1.2;database=GMI_JCWEB_WTD;User ID=sa;Password=B1Admin;Persist Security Info=True;"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;

                    using (dsPagoFi dsEmployees = new dsPagoFi())
                    {
                        sda.Fill(dsEmployees, "V_REPORTE_PAGO_FINANZAS");

                        return dsEmployees;
                    }
                }
            }
        }
        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}