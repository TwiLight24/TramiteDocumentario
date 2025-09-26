using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad.PArticulos;
using Negocio = CapaNegocio.PArticulos;
using Intellisoft.Project.Util;

namespace CapaWeb.PeUtiles.pages
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //HabilitarFormulario(false, 0);
                CargarPedidos();
               
            }

        }


        /// <summary>
        /// establece el tamaño del grid
        /// </summary>
        private void ConfigurarTamañoPaginaPedido(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwPedido.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwPedido.DataSource = Session["Pedidos"];
            gvwPedido.DataBind();

        }

        /// <summary>
        /// Carga los Pedidos del Usuario
        /// </summary>
        private void CargarPedidos()
        {

            try
            {
                Session["Pedidos"] = null;
                Entity.Pedido oEMovimientos = null;
                oEMovimientos = new Entity.Pedido();

                oEMovimientos.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEMovimientos = Negocio.Pedido.ListarByUsuario(oEMovimientos);
                Session["Pedidos"] = oEMovimientos.LstPedido;
                gvwPedido.DataSource = oEMovimientos.LstPedido;

                gvwPedido.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        
        }




        /// <summary>
        /// establece el tamaño del grid
        /// </summary>
        private void ConfigurarTamañoPaginaPedidoDetalle(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvPedidoDetalle.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvPedidoDetalle.DataSource = Session["PedidoDetalle"];
            gvPedidoDetalle.DataBind();

        }

        /// <summary>
        /// establece el tamaño del grid
        /// </summary>
        private void ConfigurarTamañoPaginaPedidoAgregar(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvPedidoAgregar.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvPedidoAgregar.DataSource = Session["Articulos"];
            gvPedidoAgregar.DataBind();

        }

                /// <summary>
        /// Carga la información y la asigna a los controles.
        /// </summary>
        private void CargarMenuPedido()
        {
            lblNroPedido2.Text = Convert.ToString(Session["IdPedido"]);
            lblTotalPedido2.Text = Convert.ToString("");
        
        }


        /// <summary>
        /// Carga la información y la asigna a los controles.
        /// </summary>
        private void CargarPedidoDetalle(bool aviso)
        {
            try
            {
                Entity.Pedido oEPedidos = new Entity.Pedido();

                oEPedidos.IdPedido = Convert.ToInt32(Session["IdPedido"]);
                oEPedidos.Activo = aviso;
                oEPedidos = Negocio.Pedido.Obtener(oEPedidos);
                if (oEPedidos.UltimoResultado.ResultadoOperacion == 1)
                {
                    Session["PedidoDetalle"] = oEPedidos.LstPedido;
                    gvPedidoDetalle.DataSource = oEPedidos.LstPedido;

                    gvPedidoDetalle.DataBind();

                    //txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                    //txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                    //txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");

                    //this.lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " " + oEDocumentos.FechaRegistro;
                    //this.lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " " + oEDocumentos.FechaCambio;
                }
                else
                {
                    Utilitario.MostrarMensaje(oEPedidos.UltimoResultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }


        /// <summary>
        /// Carga la información y de articulos que desea Agregar
        /// </summary>
        private void CargarArticulos()
        {
            try
            {
                Session["Articulos"] = null;
                Entity.Articulo oEArticulos = null;
                oEArticulos = new Entity.Articulo();


                oEArticulos = Negocio.Articulo.Listar(oEArticulos);
                Session["Articulos"] = oEArticulos.LstArticulo;
                gvPedidoAgregar.DataSource = oEArticulos.LstArticulo;
                gvPedidoAgregar.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

                /// <summary>
        /// Muestra la formulario para registro o edición de empleados
        /// <param name="accion">Indica si es registro, edición de datos, o restauracion o vista</param>
        /// </summary>
        private void HabilitarFormulario(bool activo, int accion)
        {
            //pnlBusqueda.Visible = !activo;
            //txtSearch.Text = string.Empty;
            //ddlEmpresaSearch.SelectedIndex = 0;
            pnlProyectosPlanificados.Visible = !activo;
            pnlPedidoAgregarAll.Visible = !activo;
            pnlPedidoEditar.Visible = activo;
            pnlLeyenda.Visible = !activo;
            pnlMenuPedido.Visible = activo;
        }

        protected void gvwPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Entity.Pedido oPedido = new Entity.Pedido();


                switch (e.CommandName)
                {
                    case "Editar":
                        hdnEstado.Value = "Edit";
                        Session["IdPedido"] = e.CommandArgument.ToString();
                        oPedido.IdPedido = Convert.ToInt32(Session["IdPedido"]);
                        CargarPedidoDetalle(true);
                        CargarMenuPedido();
                        //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);
                        //RecuperarDatos(oDocumento);                        
                        HabilitarFormulario(true, 0);
                        //pnlEliminar.Visible = true;
                        //pnlLimpiar.Visible = false;
                        //tSeguridad.Visible = true;

                        break;


                    case "Ver":
                        hdnEstado.Value = "View";
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwPedido_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string KeyID = e.Row.Cells[6].Text.ToString();

                //var image e.Row.FindControl("imgEstadoSubTarea") as Image;

                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgestado");

                if (KeyID == "Enviado")
                {
                    imagen.ImageUrl = "~/images/circle_silver1.png";

                }
                if (KeyID == "Recibido")
                {
                    imagen.ImageUrl = "~/images/circle_green1.png";

                }
                if (KeyID == "EnEspera")
                {
                    imagen.ImageUrl = "~/images/circle_yellow1.png";

                }
                if (KeyID == "Entregado")
                {
                    imagen.ImageUrl = "~/images/circle_orange1.png";

                }
                if (KeyID == "RECHAZADO")
                {
                    imagen.ImageUrl = "~/images/circle_red1.png";

                }

            }

        }

        protected void gvwPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwPedido.PageIndex > -1)
                {
                    gvwPedido.PageIndex = e.NewPageIndex;
                    gvwPedido.DataSource = Session["Pedidos"];
                    gvwPedido.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void ddlPagegvPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPedido(sender as DropDownList);

        }

        protected void ddlPagegvPedidoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPedidoDetalle(sender as DropDownList);
        }

        protected void gvPedidoDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvPedidoDetalle.PageIndex > -1)
                {
                    gvPedidoDetalle.PageIndex = e.NewPageIndex;
                    gvPedidoDetalle.DataSource = Session["PedidoDetalle"];
                    gvPedidoDetalle.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void gvPedidoDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow obj_row_consol = null;
            HiddenField hdnIdArticulo = null;
            HiddenField hdnCantidad = null;

          
            try
            {
                Entity.Pedido oPedido = new Entity.Pedido();


                switch (e.CommandName)
                {
                    case "Actualizar":

                        int index = Convert.ToInt32(e.CommandArgument); 
                        obj_row_consol = this.gvPedidoDetalle.Rows[Convert.ToInt32(e.CommandArgument) - 1];
                        hdnCantidad = (obj_row_consol.FindControl("hdnCantidad") as HiddenField);
                        hdnIdArticulo = (obj_row_consol.FindControl("hdnIdArticulo") as HiddenField);

                        GridViewRow row = gvPedidoDetalle.Rows[index - 1];  
                        TextBox cantidad = (TextBox)row.FindControl("txtCantidad");


                        hdnEstado.Value = "Edit";
                        Session["IdArticulo"] = hdnIdArticulo.Value;
                        oPedido.IdArticulo = Convert.ToInt32(Session["IdArticulo"]);
                        oPedido.IdPedido = Convert.ToInt32(Session["IdPedido"]);
                        oPedido.Cantidad = Convert.ToInt32(cantidad.Text);


                        oPedido = Negocio.Pedido.Actualizar(oPedido);
                        Utilitario.MostrarMensaje(oPedido.UltimoResultado.Mensaje);

                        //RecuperarDatos(oDocumento);                        
                        HabilitarFormulario(true, 0);
                        //pnlEliminar.Visible = true;
                        //pnlLimpiar.Visible = false;
                        //tSeguridad.Visible = true;

                        break;


                    case "Ver":
                        hdnEstado.Value = "View";
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }



        protected void gvPedidoDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int cantidad = 0;
            cantidad = Convert.ToInt32((TextBox)gvPedidoDetalle.Rows[e.RowIndex].FindControl("txtCantidad"));
        }

        protected void imgbButtonAdd_Click(object sender, ImageClickEventArgs e)
        {
            //pnlPedidosAll.Visible = false;
            pnlProyectosPlanificados.Visible = false;
            pnlPedidoEditar.Visible = false;
            pnlPedidoAgregarAll.Visible = true;
            CargarArticulos();

        }

        protected void imgbVistaDetallada_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgbRefresh_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gvPedidoAgregar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvPedidoAgregar.PageIndex > -1)
                {
                    gvPedidoAgregar.PageIndex = e.NewPageIndex;
                    gvPedidoAgregar.DataSource = Session["Articulos"];
                    gvPedidoAgregar.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

        }

        protected void gvPedidoAgregar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entity.Pedido oPedido = new Entity.Pedido();


            GridViewRow obj_row_consol = null;
            HiddenField hdnIdArticulo = null;
            HiddenField hdnNombreArticulo = null;
            HiddenField hdnPrecio = null;





            switch (e.CommandName)
            {
                case "Agregar":

                    int index = Convert.ToInt32(e.CommandArgument);

                    obj_row_consol = this.gvPedidoAgregar.Rows[Convert.ToInt32(e.CommandArgument) - 1];
                    hdnIdArticulo = (obj_row_consol.FindControl("hdnIdArticulo") as HiddenField);
                    hdnNombreArticulo = (obj_row_consol.FindControl("hdnNombreArticulo") as HiddenField);
                    hdnPrecio = (obj_row_consol.FindControl("hdnPrecio") as HiddenField);

                    oPedido.IdPedido = Convert.ToInt32(Session["IdPedido"]);
                    oPedido.IdArticulo = Convert.ToInt32(hdnIdArticulo.Value);
                    //nombreArticulo = hdnNombreArticulo.Value;
                    oPedido.Precio = Convert.ToDecimal(hdnPrecio.Value);

                    //int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvPedidoAgregar.Rows[index - 1];
                    TextBox cantidad = (TextBox)row.FindControl("txtCantidad");
                    oPedido.Cantidad = Convert.ToInt32(cantidad.Text);
                    oPedido.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oPedido = Negocio.Pedido.Agregar(oPedido);
                    Utilitario.MostrarMensaje(oPedido.UltimoResultado.Mensaje);





                    break;

            }
        }

        protected void gvPedidoAgregar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void ddlPagegvPedidoAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPedidoAgregar(sender as DropDownList);
        }

    }
}