using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad.PArticulos;
using Negocio  = CapaNegocio.PArticulos;
using Intellisoft.Project.Util;

namespace CapaWeb.PeUtiles.pages.administracion
{
    public partial class PlantillaGenerar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HabilitarFormulario( true );
                CargarPlantillas();
                //gvwEmpleado.Columns[1].Visible = false;
                //gvwEmpleado.Columns[2].Visible = false;
            }

        }

        private void HabilitarFormulario(bool activo)
        {
            pnlProyectosAll.Visible = activo;
            pnlProyectosPlanificados.Visible = !activo;
            //pnlBusqueda.Visible = !activo;
            pnlLeyenda.Visible = !activo;
            gvwArticulos.Visible = !activo;

        
        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarPlantillas()
        {
            try
            {
                Entity.Plantilla oEPlantilla = null;
                oEPlantilla = new Entity.Plantilla();
                oEPlantilla.Activo = !chkEliminados.Checked;
                oEPlantilla.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEPlantilla = Negocio.Plantilla.Listar(oEPlantilla);
                Session["Plantillas"] = oEPlantilla.ListPlantilla;
                gvwPlantilla.DataSource = Session["Plantillas"];
                gvwPlantilla.PageIndex = 0;
                gvwPlantilla.DataBind();


            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarArticulos()
        {
            try
            {
                Entity.Plantilla oEPlantilla = null;
                oEPlantilla = new Entity.Plantilla();
                oEPlantilla = Negocio.Plantilla.ListarArticulos(oEPlantilla);
                Session["PlantillaDetalle"] = oEPlantilla.ListPlantilla;
                gvwArticulos.DataSource = Session["PlantillaDetalle"];
                gvwArticulos.PageIndex = 0;
                gvwArticulos.DataBind();


            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Carga la información y la asigna a los controles.
        /// </summary>
        private void CargarControles(bool aviso)
        {
            try
            {
                Entity.Plantilla oEPlantilla = new Entity.Plantilla();

                oEPlantilla.IdPlantilla = Convert.ToInt32(Session["IdPlantilla"]);
                oEPlantilla.Activo = aviso;
                oEPlantilla = Negocio.Plantilla.ListarArticulosPorPlanilla(oEPlantilla);
                //if (oEPlantilla.UltimoResultado.ResultadoOperacion == 1)
                //{
                    Session["PlantillaDetalle"] = oEPlantilla.ListPlantilla;
                    gvwArticulos.DataSource = Session["PlantillaDetalle"];
                    gvwArticulos.PageIndex = 0;
                    gvwArticulos.DataBind();

                    //txtComentario.Text = oEDocumentos.Comentario;

                    //txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                    //txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                    //txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");


                //}
                //else
                //{
                //    Utilitario.MostrarMensaje(oEPlantilla.UltimoResultado.Mensaje);
                //}
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }



        private void ConfigurarTamañoPaginaArticulo(DropDownList ddlControl)
        {

            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwArticulos.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwArticulos.DataSource = Session["PlantillaDetalle"];
            gvwArticulos.DataBind();

        }



        private void ConfigurarTamañoPaginaPlantilla(DropDownList ddlControl)
        {

            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwPlantilla.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwPlantilla.DataSource = Session["Plantillas"];
            gvwPlantilla.DataBind();

        }


        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void RegistrarPlantilla(int usuarioActual)
        {
            Entity.Plantilla oPlantilla = null;

            try
            {
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                string arrayIdPlantilla = "";
                //string arrayIdMovimiento = "";

                foreach (GridViewRow row in gvwArticulos.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("False")) // if (!hdnEstado.Value.Equals(str_estado))
                        {

                            arrayIdPlantilla = arrayIdPlantilla + (row.FindControl("hdnIdArticulo") as HiddenField).Value + ",";                           

                        }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdArticulo") as HiddenField).Value;
                    }

                }

                if (string.IsNullOrEmpty(str_msj))
                {
                    arrayIdPlantilla = arrayIdPlantilla.Substring(0, arrayIdPlantilla.Length - 1);
                    //arrayIdMovimiento = arrayIdMovimiento.Substring(0, arrayIdMovimiento.Length - 1);

                    oPlantilla = new Entity.Plantilla();
                    oPlantilla.UsuarioCreador = usuarioActual;
                    oPlantilla.UsuarioModificador = usuarioActual;
                    oPlantilla.Descripcion = txtComentario.Text;
                    oPlantilla = Negocio.Plantilla.Registrar(oPlantilla, arrayIdPlantilla);

                    //dMensaje = CapaNegocio.Bandeja.Registrar(arrayRowIdPick);

                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oBandeja.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    //Session["Cargo"] = oBandeja.IdCargo;
                    //Response.Redirect("~/reportes/ReporteCargo.aspx", false);
                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");


                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(oPlantilla.UltimoResultado.Mensaje);
                    return;
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Articulos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            }

        }

        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void ActualizarPlantilla(int usuarioActual)
        {
            Entity.Plantilla oPlantilla = null;

            try
            {
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                string arrayIdPlantilla = "";
                //string arrayIdMovimiento = "";

                foreach (GridViewRow row in gvwArticulos.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("False")) // if (!hdnEstado.Value.Equals(str_estado))
                        {

                            arrayIdPlantilla = arrayIdPlantilla + (row.FindControl("hdnIdArticulo") as HiddenField).Value + ",";

                        }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdArticulo") as HiddenField).Value;
                    }

                }

                if (string.IsNullOrEmpty(str_msj))
                {
                    arrayIdPlantilla = arrayIdPlantilla.Substring(0, arrayIdPlantilla.Length - 1);
                    //arrayIdMovimiento = arrayIdMovimiento.Substring(0, arrayIdMovimiento.Length - 1);

                    oPlantilla = new Entity.Plantilla();
                    oPlantilla.IdPlantilla = Convert.ToInt32(Session["IdPlantilla"]);
                    oPlantilla.UsuarioModificador = usuarioActual;
                    oPlantilla.Descripcion = txtComentario.Text;
                    oPlantilla = Negocio.Plantilla.Actualizar(oPlantilla, arrayIdPlantilla);

                    //dMensaje = CapaNegocio.Bandeja.Registrar(arrayRowIdPick);

                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oBandeja.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    //Session["Cargo"] = oBandeja.IdCargo;
                    //Response.Redirect("~/reportes/ReporteCargo.aspx", false);
                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");


                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(oPlantilla.UltimoResultado.Mensaje);
                    return;
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Articulos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            }

        }

        protected void chkEliminados_CheckedChanged(object sender, EventArgs e)
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

        protected void ibAgregarPlantilla_Click(object sender, ImageClickEventArgs e)
        {
            hdnEstado.Value = "New";
            HabilitarFormulario(false);
            CargarArticulos();
        }

        protected void gvwPlantilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwPlantilla.PageIndex > -1)
                {
                    gvwPlantilla.PageIndex = e.NewPageIndex;
                    gvwPlantilla.DataSource = Session["Plantillas"];
                    gvwPlantilla.DataBind();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwPlantilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Entity.Plantilla oPlantilla = new Entity.Plantilla();


                switch (e.CommandName)
                {
                    case "Editar":
                        hdnEstado.Value = "Edit";
                        Session["IdPlantilla"] = e.CommandArgument.ToString();                        
                        CargarControles(true);
                        //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);
                        //RecuperarDatos(oDocumento);                        
                        HabilitarFormulario(false);

                        break;


                    case "Ver":
                        hdnEstado.Value = "View";
                        Session["IdPlantilla"] = e.CommandArgument.ToString();
                        //BloquearControles(false);                       
                        CargarControles(false);
                        //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);                                               
                        //RecuperarDatos(oDocumento);
                        HabilitarFormulario(false);
                        //lblliminarEmpresa.Text = "Eliminar";
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

        }

        protected void gvwPlantilla_DataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void ddlPlantillaPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPlantilla(sender as DropDownList);
        }
        protected void chkAllPlantillas_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void chkAllArticulos_CheckedChanged(object sender, EventArgs e)
        { 

        }

        protected void gvwArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwArticulos.PageIndex > -1)
                {
                    gvwArticulos.PageIndex = e.NewPageIndex;
                    gvwArticulos.DataSource = Session["PlantillaDetalle"];
                    gvwArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvwArticulos_DataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlArticuloPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaArticulo(sender as DropDownList);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            if (hdnEstado.Value == "Edit")
            {

                IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                ActualizarPlantilla(IdUser);

               // Utilitario.MostrarMensaje("Empresa desactivada correctamente.");
            }
            else
            {

                IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                RegistrarPlantilla(IdUser);

                // Utilitario.MostrarMensaje("Empresa restaurada correctamente.");
            }


            //CargarComboJefes(ddlJefeSearch, 0);
            //ddlEmpresaSearch.SelectedIndex = 0;

            //cbeEliminar.TargetControlID = "btnEliminar";
            //LimpiarSesion();
        }
        protected void btnBusqueda_Click(object sender, EventArgs e)
        {

        }


    }
}