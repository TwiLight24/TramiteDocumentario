using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using Entity = CapaEntidad.Seguridad;

namespace CapaWeb
{
    public partial class PedidoUtiles : System.Web.UI.MasterPage
    {
        public bool mnu_config = false;
        public bool mnu_mant = false;
        public bool mnu_admin = false;
        public bool mnu_cons = false;
        public bool op_301 = false; //mi timesheet
        public string nombreSistema = string.Empty;


        public string ServerRootPath
        {
            get
            {
                //string completePath = Page.ResolveUrl("~/pages/Password.aspx"); // "http://" + this.Request.Url.Authority;
                string completePath = this.Request.Url.AbsoluteUri.Replace(this.Request.Url.AbsolutePath, "");


                return completePath;
                /*string completePath = this.Server.MapPath(this.Request.ApplicationPath).Replace("/", "\\");
                string applicationPath = this.Request.ApplicationPath.Replace("/", "\\");
                string rootPath = completePath.Replace(applicationPath, string.Empty);
                
                return rootPath;*/
            }
        }

        /// <summary>
        /// Habilita o no la opcion de administracion de TimeSheet para el usuario
        /// </summary>
        private void HabilitarAdmTs()
        {
            //bool EsValido = Intellisoft.Project.Util.Utilitario.ValidarUsrEditarTs();
            //Entidad.Usuario UsuarioActual = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual();
            //if (UsuarioActual.IdRol == 2)
            //    this.imgbAdmin.Visible = EsValido;

            //if (op_301)
            //    op_301 = EsValido;
        }

        private void Password()
        {
            CapaEntidad.ParametroDetalle objDetalle = new CapaEntidad.ParametroDetalle();
            objDetalle = CapaNegocio.ParametroDetalle.DatosFileUpload();
            string completePath = "http://192.168.1.9:82/" + "pages/Password.aspx";
            string javascript = "function NewWindow() { window.open";
            javascript += "('" + completePath + "','Password','width=330,height=165,toolbar=no,location=no, directories=no,status=no,menubar=no,scrollbars=no,resizable=no'); }";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", javascript, true);
            imgbAgregarPassword.Attributes.Add("OnClick", "javascript:NewWindow()");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Intellisoft.Project.Util.Seguridad.ValidarSesionActiva();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreSistema = ConfigurationManager.AppSettings["NombreSistema"];

            lblUser.Text = (Session["UsuarioActual"] as CapaEntidad.Usuario).NombreEmpleado;

            //obtiene las opciones de menu
            List<Entity.RolFuncionalidad> lstRolFuncionalidad = null;
            lstRolFuncionalidad = (Session["FuncionalidadActual"] as List<Entity.RolFuncionalidad>);
            foreach (Entity.RolFuncionalidad objData in lstRolFuncionalidad)
            {
                if (objData.IdMenu == "CFG") mnu_config = true;
                if (objData.IdMenu == "MTO") mnu_mant = true;
                if (objData.IdMenu == "ADM") mnu_admin = true;
                if (objData.IdMenu == "CON") mnu_cons = true;
                if (objData.IdFuncionalidad == 301) op_301 = true;
            }

            this.HabilitarAdmTs();

            this.Password();
        }
        protected void imgbLogOut_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Inicio.aspx");
        }
        protected void imgbInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PeUtiles/Principal.aspx", false);
        }



        protected void imgbConfig_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/OpPedido.aspx", false);
        }

        protected void imgbMant_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/OpAdministracion.aspx", false);
        }

        protected void imgbAdmin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PeUtiles/OpHerramientas.aspx", false);
        }

        protected void imgbCons_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/PeUtiles/OpAdministracion.aspx", false);
        }
    }
}