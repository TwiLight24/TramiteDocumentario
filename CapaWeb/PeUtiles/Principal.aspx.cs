using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad.PArticulos;
using Negocio = CapaNegocio.PArticulos;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CapaWeb.PeUtiles
{
    public partial class Principal : System.Web.UI.Page
    {

        TextBox Horas = new TextBox();
        DataTable pedido;
        double TotalPedido = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //HabilitarFormulario(false, 0);
                cargarDetalle();
                CargarArticulos();
                
                //CargarComboUsuarios();
            }

        }

        private void cargarDetalle()
        {
            pedido = new DataTable("carrito");
            pedido.Columns.Add("IdArticulo", System.Type.GetType("System.Int32"));
            pedido.Columns.Add("NombreArticulo", System.Type.GetType("System.String"));
            pedido.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            pedido.Columns.Add("Total", System.Type.GetType("System.Double"));
            Session["pedido"] = pedido;
            Session["TotalPedido"] = 0;
        }


        private void CargarArticulos()
        {
            try
            {
                Session["Articulos"] = null;
                Entity.Articulo oEArticulos = null;
                oEArticulos = new Entity.Articulo();
                oEArticulos.IdUsuario = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEArticulos.Activo = true;

                oEArticulos = Negocio.Articulo.ListarByPlantilla(oEArticulos);
                Session["Articulos"] = oEArticulos.LstArticulo;
                gvwArticulo.DataSource = oEArticulos.LstArticulo;
                gvwArticulo.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwArticulo.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwArticulo.DataSource = Session["Articulos"];
            gvwArticulo.DataBind();

        }

               /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void EnviarDocumentos(int usuarioActual)
        {
            Entity.Pedido oPedido = null;
            int PedidoDetalleResultadoOperacion = 0;
            string PedidoDetalleMensaje = string.Empty;


            try
            {
                //CheckBox chkSelect = null;
                //HiddenField hdnEstado = null;
                //string str_msj = string.Empty;
                int NroPedido = 0;
                //int NroArticulo = 0;
                //int Cantidad = 0;
                //string arrayIdMovimiento = "";

                oPedido = new Entity.Pedido();
                oPedido.UsuarioCreador = usuarioActual;
                oPedido.UsuarioModificador = usuarioActual;
                oPedido.TotalPedido = Convert.ToDecimal(txtTotalPedido.Text);
                oPedido = Negocio.Pedido.Registrar(oPedido);

                NroPedido = oPedido.IdPedido;
                //Session["Carrito"] = gvwEmple.DataSource;
                //gvwEmple.DataBind();

                if (oPedido.UltimoResultado.ResultadoOperacion == 1)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PEDIDOS"].ConnectionString))
                    {

                        conn.Open();

                        //DataTable dt = Session["Carrito"] as DataTable;

                        string sql = "USP_JC_PedidosDetalle_Insert";

                        DataTable carrito = new DataTable();
                        carrito = (DataTable)Session["pedido"];
                        //DataRow fila = carrito.NewRow();

                        foreach (DataRow fila in carrito.Rows)
                        //foreach (GridViewRow row in gvwEmple.Rows)
                        {

                            SqlCommand command = new SqlCommand(sql, conn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@IdPedido", NroPedido);
                            command.Parameters.AddWithValue("@IdArticulo", Convert.ToInt32(fila["IdArticulo"].ToString()));
                            command.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(fila["Cantidad"].ToString()));
                            command.Parameters.AddWithValue("@UsuarioRegistro", usuarioActual);
                            command.Parameters.AddWithValue("@cResultado", PedidoDetalleResultadoOperacion);
                            command.Parameters.AddWithValue("@aMensaje", PedidoDetalleMensaje);
                            

                            command.ExecuteNonQuery();
                        }

                    }

                    //oPedido = Negocio.Pedido.RegistrarDetalle(oPedido);

                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Se Registro el Pedido N° " + NroPedido + " ");
                }
                else
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("No se Puede Registrar más de dos Pedido por Mes");
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }

               

        #region Métodos de Controles

        protected void imgbButtonAdd_Click(object sender, ImageClickEventArgs e)
        {
            //if (this.ValidarHoras(false))
            //    this.NuevaFilaGrilla();
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void imgbtnGrabar_Click(object sender, ImageClickEventArgs e)
        {
            //if (this.ValidarHoras(true))
            //    this.GrabarRegistro();
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            Session["DatosConsolida"] = null;
            Session["RegActividadesAdmin"] = null;
            Session["ContadorAdmin"] = null;
            Response.Redirect("Consolidado.aspx", false);
        }

        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {
            //if (this.ValidarHoras(false))
            //    QuitarDetalle((sender as ImageButton).Parent.Parent as GridViewRow);
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }
        protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
        {
            //int cantidad;
            //cantidad = gvwArticulo.RowCommand;

        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarComboProyectosporEmpresa((sender as DropDownList).Parent.Parent as GridViewRow);
            //CargarComboSolicitanteporEmpresa((sender as DropDownList).Parent.Parent as GridViewRow);
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }
        protected void ddlTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarComboActividadEmpresa((sender as DropDownList).Parent.Parent as GridViewRow);
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            //DescripcionTextChanged((sender as TextBox).Parent.Parent as GridViewRow);
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void txtDescripcionPopUp_TextChanged(object sender, EventArgs e)
        {
            //DescripcionPopUpTextChanged((sender as TextBox).Parent.Parent.Parent as GridViewRow);
            // ScriptManager.RegisterClientScriptBlock(this.upnReghoras, GetType(), "grilla", "gridviewScroll();", true);
        }
        protected void imgbAgregarSustento_Click(object sender, ImageClickEventArgs e)
        {
            //if (this.ValidarHoras(false))
            //{
            //    if ((Session["arr_param_consolidado"] as ArrayList)[3].ToString() == Variables.TiposEstadosPeriodos.EnProceso ||
            //           (Session["arr_param_consolidado"] as ArrayList)[3].ToString() == Variables.TiposEstadosPeriodos.Rechazado)
            //    { Session["RegActividadesAdmin"] = this.ObtenerDatosGrilla(); }

            //    ParametrosSustento((sender as ImageButton).Parent.Parent as GridViewRow);
            //}
        }

        protected void gvwRegHoras_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion

        protected void ddlGrupoSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Funciones_ddlPaisSearch();
        }

        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            //Funciones_btnSearch();
        }

        protected void gvwArticulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwArticulo.PageIndex > -1)
                {
                    gvwArticulo.PageIndex = e.NewPageIndex;
                    gvwArticulo.DataSource = Session["Articulos"];
                    gvwArticulo.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }


        protected void gvwArticulo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow obj_row_consol = null;
            HiddenField hdnIdArticulo = null;
            HiddenField hdnNombreArticulo = null;
            HiddenField hdnPrecio = null;

            string idArticulo = string.Empty;
            string nombreArticulo = string.Empty;
            double precio = 0;

          

            switch (e.CommandName)
            {
                case "Agregar":
                    
                  int index = Convert.ToInt32(e.CommandArgument);    
              
                  obj_row_consol = this.gvwArticulo.Rows[Convert.ToInt32(e.CommandArgument)-1];
                  hdnIdArticulo = (obj_row_consol.FindControl("hdnIdArticulo") as HiddenField);
                  hdnNombreArticulo = (obj_row_consol.FindControl("hdnNombreArticulo") as HiddenField);
                  hdnPrecio = (obj_row_consol.FindControl("hdnPrecio") as HiddenField);

                  idArticulo = hdnIdArticulo.Value;
                  nombreArticulo = hdnNombreArticulo.Value;
                  precio = Convert.ToDouble(hdnPrecio.Value);

                    //int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvwArticulo.Rows[index-1];                    
                    TextBox cantidad = (TextBox)row.FindControl("txtCantidad");

                    double total = Convert.ToInt32(cantidad.Text) * precio ;

                    TotalPedido = Convert.ToDouble(Session["TotalPedido"]);              
                    TotalPedido = TotalPedido + total;
                    Session["TotalPedido"] = TotalPedido;

                    DataTable carrito = new DataTable();
                    carrito = (DataTable)Session["pedido"];
                    DataRow fila = carrito.NewRow();

                    fila[0] = idArticulo;
                    fila[1] = nombreArticulo;
                    fila[2] = cantidad.Text;
                    fila[3] = total;
                    carrito.Rows.Add(fila);
                    Session["pedido"] = carrito;

                    txtTotalPedido.Text = Convert.ToString(TotalPedido);

                    gvwEmple.DataSource = Session["pedido"];
                    gvwEmple.DataBind();


                 


                   
                    

                    break;
            
            }


        }

        protected void gvwArticulo_DataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPagina(sender as DropDownList);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            EnviarDocumentos(IdUser);
        }

        protected void gvwEmple_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GridViewRow obj_row_consol = null;
            //HiddenField hdnIdArticulo = null;
            string idArticulo = string.Empty;

            switch (e.CommandName)
            {
                case "Eliminar":

                    idArticulo = Convert.ToString(e.CommandArgument);

                    DataTable carrito = new DataTable();
                    carrito = (DataTable)Session["pedido"];
                    //DataRow fila = carrito.NewRow();

                    foreach (DataRow fila in carrito.Rows)
                    {

                        if (idArticulo == fila["IdArticulo"].ToString())
                        {
                            fila.Delete();
                            Session["pedido"] = carrito;
                            gvwEmple.DataSource = Session["pedido"];
                            gvwEmple.DataBind();
                            break;
                        }
                    }
                    

                    break;

            }
        }

        protected void gvwEmple_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmple.PageIndex > -1)
                {
                    gvwEmple.PageIndex = e.NewPageIndex;
                    gvwEmple.DataSource = Session["pedido"];
                    gvwEmple.DataBind();
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

    } 
}