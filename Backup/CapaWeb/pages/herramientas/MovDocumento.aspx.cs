using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entity = CapaEntidad;
using Negocio = CapaNegocio;
using Intellisoft.Project.Comun.Entidad;
using System.IO;
using Intellisoft.Project.Util;

namespace CapaWeb.pages.herramientas
{
    public partial class MovDocumento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HabilitarFormulario(false, 0);
                CargarDocumentos();
                //CargarComboUsuarios();
            }
        }

        /// <summary>
        /// Exporta la grilla a formato Excell
        /// </summary>
        private void ExportarExcell()
        {
            try
            {
                string strFileName = "prueba" + "_VistaProyecto.xls";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=" + strFileName); // VistaEmpleado.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gvDatos = null;
                List<CapaEntidad.CEMovimientos> lstData = null;

                if (Session["Movimientos"] != null)
                {
                    gvDatos = this.gvwEmpleado;
                    lstData = (Session["Movimientos"] as List<CapaEntidad.CEMovimientos>);
                }
                //else if (Session["lista_por_actividad"] != null)
                //{
                //    gvDatos = this.gvwEmpleado;
                //    lstData = (Session["lista_por_actividad"] as List<CapaEntidad.CEMovimientos>);
                //}

                gvDatos.AllowPaging = false;
                gvDatos.DataSource = lstData;
                gvDatos.Columns[gvDatos.Columns.Count - 1].Visible = false;
                gvDatos.DataBind();

                gvDatos.HeaderRow.Style.Add("background-color", "#FFFFFF");

                for (int i = 0; i < gvDatos.Columns.Count; i++)
                {
                    gvDatos.HeaderRow.Cells[i].Style.Add("background-color", "blue");
                    gvDatos.HeaderRow.Cells[i].Style.Add("color", "white");
                }

                for (int i = 0; i < gvDatos.Rows.Count; i++)
                {
                    GridViewRow row = gvDatos.Rows[i];
                    row.BackColor = System.Drawing.Color.White;
                    row.Attributes.Add("class", "textmode");
                    for (int j = 0; j < gvDatos.Columns.Count; j++)
                    {
                        if (i % 2 == 0)
                            row.Cells[j].Style.Add("background-color", "White");
                        else
                            row.Cells[j].Style.Add("background-color", "LightBlue");
                    }
                }

                gvDatos.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                gvDatos.Style.Add("font-size", "9px");
                gvDatos.RenderControl(hw);

                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
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
                Session["Movimientos"] = null;
                Entity.CEMovimientos oEMovimientos = null;
                oEMovimientos = new Entity.CEMovimientos();

                oEMovimientos.IdDocumento = 1026;
                oEMovimientos = CapaNegocio.CNMovimientos.MovListar(oEMovimientos);
                Session["Movimientos"] = oEMovimientos.LstMovimiento;
                gvwEmpleado.DataSource = oEMovimientos.LstMovimiento;

                gvwEmpleado.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Carga la grilla según el país seleccionado
        /// </summary>
        private void Funciones_ddlPaisSearch()
        {
            try
            {
                Entity.CEMovimientos oEMovimientos = new Entity.CEMovimientos();
                oEMovimientos.empresa = ddlEmpresaSearch.SelectedValue;               
                oEMovimientos = CapaNegocio.CNMovimientos.MovListarByPais(oEMovimientos);
                Session["Movimientos"] = oEMovimientos.LstMovimiento;
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataSource = Session["Movimientos"];
                gvwEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Carga la grilla según Empresa
        /// </summary>
        private void Funciones_btnSearch()
        {
            try
            {
                if (ddlTipoBusqueda.SelectedValue.Equals("0"))
                {
                    //ddlEmpresaSearch.SelectedIndex = 0;
                    Entity.CEMovimientos oMovimientos = new Entity.CEMovimientos();
                    oMovimientos.empresa = ddlEmpresaSearch.SelectedValue;
                    String texto = string.Empty;
                    texto = txtSearch.Text;
                    txtSearch.Text = string.Empty;
                    oMovimientos = CapaNegocio.CNMovimientos.MovListarByTexto(oMovimientos, texto);
                    Session["Movimientos"] = oMovimientos.LstMovimiento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Movimientos"];
                    gvwEmpleado.DataBind();


                }

                else
                {
                    string buscar = "";

                    if (ddlTipoBusqueda.SelectedValue.Equals("1"))
                    {
                        buscar = " and c.IdCargo =  " + txtTipoBusqueda.Text + "  ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("2"))
                    {
                        string fecha = "";
                        fecha = txtTipoBusqueda.Text;

                        if (fecha.Length <= 4)
                        {
                            buscar = " and year (m.FechaRegistro) ='" + fecha + "' ";
                        }
                        else if (fecha.Length <= 6 && fecha.Length > 4)
                        {
                            buscar = " and year (m.FechaRegistro) ='" + fecha.Substring(0, 4) + "' and month(m.FechaRegistro) ='" + fecha.Substring(4, 2) + "' ";
                        }
                        else if (fecha.Length <= 8 && fecha.Length > 6)
                        {
                            buscar = " and year (m.FechaRegistro) ='" + fecha.Substring(0, 4) + "' and month(m.FechaRegistro) ='" + fecha.Substring(4, 2) + "' and day(m.FechaRegistro) ='" + fecha.Substring(6, 2) + "' ";
                        }


                        //buscar = " and d.FechaRegistro LIKE '%" + txtTipoBusqueda.Text + "%'";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("3"))
                    {
                        buscar = "  and d.IdDocumento = " + txtTipoBusqueda.Text + "  ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("4"))
                    {
                        buscar = "   and d.NOrden  = " + txtTipoBusqueda.Text + "  ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("5"))
                    {
                        buscar = "   and d.NroDoc  = '" + txtTipoBusqueda.Text + "' ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("6"))
                    {
                        buscar = "   and d.DocNumReserva  = '" + txtTipoBusqueda.Text + "' ";
                    }

                    Entity.CEMovimientos oEMovimientos = new Entity.CEMovimientos();
                    oEMovimientos.empresa = ddlEmpresaSearch.SelectedValue;
                    oEMovimientos.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oEMovimientos = CapaNegocio.CNMovimientos.MovListarByTipoBusqueda(oEMovimientos, buscar);
                    Session["Movimientos"] = oEMovimientos.LstMovimiento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Movimientos"];
                    gvwEmpleado.DataBind();


                }
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
            gvwEmpleado.DataSource = Session["Movimientos"];
            gvwEmpleado.DataBind();

        }

        /// <summary>
        /// Bloquea o desbloquea controles segun el estado del formulario
        /// </summary>
        private void BloquearControles(bool aviso)
        {

            txtProveedor.Enabled = aviso;
            txtRuc.Enabled = aviso;
            txtNrDocumento.Enabled = aviso;
            txtFrPago.Enabled = aviso;
            //txtNrOrdenBusOrden.Enabled = aviso;
            txtNrOrden.Enabled = aviso;
            txtFechaDoc.Enabled = aviso;
            txtFechaRecepcion.Enabled = aviso;
            txtFechaVen.Enabled = aviso;
            ddlTDocumento.Enabled = aviso;
            ddlTipo.Enabled = aviso;
            txtMoneda.Enabled = aviso;
            txtMonIni.Enabled = aviso;
            txtSaldAct.Enabled = aviso;
            txtMonFac.Enabled = aviso;
            txtComentario.Enabled = aviso;
            //btnBuscarOrden.Enabled = aviso;
            //btnCambiarImagen.Enabled = aviso;
            //ddlEmpresaBusOrden.Enabled = aviso;
            ddlEmpresa.Enabled = aviso;

        }

        /// <summary>
        /// Carga la información y la asigna a los controles.
        /// </summary>
        private void CargarControles(bool aviso)
        {
            try
            {
                Entity.CEDocumento oEDocumentos = new Entity.CEDocumento();

                oEDocumentos.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                oEDocumentos.Activo = aviso;
                oEDocumentos = CapaNegocio.CNDocumento.Obtener(oEDocumentos);
                if (oEDocumentos.UltimoResultado.ResultadoOperacion == 1)
                {
                    txtProveedor.Text = oEDocumentos.Proveedor;
                    txtNrOrden.Text = oEDocumentos.norden;
                    txtRuc.Text = oEDocumentos.ruc;
                    txtNrDocumento.Text = oEDocumentos.nrodoc;
                    txtFrPago.Text = oEDocumentos.formpago;
                    ddlEmpresa.SelectedValue = oEDocumentos.empresa;
                    ddlTipo.SelectedValue = oEDocumentos.tipo;
                    ddlTDocumento.SelectedValue = oEDocumentos.tipodoc;
                    txtMoneda.Text = oEDocumentos.moneda;
                    txtMonIni.Text = Convert.ToString(oEDocumentos.montoini);
                    txtSaldAct.Text = Convert.ToString(oEDocumentos.montoact);
                    txtMonFac.Text = Convert.ToString(oEDocumentos.monto);
                    txtComentario.Text = oEDocumentos.Comentario;

                    txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                    txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                    txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");

                    this.lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " " + oEDocumentos.FechaRegistro;
                    this.lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " " + oEDocumentos.FechaCambio;
                }
                else
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(oEDocumentos.UltimoResultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }



        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Funciones_ddlPaisSearch();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();
        }

        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();
        }

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow obj_row_consol = null;
            HiddenField hdnIdDocumento = null;
            string str_para_encr_1 = string.Empty;
            Entity.CEDocumento oDocumento = new Entity.CEDocumento();
            
          switch (e.CommandName)
          {
              case "Ver":
                  hdnEstado.Value = "View";
                  Session["IdDocumento"] = e.CommandArgument.ToString();
                  BloquearControles(false);
                  oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                  CargarControles(true);
                  //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);                                               
                  //RecuperarDatos(oDocumento);
                  Formulario.Visible = true;
                  HabilitarFormulario(true, 0);
                  pnlCancelar2.Visible = true;
                  //pnlLimpiar.Visible = false;
                  //pnlGrabar2.Visible = false;
                  //pnlBusOrden.Visible = false;
                  //pnlEliminar.Visible = true;
                  //pnlRestaurar.Visible = true;
                  //tSeguridad.Visible = true;
                  //lblliminarEmpresa.Text = "Eliminar";

                  break;

              case "VerRegMov":
                  obj_row_consol = this.gvwEmpleado.Rows[Convert.ToInt32(e.CommandArgument)];
                  hdnIdDocumento = (obj_row_consol.FindControl("hdnIdDocumento") as HiddenField);

                  str_para_encr_1 = hdnIdDocumento.Value;

                  ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../../pages/herramientas/VistaMovimientos.aspx?var1=" + str_para_encr_1 + "', null, 'height=600, width=900, status=no, toolbar=no, scrollbars=no, menubar=no, location=no, top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

            break;
            }
        }

        protected void gvwEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmpleado.PageIndex > -1)
                {
                    gvwEmpleado.PageIndex = e.NewPageIndex;
                    gvwEmpleado.DataSource = Session["Movimientos"];
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

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ddlTDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFechaRecepcion.Focus();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonIni.Focus();
        }


        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                hdnEstado.Value = "F";
                HabilitarFormulario(false, 0);
                Formulario.Visible = false;
                //LimpiarControles();
                //txtNrOrdenBusOrden.Text = string.Empty;
                CargarDocumentos();
                //BloquearControles(true);
                //cbeEliminar.TargetControlID = "btnEliminar";
                //LimpiarSesion();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message.ToString());
            }
        }


    }
}