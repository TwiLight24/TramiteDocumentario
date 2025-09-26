using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Entity = CapaEntidad;
using Negocio = CapaNegocio;
using Intellisoft.Project.Comun.Entidad;
using System.IO;
using Intellisoft.Project.Util;
using System.Text.RegularExpressions;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

//using OfficeOpenXml;
//using OfficeOpenXml.Drawing;
//using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CapaWeb.pages.herramientas
{
    public partial class VistaAsistentePagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HabilitarFormulario(false, 0);
                cargarInfoPlanillas("","");
                if(ddlnroplanilla.SelectedValue.ToString() != "-")
                {
                    CargarDocumentos();
                    mostrarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString());
                }

            }
        }

        /// <summary>
        /// Muestra la formulario para registro o edición de empleados
        /// <param name="accion">Indica si es registro, edición de datos, o restauracion o vista</param>
        /// </summary>
        private void HabilitarFormulario(bool activo, int accion)
        {
            pnlBusqueda.Visible = !activo;
            pnlProyectosPlanificados.Visible = !activo;
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarDocumentos();
        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarDocumentos()
        {
            try
            {
                Session["Pagos"] = null;
                Entity.CEPagos oePagos = null;
                oePagos = new Entity.CEPagos();
                oePagos = CapaNegocio.CNPagos.MovListar(oePagos, ddlnroplanilla.SelectedValue); //"PLLA PROV SOL 31.01.25 CNT."
                Session["Pagos"] = oePagos.LstPago;
                gvwEmpleado.DataSource = oePagos.LstPago;
                gvwEmpleado.DataBind();

                string totales = CapaNegocio.CNPagos.TotalesPlanilla(ddlnroplanilla.SelectedValue);
                string[] lstotales = totales.Split('@');

                if (lstotales.Length < 5)
                {
                    totalDoc.Text = "0.00";
                    totalRetencion.Text = "0.00";
                    totalDetraccion.Text = "0.00";
                    montoPagodo.Text = "0.00";
                }
                else
                {
                    totalDoc.Text = lstotales.GetValue(0).ToString();
                    totalRetencion.Text = lstotales.GetValue(1).ToString();
                    totalDetraccion.Text = lstotales.GetValue(2).ToString();
                    montoPagodo.Text = lstotales.GetValue(3).ToString();
                }

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void ddlnroplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlnroplanilla.SelectedValue.ToString() != "-")
            {
                CargarDocumentos();
                mostrarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString());
            }
        }

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow obj_row_consol = null;
            HiddenField hdnIdDocumento = null;
            string str_para_encr_1 = string.Empty;
            Entity.CEDocumento oDocumento = new Entity.CEDocumento();

            switch (e.CommandName)
            {
                case "VerAdjuntos":
                    obj_row_consol = this.gvwEmpleado.Rows[Convert.ToInt32(e.CommandArgument)];
                    hdnIdDocumento = (obj_row_consol.FindControl("hdnIdDocumento") as HiddenField);

                    str_para_encr_1 = hdnIdDocumento.Value;

                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../../pages/herramientas/VistaAdjuntosDoc.aspx?var1=" + str_para_encr_1 + "', null, 'height=600, width=900, status=no, toolbar=no, scrollbars=no, menubar=no, location=no, top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
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
                    gvwEmpleado.DataSource = Session["Pagos"];
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
            //ConfigurarTamañoPagina(sender as DropDownList);
        }

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {
            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Pagos"];
            gvwEmpleado.DataBind();
        }

        private void cargarInfoPlanillas(String F_Inicio, String F_Fin)
        {
            imgestadoPlanilla.ImageUrl = "";
            lblestadoPlanilla.Text = "";

            gvwEmpleado.DataSource = null;
            gvwEmpleado.DataBind();

            List<string> ListaPlanillas = new List<string>();
            ListaPlanillas = CapaNegocio.CNPagos.VistaPlanillas(F_Inicio, F_Fin);

            ddlnroplanilla.DataSource = ListaPlanillas;
            ddlnroplanilla.DataBind();

            ddlnroplanilla.SelectedIndex = 0;

            if (ddlnroplanilla.SelectedValue != "")
            {
                string nombreArchivo = ddlnroplanilla.SelectedValue;
                string ruta = ResolveUrl($"~/adjuntos/{nombreArchivo}");
                //pdfViewer.Attributes["src"] = ruta;
            }

        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnCorreoGG_Click(object sender, EventArgs e)
        {

            if (ddlnroplanilla.SelectedValue.ToString() != "-")
            {
                string[] lstotales;
                string excel;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage())
                {
                    var ws = package.Workbook.Worksheets.Add("Reporte");

                    // ✔ Insertar el logo
                    //var imagePath = @"C:\Ruta\mega.PNG";
                    var imagePath = Server.MapPath("~/images/mega.PNG");
                    var picture = ws.Drawings.AddPicture("mega", new FileInfo(imagePath));
                    picture.SetPosition(0, 0, 0, 0);
                    picture.SetSize(80);

                    ws.Cells["C2"].Value = "ASISTENTE DE PAGOS DETALLADO (V.2.0)";
                    ws.Cells["C2"].Style.Font.Size = 14;
                    ws.Cells["C2"].Style.Font.Bold = true;
                    ws.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    ws.Cells["A6"].Value = "Asistente de Pago:";
                    ws.Cells["A6"].Style.Font.Size = 12;
                    ws.Cells["A6"].Style.Font.Bold = true;
                    ws.Cells["A6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    ws.Cells["H6"].Value = "Medio de Pago:";
                    ws.Cells["H6"].Style.Font.Size = 12;
                    ws.Cells["H6"].Style.Font.Bold = true;
                    ws.Cells["H6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                    DataSet ds = CapaNegocio.CNPagos.MovListarCrystal(ddlnroplanilla.SelectedValue.ToString()); // tu función que retorna el DataSet
                    DataTable tabla = ds.Tables[0];


                    ws.Cells[6, 3].Value = tabla.Rows[0][14];
                    ws.Cells[6, 9].Value = tabla.Rows[0][15];

                    int fila = 9;
                    foreach (DataRow row in tabla.Rows)
                    {
                        for (int col = 0; col < tabla.Columns.Count - 5; col++)
                        {
                            ws.Cells[fila, col + 1].Value = row[col].ToString();


                        }
                        fila++;
                    }

                    for (int col = 0; col < tabla.Columns.Count - 5; col++)
                    {
                        ws.Cells[8, col + 1].Value = tabla.Columns[col].ColumnName;
                        ws.Cells[8, col + 1].Style.Font.Bold = true;
                        ws.Cells[8, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[8, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    // ✅ Ajustar ancho de columnas
                    ws.Column(1).Width = 6;
                    ws.Column(1).Style.WrapText = true;

                    ws.Column(2).Width = 30;
                    ws.Column(2).Style.WrapText = true;

                    ws.Column(3).Width = 10;
                    ws.Column(3).Style.WrapText = true;

                    ws.Column(4).AutoFit();
                    ws.Column(5).AutoFit();
                    ws.Column(6).AutoFit();
                    ws.Column(7).AutoFit();

                    ws.Column(8).Width = 50;
                    ws.Column(8).Style.WrapText = true;

                    ws.Column(9).AutoFit();
                    ws.Column(10).AutoFit();
                    ws.Column(11).AutoFit();
                    ws.Column(12).AutoFit();


                    ws.Cells["A6:B6"].Merge = true;

                    ws.Cells["C6:E6"].Merge = true;

                    ws.Cells["C2:H3"].Merge = true;
                    ws.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["C2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    for (int i = 9; i < fila; i++)
                    {
                        for (int j = 1; j <= tabla.Columns.Count - 5; j++)
                        {
                            var celda = ws.Cells[i, j];
                            celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            celda.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }
                    }

                    ws.Cells["A1:T100"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells["A1:T100"].Style.Fill.BackgroundColor.SetColor(Color.White);

                    int totalFilas = tabla.Rows.Count;
                    int totalColumnas = tabla.Columns.Count;

                    var rango = ws.Cells[8, 1, totalFilas + 8, totalColumnas - 5]; // Desde A8 hacia abajo
                    var border = rango.Style.Border;

                    border.Top.Style = ExcelBorderStyle.Thin;
                    border.Bottom.Style = ExcelBorderStyle.Thin;
                    border.Left.Style = ExcelBorderStyle.Thin;
                    border.Right.Style = ExcelBorderStyle.Thin;


                    ws.Cells["H" + (totalFilas + 9)].Value = "Totales:";
                    ws.Cells["H" + (totalFilas + 9)].Style.Font.Size = 12;
                    ws.Cells["H" + (totalFilas + 9)].Style.Font.Bold = true;
                    ws.Cells["H" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    string totales = CapaNegocio.CNPagos.TotalesPlanilla(ddlnroplanilla.SelectedValue.ToString());
                    lstotales = totales.Split('@');

                    ws.Cells["I" + (totalFilas + 9)].Value = lstotales.GetValue(0).ToString();
                    ws.Cells["I" + (totalFilas + 9)].Style.Font.Size = 12;
                    ws.Cells["I" + (totalFilas + 9)].Style.Font.Bold = true;
                    ws.Cells["I" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells["J" + (totalFilas + 9)].Value = lstotales.GetValue(1).ToString();
                    ws.Cells["J" + (totalFilas + 9)].Style.Font.Size = 12;
                    ws.Cells["J" + (totalFilas + 9)].Style.Font.Bold = true;
                    ws.Cells["J" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells["K" + (totalFilas + 9)].Value = lstotales.GetValue(2).ToString();
                    ws.Cells["K" + (totalFilas + 9)].Style.Font.Size = 12;
                    ws.Cells["K" + (totalFilas + 9)].Style.Font.Bold = true;
                    ws.Cells["K" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells["L" + (totalFilas + 9)].Value = lstotales.GetValue(3).ToString();
                    ws.Cells["L" + (totalFilas + 9)].Style.Font.Size = 12;
                    ws.Cells["L" + (totalFilas + 9)].Style.Font.Bold = true;
                    ws.Cells["L" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // ✅ Guardar archivo
                    excel = ddlnroplanilla.SelectedValue.ToString() + ".xlsx";
                    var rutaSalida = Server.MapPath("~/excel_Planilla/" + ddlnroplanilla.SelectedValue.ToString() + ".xlsx");
                    File.WriteAllBytes(rutaSalida, package.GetAsByteArray());
                }


                MailMessage miCorreo = new MailMessage();
                miCorreo.IsBodyHtml = true;

                miCorreo.From = new System.Net.Mail.MailAddress("AlertasGMI@metalindustrias.com.pe");
                miCorreo.To.Add("squispe@metalindustrias.com.pe");
                //miCorreo.To.Add("umendoza@metalindustrias.com.pe");
                //miCorreo.CC.Add("ascheggia@metalindustrias.com.pe");
                //miCorreo.Bcc.Add("aplicaciones@metalindustrias.com.pe");
                miCorreo.To.Add("kgalvez@metalindustrias.com.pe");
                miCorreo.To.Add("scastillo@metalindustrias.com.pe");

                //miCorreo.Attachments.Add(new Attachment(@"C:\Ruta\" + ddlnroplanilla.SelectedValue.ToString() + ".xlsx"));
                var rutaSalidaCorreo = Server.MapPath("~/excel_Planilla/" + ddlnroplanilla.SelectedValue.ToString() + ".xlsx");
                miCorreo.Attachments.Add(new Attachment(rutaSalidaCorreo));
                
                miCorreo.Subject = "MONTALVO // PLLA PROVEEDORES: " + ddlnroplanilla.SelectedValue.ToString();
                
                if (lstotales.GetValue(4).ToString() == "USD")
                {
                    miCorreo.Body = "Estimado Ugo, para tu revisión<br><br>" +                                
                                "<table border='1' style='border-collapse: collapse;'>" +
                                    "<tr>" +
                                      "<th style='width: 200px;'>PLANILLA 07.03.25</th>" +
                                      "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                    "</tr>" +
                                    "<tr>" +
                                      "<td style='width: 200px;'>SOLES</td>" +
                                      "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                      "<td style='width: 200px;'>DOLARES</td>" +
                                      "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                    "</tr>" +
                                "</table><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }
                else
                {
                    miCorreo.Body = "Estimado Ugo, para su revisión<br><br>" +
                                "Planilla visada conforme, proceder.<br><br>" +
                                "<table border='1' style='border-collapse: collapse;'>" +
                                    "<tr>" +
                                      "<th style='width: 200px;'>PLANILLA 07.03.25</th>" +
                                      "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                    "</tr>" +
                                    "<tr>" +
                                      "<td style='width: 200px;'>SOLES</td>" +
                                      "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                      "<td style='width: 200px;'>DOLARES</td>" +
                                      "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                    "</tr>" +
                                "</table><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }
                
                miCorreo.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.metalindustrias.com.pe";

                smtp.Credentials = new System.Net.NetworkCredential("AlertasGMI@metalindustrias.com.pe", "{8fXUTLcdHA@");
                smtp.Send(miCorreo);

                Utilitario.MostrarMensaje("Se envio el correo a Gerencia General");

            }
            else
            {
                Utilitario.MostrarMensaje("Debe de seleccionar una Planilla para poder enviar el correo a Gerencia General");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int rsptActualizarEstado = CapaNegocio.CNPagos.InsertarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString(), "A");
            if (rsptActualizarEstado == 1)
            {
                envioAlertaEstado("A","");
                mostrarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString());
                Utilitario.MostrarMensaje("Se Acepto exitosamente la Planilla");
                
                gvwEmpleado.DataSource = null;
                gvwEmpleado.DataBind();

                ddlnroplanilla.DataSource = null;
                ddlnroplanilla.DataBind();

                totalDoc.Text = "";
                totalRetencion.Text = "";
                totalDetraccion.Text = "";
                montoPagodo.Text = "";

                cargarInfoPlanillas("", "");
            }
            else
            {
                Utilitario.MostrarMensaje("Hubo un error al actualizar el estado de la Planilla!");
            }

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            string motivoCorreo = txt_motivo.Text;
            string motivo = txt_motivo.Text.Replace(" ", "").Replace(".","").Replace(",", "").Replace("/", "").Replace("?", "").Replace("-", "").Replace("+", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "");
            if (string.IsNullOrWhiteSpace(motivo))
            {
                Utilitario.MostrarMensaje("Debe ingresar el motivo de Rechazo!");
                return;
            }


            int rsptActualizarEstado = CapaNegocio.CNPagos.InsertarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString(), "R");
            if (rsptActualizarEstado == 1)
            {
                Utilitario.MostrarMensaje("Se Rechazo exitosamente la Planilla");
            }
            else
            {
                Utilitario.MostrarMensaje("Hubo un error al actualizar el estado de la Planilla!");
            }
            envioAlertaEstado("R", motivoCorreo);
            txt_motivo.Text = "";
            mostrarEstadoPlanilla(ddlnroplanilla.SelectedValue.ToString());
        }

        protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaInicio.Text) && string.IsNullOrEmpty(txtFechaFin.Text))
            {
                cargarInfoPlanillas("", "");
            }
            else
            {
                cargarInfoPlanillas(txtFechaInicio.Text, txtFechaFin.Text);
            }
        }

        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaInicio.Text) && string.IsNullOrEmpty(txtFechaFin.Text))
            {
                cargarInfoPlanillas("", "");
            }
            else
            {
                cargarInfoPlanillas(txtFechaInicio.Text, txtFechaFin.Text);
            }
        }


        protected void mostrarEstadoPlanilla(String Planilla)
        {
            string KeyID = CapaNegocio.CNPagos.EstadoPlanilla(Planilla);
            
            if (KeyID == "P")
            {
                imgestadoPlanilla.ImageUrl = "~/images/circle_silver1.png";
                string Planilla_tex = Planilla.Replace("PLLA ", "");
                lblestadoPlanilla.Text = "LA PLANILLA " + Planilla_tex + " CUENTA CON EL ESTADO: (PENDIENTE)";
            }
            if (KeyID == "A")
            {
                imgestadoPlanilla.ImageUrl = "~/images/circle_green1.png";
                string Planilla_tex = Planilla.Replace("PLLA ", "");
                lblestadoPlanilla.Text = "LA PLANILLA " + Planilla_tex + " CUENTA CON EL ESTADO: (ACEPTADO)";
            }
            if (KeyID == "R")
            {
                imgestadoPlanilla.ImageUrl = "~/images/circle_red1.png";
                string Planilla_tex = Planilla.Replace("PLLA ", "");
                lblestadoPlanilla.Text = "LA PLANILLA " + Planilla_tex + " CUENTA CON EL ESTADO: (RECHAZADO)";
            }
        }

        private void envioAlertaEstado(String Estado, String motivo)
        {
            string[] lstotales;
            string excel;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Reporte");

                // ✔ Insertar el logo
                //var imagePath = @"C:\Ruta\mega.PNG";
                var imagePath = Server.MapPath("~/images/mega.PNG");
                var picture = ws.Drawings.AddPicture("mega", new FileInfo(imagePath));
                picture.SetPosition(0, 0, 0, 0);
                picture.SetSize(80);

                ws.Cells["C2"].Value = "ASISTENTE DE PAGOS DETALLADO (V.2.0)";
                ws.Cells["C2"].Style.Font.Size = 14;
                ws.Cells["C2"].Style.Font.Bold = true;
                ws.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells["A6"].Value = "Asistente de Pago:";
                ws.Cells["A6"].Style.Font.Size = 12;
                ws.Cells["A6"].Style.Font.Bold = true;
                ws.Cells["A6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells["H6"].Value = "Medio de Pago:";
                ws.Cells["H6"].Style.Font.Size = 12;
                ws.Cells["H6"].Style.Font.Bold = true;
                ws.Cells["H6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                DataSet ds = CapaNegocio.CNPagos.MovListarCrystal(ddlnroplanilla.SelectedValue.ToString()); // tu función que retorna el DataSet
                DataTable tabla = ds.Tables[0];


                ws.Cells[6, 3].Value = tabla.Rows[0][14];
                ws.Cells[6, 9].Value = tabla.Rows[0][15];

                int fila = 9;
                foreach (DataRow row in tabla.Rows)
                {
                    for (int col = 0; col < tabla.Columns.Count - 5; col++)
                    {
                        ws.Cells[fila, col + 1].Value = row[col].ToString();


                    }
                    fila++;
                }

                for (int col = 0; col < tabla.Columns.Count - 5; col++)
                {
                    ws.Cells[8, col + 1].Value = tabla.Columns[col].ColumnName;
                    ws.Cells[8, col + 1].Style.Font.Bold = true;
                    ws.Cells[8, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[8, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                // ✅ Ajustar ancho de columnas
                ws.Column(1).Width = 6;
                ws.Column(1).Style.WrapText = true;

                ws.Column(2).Width = 30;
                ws.Column(2).Style.WrapText = true;

                ws.Column(3).Width = 10;
                ws.Column(3).Style.WrapText = true;

                ws.Column(4).AutoFit();
                ws.Column(5).AutoFit();
                ws.Column(6).AutoFit();
                ws.Column(7).AutoFit();

                ws.Column(8).Width = 50;
                ws.Column(8).Style.WrapText = true;

                ws.Column(9).AutoFit();
                ws.Column(10).AutoFit();
                ws.Column(11).AutoFit();
                ws.Column(12).AutoFit();


                ws.Cells["A6:B6"].Merge = true;

                ws.Cells["C6:E6"].Merge = true;

                ws.Cells["C2:H3"].Merge = true;
                ws.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["C2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                for (int i = 9; i < fila; i++)
                {
                    for (int j = 1; j <= tabla.Columns.Count - 5; j++)
                    {
                        var celda = ws.Cells[i, j];
                        celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        celda.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }
                }

                ws.Cells["A1:T100"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["A1:T100"].Style.Fill.BackgroundColor.SetColor(Color.White);

                int totalFilas = tabla.Rows.Count;
                int totalColumnas = tabla.Columns.Count;

                var rango = ws.Cells[8, 1, totalFilas + 8, totalColumnas - 5]; // Desde A8 hacia abajo
                var border = rango.Style.Border;

                border.Top.Style = ExcelBorderStyle.Thin;
                border.Bottom.Style = ExcelBorderStyle.Thin;
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.Thin;


                ws.Cells["H" + (totalFilas + 9)].Value = "Totales:";
                ws.Cells["H" + (totalFilas + 9)].Style.Font.Size = 12;
                ws.Cells["H" + (totalFilas + 9)].Style.Font.Bold = true;
                ws.Cells["H" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                string totales = CapaNegocio.CNPagos.TotalesPlanilla(ddlnroplanilla.SelectedValue.ToString());
                lstotales = totales.Split('@');

                ws.Cells["I" + (totalFilas + 9)].Value = lstotales.GetValue(0).ToString();
                ws.Cells["I" + (totalFilas + 9)].Style.Font.Size = 12;
                ws.Cells["I" + (totalFilas + 9)].Style.Font.Bold = true;
                ws.Cells["I" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["J" + (totalFilas + 9)].Value = lstotales.GetValue(1).ToString();
                ws.Cells["J" + (totalFilas + 9)].Style.Font.Size = 12;
                ws.Cells["J" + (totalFilas + 9)].Style.Font.Bold = true;
                ws.Cells["J" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["K" + (totalFilas + 9)].Value = lstotales.GetValue(2).ToString();
                ws.Cells["K" + (totalFilas + 9)].Style.Font.Size = 12;
                ws.Cells["K" + (totalFilas + 9)].Style.Font.Bold = true;
                ws.Cells["K" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["L" + (totalFilas + 9)].Value = lstotales.GetValue(3).ToString();
                ws.Cells["L" + (totalFilas + 9)].Style.Font.Size = 12;
                ws.Cells["L" + (totalFilas + 9)].Style.Font.Bold = true;
                ws.Cells["L" + (totalFilas + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // ✅ Guardar archivo
                excel = ddlnroplanilla.SelectedValue.ToString() + ".xlsx";
                var rutaSalida = Server.MapPath("~/excel_Planilla/" + ddlnroplanilla.SelectedValue.ToString() + ".xlsx");
                File.WriteAllBytes(rutaSalida, package.GetAsByteArray());
            }

        

            MailMessage miCorreo = new MailMessage();
            miCorreo.IsBodyHtml = true;
            miCorreo.From = new System.Net.Mail.MailAddress("AlertasGMI@metalindustrias.com.pe");
            miCorreo.To.Add("ascheggia@metalindustrias.com.pe"); //PARA Despues regresar a amalia
            miCorreo.To.Add("rhernandez@metalindustrias.com.pe"); //PARA
            miCorreo.CC.Add("lespinoza@metalindustrias.com.pe"); //CON COPIA
            miCorreo.CC.Add("ycaycho@metalindustrias.com.pe"); //PARA
            miCorreo.CC.Add("jestela@metalindustrias.com.pe"); //PARA
            miCorreo.CC.Add("dgomez@metalindustrias.com.pe"); //PARA
            miCorreo.Bcc.Add("aplicaciones@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("squispe@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("kgalvez@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("scastillo@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("salmidon@metalindustrias.com.pe"); // CON COPIA
            miCorreo.Bcc.Add("curiarte@metalindustrias.com.pe"); // CON COPIA
            //Peticion de Kriss 14/07/2025
            miCorreo.CC.Add("CPMENDOZA@MEGAESTRUCTURAS.PE"); // CON COPIA Catherine
            miCorreo.CC.Add("gchagua@megaestructuras.pe"); // CON COPIA Guisela
            miCorreo.Bcc.Add("blopez@metalindustrias.com.pe"); // CON COPIA Bryan
            var rutaSalidaCorreo = Server.MapPath("~/excel_Planilla/" + ddlnroplanilla.SelectedValue.ToString() + ".xlsx");
            miCorreo.Attachments.Add(new Attachment(rutaSalidaCorreo));
            string semana = CapaNegocio.CNPagos.SP_ConsultarSemanaPLL(ddlnroplanilla.SelectedValue.ToString());
            if (Estado.Equals("A")) {
                //miCorreo.Subject = "ACEPTADA: " + ddlnroplanilla.SelectedValue.ToString() + ' ' + semana;
                if (lstotales.GetValue(4).ToString() == "USD")
                {
                    string fecha1 = ExtraerFecha(ddlnroplanilla.SelectedValue.ToString());
                    miCorreo.Subject = "ACEPTADA: PLANILLA MONTALVO " + fecha1 + " OT-1664 - " + semana + " - USD " + lstotales.GetValue(3).ToString();
                    miCorreo.Body = "Estimados, <br><br>" +
                                "Planilla <b><span>" + ddlnroplanilla.SelectedValue.ToString() + "</span></b> visada conforme, proceder.<br><br>" +
                                "<table border='1' style='border-collapse: collapse;'>" +
                                "<tr>" +
                                    "<th style='width: 200px;'>PLANILLA USD " + fecha1 + "</th>" +
                                    "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>SOLES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>DOLARES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                "</tr>" +
                                "</table><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }
                else
                {
                    string fecha1 = ExtraerFecha(ddlnroplanilla.SelectedValue.ToString());
                    miCorreo.Subject = "ACEPTADA: PLANILLA MONTALVO " + fecha1 + " OT-1664 - " + semana + " - SOL " + lstotales.GetValue(3).ToString();
                    miCorreo.Body = "Estimados, <br><br>" +
                                "Planilla <b><span>" + ddlnroplanilla.SelectedValue.ToString() + "</span></b> visada conforme, proceder.<br><br>" +
                                "<table border='1' style='border-collapse: collapse;'>" +
                                "<tr>" +
                                    "<th style='width: 200px;'>PLANILLA SOL " + fecha1 + "</th>" +
                                    "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>SOLES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>DOLARES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                "</tr>" +
                                "</table><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }

            }
            else {
                //miCorreo.Subject = "RECHAZADA: " + ddlnroplanilla.SelectedValue.ToString() + ' ' + semana;
                if (lstotales.GetValue(4).ToString() == "USD")
                {
                    string fecha1 = ExtraerFecha(ddlnroplanilla.SelectedValue.ToString());
                    miCorreo.Subject = "RECHAZADA: PLANILLA MONTALVO " + fecha1 + " OT-1664 - " + semana + " - USD " + lstotales.GetValue(3).ToString();
                    miCorreo.Body = "Estimados, <br><br>" +
                                "Planilla <b><span>" + ddlnroplanilla.SelectedValue.ToString() + "</span></b> rechazada.<br><br>" +
                                "<table border='1' style='border-collapse: collapse;'>" +
                                "<tr>" +
                                    "<th style='width: 200px;'>PLANILLA USD " + fecha1 + "</th>" +
                                    "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>SOLES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>DOLARES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                "</tr>" +
                                "</table><br><br>" +
                                "Motivo: <b><span>" + motivo + "</span></b><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }
                else
                {
                    string fecha1 = ExtraerFecha(ddlnroplanilla.SelectedValue.ToString());
                    miCorreo.Subject = "RECHAZADA: PLANILLA MONTALVO " + fecha1 + " OT-1664 - " + semana + " - SOL " + lstotales.GetValue(3).ToString();
                    miCorreo.Body = "Estimados, <br><br>" +
                                "Planilla <b><span>" + ddlnroplanilla.SelectedValue.ToString() + "</span></b> rechazada.<br><br>" +
                                "<table border='1' style='border-collapse: collapse;'>" +
                                "<tr>" +
                                    "<th style='width: 200px;'>PLANILLA SOL " + fecha1 + "</th>" +
                                    "<th style='background-color: #28a745; color: white; width: 280px;'>MEGA(PUENTE MONTALVO)</th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>SOLES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>" + lstotales.GetValue(3).ToString() + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 200px;'>DOLARES</td>" +
                                    "<td style='background-color: #28a745; width: 280px; text-align: right;'>0.00</td>" +
                                "</tr>" +
                                "</table><br><br>" +
                                "Motivo: <b><span>" + motivo + "</span></b><br><br>" +
                                "Atte.<br>" +
                                "Amalia Scheggia";
                }
            }
            
            miCorreo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "mail.metalindustrias.com.pe";
            smtp.Credentials = new System.Net.NetworkCredential("AlertasGMI@metalindustrias.com.pe", "{8fXUTLcdHA@");
            smtp.Timeout = 9999999;
            smtp.Send(miCorreo);
        }

        static string ExtraerFecha(string texto)
        {
            try
            {
                // Busca un patrón de fecha con formato yy.MM.dd
                Match match = Regex.Match(texto, @"\b\d{2}\.\d{2}\.\d{2}\b");
                return match.Success ? match.Value : string.Empty;
            }
            catch
            {
                return "";
            }

        }
    }

}