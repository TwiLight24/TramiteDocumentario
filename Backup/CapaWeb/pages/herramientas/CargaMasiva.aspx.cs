using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Entity = CapaEntidad;
namespace CapaWeb.pages.herramientas
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //HabilitarFormulario(false, 0);
                CargarDocumentos();
                CargarComboUsuarios();

            }
        }

        protected void checkfilesize(object source, ServerValidateEventArgs args)
        { }


        protected void ibCargarArchivos_Click(object sender, ImageClickEventArgs e)
        {
            pnlCarga.Visible = true;
            pnlMostrarCarga.Visible = false;
            pnlPreparar.Visible = false;
            pnlLeyenda.Visible = false;

        
        }

        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                 .ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                  .ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT [Numero],[Ruc],[Proveedor],[NrDocumento],[Fecha],[FechaVencimiento],[Concepto],[Monto] FROM [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                //Bind Data to GridView
                string datos = Path.GetFileName(FilePath);

      

                DataColumn column;
                DataColumn column2;
                DataColumn column3;
                DataColumn column4;
                column = new DataColumn();
                column2 = new DataColumn();
                column3 = new DataColumn();
                column4 = new DataColumn();

                column.DataType = System.Type.GetType("System.String");
                column2.DataType = System.Type.GetType("System.String");
                column3.DataType = System.Type.GetType("System.String");
                column4.DataType = System.Type.GetType("System.String");

                column.ColumnName = "Empresa";
                column2.ColumnName = "UsuarioRegistro";
                column3.ColumnName = "FechaRegistro";
                column4.ColumnName = "Situacion";

                dt.Columns.Add(column);
                dt.Columns.Add(column2);
                dt.Columns.Add(column3);
                dt.Columns.Add(column4);
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Empresa"] = ddlEmpresa.SelectedValue;
                    dr["UsuarioRegistro"] = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    dr["FechaRegistro"] = DateTime.Now;
                    dr["Situacion"] = "O"; 
                }

                gv1.Caption = Path.GetFileName(FilePath);
                gv1.DataSource = dt;
                gv1.DataBind();

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["ISOFT"].ConnectionString;
                cn.Open();
                SqlBulkCopy importar = default(SqlBulkCopy);
                importar = new SqlBulkCopy(cn.ConnectionString , SqlBulkCopyOptions.KeepIdentity);
                importar.DestinationTableName = "CargaMasiva";
                SqlBulkCopyColumnMapping Numero = new SqlBulkCopyColumnMapping("Numero", "Numero");
                importar.ColumnMappings.Add(Numero);
                SqlBulkCopyColumnMapping Ruc = new SqlBulkCopyColumnMapping("Ruc", "Ruc");
                importar.ColumnMappings.Add(Ruc);
                SqlBulkCopyColumnMapping Proveedor = new SqlBulkCopyColumnMapping("Proveedor", "Proveedor");
                importar.ColumnMappings.Add(Proveedor);
                SqlBulkCopyColumnMapping NrDocumento = new SqlBulkCopyColumnMapping("NrDocumento", "NrDocumento");
                importar.ColumnMappings.Add(NrDocumento);
                SqlBulkCopyColumnMapping Fecha = new SqlBulkCopyColumnMapping("Fecha", "Fecha");
                importar.ColumnMappings.Add(Fecha);
                SqlBulkCopyColumnMapping FechaVencimiento = new SqlBulkCopyColumnMapping("FechaVencimiento", "FechaVencimiento");
                importar.ColumnMappings.Add(FechaVencimiento);
                SqlBulkCopyColumnMapping Concepto = new SqlBulkCopyColumnMapping("Concepto", "Concepto");
                importar.ColumnMappings.Add(Concepto);
                SqlBulkCopyColumnMapping Monto = new SqlBulkCopyColumnMapping("Monto", "Monto");
                importar.ColumnMappings.Add(Monto);
                SqlBulkCopyColumnMapping Empresa = new SqlBulkCopyColumnMapping("Empresa", "Empresa");
                importar.ColumnMappings.Add(Empresa);
                SqlBulkCopyColumnMapping UsuarioRegistro = new SqlBulkCopyColumnMapping("UsuarioRegistro", "UsuarioRegistro");
                importar.ColumnMappings.Add(UsuarioRegistro);
                SqlBulkCopyColumnMapping FechaRegistro = new SqlBulkCopyColumnMapping("FechaRegistro", "FechaRegistro");
                importar.ColumnMappings.Add(FechaRegistro);
                SqlBulkCopyColumnMapping Situacion = new SqlBulkCopyColumnMapping("Situacion", "Situacion");
                importar.ColumnMappings.Add(Situacion);

                

                //importar.ColumnMappings.Add(new SqlBulkCopyColumnMapping("deleted-IdCarga-on-target", ""));
                importar.WriteToServer(dt);
                pnlMostrarCarga.Visible = true;
                pnlCarga.Visible = false;
                

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
                
            }
        }


                /// <summary>
        /// Cargar Documentos relacionados
        /// </summary>
        private void CargarDocumentos()
        {
            try
            {
                Entity.CargaMasiva oEMovimientos = new Entity.CargaMasiva();
                oEMovimientos.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEMovimientos = CapaNegocio.CargaMasiva.ListarCargaMasiva(oEMovimientos);
                Session["Movimientos"] = oEMovimientos.LstCargaMasiva;
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataSource = Session["Movimientos"];
                gvwEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
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
                ddlDestino.SelectedValue = "4";
                ddlDestino.Enabled = false;
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }


        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void EnviarDocumentos(int usuarioActual)
        {
            Entity.CargaMasiva oCargaMasiva = null;

            try
            {
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                string arrayIdDocumento = "";
                string arrayIdMovimiento = "";

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("RECIBIDO") || hdnEstado.Value.Equals("INGRESADO") || hdnEstado.Value.Equals("RECIBIR")) // if (!hdnEstado.Value.Equals(str_estado))
                        {

                            arrayIdDocumento = arrayIdDocumento + (row.FindControl("hdnIdEmpleados") as HiddenField).Value + ",";
                            arrayIdMovimiento = arrayIdMovimiento + (row.FindControl("hdnMovimiento") as HiddenField).Value + ",";

                        }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;
                    }

                }

                if (string.IsNullOrEmpty(str_msj))
                {
                    arrayIdDocumento = arrayIdDocumento.Substring(0, arrayIdDocumento.Length - 1);
                    arrayIdMovimiento = arrayIdMovimiento.Substring(0, arrayIdMovimiento.Length - 1);

                    oCargaMasiva = new Entity.CargaMasiva();
                    oCargaMasiva.Origen = usuarioActual;
                    oCargaMasiva.Destino = Convert.ToInt32(ddlDestino.SelectedValue);
                    oCargaMasiva.UsuarioCreador = usuarioActual;
                    oCargaMasiva.UsuarioModificador = usuarioActual;
                    oCargaMasiva.Observacion = txtComentario.Text;
                    oCargaMasiva = CapaNegocio.CargaMasiva.Registrar(oCargaMasiva, arrayIdDocumento, arrayIdMovimiento);

                    //dMensaje = CapaNegocio.Bandeja.Registrar(arrayRowIdPick);

                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oBandeja.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);


                    Session["Cargo"] = oCargaMasiva.IdCargo;
                    Response.Redirect("~/reportes/ReporteCargo.aspx", false);


                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");


                    //Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
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
    

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
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

                    //if (hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.PendienteAprobación) ||
                    //    hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Ingresado) ||
                    //    hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Aprobado) ||
                    //    hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Rechazado))
                    chkSelect.Checked = aviso;
                }

                //ScriptManager.RegisterClientScriptBlock(this.upaEdicion, GetType(), "grilla", "gridviewScroll();", true);
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

                string KeyID = e.Row.Cells[11].Text.ToString();

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
        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPagina(sender as DropDownList);
        }
        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {
            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Movimientos"];
            gvwEmpleado.DataBind();

        }

        protected void btnRecibir_Click(object sender, EventArgs e)
        {

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
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
                    EnviarDocumentos(IdUser);
                }
            }
            


        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {

                if (AsyncFileUpload1.HasFile)
                {
                    string FileName = Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(AsyncFileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];


                    string FilePath = Server.MapPath(FolderPath + FileName);
                    AsyncFileUpload1.SaveAs(FilePath);

                    Import_To_Grid(FilePath, Extension, "Yes");
                    //StatusLabel.Text = "Cargar Finalizada";

                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            }
        }

        protected void btnPreparar_Click(object sender, EventArgs e)
        {
            //gv1.Visible = false;
            pnlMostrarCarga.Visible = false;
            pnlPreparar.Visible = true;
            CargarDocumentos();
        }

    }
}