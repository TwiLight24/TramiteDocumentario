using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaWeb.pages.mantenimiento
{
    public partial class VerPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarPDF();
            }
        }

        private void CargarPDF()
        
        {
            try
            {

                string ID = Request.QueryString["IdDocumento"];

                string name = @"\\192.168.1.2\b1_shr\WebDocumentaria\" + ID + ".pdf";

                string FileName = name;

                Response.ClearContent();
                //Borra todos los encabezados del flujo de memoria
                Response.ClearHeaders();
                //Añade una cabecera HTTP al flujo de salida
                Response.AddHeader("Content-Disposition", "inline;filename=" + FileName);
                //Obtiene o establece el tipo MIME de HTTP del flujo de salida
                Response.ContentType = "application/pdf";
                //Escribe el contenido del archivo especificado en un flujo de salida de respuesta HTTP como un bloque de archivos
                Response.WriteFile(FileName);
                //envía toda la salida del buffer al cliente
                Response.Flush();
                //Borra todas las salidas de contenidos del flujo de memoria
                Response.Clear();
            }
            catch (Exception)
            {

                Intellisoft.Project.Util.Utilitario.MostrarMensaje("No existe el documento seleccionado en el servidor.Contáctese con el Administrador ");
            }
        }
    }
}