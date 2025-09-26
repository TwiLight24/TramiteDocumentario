using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entity = CapaEntidad;
using Negocio = CapaNegocio;
using Intellisoft.Project.Comun.Entidad;

namespace CapaWeb.pages.documento
{
    public partial class Distribucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                HabilitarFormulario(false, 0);
                CargarDocumentos();
                CargarComboUsuarios();
            }

        }


                /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void EnviarDocumentos()
        {
                        try
            {

            CheckBox chkSelect = null;
            HiddenField hdnEstado = null;
            Entity.CEDistribucion oDistribucion  = null;
            List<Entity.CEDistribucion> lista = new List<Entity.CEDistribucion>();

            foreach (GridViewRow row in gvwEmpleado.Rows)
            {
                chkSelect = (row.FindControl("chkSelect") as CheckBox);
                hdnEstado = (row.FindControl("hdnEstado") as HiddenField);



                //if (hdnEstado.Value.Contains(","))
                //{
                //    string[] hdnEst = (row.FindControl("hdnEstado") as HiddenField).Value.Split(new string[] { "," }, StringSplitOptions.None);
                //    hdnEstado.Value = hdnEst[0];
                //}

                if (chkSelect != null && chkSelect.Checked)
                {
                    //if (hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Ingresado)) // if (!hdnEstado.Value.Equals(str_estado))
                    //{
                    oDistribucion = new Entity.CEDistribucion();
                    oDistribucion.IdDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                    oDistribucion.IdMovimiento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][1]);                 
                    oDistribucion.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oDistribucion.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

                    oDistribucion.UsuarioAsignado = Convert.ToInt32(ddlDestino.SelectedValue);
                    oDistribucion = CapaNegocio.CNDistribucion.Registrar(oDistribucion);
                    lista.Add(oDistribucion);

                }
            }

            CargarDocumentos();
            }
                        catch (Exception ex)
                        {
                            Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                        }
        
        
        }


        /// <summary>
        /// Cargar en el ComboBox todos las empresas
        /// </summary>
        private void CargarComboUsuarios()
        {
            try
            {
                Entity.Usuario oEmpresa = new Entity.Usuario();
                oEmpresa.Activo = true;
                oEmpresa = CapaNegocio.Usuario.Listar(oEmpresa);
                Intellisoft.Project.Util.Utilitario.CargaCombo(oEmpresa.LstUsuario, ddlDestino, "IdUsuario", "NombreUsuario", " ---- Ninguno ---- ");
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Distribucion"];
            gvwEmpleado.DataBind();

        }

        /// <summary>
        /// Carga la grilla según el país seleccionado
        /// </summary>
        /// 
        private void Funciones_ddlPaisSearch()
        {
            try
            {
                Entity.CEDistribucion oEDistribucion = new Entity.CEDistribucion();
                oEDistribucion.Empresa = ddlEmpresaSearch.SelectedValue;
                oEDistribucion.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEDistribucion = CapaNegocio.CNDistribucion.ListarByPais(oEDistribucion);
                Session["Distribucion"] = oEDistribucion.LstDistribucion;
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataSource = Session["Distribucion"];
                gvwEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }


        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //HabilitarFormulario(false, 0);
            try
            {
                //    Entity.CEDocumento oDocumento = new Entity.CEDocumento();

                //    //Entity.Usuario oUsuario = new Entity.Usuario();
                //    switch (e.CommandName)
                //    {
                //        case "Editar":
                //            hdnEstado.Value = "Edit";
                //            Session["IdDocumento"] = e.CommandArgument.ToString();
                //            //CargarCombosFormulario();
                //            oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);

                //            //oUsuario.IdEmpleado = Convert.ToInt32(Session["Id"]);
                //            oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);


                //            //oUsuario = Intellisoft.Project.Control.Usuario.Obtener(oUsuario);
                //            RecuperarDatos(oDocumento);
                //            //, oUsuario);

                //            //HabilitarFormulario(true, 1);
                //            HabilitarFormulario(true, 0);


                //            break;
                //        case "Ver":
                //            hdnEstado.Value = "View";
                //            Session["IdDocumento"] = e.CommandArgument.ToString();
                //            BloquearControles(false);
                //            //CargarCombosFormulario();
                //            oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);

                //            //oUsuario.IdEmpleado = Convert.ToInt32(Session["Id"]);
                //            oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);


                //            //oUsuario = Intellisoft.Project.Control.Usuario.Obtener(oUsuario);
                //            RecuperarDatos(oDocumento);

                //            HabilitarFormulario(true, 0);
                //, oEEspecialidad, oUsuario);


                //HabilitarFormulario(true, 2);
                //txtDIdentidad.Enabled = false;
                //txtCWindows.Enabled = false;
                //ddlJefe.Enabled = false;
                //RecuperarPeriodo(Convert.ToInt32(Session["Id"]));
                //        break;
                //}
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void gvwEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmpleado.PageIndex > -1)
                {
                    gvwEmpleado.PageIndex = e.NewPageIndex;
                    gvwEmpleado.DataSource = Session["Distribucion"];
                    gvwEmpleado.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPagina(sender as DropDownList);

        }



        /// <summary>
        /// Muestra la formulario para registro o edición de empleados
        /// <param name="accion">Indica si es registro, edición de datos, o restauracion o vista</param>
        /// </summary>
        private void HabilitarFormulario(bool activo, int accion)
        {
            pnlBusqueda.Visible = !activo;
            txtSearch.Text = string.Empty;
            //ddlJefeSearch.SelectedIndex = 0;
            pnlProyectosPlanificados.Visible = !activo;

        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarDocumentos()
        {
            try
            {
                Session["Distribucion"] = null;
                Entity.CEDistribucion oEDistribucion = null;
                oEDistribucion = new Entity.CEDistribucion();

                oEDistribucion.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEDistribucion = CapaNegocio.CNDistribucion.Listar(oEDistribucion);
                Session["Distribucion"] = oEDistribucion.LstDistribucion;
                gvwEmpleado.DataSource = oEDistribucion.LstDistribucion;

                gvwEmpleado.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Funciones_ddlPaisSearch();
        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        { }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool aviso = ((this.gvwEmpleado.HeaderRow.FindControl("chkAll") as CheckBox).Checked);
                HiddenField hdnEstado = null;
                CheckBox chkSelect = null;

                for (int i = 0; i < this.gvwEmpleado.Rows.Count; i++)
                {
                    hdnEstado = (this.gvwEmpleado.Rows[i].FindControl("hdnEstado") as HiddenField);
                    chkSelect = (this.gvwEmpleado.Rows[i].FindControl("chkSelect") as CheckBox);

                    if (hdnEstado.Value.Contains(","))
                    {
                        string[] hdnEst = hdnEstado.Value.Split(new string[] { "," }, StringSplitOptions.None);
                        hdnEstado.Value = hdnEst[0];
                    }

                    if (hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.PendienteAprobación) ||
                        hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Ingresado) ||
                        hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Aprobado) ||
                        hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Rechazado))
                        chkSelect.Checked = aviso;
                }

                ScriptManager.RegisterClientScriptBlock(this.upaEdicion, GetType(), "grilla", "gridviewScroll();", true);
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }

        protected void gvwEmpleado_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnEstado = null;
                //string KeyID = e.Row.Cells[11].Text.ToString();
                hdnEstado = (e.Row.FindControl("hdnEstado") as HiddenField);
                string KeyID = hdnEstado.Value;

                //var image e.Row.FindControl("imgEstadoSubTarea") as Image;

                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgestado");

                if (KeyID == "INGRESADO")
                {
                    imagen.ImageUrl = "~/images/circle_silver1.png";

                }
                if (KeyID == "RECIBIDO")
                {
                    imagen.ImageUrl = "~/images/circle_green1.png";

                }
                if (KeyID == "ENVIADO")
                {
                    imagen.ImageUrl = "~/images/circle_yellow1.png";

                }
                if (KeyID == "ENVIAR")
                {
                    imagen.ImageUrl = "~/images/circle_yellow1.png";

                }
                if (KeyID == "RECHAZADO")
                {
                    imagen.ImageUrl = "~/images/circle_red1.png";

                }

            }

        }
       
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            if (ddlDestino.SelectedValue == "-1")
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje("Debe Seleccionar Destino");
            }
            else
            {

                if (ddlDestino.SelectedValue == Convert.ToString(IdUser))
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("El Usuario Destino debe ser Diferente al Usuario Actual");
                }
                else
                {
                    //string nwEstado = "ENVIADO";
                    EnviarDocumentos();
                }
            }
        }

        protected void gvwEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}