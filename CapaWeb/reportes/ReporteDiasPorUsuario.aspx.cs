using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.reportes
{
    public partial class ReporteDiasPorUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtFecIni.Text.Length > 0 && txtFecFin.Text.Length > 0)
            {
                DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
                DateTime FecFin = Convert.ToDateTime(txtFecFin.Text);
                reportes.ReportDiasPorUsuario rpt = new ReportDiasPorUsuario();
                rpt.SetDatabaseLogon("sa", "B1Admin");
                rpt.SetParameterValue(0, FecIni);
                rpt.SetParameterValue(1, FecFin);
                rpt.Load(Server.MapPath("~/reportes/ReportDiasPorUsuario.rpt"));
                CrystalReportViewer1.ReportSource = rpt;
                CrystalReportViewer1.RefreshReport();
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
                DateTime FecFin = Convert.ToDateTime(txtFecFin.Text);
                reportes.ReportDiasPorUsuario rpt = new ReportDiasPorUsuario();
                rpt.SetDatabaseLogon("sa", "B1Admin");
                rpt.SetParameterValue(0, FecIni);
                rpt.SetParameterValue(1, FecFin);
                rpt.Load(Server.MapPath("~/reportes/ReportDiasPorUsuario.rpt"));
                CrystalReportViewer1.ReportSource = rpt;
                CrystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
            DateTime FecFin = Convert.ToDateTime(txtFecFin.Text);

            Response.Write("<script>window.alert('hola');</script>"); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime FecIni = Convert.ToDateTime(txtFecIni.Text);
            Response.Write("<script>window.alert('" + txtFecIni.Text + "');</script>"); 
        }
    }
}