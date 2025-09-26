using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using CapaWeb.pages.herramientas;
using System.IO;



namespace CapaWeb.pages.util
{
    public partial class FileUpload : System.Web.UI.Page
    {
        public string nombreSistema = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            nombreSistema = ConfigurationManager.AppSettings["NombreSistema"];

            if (!this.IsPostBack)
            {
                //HablitarControles();
            }
        }

        protected void hdRefereshGrid_ValueChanged(object sender, EventArgs e)
        {

        }
        protected void imgBtnDel_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void imgbDownload_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void gvNewFiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {


        }

        protected void btnCargar_Click1(object sender, EventArgs e)
        {
            CargaMasiva cm = new CargaMasiva();

            if (fileUp.HasFile)
            {
                string FileName = Path.GetFileName(fileUp.PostedFile.FileName);
                string Extension = Path.GetExtension(fileUp.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                fileUp.SaveAs(FilePath);
                //cm.Import_To_Grid(FilePath, Extension, "Yes");

            }


        }
    }
}