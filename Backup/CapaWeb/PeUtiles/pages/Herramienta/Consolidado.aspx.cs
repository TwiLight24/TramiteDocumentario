using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Entity = CapaEntidad.PArticulos;
using Control = CapaNegocio.PArticulos;
using Intellisoft.Project.Util;
using System.IO; 

namespace CapaWeb.PeUtiles.pages.Herramienta
{
    public partial class Consolidado : System.Web.UI.Page
    {

        static decimal[] cad_dec_sum = new decimal[0];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.CargarComboPeriodo();
                //this.CargarComboActividad();
                //this.ConfiguracionParametroBusqueda();
                //this.CargarConfiguracion();
                this.CargarPeriodos();
                this.CargarGrilla();
                //this.CargarMensaje();
                // ddlPage.SelectedValue = Convert.ToString((HttpContext.Current.Session["page"] == null) ? "10" : HttpContext.Current.Session["page"]);

                ScriptManager.RegisterClientScriptBlock(this.upaEdicion, this.GetType(), "grilla", "gridviewScroll();", true);
            }

            //this.CrearFooter();

            ScriptManager.RegisterClientScriptBlock(this.upaEdicion, this.GetType(), "grilla", "gridviewScroll();", true);
            //gvwSupervisor.HeaderRow.TableSection = TableRowSection.TableHeader; 
        }


        /// <summary>
        /// Exporta la grilla a formato Excell
        /// </summary>
        private void ExportarExcell()
        {
            try
            {
                string strFileName = this.ltlFecha.Text.Replace(' ', '_') + "_VistaEmpleado.xls";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=" + strFileName); //VistaEmpleado.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                this.gvwSupervisor.AllowPaging = false;
                this.gvwSupervisor.DataSource = (Session["PedidosConsolidado"] as List<Entity.ConsolidaPedido>);
                this.gvwSupervisor.Columns[this.gvwSupervisor.Columns.Count - 1].Visible = false;
                this.gvwSupervisor.DataBind();

                this.gvwSupervisor.HeaderRow.Style.Add("background-color", "#FFFFFF");

                for (int i = 0; i < this.gvwSupervisor.Columns.Count; i++)
                {
                    this.gvwSupervisor.HeaderRow.Cells[i].Style.Add("background-color", "blue");
                    this.gvwSupervisor.HeaderRow.Cells[i].Style.Add("color", "white");
                }

                for (int i = 0; i < this.gvwSupervisor.Rows.Count; i++)
                {
                    GridViewRow row = this.gvwSupervisor.Rows[i];
                    row.BackColor = System.Drawing.Color.White;
                    row.Attributes.Add("class", "textmode");
                    for (int j = 0; j < this.gvwSupervisor.Columns.Count; j++)
                    {
                        if (i % 2 == 0)
                            row.Cells[j].Style.Add("background-color", "White");
                        else
                            row.Cells[j].Style.Add("background-color", "LightBlue");
                    }
                }

                // Agregado 16-05-2013 - Paul Palomino
                // mso-number-format:'\@' -> formato personalizado: mostrar ceros antes : ejm: 00123456
                // el style debe ir antes del RenderControl
                string style = @"<style> .textmode { mso-number-format:'\@'; } </style>";

                this.gvwSupervisor.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                this.gvwSupervisor.Style.Add("font-size", "9px");
                this.gvwSupervisor.RenderControl(hw);

                //string style = @"<style>.textmode{mso-number-format:General;}</style>";

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


        protected void gvwSupervisor_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvwSupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void imgbRepConsolidado_Click(object sender, ImageClickEventArgs e)
        {
            Session["BackPage"] = true;
            Session["UrlPaginaAnterior"] = "~/PeUtiles/pages/Herramienta/Consolidado.aspx";
            Session["ReporteBandeja"] = null;

            Response.Redirect("~/PeUtiles/pages/consulta/ConsultaConsolidado.aspx", false);
        }


        protected void ddlPeriodoSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Entity.ConsolidaPedido oEPedidos = new Entity.ConsolidaPedido();
                oEPedidos.Empresa = ddlEmpresaSearch.SelectedValue;
                oEPedidos.IdPeriodo = Convert.ToInt32(ddlPeriodoSearch.SelectedValue);


                oEPedidos = Control.ConsolidaPedido.ListarConsolidadoByEmpresa(oEPedidos);
                //if (oEPedidos.UltimoResultado.ResultadoOperacion == 1)
                //{
                Session["PedidosConsolidado"] = oEPedidos.ListConsolidaPedido;
                gvwSupervisor.DataSource = oEPedidos.ListConsolidaPedido;

                gvwSupervisor.DataBind();

                //txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                //txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                //txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");

                //this.lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " " + oEDocumentos.FechaRegistro;
                //this.lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " " + oEDocumentos.FechaCambio;
                //}
                //else
                //{
                //    Utilitario.MostrarMensaje(oEPedidos.UltimoResultado.Mensaje);
                //}
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Carga la grilla con datos iniciales
        /// </summary>
        public void CargarPeriodos()
        {
            try
            {
                Entity.Periodo oEmpresa = new Entity.Periodo();
                oEmpresa.Activo = true;
                oEmpresa = CapaNegocio.PArticulos.Periodo.Listar(oEmpresa);
                Intellisoft.Project.Util.Utilitario.CargaCombo(oEmpresa.LstPeriodo, ddlPeriodoSearch, "IdPeriodo", "Descripcion", " ---- Ninguno ---- ");
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }


        /// <summary>
        /// Carga la grilla con datos iniciales
        /// </summary>
        public void CargarGrilla()
        {

            try
            {
                Entity.ConsolidaPedido oEPedidos = new Entity.ConsolidaPedido();



                oEPedidos = Control.ConsolidaPedido.ListarConsolidado(oEPedidos);
                //if (oEPedidos.UltimoResultado.ResultadoOperacion == 1)
                //{
                    Session["PedidosConsolidado"] = oEPedidos.ListConsolidaPedido;
                    gvwSupervisor.DataSource = oEPedidos.ListConsolidaPedido;

                    gvwSupervisor.DataBind();

                    //txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                    //txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                    //txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");

                    //this.lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " " + oEDocumentos.FechaRegistro;
                    //this.lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " " + oEDocumentos.FechaCambio;
                //}
                //else
                //{
                //    Utilitario.MostrarMensaje(oEPedidos.UltimoResultado.Mensaje);
                //}
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            switch (this.ddlExportar.SelectedValue)
            {
                case "1": ExportarExcell(); break;
                //case "2": ExportarPDF(); break;
                //case "2": ExportarPDF(); break;
                //case "3": ExportarWord(); break;
            }

            ClientScript.RegisterStartupScript(GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void ibtnVolver_Click(object sender, ImageClickEventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            return;
        }

        protected void gvwSupervisor_PreRender(object sender, EventArgs e)
        {

        }


    }
}