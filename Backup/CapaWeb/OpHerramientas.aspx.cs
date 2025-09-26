using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb
{
    public partial class OpHerramientas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkMovimientosDocumentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/herramientas/MovDocumento.aspx", false);
        }

        protected void imgbRegistroDocumentos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/herramientas/MovDocumento.aspx", false);
        }

        protected void lnkCargaMasiva_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/pages/herramientas/CargaMasiva.aspx", false);
        }

        protected void imgbCargaMasiva_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/herramientas/CargaMasiva.aspx", false);
        }

        protected void lnkEditarCarga_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/herramientas/EditarCargaMasiva.aspx", false);
        }

        protected void imgbEditarCarga_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/herramientas/EditarCargaMasiva.aspx", false);
        }
    }
}