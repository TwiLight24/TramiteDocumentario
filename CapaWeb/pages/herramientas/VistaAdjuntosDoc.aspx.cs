using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Intellisoft.Project.Util;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using Entity = CapaEntidad;
using Negocio = CapaNegocio;

namespace CapaWeb.pages.herramientas
{
    public partial class VistaAdjuntosDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                CargarPantalla();

            ClientScript.RegisterStartupScript(GetType(), "grilla", "gridviewScroll();", true);
        }

        private void CargarPantalla()
        {
            try
            {
                Session["VerDocAdjuntos"] = null;
                Entity.CEDocumento oEDocAdjuntos = null;
                oEDocAdjuntos = new Entity.CEDocumento();

                string param1 = Request.Url.Query.Replace("?var1=", "");
                oEDocAdjuntos.IdDocumento = Convert.ToInt32(param1.ToString());
                oEDocAdjuntos = CapaNegocio.CNDocumento.VistaDocAdjuntos(oEDocAdjuntos);
                Session["VerDocAdjuntos"] = oEDocAdjuntos.LstDocumento;
                

                cmbDocAdjuntos.DataSource = oEDocAdjuntos.LstDocumento;
                cmbDocAdjuntos.DataTextField = "DocAdjuntos";
                cmbDocAdjuntos.DataValueField = "DocAdjuntos";
                cmbDocAdjuntos.DataBind();

                cmbDocAdjuntos.SelectedIndex = 0;

                if (cmbDocAdjuntos.SelectedValue != "") {
                    string nombreArchivo = cmbDocAdjuntos.SelectedValue;
                    string ruta = ResolveUrl($"~/adjuntos/{nombreArchivo}");
                    pdfViewer.Attributes["src"] = ruta;
                }


            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void Selection_Change(object sender, EventArgs e)
        {
            if (cmbDocAdjuntos.SelectedValue != ""){
                string nombreArchivo = cmbDocAdjuntos.SelectedValue;
                string ruta = ResolveUrl($"~/adjuntos/{nombreArchivo}");
                pdfViewer.Attributes["src"] = ruta;
            }


        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string str_script = "window.close();";

            if (!ClientScript.IsClientScriptBlockRegistered("CloseWindows"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindows", str_script, true);
            }
        }

    }

}