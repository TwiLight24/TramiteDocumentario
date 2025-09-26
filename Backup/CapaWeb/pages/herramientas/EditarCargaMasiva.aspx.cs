using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad;
using Intellisoft.Project.Util;

namespace CapaWeb.pages.herramientas
{
    public partial class EditarCargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //HabilitarFormulario(false, 0);
                CargarDocumentos();
                //gvwEmpleado.Columns[1].Visible = false;
                //gvwEmpleado.Columns[2].Visible = false;
            }

        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarDocumentos()
        {
            try
            {
                Entity.CargaMasiva oEDocumentos = null;
                oEDocumentos = new Entity.CargaMasiva();
                if (!chkEnviados.Checked)
                {
                    oEDocumentos.Situacion = "O";
                }
                else {
                    oEDocumentos.Situacion = "C";
                }
                oEDocumentos.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEDocumentos = CapaNegocio.CargaMasiva.Listar(oEDocumentos);
                Session["CargaMasiva"] = oEDocumentos.LstCargaMasiva;
                gvwEmpleado.DataSource = Session["CargaMasiva"];
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataBind();


            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }


        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {

            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["CargaMasiva"];
            gvwEmpleado.DataBind();

        }

        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Funciones_ddlEmpresaSearch();
            //txtSearch.Focus();

        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //Funciones_btnSearch();
        }

        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            //Funciones_btnSearch();
        }

        protected void chkEnviadoss_CheckedChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    if (chkEliminados.Checked)
            //    {
            //        CargarDocumentos();
            //        HabilitarBusqueda(false);
            //    }
            //    else
            //    {
            //        CargarDocumentos();
            //        HabilitarBusqueda(true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.RegistrarIncidencia(ex);
            //}

        }

        protected void ibNuevoEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            //hdnEstado.Value = "New";
            //HabilitarFormulario(true, 0);
            //pnlGrabar2.Visible = true;
            //pnlLimpiar.Visible = true;
            ////CargarCombosFormulario();
            ////this.txtNrOrdenBusOrden.Text = string.Empty;
            ////this.txtContraseña.Attributes.Add("value", string.Empty);
            ////this.txtContraseña.Attributes.Add("value", this.txtContraseña.Text);
        }

        protected void gvwEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmpleado.PageIndex > -1)
                {
                    gvwEmpleado.PageIndex = e.NewPageIndex;
                    gvwEmpleado.DataSource = Session["CargaMasiva"];
                    gvwEmpleado.DataBind();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPagina(sender as DropDownList);
        }

        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {

        }





    }
}