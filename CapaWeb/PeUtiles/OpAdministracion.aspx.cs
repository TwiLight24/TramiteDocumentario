using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.PeUtiles
{
    public partial class OpAdministracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/administracion/PlantillaUsuario.aspx", false);
        }

        protected void imgbUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/administracion/PlantillaUsuario.aspx", false);
        }

        protected void lnkPlantillas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/administracion/PlantillaGenerar.aspx", false);
        }

        protected void imgbPlantillas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/pages/administracion/PlantillaGenerar.aspx", false);
        }

        protected void lnkParametros_Click(object sender, EventArgs e)
        {

        }

        protected void imgbParametros_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}