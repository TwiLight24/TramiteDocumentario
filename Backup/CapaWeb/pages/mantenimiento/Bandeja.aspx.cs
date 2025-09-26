using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Entity = CapaEntidad;
using Negocio = CapaNegocio;
using Intellisoft.Project.Comun.Entidad;

namespace CapaWeb.pages.mantenimiento
{
    public partial class Bandeja : System.Web.UI.Page
    {
        int NrCorre = 0;

        static List<Entity.CEMovimientos> list = null;

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
        /// Genera el Correlativo del Documento.
        /// </summary>
        private void GenerarCorrelativo()
        {

            //try
            //{
            Entity.CECargos oeDocumento = new Entity.CECargos();
            //oeDocumento = this.ObtenerDatos();             
            oeDocumento = CapaNegocio.CNCargos.GenerarCorrelativo(oeDocumento);

            if (oeDocumento.idCargo > 0)
            {
                NrCorre = oeDocumento.idCargo + 1;
            }
            else
            {
                NrCorre = 1;

            }

            //Intellisoft.Project.Util.Utilitario.MostrarMensaje(oeDocumento.UltimoResultado.Mensaje);
            //Intellisoft.Project.Util.Utilitario.LimpiarControles(this.Controls);

            //}
            //catch (Exception ex)
            //{ Intellisoft.Project.Util.Log.RegistrarIncidencia(ex); }

        }

        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void AgregarDescripcion(string nwestado)
        {
            //int j = 1;
            try
            {
                list = new List<Entity.CEMovimientos>();
                Entity.CEMovimientos oMovimiento = null;
                Entity.CECargos oCargo = null;
                Entity.Usuario oUsuario = null;


                List<Entity.CEMovimientos> lista = new List<Entity.CEMovimientos>();
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                //string str_estado = (accion ? VariablesGlobales.TiposEstadosPeriodos.Aprobado : VariablesGlobales.TiposEstadosPeriodos.Rechazado);

                Session["Cargo"] = null;
                GenerarCorrelativo();
                oCargo = new Entity.CECargos();


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
                        if (hdnEstado.Value.Equals("INGRESADO") || hdnEstado.Value.Equals("RECIBIDO") ) // if (!hdnEstado.Value.Equals(str_estado))
                        {
                            oMovimiento = new Entity.CEMovimientos();
                            oMovimiento.IdDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oMovimiento.IdMovimiento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][1]);
                            oMovimiento.Situacion = "C";
                            oMovimiento.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento = CapaNegocio.CNMovimientos.Actualizar(oMovimiento);

                            oMovimiento.Origen = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Destino = Convert.ToInt32(ddlDestino.SelectedValue);
                            oMovimiento.Estado = nwestado;
                            oMovimiento.Situacion = "O";
                            oMovimiento = CapaNegocio.CNMovimientos.Registrar(oMovimiento);



                            oCargo.idCargo = NrCorre;
                            oCargo.idDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oCargo = CapaNegocio.CNCargos.RegistrarCargoDetalle(oCargo);
                        
                        

                            lista.Add(oMovimiento);

                            if (!oMovimiento.UltimoResultado.EsValido)
                            {
                                //j = 0;
                                break;
                            }

                        }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;
                    }                  
                }
                if (string.IsNullOrEmpty(str_msj))
                {
                    if (lista == null || lista.Count == 0)
                    {
                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No ha seleccionado ningún registro");
                        return;
                    }
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;



                    if (lista == null || lista.Count == 0)
                    {

                        Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                        return;
                    }
                    
                }

                
                oCargo.idCargo = NrCorre;
                Session["Cargo"] = NrCorre;
                oCargo.destino = Convert.ToInt32(ddlDestino.SelectedValue);
                oCargo.tipo = nwestado;
                oCargo.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

                oCargo = CapaNegocio.CNCargos.Registrar(oCargo);
                    CargarDocumentos();
                    int id = 0;
                    oUsuario = new Entity.Usuario();
                   
                    id  = oMovimiento.Destino;
                    oUsuario.IdUsuario = id;
                    oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    Response.Redirect("~/reportes/ReporteCargo.aspx",false);
                    //Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");
                    
                

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }

        /// <summary>
        /// Rechazar Documentos.
        /// </summary>
        private void RechazarDocumentos(string nwestado)
        {
            //int j = 1;
            try
            {
                list = new List<Entity.CEMovimientos>();
                Entity.CEMovimientos oMovimiento = null;
                Entity.CECargos oCargo = null;
                Entity.Usuario oUsuario = null;


                List<Entity.CEMovimientos> lista = new List<Entity.CEMovimientos>();
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                HiddenField hdnNewDestino = null;
                string str_msj = string.Empty;
                //string str_estado = (accion ? VariablesGlobales.TiposEstadosPeriodos.Aprobado : VariablesGlobales.TiposEstadosPeriodos.Rechazado);

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);
                    hdnNewDestino = (row.FindControl("hdnOrigen") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("ENVIAR") || hdnEstado.Value.Equals("ENVIADO")) // if (!hdnEstado.Value.Equals(str_estado))
                        { }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;
                    }

                }
                if (string.IsNullOrEmpty(str_msj))
                {
                    Session["Cargo"] = null;
                    GenerarCorrelativo();
                    oCargo = new Entity.CECargos();
                    oCargo.idCargo = NrCorre;
                    Session["Cargo"] = NrCorre;
                    oCargo.destino = Convert.ToInt32(hdnNewDestino.Value);
                    oCargo.tipo = nwestado;
                    oCargo.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

                    oCargo = CapaNegocio.CNCargos.Registrar(oCargo);

                    foreach (GridViewRow row in gvwEmpleado.Rows)
                    {
                        chkSelect = (row.FindControl("chkSelect") as CheckBox);
                        hdnEstado = (row.FindControl("hdnEstado") as HiddenField);
                        hdnNewDestino = (row.FindControl("hdnOrigen") as HiddenField);


                        //if (hdnEstado.Value.Contains(","))
                        //{
                        //    string[] hdnEst = (row.FindControl("hdnEstado") as HiddenField).Value.Split(new string[] { "," }, StringSplitOptions.None);
                        //    hdnEstado.Value = hdnEst[0];
                        //}

                        if (chkSelect != null && chkSelect.Checked)
                        {
                            //if (hdnEstado.Value.Equals(VariablesGlobales.TiposEstadosPeriodos.Ingresado)) // if (!hdnEstado.Value.Equals(str_estado))
                            //{
                            oMovimiento = new Entity.CEMovimientos();
                            oMovimiento.IdDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oMovimiento.IdMovimiento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][1]);
                            oMovimiento.Situacion = "C";
                            oMovimiento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento = CapaNegocio.CNMovimientos.Actualizar(oMovimiento);

                            oMovimiento.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Origen = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Destino = Convert.ToInt32(hdnNewDestino.Value);
                            oMovimiento.Estado = nwestado;
                            oMovimiento.Situacion = "O";
                            oMovimiento.Observac = txtComentario.Text;
                            oMovimiento = CapaNegocio.CNMovimientos.Registrar(oMovimiento);



                            oCargo.idCargo = NrCorre;
                            oCargo.idDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oCargo = CapaNegocio.CNCargos.RegistrarCargoDetalle(oCargo);



                            lista.Add(oMovimiento);

                        }
                    }

                    if (lista == null || lista.Count == 0)
                    {
                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No ha seleccionado ningún registro");
                        return;
                    }

                    int id = 0;
                    oUsuario = new Entity.Usuario();

                    id = oMovimiento.Destino;
                    oUsuario.IdUsuario = id;
                    oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    Response.Redirect("~/reportes/ReporteCargo.aspx",false);
                    Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Rechazados en Su Bandeja");
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Rechazar y no seran tomados en cuenta:" + str_msj;



                    if (lista == null || lista.Count == 0)
                    {

                        Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }


        /// <summary>
        /// Rechazar Documentos.
        /// </summary>
        private void RechazarDocumentos2(int usuarioActual)
        {
            Entity.Bandeja oBandeja = null;

            try
            {
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                HiddenField hdnNewDestino = null;
                string str_msj = string.Empty;
                string arrayIdDocumento = "";
                string arrayIdMovimiento = "";
                int usuarioDestino = 0;

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);
                    hdnNewDestino = (row.FindControl("hdnOrigen") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("ENVIAR") || hdnEstado.Value.Equals("ENVIADO")) // if (!hdnEstado.Value.Equals(str_estado))
                        {

                            arrayIdDocumento = arrayIdDocumento + (row.FindControl("hdnIdEmpleados") as HiddenField).Value + ",";
                            arrayIdMovimiento = arrayIdMovimiento + (row.FindControl("hdnMovimiento") as HiddenField).Value + ",";

                            if (Convert.ToInt32(hdnNewDestino.Value) == usuarioDestino || usuarioDestino == 0)
                            {
                                usuarioDestino = Convert.ToInt32(hdnNewDestino.Value);
                            }
                            else { 
                                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No se Puede Rezhazar los Documentos Por Que Seleccionaste Documentos con Destinos Distintos");
                                return;
                            }
                          

                        }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;


                        
                    }

                }
                if (string.IsNullOrEmpty(str_msj))
                {

                    arrayIdDocumento = arrayIdDocumento.Substring(0, arrayIdDocumento.Length - 1);
                    arrayIdMovimiento = arrayIdMovimiento.Substring(0, arrayIdMovimiento.Length - 1);

                    oBandeja = new Entity.Bandeja();
                    oBandeja.Origen = usuarioActual;
                    oBandeja.Destino = usuarioDestino;
                    oBandeja.UsuarioCreador = usuarioActual;
                    oBandeja.UsuarioModificador = usuarioActual;
                    oBandeja.Observacion = txtComentario.Text;
                    oBandeja = CapaNegocio.Bandeja.Rechazar(oBandeja, arrayIdDocumento, arrayIdMovimiento);




                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oMovimiento.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);

                    Session["Cargo"] = oBandeja.IdCargo;
                    Response.Redirect("~/reportes/ReporteCargoRechazo.aspx", false);
                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Rechazados en Su Bandeja");
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Rechazar y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
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
                    oMovimientos.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oMovimientos.empresa = ddlEmpresaSearch.SelectedValue;
                    String texto = string.Empty;
                    texto = txtSearch.Text;
                    txtSearch.Text = string.Empty;
                    oMovimientos = CapaNegocio.CNMovimientos.ListarByTexto(oMovimientos, texto);
                    Session["Movimientos"] = oMovimientos.LstMovimiento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Movimientos"];
                    gvwEmpleado.DataBind();

                }
                else if (ddlTipoBusqueda.SelectedValue.Equals("6"))
                {
                    string arrayIdDocumento = "";

                    arrayIdDocumento = txtTipoBusqueda.Text;

                    Entity.Bandeja oEBandeja = new Entity.Bandeja();
                    oEBandeja.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oEBandeja = CapaNegocio.Bandeja.ListarByIdCocumentoMasivo(oEBandeja, arrayIdDocumento);
                    Session["Movimientos"] = oEBandeja.LstMovimiento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Movimientos"];
                    gvwEmpleado.DataBind();

                }
                else {
                    string buscar = "";

                    if (ddlTipoBusqueda.SelectedValue.Equals("1"))
                    {
                        buscar = " and c.IdCargo =  " + txtTipoBusqueda.Text + "  ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("2"))
                    {
                        string fecha = "";
                        fecha = txtTipoBusqueda.Text;

                        if (fecha.Length <=4) {
                            buscar = " and year (m.FechaRegistro) ='" + fecha + "' ";
                        }
                        else if (fecha.Length <= 6 && fecha.Length >4 ) {
                            buscar = " and year (m.FechaRegistro) ='" + fecha.Substring(0,4) + "' and month(m.FechaRegistro) ='" + fecha.Substring(4,2) + "' ";
                        }
                        else if (fecha.Length <= 8 && fecha.Length >6)
                        {
                            buscar = " and year (m.FechaRegistro) ='" + fecha.Substring(0,4) + "' and month(m.FechaRegistro) ='" + fecha.Substring(4, 2) + "' and day(m.FechaRegistro) ='" + fecha.Substring(6,2) + "' ";
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
                        buscar = "   and d.NroDoc  = '"+ txtTipoBusqueda.Text +"' ";
                    }
                    else if (ddlTipoBusqueda.SelectedValue.Equals("7"))
                    {
                        buscar = "   and d.DocNumReserva  = '" + txtTipoBusqueda.Text + "' ";
                    }


                    Entity.CEMovimientos oEMovimientos = new Entity.CEMovimientos();
                    oEMovimientos.empresa = ddlEmpresaSearch.SelectedValue;
                    oEMovimientos.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oEMovimientos = CapaNegocio.CNMovimientos.ListarByTipoBusqueda(oEMovimientos , buscar);
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


        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void EnviarDocumentos(string nwestado)
        {
            //int j = 1;
            try
            {
                list = new List<Entity.CEMovimientos>();
                Entity.CEMovimientos oMovimiento = null;
                Entity.CECargos oCargo = null;
                Entity.Usuario oUsuario = null;


                List<Entity.CEMovimientos> lista = new List<Entity.CEMovimientos>();
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                //string str_estado = (accion ? VariablesGlobales.TiposEstadosPeriodos.Aprobado : VariablesGlobales.TiposEstadosPeriodos.Rechazado);

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("RECIBIDO") || hdnEstado.Value.Equals("INGRESADO") || hdnEstado.Value.Equals("RECIBIR")) // if (!hdnEstado.Value.Equals(str_estado))
                        { }
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;
                    }

                }
                if (string.IsNullOrEmpty(str_msj))
                {
                    Session["Cargo"] = null;
                    GenerarCorrelativo();
                    oCargo = new Entity.CECargos();
                    oCargo.idCargo = NrCorre;
                    Session["Cargo"] = NrCorre;
                    oCargo.destino = Convert.ToInt32(ddlDestino.SelectedValue);
                    oCargo.tipo = nwestado;
                    oCargo.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

                    oCargo = CapaNegocio.CNCargos.Registrar(oCargo);

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
                            oMovimiento = new Entity.CEMovimientos();
                            oMovimiento.IdDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oMovimiento.IdMovimiento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][1]);
                            oMovimiento.Situacion = "C";
                            oMovimiento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento = CapaNegocio.CNMovimientos.Actualizar(oMovimiento);

                            oMovimiento.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Origen = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Destino = Convert.ToInt32(ddlDestino.SelectedValue);
                            oMovimiento.Estado = nwestado;
                            oMovimiento.Situacion = "O";
                            oMovimiento.Observac = txtComentario.Text;
                            oMovimiento = CapaNegocio.CNMovimientos.Registrar(oMovimiento);



                            oCargo.idCargo = NrCorre;
                            oCargo.idDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oCargo = CapaNegocio.CNCargos.RegistrarCargoDetalle(oCargo);



                            lista.Add(oMovimiento);

                        }
                    }

                    if (lista == null || lista.Count == 0)
                    {
                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No ha seleccionado ningún registro");
                        return;
                    }
                   
                    int id = 0;
                    oUsuario = new Entity.Usuario();

                    id = oMovimiento.Destino;
                    oUsuario.IdUsuario = id;
                    oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    Response.Redirect("~/reportes/ReporteCargo.aspx", false);
                    Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;



                    if (lista == null || lista.Count == 0)
                    {

                        Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                        return;
                    }

                }
            
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }


        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void EnviarDocumentos2(int usuarioActual)
        {         
            Entity.Bandeja oBandeja = null;

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

                    oBandeja = new Entity.Bandeja();
                    oBandeja.Origen = usuarioActual;
                    oBandeja.Destino = Convert.ToInt32(ddlDestino.SelectedValue);
                    oBandeja.UsuarioCreador = usuarioActual;
                    oBandeja.UsuarioModificador = usuarioActual;
                    oBandeja.Observacion = txtComentario.Text;
                    oBandeja = CapaNegocio.Bandeja.Registrar(oBandeja, arrayIdDocumento, arrayIdMovimiento);

                    //dMensaje = CapaNegocio.Bandeja.Registrar(arrayRowIdPick);

                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oBandeja.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    Session["Cargo"] = oBandeja.IdCargo;
                    Response.Redirect("~/reportes/ReporteCargo.aspx");
                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");


                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
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


        /// <summary>
        /// REcibir Documentos.
        /// </summary>
        private void RecibirDocumentos(string nwestado)
        {
            //int j = 1;
            try
            {
                list = new List<Entity.CEMovimientos>();
                Entity.CEMovimientos oMovimiento = null;
                //Entity.CECargos oCargo = null;
                Entity.Usuario oUsuario = null;


                List<Entity.CEMovimientos> lista = new List<Entity.CEMovimientos>();
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                //string str_estado = (accion ? VariablesGlobales.TiposEstadosPeriodos.Aprobado : VariablesGlobales.TiposEstadosPeriodos.Rechazado);

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        if (hdnEstado.Value.Equals("ENVIAR") || hdnEstado.Value.Equals("RECHAZADO") || hdnEstado.Value.Equals("ENVIADO")) // if (!hdnEstado.Value.Equals(str_estado))
                        { }                         
                        else
                            str_msj += "\\n- " + (row.FindControl("hdnIdEmpleados") as HiddenField).Value;
                    }

                }
                if (string.IsNullOrEmpty(str_msj))
                {
                    //Session["Cargo"] = null;
                    //GenerarCorrelativo();
                    //oCargo = new Entity.CECargos();
                    //oCargo.idCargo = NrCorre;
                    //Session["Cargo"] = NrCorre;
                    //oCargo.destino = Convert.ToInt32(ddlDestino.SelectedValue);
                    //oCargo.tipo = nwestado;
                    //oCargo.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

                    //oCargo = CapaNegocio.CNCargos.Registrar(oCargo);

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
                            oMovimiento = new Entity.CEMovimientos();
                            oMovimiento.IdDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            oMovimiento.IdMovimiento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][1]);
                            oMovimiento.Situacion = "C";
                            oMovimiento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento = CapaNegocio.CNMovimientos.Actualizar(oMovimiento);

                            oMovimiento.Origen = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Estado = nwestado;
                            oMovimiento.Situacion = "O";
                            oMovimiento.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                            oMovimiento.Observac = txtComentario.Text;
                            oMovimiento = CapaNegocio.CNMovimientos.Registrar(oMovimiento);



                            //oCargo.idCargo = NrCorre;
                            //oCargo.idDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                            //oCargo = CapaNegocio.CNCargos.RegistrarCargoDetalle(oCargo);



                            lista.Add(oMovimiento);

                        }
                    }

                    if (lista == null || lista.Count == 0)
                    {
                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No ha seleccionado ningún registro");
                        return;
                    }

                     CargarDocumentos();
                    int id = 0;
                    oUsuario = new Entity.Usuario();

                    id = oMovimiento.Destino;
                    oUsuario.IdUsuario = id;
                    oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);

                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Documentos Recibidos Correctamente.");
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;



                    if (lista == null || lista.Count == 0)
                    {

                        Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                        return;
                    }

                }

                    //Session["Cargo"] = null;
                    //GenerarCorrelativo();
                    //oCargo = new Entity.CECargos();
                    //oCargo.idCargo = NrCorre;
                    //Session["Cargo"] = NrCorre;
                    //oCargo.destino = Convert.ToInt32(ddlDestino.SelectedValue);
                    //oCargo.tipo = ddlAccion.SelectedValue;
                    //oCargo.UsuarioCreador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;



                    //oCargo = CapaNegocio.CNCargos.Registrar(oCargo);
                    //Intellisoft.Project.Util.Utilitario.MostrarMensaje(oCargo.UltimoResultado.Mensaje);
                    //Intellisoft.Project.Util.Utilitario.LimpiarControles(this.Controls);


                    //foreach (GridViewRow row in gvwEmpleado.Rows)
                    //{
                    //    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    //    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    //    if (chkSelect != null && chkSelect.Checked)
                    //    {
                    //        oCargo.idCargo = NrCorre; 
                    //        oCargo.idDocumento = Convert.ToInt32(gvwEmpleado.DataKeys[row.RowIndex][0]);
                    //        oCargo = CapaNegocio.CNCargos.RegistrarCargoDetalle(oCargo);

                    //    }
                    //}

                   
                    //Response.Redirect("~/reportes/ReporteCargo.aspx");

                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");

                



                //if (string.IsNullOrEmpty(str_msj))
                //{
                //    if (lista == null || lista.Count == 0)
                //    {
                //        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No ha seleccionado ningún registro");
                //        return;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }
        }


        /// <summary>
        /// Recibir Documentos.
        /// </summary>
        private void RecibirDocumentos2(int usuarioActual)
        {
            Entity.Bandeja oBandeja = null;
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
                        if (hdnEstado.Value.Equals("ENVIAR") || hdnEstado.Value.Equals("RECHAZADO") || hdnEstado.Value.Equals("ENVIADO")) // if (!hdnEstado.Value.Equals(str_estado))
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

                    oBandeja = new Entity.Bandeja();

                    oBandeja.Origen = usuarioActual;
                    oBandeja.Destino = usuarioActual;
                    oBandeja.UsuarioCreador = usuarioActual;
                    oBandeja.UsuarioModificador = usuarioActual;
                    oBandeja.Observacion = txtComentario.Text;
                    oBandeja = CapaNegocio.Bandeja.Recibir(oBandeja, arrayIdDocumento, arrayIdMovimiento);

                    CargarDocumentos();


                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Documentos Recibidos Correctamente.");
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Documentos No se Pueden Recibir y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }

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

                oEMovimientos.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEMovimientos = CapaNegocio.CNMovimientos.Listar(oEMovimientos);
                Session["Movimientos"] = oEMovimientos.LstMovimiento;
                gvwEmpleado.DataSource = oEMovimientos.LstMovimiento;
                gvwEmpleado.DataBind();
               // lblContar.Text = oEMovimientos.LstMovimiento.Count.ToString();
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
                oEMovimientos.Destino = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEMovimientos = CapaNegocio.CNMovimientos.ListarByPais(oEMovimientos);
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

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {

            Intellisoft.Project.Util.Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Movimientos"];
            gvwEmpleado.DataBind();

        }

        private void MostrarTipoBusqueda(bool estado) {

            lblEmpresaSearch.Visible = estado;
            ddlEmpresaSearch.Visible = estado;
            lblSearch.Visible = estado;
            txtSearch.Visible = estado;
            btnBuscar.Visible = estado;
            Contenedor1.Visible = estado;
            Contenedor2.Visible = estado;
            Contenedor3.Visible = estado;
            Contenedor4.Visible = estado;
            Contenedor5.Visible = estado;
        }

        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Funciones_ddlPaisSearch();
        }

        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoBusqueda.SelectedValue.Equals("6"))
            {
                MostrarTipoBusqueda(false);
                Contenedor7.Width = Unit.Percentage(63);
                txtTipoBusqueda.ControlStyle.Height = 26;
                txtTipoBusqueda.TextMode = TextBoxMode.MultiLine;
            }
            else {

                MostrarTipoBusqueda(true);
                Contenedor7.Width = Unit.Percentage(19);
                txtTipoBusqueda.ControlStyle.Height = 13;
                txtTipoBusqueda.TextMode = TextBoxMode.SingleLine;
            }

            txtTipoBusqueda.Text = "";
            txtTipoBusqueda.Focus();



            
            
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();
        }

        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

           
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
        
        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {

            //AgregarDocumento();


            ////CargarComboJefes(ddlJefeSearch, 0);
            //ddlEmpresaSearch.SelectedIndex = 0;

            //cbeEliminar2.TargetControlID = "btnEliminar";
            //LimpiarSesion();
        }
        
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        { }

        protected void btnRestaurar_Click(object sender, ImageClickEventArgs e)
        { }
        protected void btnPasar_Click(object sender, ImageClickEventArgs e)
        { }
        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        { }
        protected void btnPasarTodo_Click(object sender, ImageClickEventArgs e)
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

              string KeyID = e.Row.Cells[13].Text.ToString();

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


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            if (ddlDestino.SelectedValue == "-1")
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje("Debe Seleccionar Destino");
            }
            else {

                if (ddlDestino.SelectedValue == Convert.ToString(IdUser))
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("El Usuario Destino debe ser Diferente al Usuario Actual");
                }
                else
                {
                    EnviarDocumentos2(IdUser);
                }
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            RechazarDocumentos2(IdUser);
        }

        protected void btnRecibir_Click(object sender, EventArgs e)
        {
           int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            RecibirDocumentos2(IdUser);
            //ScriptManager.RegisterClientScriptBlock(this.upaEdicion, GetType(), "grilla", "gridviewScroll();", true);
        }

        protected void ibDistribucion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/mantenimiento/Distribucion.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;

            try
            {
                CheckBox chkSelect = null;
                List<string> list = new List<string>();

                foreach (GridViewRow row in gvwEmpleado.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        list.Add((row.FindControl("hdnIdEmpleados") as HiddenField).Value);
                    }
                }

                string line = string.Join(",", list.ToArray());
         
                string rs = CapaNegocio.Bandeja.EliminarDocs(line, IdUser);
                if (rs.Equals("1"))
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Proceso Correcto.");
                }
                else if (rs.Equals("0"))
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Error al intentar Eliminar, contactese con el Administrador");
                }
                else
                {
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("Error: " + rs);
                }
                CargarDocumentos();
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message.ToString());
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
            }

        }

        protected void gvwEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/pages/mantenimiento/Descargar.aspx", false);
            
        }

    }
}