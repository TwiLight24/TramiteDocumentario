using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Intellisoft.Project.Util;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using Entity = CapaEntidad;
using Negocio = CapaNegocio;

namespace CapaWeb.pages.herramientas
{
    public partial class VistaMovimientos : System.Web.UI.Page
    {
        #region Variables Privadas
            HiddenField hdfIdActividad = null;
        #endregion

        #region Métodos Privados

        /// <summary>
        /// Carga la pantalla con los datos y la grilla
        /// </summary>
        private void CargarPantalla()
        {
            try
            {
                Session["Movimientos"] = null;
                Entity.CEMovimientos oEMovimientos = null;
                oEMovimientos = new Entity.CEMovimientos();

                string param1 = Request.Url.Query.Replace("?var1=", "");
                oEMovimientos.IdDocumento = Convert.ToInt32(param1.ToString());
                oEMovimientos = CapaNegocio.CNMovimientos.VistaMovListar(oEMovimientos);
                Session["Movimientos"] = oEMovimientos.LstMovimiento;
                gvwHorasProyEmp.DataSource = oEMovimientos.LstMovimiento;

                gvwHorasProyEmp.DataBind();

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Exporta la grilla a formato Excell
        /// </summary>
        private void ExportarExcell()
        {
            try
            {
                string strFileName = this.ltlEmpleado.Text.Replace(' ', '_') + "_VistaEmpleado.xls";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=" + strFileName); //VistaEmpleado.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                this.gvwHorasProyEmp.AllowPaging = false;
                this.gvwHorasProyEmp.DataSource = (Session["Movimientos"] as List<CapaEntidad.CEMovimientos>);
                this.gvwHorasProyEmp.Columns[this.gvwHorasProyEmp.Columns.Count - 1].Visible = false;
                this.gvwHorasProyEmp.DataBind();

                this.gvwHorasProyEmp.HeaderRow.Style.Add("background-color", "#FFFFFF");

                for (int i = 0; i < this.gvwHorasProyEmp.Columns.Count; i++)
                {
                    this.gvwHorasProyEmp.HeaderRow.Cells[i].Style.Add("background-color", "blue");
                    this.gvwHorasProyEmp.HeaderRow.Cells[i].Style.Add("color", "white");
                }

                for (int i = 0; i < this.gvwHorasProyEmp.Rows.Count; i++)
                {
                    GridViewRow row = this.gvwHorasProyEmp.Rows[i];
                    row.BackColor = System.Drawing.Color.White;
                    row.Attributes.Add("class", "textmode");
                    for (int j = 0; j < this.gvwHorasProyEmp.Columns.Count; j++)
                    {
                        if (i % 2 == 0)
                            row.Cells[j].Style.Add("background-color", "White");
                        else
                            row.Cells[j].Style.Add("background-color", "LightBlue");
                    }
                }

                this.gvwHorasProyEmp.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                this.gvwHorasProyEmp.Style.Add("font-size", "9px");
                this.gvwHorasProyEmp.RenderControl(hw);

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
        /// Exporta la grilla a formato PDF
        /// </summary>
        private void ExportarPDF()
        {
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=VistaEmpleado.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                this.gvwHorasProyEmp.AllowPaging = false;
                this.gvwHorasProyEmp.DataSource = (Session["Movimientos"] as List<CapaEntidad.CEMovimientos>);
                this.gvwHorasProyEmp.Columns[this.gvwHorasProyEmp.Columns.Count - 1].Visible = false;
                this.gvwHorasProyEmp.DataBind();
                this.gvwHorasProyEmp.HeaderRow.Style.Add("color", "blue");
                this.gvwHorasProyEmp.RenderControl(hw);
                
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                
                Response.Write(style);
                this.gvwHorasProyEmp.HeaderRow.Style.Add("width", "15%");
                this.gvwHorasProyEmp.HeaderRow.Style.Add("font-size", "10px");
                this.gvwHorasProyEmp.Style.Add("text-decoration", "none");
                this.gvwHorasProyEmp.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                this.gvwHorasProyEmp.Style.Add("font-size", "9px");
                
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Exporta la grilla a Word
        /// </summary>
        private void ExportarWord()
        {
            try
            {
                string strFileName = this.ltlEmpleado.Text.Replace(' ', '_') + "_VistaEmpleado.doc";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=" + strFileName); // VistaEmpleado.doc");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-word ";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                this.gvwHorasProyEmp.AllowPaging = false;
                this.gvwHorasProyEmp.DataSource = (Session["Movimientos"] as List<CapaEntidad.CEMovimientos>);
                this.gvwHorasProyEmp.Columns[this.gvwHorasProyEmp.Columns.Count - 1].Visible = false;
                this.gvwHorasProyEmp.DataBind();
                this.gvwHorasProyEmp.HeaderRow.Style.Add("color", "white");

                for (int i = 0; i < this.gvwHorasProyEmp.Columns.Count; i++)
                {
                    this.gvwHorasProyEmp.HeaderRow.Cells[i].Style.Add("background-color", "blue");
                }

                for (int i = 0; i < this.gvwHorasProyEmp.Rows.Count; i++)
                {
                    GridViewRow row = this.gvwHorasProyEmp.Rows[i];
                    row.BackColor = System.Drawing.Color.White;
                    row.Attributes.Add("class", "textmode");
                    for (int j = 0; j < this.gvwHorasProyEmp.Columns.Count; j++)
                    {
                        if (i % 2 == 0)
                            row.Cells[j].Style.Add("background-color", "White");
                        else
                            row.Cells[j].Style.Add("background-color", "LightBlue");
                    }
                }

                this.gvwHorasProyEmp.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                this.gvwHorasProyEmp.Style.Add("font-size", "9px");
                this.gvwHorasProyEmp.RenderControl(hw);

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                CargarPantalla();

            ClientScript.RegisterStartupScript(GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void gvwHorasProyEmp_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(this.gvwHorasProyEmp, GridDecorator.Vista.HorasEmpleado);
        }

        protected void gvwHorasProyEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            switch (this.ddlExportar.SelectedValue)
            {
                case "1": ExportarExcell(); break;
                case "2": ExportarPDF(); break;
                case "3": ExportarWord(); break;
            }

            ClientScript.RegisterStartupScript(GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string str_script = "window.close();";

            if (!ClientScript.IsClientScriptBlockRegistered("CloseWindows"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindows", str_script, true);
            }
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            return;
        }

    }
}