using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad.PArticulos;
using Negocio = CapaNegocio.PArticulos;
using Intellisoft.Project.Util;

namespace CapaWeb.PeUtiles.pages.Herramienta
{
    public partial class AprobarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                //HabilitarFormulario(false, 0);
                CargarPedidos();
                //CargarComboUsuarios();
            }

        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarPedidos()
        {
            try
            {
                Session["Pedidos"] = null;
                Entity.Pedido oEMovimientos = null;
                oEMovimientos = new Entity.Pedido();

                oEMovimientos = Negocio.Pedido.Listar(oEMovimientos);
                Session["Pedidos"] = oEMovimientos.LstPedido;
                gvwEmpleado.DataSource = oEMovimientos.LstPedido;

                gvwEmpleado.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Carga la información y la asigna a los controles.
        /// </summary>
        private void CargarPedidosDetalle(bool aviso)
        {
            try
            {
                Entity.Pedido oEPedidos = new Entity.Pedido();

                oEPedidos.IdPedido = Convert.ToInt32(Session["IdPedido"]);
                oEPedidos.Activo = aviso;
                oEPedidos = Negocio.Pedido.Obtener(oEPedidos);
                if (oEPedidos.UltimoResultado.ResultadoOperacion == 1)
                {
                    Session["PedidosDetalle"] = oEPedidos.LstPedido;
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
        /// Muestra la formulario para registro o edición de empleados
        /// <param name="accion">Indica si es registro, edición de datos, o restauracion o vista</param>
        /// </summary>
        private void HabilitarFormulario(bool activo, int accion)
        {
            pnlBusqueda.Visible = !activo;
            txtSearch.Text = string.Empty;
            //ddlJefeSearch.SelectedIndex = 0;
            pnlProyectosPlanificados.Visible = !activo;
            Formulario.Visible = activo;
            

        }

        private void ConfigurarTamañoPaginaPedido(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Pedidos"];
            gvwEmpleado.DataBind();

        }



        private void ConfigurarTamañoPaginaPedidoDetalle(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvPedidoDetalle.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvPedidoDetalle.DataSource = Session["PedidosDetalle"];
            gvPedidoDetalle.DataBind();

        }


        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Funciones_ddlPaisSearch();
        }

        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //Funciones_btnSearch();
        }

        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            //Funciones_btnSearch();
        }

        protected void gvwEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmpleado.PageIndex > -1)
                {
                    gvwEmpleado.PageIndex = e.NewPageIndex;
                    gvwEmpleado.DataSource = Session["Pedidos"];
                    gvwEmpleado.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        CargarPedidosDetalle(true);
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

        protected void gvwEmpleado_DataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlPagePedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPedido(sender as DropDownList);

        }

        protected void gvPedidoDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvPedidoDetalle.PageIndex > -1)
                {
                    gvPedidoDetalle.PageIndex = e.NewPageIndex;
                    gvPedidoDetalle.DataSource = Session["PedidosDetalle"];
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

        }

        protected void gvPedidoDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void ddlPagePedidoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPedidoDetalle(sender as DropDownList);
        }
    }
}