using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.util;
using System.IO;
using System.Configuration;
using CapaWeb.pages.herramientas;

namespace CapaWeb.pages.util
{
    public partial class UploadEngine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void checkfilesize(object source, ServerValidateEventArgs args)
        {
            //try
            //{
            //    string data = args.Value;

            //    args.IsValid = true;

            //    if (fileUpload.HasFile)
            //    {

            //            fileUpload.PostedFile.InputStream.Dispose();
            //            txtDescripcion.Text = string.Empty;
            //            const string js = "window.parent.onComplete(3, 'Por políticas de seguridad, no esta permitido la carga de archivos ejecutables. Por favor ingrese un nuevo sustento válido.','','0 de 0 Bytes'); window.parent.setProgress(0);";
            //            ScriptManager.RegisterStartupScript(this, typeof(UploadEngine), "progress", js, true);
                    
            //    }
            //}
            //catch (Exception ex)
            //{
            //       Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            //    Intellisoft.Project.Util.Log.SaveLog(ex.Message);
            //}
        }


        public  string cargar (){

            CargaMasiva cm = new CargaMasiva();

            if (fileUp.HasFile)
            {
                string FileName = Path.GetFileName(fileUp.PostedFile.FileName);
                string Extension = Path.GetExtension(fileUp.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                fileUp.SaveAs(FilePath);
                //cm.Import_To_Grid(FilePath, Extension, "1");
            }
            return "-1";

        
        }
    }
}