using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.PeUtiles
{
    public partial class OpHerramientas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbSupervision_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Herramienta/AprobarPedido.aspx", false);
        }

        protected void lnkSupervision_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Herramienta/AprobarPedido.aspx", false);
        }

        protected void imgbConsolidacion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Herramienta/Consolidado.aspx", false);
        }

        protected void lnkConsolidacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Herramienta/Consolidado.aspx", false);
        }
    }
}