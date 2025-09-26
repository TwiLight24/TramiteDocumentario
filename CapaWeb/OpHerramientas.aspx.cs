using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intellisoft.Project.Util;

namespace CapaWeb
{
    public partial class OpHerramientas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Utilitario.ObtenerUsuarioActual().IdUsuario;

            //if (id.Equals(34) || id.Equals(151) || id.Equals(44) || id.Equals(25))
            if (id.Equals(34) || id.Equals(151) || id.Equals(44) || id.Equals(193))
            {
                divPlanilla.Visible = true;
            }

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

        protected void lnkAsistentePagosDocumentoAdjuntos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/herramientas/VistaAsistentePagos.aspx", false);
        }

        protected void imgbAsistentePagosDocumentoAdjuntos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/pages/herramientas/VistaAsistentePagos.aspx", false);
        }
    }
}