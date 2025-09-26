using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb
{
    public partial class OpDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbRegistroDocumentos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/documento/Documento.aspx");
        }

        protected void lnkRegistroDocumentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/documento/Documento.aspx");
        }

        protected void lnkDistribucion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/documento/Distribucion.aspx");
        }

        protected void imgbDistribucion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/documento/Distribucion.aspx");
        }

        protected void imgbConsolidacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkConsolidacion_Click(object sender, EventArgs e)
        {

        }
    }
}