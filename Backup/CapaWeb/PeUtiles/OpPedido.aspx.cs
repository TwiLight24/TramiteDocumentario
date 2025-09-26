using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.PeUtiles
{
    public partial class OpPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkRegistroPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Pedido.aspx", false);
        }

        protected void imgbRegistroPedidos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/Pedido.aspx", false);
        }
    }
}