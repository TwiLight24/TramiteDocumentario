using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intellisoft.Project.Util;

namespace CapaWeb
{
    public partial class OpConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkTSDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteCargo.aspx");
            //Response.Redirect("~/pages/reportes/ReporteCargo.aspx");
        }

        protected void imgbTSDetalle_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteCargo.aspx");
            //Response.Redirect("~/pages/reportes/ReporteCargo.aspx");
        }

        protected void imgbTSTotalizado_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteCargoRechazo.aspx");
        }

        protected void lnkTSTotalizado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteCargoRechazo.aspx");
        }

        protected void lnkTSConsolidado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteVencimiento.aspx");
        }

        protected void imgbTSConsolidado_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteVencimiento.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteMovimientos.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteMovimientos.aspx");
        }

        protected void lnkReportDiasPorArea_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteDiasPorArea.aspx");
        }

        protected void imgbReportDiasPorArea_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteDiasPorArea.aspx");
        }

        protected void lnkReportDiasPorUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteDiasPorUsuario.aspx");
        }

        protected void imgbReportDiasPorUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteDiasPorUsuario.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void lnkReportFacturasPorPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportes/ReporteFinanzasPagos.aspx");
        }

        protected void imgbReportFacturasPorPagar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/reportes/ReporteFinanzasPagos.aspx");
        }

    }
}