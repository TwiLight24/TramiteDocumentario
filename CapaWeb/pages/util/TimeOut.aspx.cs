using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CapaWeb.pages.util
{
    public partial class TimeOut : System.Web.UI.Page
    {
        public string nombreSistema = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreSistema = ConfigurationManager.AppSettings["NombreSistema"];
        }

        protected void linkSession_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("~/Inicio.aspx");
        }
    }
}