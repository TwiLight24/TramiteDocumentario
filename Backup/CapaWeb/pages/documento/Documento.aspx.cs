using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad;
using Negocio = CapaNegocio;
using System.Data;
using System.Transactions;
using System.IO;
using Intellisoft.Project.Util;
using System.Text.RegularExpressions;

namespace CapaWeb.pages.documento
{
    public partial class Documento : System.Web.UI.Page
    {
        private DataTable dtld;
        Negocio.CNDistribucion objCNDIST;
        int NrCorre = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HabilitarFormulario(false, 0);
                CargarDocumentos();
                gvwEmpleado.Columns[1].Visible = false;
                //gvwEmpleado.Columns[2].Visible = false;
            }
        }

        private void LimpiarControles()
        {
            //ddlEmpresaBusOrden.SelectedIndex = 0;
            txtNrOrdenBusOrden.Text = string.Empty;
            ddlEmpresa.SelectedIndex = 0;
            txtNrOrden.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtNrDocumento.Text = string.Empty;
            txtRuc.Text = string.Empty;
            txtFrPago.Text = string.Empty;
            txtFechaDoc.Text = string.Empty;
            txtFechaRecepcion.Text = string.Empty;
            txtFechaVen.Text = string.Empty;

            ddlTDocumento.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            txtMoneda.Text = string.Empty;
            txtMonIni.Text = string.Empty;
            txtSaldAct.Text = string.Empty;
            txtMonFac.Text = string.Empty;
            txtComentario.Text = string.Empty;
            //txtTCelular.Text = string.Empty;
            //txtCodigo.Text = string.Empty;
            //ddlTContrato.SelectedIndex = 0;
            //ddlEspecialidad.SelectedIndex = 0;
            //ddlJefe.SelectedIndex = 0;
            //ddlRol.SelectedIndex = 0;
            //ddlArea.SelectedIndex = 0;
            //txtCentroCosto.Text = string.Empty;
            //txtCosto.Text = string.Empty;
            //txtTTrabajo.Text = string.Empty;
            //txtFechaIngreso.Text = string.Empty;
            //txtFechaCese.Text = string.Empty;
            //txtNombreUsuario.Text = string.Empty;
            //txtContraseña.Text = string.Empty;
            //ddlTAutenticacion.SelectedIndex = 0;
            //txtCWindows.Text = string.Empty;
            //txtCaducidad.Text = string.Empty;
            //imgFoto.ImageUrl = "~/images/temp/web-user.jpg";
            LimpiarListas();
        }

        /// <summary>
        /// Habilita o deshabilita búsqueda según el dato booleano enviado
        /// </summary>
        /// <param name="activo">True, False</param>
        private void HabilitarBusqueda(bool activo)
        {

            lblEmpresaSearch.Visible = activo;
            ddlEmpresaSearch.Visible = activo;
            lblSearch.Visible = activo;
            txtSearch.Visible = activo;
            btnBuscar.Visible = activo;
            gvwEmpleado.Columns[1].Visible = !activo;
            //gvwEmpleado.Columns[2].Visible = !activo;
            gvwEmpleado.Columns[0].Visible = activo;
            ddlEmpresaSearch.SelectedIndex = 0;
        }

        private void LimpiarListas()
        {
            //ddlEmpresa.SelectedIndex = 0;
            //lstbProyecto.Items.Clear();
            //lstbProyectoAsignados.Items.Clear();
            //lstbProyecto.Items.Insert(0, new ListItem("Ninguno", "-1"));
            //lstbProyectoAsignados.Items.Insert(0, new ListItem("Ninguno", "-1"));
        }
        /// <summary>
        /// Limpia los datos de las sesiones
        /// </summary>
        private void LimpiarSesion()
        {
            Session["Id"] = null;
            Session["IdRol"] = null;
        }

        /// <summary>
        /// Muestra la formulario para registro o edición de empleados
        /// <param name="accion">Indica si es registro, edición de datos, o restauracion o vista</param>
        /// </summary>
        private void HabilitarFormulario(bool activo, int accion)
        {
            pnlBusqueda.Visible = !activo;
            txtSearch.Text = string.Empty;
            ddlEmpresaSearch.SelectedIndex = 0;
            pnlProyectosPlanificados.Visible = !activo;
            Formulario.Visible = activo;
            pnlBusOrden.Visible = activo;
            //pnlBCancelar.Visible = activo;
            pnlCancelar2.Visible = activo;
            //pnlBGrabar.Visible = (accion != 2 && activo);
            pnlGrabar2.Visible =  activo;
            pnlRestaurar.Visible = (accion == 2 && activo);
            pnlEliminar.Visible = (accion == 1 && activo);
            //pnlEliminar.Visible =  activo;
            tSeguridad.Visible = (accion != 0 && activo);
        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarDocumentosxOrden()
        {
            string emp;
            try
            {
                Entity.CEDocumento oEDocumentos = null;
                oEDocumentos = new Entity.CEDocumento();
                emp = ddlEmpresaBusOrden.SelectedValue;

                if (emp.Equals("Steel Form"))
                {
                    oEDocumentos.empresa = "SBO_SF";
                    //oEDocumentos.norden = txtNrOrdenBusOrden.Text;
                    //oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxOrdenSteel(oEDocumentos);
                }
                else if (emp.Equals("China Bolts"))
                {
                    oEDocumentos.empresa = "SBO_BB";
                    //oEDocumentos.norden = txtNrOrdenBusOrden.Text;
                    //oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxOrdenSteel(oEDocumentos);
                }
                else if (emp.Equals("POSTES"))
                {
                    oEDocumentos.empresa = "SBO_Postes_y_Estructuras";
                }
                else if (emp.Equals("MIMSA"))
                {
                    oEDocumentos.empresa = "SBO_ComercialMendoza";
                }
                else if (emp.Equals("MEGA"))
                {
                    oEDocumentos.empresa = "SBO_Mega_Estructuras";
                }
                else if (emp.Equals("RUMI"))
                {
                    oEDocumentos.empresa = "SBO_RumiImport";
                }
                else if (emp.Equals("INDUZINC"))
                {
                    oEDocumentos.empresa = "SBO_INDUZINC";
                }
                else if (emp.Equals("DOBLE RR"))
                {
                    oEDocumentos.empresa = "SBO_DOBLER";
                }


                    oEDocumentos.norden = txtNrOrdenBusOrden.Text;
                    oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxOrden(oEDocumentos);
                   
                    txtNrOrden.Text = txtNrOrdenBusOrden.Text;
                    ddlEmpresa.SelectedValue = ddlEmpresaBusOrden.SelectedValue;
                    txtProveedor.Text = oEDocumentos.Proveedor;
                    txtRuc.Text = oEDocumentos.ruc;
                    txtNrDocumento.Text = oEDocumentos.nrodoc;
                    txtFrPago.Text = oEDocumentos.formpago;
                    ddlTipo.SelectedValue = oEDocumentos.tipo;
                    txtMoneda.Text = oEDocumentos.moneda;
                    txtMonIni.Text = Convert.ToString(oEDocumentos.montoini);
                    txtSaldAct.Text = Convert.ToString(oEDocumentos.montoact);
                    txtFechaVen.Text = oEDocumentos.Vencimiento;

              
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }


        /// <summary>
        /// Carga los Documentos Por Ruc
        /// </summary>
        private void CargarDocumentosxRuc()
        {
            string emp;
            try
            {
                Entity.CEDocumento oEDocumentos = null;
                oEDocumentos = new Entity.CEDocumento();
                emp = ddlEmpresaBusOrden.SelectedValue;

                if (emp.Equals("Steel Form"))
                {
                    oEDocumentos.empresa = "SBO_SF";
                    oEDocumentos.ruc = txtNrOrdenBusOrden.Text;
                    oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxRucSteel(oEDocumentos);
                }
                else if (emp.Equals("China Bolts"))
                {
                    oEDocumentos.empresa = "SBO_BB";
                    oEDocumentos.ruc = txtNrOrdenBusOrden.Text;
                    oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxRucSteel(oEDocumentos);
                }
                else
                {
                    if (emp.Equals("POSTES"))
                    {
                        oEDocumentos.empresa = "SBO_Postes_y_Estructuras";
                    }
                    else if (emp.Equals("MIMSA"))
                    {
                        oEDocumentos.empresa = "SBO_ComercialMendoza";
                    }
                    else if (emp.Equals("MEGA"))
                    {
                        oEDocumentos.empresa = "SBO_Mega_Estructuras";
                    }
                    else if (emp.Equals("RUMI"))
                    {
                        oEDocumentos.empresa = "SBO_RumiImport";
                    }
                    else if (emp.Equals("INDUZINC"))
                    {
                        oEDocumentos.empresa = "SBO_INDUZINC";
                    }
                    else if (emp.Equals("DOBLE RR"))
                    {
                        oEDocumentos.empresa = "SBO_DOBLER";
                    }


                    oEDocumentos.ruc = txtNrOrdenBusOrden.Text;
                    oEDocumentos = CapaNegocio.CNDocumento.CargarDatosxRuc(oEDocumentos);
                }

                ddlEmpresa.SelectedValue = ddlEmpresaBusOrden.SelectedValue;
                txtProveedor.Text = oEDocumentos.Proveedor;
                txtRuc.Text = oEDocumentos.ruc;



            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Actualiza el estado de Documento.
        /// </summary>
        private void ActualizarEstado()
        {
            try
            {
                Entity.CEDocumento oeDocumento = new Entity.CEDocumento();
                oeDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                oeDocumento.Activo = (hdnEstado.Value == "Edit") ? false : true;
                oeDocumento.UsuarioModificador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                oeDocumento = CapaNegocio.CNDocumento.ActualizarEstado(oeDocumento);
                if (hdnEstado.Value == "Edit")
                    Utilitario.MostrarMensaje("Empresa desactivada correctamente.");
                else
                    Utilitario.MostrarMensaje("Empresa restaurada correctamente.");
                CargarDocumentos();
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Elimina fisicamente a la empresa seleccionada.
        /// </summary>
        private void EliminarFisico()
        {
            try
            {
                Entity.CEDocumento oeEmpresa = new Entity.CEDocumento();
                oeEmpresa.IdDocumento = Convert.ToInt32(Session["idEmpresa"]);
                oeEmpresa = CapaNegocio.CNDocumento.EliminadoFisico(oeEmpresa);
                if (oeEmpresa.UltimoResultado.EsValido)
                    Utilitario.MostrarMensaje("Eliminación definitiva de empresa se realizó correctamente.");
                else
                    Utilitario.MostrarMensaje(oeEmpresa.UltimoResultado.Mensaje);
                // Intellisoft.Project.Util.Utilitario.MostrarMensaje("Eliminación definitiva de empresa no se realizó debido a fallos.");
                //HabilitarEdicion(true);
                CargarDocumentos();
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Recupera Datos para Actualizar o ver
        /// </summary>
        private void RecuperarDatos(Entity.CEDocumento oEDocumentos)
        {
            try
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

                txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");
                txtFactReserva.Text = Convert.ToString(oEDocumentos.DocNumFactReserva);


                lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " / " + oEDocumentos.FechaRegistro;
                lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " / " + oEDocumentos.FechaCambio;

                /*Entity.ParametroDetalle objDetalle = new Entity.ParametroDetalle();
                objDetalle = Intellisoft.Project.Control.ParametroDetalle.DatosFileUpload();
                string savePath = objDetalle.CarpetaBase + "/" + objDetalle.CarpetaImagenes + "/" + oEmpleado.Codigo + "/" + oEmpleado.Foto;
                savePath = Server.MapPath(@"~\" + savePath);
                string urlFoto = objDetalle.UrlImagenes + oEmpleado.Codigo + "/" + oEmpleado.Foto;
                imgFoto.ImageUrl = (File.Exists(savePath)) ? urlFoto : "~/images/profile.png";*/

                if (hdnEstado.Value == "Edit")
                {
                    int num = Convert.ToInt16(Session["IdRol"]);
                    cbeEliminar.TargetControlID = "btnEliminar";

                    cbeEliminar.ConfirmText = "¿Está seguro que desea desactivar el empleado?";

                }
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
                    txtFactReserva.Text = Convert.ToString(oEDocumentos.DocNumFactReserva);

                    this.lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " " + oEDocumentos.FechaRegistro;
                    this.lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " " + oEDocumentos.FechaCambio;
                }
                else
                {
                    Utilitario.MostrarMensaje(oEDocumentos.UltimoResultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarDocumentos()
        {
            try
            {
                Entity.CEDocumento oEDocumentos = null;
                oEDocumentos = new Entity.CEDocumento();
                oEDocumentos.Activo = !chkEliminados.Checked;
                oEDocumentos.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                oEDocumentos = CapaNegocio.CNDocumento.Listar(oEDocumentos);
                Session["Documentos"] = oEDocumentos.LstDocumento;
                gvwEmpleado.DataSource = Session["Documentos"];
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataBind();


            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
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
                    Entity.CEDocumento oEmpresa = new Entity.CEDocumento();
                    oEmpresa.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                    String texto = string.Empty;
                    texto = txtSearch.Text;
                    txtSearch.Text = string.Empty;
                    oEmpresa = CapaNegocio.CNDocumento.ListarByTexto(oEmpresa, texto);
                    Session["Documentos"] = oEmpresa.LstDocumento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Documentos"];
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
                            buscar = " and year (D.FechaRegistro) ='" + fecha + "' ";
                        }
                        else if (fecha.Length <= 6 && fecha.Length > 4)
                        {
                            buscar = " and year (D.FechaRegistro) ='" + fecha.Substring(0, 4) + "' and month(D.FechaRegistro) ='" + fecha.Substring(4, 2) + "' ";
                        }
                        else if (fecha.Length <= 8 && fecha.Length > 6)
                        {
                            buscar = " and year (D.FechaRegistro) ='" + fecha.Substring(0, 4) + "' and month(D.FechaRegistro) ='" + fecha.Substring(4, 2) + "' and day(D.FechaRegistro) ='" + fecha.Substring(6, 2) + "' ";
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

                    Entity.CEDocumento oDocumento = new Entity.CEDocumento();
                    oDocumento.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                    oDocumento.empresa = ddlEmpresaSearch.SelectedValue;
                    oDocumento = CapaNegocio.CNDocumento.ListarByTipoBusqueda(oDocumento, buscar);
                    Session["Documentos"] = oDocumento.LstDocumento;
                    gvwEmpleado.PageIndex = 0;
                    gvwEmpleado.DataSource = Session["Documentos"];
                    gvwEmpleado.DataBind();


                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }


        /// <summary>
        /// Carga la grilla según la Empresa seleccionada
        /// </summary>
        private void Funciones_ddlEmpresaSearch()
        {
            try
            {
                Entity.CEDocumento oDocumentos = new Entity.CEDocumento();
                oDocumentos.empresa = ddlEmpresaSearch.SelectedValue;
                oDocumentos.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                oDocumentos = CapaNegocio.CNDocumento.ListarByEmpresa(oDocumentos);
                Session["Documentos"] = oDocumentos.LstDocumento;
                gvwEmpleado.PageIndex = 0;
                gvwEmpleado.DataSource = Session["Documentos"];
                gvwEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        /// <summary>
        /// Obtiene los datos de los controles y se le asigna a la entidad Documento.
        /// </summary>
        /// 
        private Entity.CEDocumento ObtenerDatos()
        {
            Entity.CEDocumento oeDocumento = new Entity.CEDocumento();
            try
            {
                oeDocumento.empresa = ddlEmpresa.SelectedValue;
                oeDocumento.norden = txtNrOrden.Text;
                oeDocumento.Proveedor = txtProveedor.Text;
                oeDocumento.ruc = txtRuc.Text;
                oeDocumento.nrodoc = txtNrDocumento.Text;
                oeDocumento.formpago = txtFrPago.Text;
                oeDocumento.tipodoc = ddlTDocumento.SelectedValue;
                oeDocumento.tipo = ddlTipo.SelectedValue;
                oeDocumento.moneda = txtMoneda.Text;
                oeDocumento.montoini = Convert.ToDecimal(txtMonIni.Text);
                oeDocumento.fecharec = Convert.ToDateTime(txtFechaRecepcion.Text);
                oeDocumento.montoact = Convert.ToDecimal(txtSaldAct.Text);
                oeDocumento.fechadoc = Convert.ToDateTime(txtFechaDoc.Text);
                oeDocumento.monto = Convert.ToDecimal(txtMonFac.Text);
                oeDocumento.fechaven = Convert.ToDateTime(txtFechaVen.Text);
                oeDocumento.fechaact = DateTime.Today;
                oeDocumento.Comentario = txtComentario.Text;
                oeDocumento.DocNumFactReserva = Convert.ToInt32(txtFactReserva.Text);

                //Movimientos               

                //oeDocumento.IdPais = Convert.ToInt32(ddlPais.SelectedValue);
                //oeDocumento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

            return oeDocumento;
        }


        /// <summary>
        /// Obtiene los datos de los controles y se le asigna a la entidad Empresa.
        /// </summary>
        /// 
        private Entity.CEMovimientos ObtenerMovimientos()
        {
            Entity.CEMovimientos oeMovimiento = new Entity.CEMovimientos();
            //Entity.CEMovimientos oeMovimiento = new Entity.CEMovimientos();

            try
            {
                //oeMovimiento.IdDocumento = NrCorre;
                oeMovimiento.Fechaini = DateTime.Today;
                oeMovimiento.Fechafin = DateTime.Today;
                oeMovimiento.Estado = "INGRESADO";
                oeMovimiento.Origen = 1;
                oeMovimiento.Destino = 1;
                oeMovimiento.Observac = "";
                oeMovimiento.Situacion = "O";
                //oeDocumento.moneda = txtMoneda.Text;
                //oeDocumento.montoini = Convert.ToDecimal(txtMonIni.Text);
                //oeDocumento.fecharec = Convert.ToDateTime(txtFechaRecepcion.Text);
                //oeDocumento.montoact = Convert.ToDecimal(txtSaldAct.Text);
                //oeDocumento.fechadoc = Convert.ToDateTime(txtFechaDoc.Text);
                //oeDocumento.monto = Convert.ToDecimal(txtMonFac.Text);
                //oeDocumento.fechaven = Convert.ToDateTime(txtFechaVen.Text);
                //oeDocumento.fechaact = DateTime.Today;

                //Movimientos



                //oeDocumento.IdPais = Convert.ToInt32(ddlPais.SelectedValue);
                //oeDocumento.UsuarioModificador = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

            return oeMovimiento;
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
            txtNrOrdenBusOrden.Enabled = aviso;
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
            btnBuscarOrden.Enabled = aviso;
            //btnCambiarImagen.Enabled = aviso;
            ddlEmpresaBusOrden.Enabled = aviso;
            ddlEmpresa.Enabled = aviso;
            
        }

        /// <summary>
        /// Genera el Correlativo del Documento.
        /// </summary>
        private void GenerarCorrelativo()
        {
            
                Entity.CEDocumento oeDocumento = new Entity.CEDocumento();
          
                oeDocumento = CapaNegocio.CNDocumento.GenerarCorrelativo(oeDocumento);
           
                if(  oeDocumento.IdDocumento > 0){
                    NrCorre = oeDocumento.IdDocumento + 1;
                }
                else{
                    NrCorre = 1;
                
                }

        }

        /// <summary>
        /// Agregar Documentos y Moviemiento
        /// </summary>
        private void AgregarDocumento()
        {
            try
            {
                Entity.CEDocumento oeDocumento = new Entity.CEDocumento();
                Entity.CEMovimientos oeMovimiento = new Entity.CEMovimientos();
                oeDocumento = this.ObtenerDatos();

                Negocio.ClsValidar x = new Negocio.ClsValidar();
                DataTable dt = x.Validar(ddlEmpresa.SelectedItem.ToString(), txtProveedor.Text.Trim(), txtNrDocumento.Text.Trim(), txtNrOrden.Text.Trim());            
              
                if (hdnEstado.Value == "New")
                {

                    DateTime fechaactual, fechavenci;
                    TimeSpan contar;
                    Int32 dias;
                    fechaactual = Convert.ToDateTime(txtFechaRecepcion.Text);
                    fechavenci = Convert.ToDateTime(txtFechaVen.Text);
                    contar = fechavenci - fechaactual;
                    dias = contar.Days;

                    if (DateTime.TryParse(txtFechaVen.Text, out fechavenci))
                    {

                        if (dias <= 365)
                        {

                            if (dt.Rows.Count > 0)
                            {                                
                            
                                 Utilitario.MostrarMensaje("Documento que esta registrado ya existe en la web documentaria.");
                            }
                            else
                            {
                                oeMovimiento = this.ObtenerMovimientos();
                                GenerarCorrelativo();
                                oeDocumento.IdDocumento = NrCorre;
                                oeDocumento.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                                oeDocumento.UsuarioModificador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                                oeDocumento = CapaNegocio.CNDocumento.Registrar(oeDocumento);

                                oeMovimiento.IdDocumento = NrCorre;
                                oeMovimiento.Origen = Utilitario.ObtenerUsuarioActual().IdUsuario;
                                oeMovimiento.Destino = Utilitario.ObtenerUsuarioActual().IdUsuario;
                                oeMovimiento.UsuarioCreador = Utilitario.ObtenerUsuarioActual().IdUsuario;
                                oeMovimiento.UsuarioModificador = Utilitario.ObtenerUsuarioActual().IdUsuario;

                                Utilitario.MostrarMensaje(oeDocumento.UltimoResultado.Mensaje);

                                oeMovimiento = CapaNegocio.CNMovimientos.Registrar(oeMovimiento);
                                //Intellisoft.Project.Util.Utilitario.MostrarMensaje(oeMovimiento.UltimoResultado.Mensaje);

                                Utilitario.LimpiarControles(this.Controls);
                                hdnEstado.Value = "New";
                            }
                        }
                        else
                        {
                            Utilitario.MostrarMensaje("La fecha de vencimiento excede los 365 dias del Año.");
                        }

                    }
                    else
                    {
                        Utilitario.MostrarMensaje("Debe completar fecha de vencimiento.");
                    }

                                    

                    

                }
                else if (hdnEstado.Value == "Edit")
                {
                    oeDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                    //oeEmpresa.Nombre = Convert.ToString(txtNombre.Text);
                    //oeEmpresa.IdPais = Convert.ToInt32(ddlPais.SelectedValue);
                    oeDocumento = CapaNegocio.CNDocumento.Actualizar(oeDocumento);
                    Utilitario.MostrarMensaje(oeDocumento.UltimoResultado.Mensaje);
                }

                if (oeDocumento.UltimoResultado.ResultadoOperacion == 1)
                {
                    //Cargarmpresas;
                    //HabilitarEdicion(true);
                    gvwEmpleado.Columns[1].Visible = false;
                    //gvwEmpresa.Columns[2].Visible = false;
                }
                else
                    Utilitario.MostrarMensaje("Ingrese correctamente el orden de las fechas del Proyecto.");
            }
            catch (Exception ex)
            { Log.RegistrarIncidencia(ex); }
        }

        protected void gvwEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                Entity.CEDocumento oDocumento = new Entity.CEDocumento();


                switch (e.CommandName)
                {
                    case "Editar":
                        hdnEstado.Value = "Edit";
                        Session["IdDocumento"] = e.CommandArgument.ToString();
                        oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                        CargarControles(true);
                        //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);
                        //RecuperarDatos(oDocumento);                        
                        HabilitarFormulario(true, 0);
                        pnlEliminar.Visible = true;
                        pnlLimpiar.Visible = false;
                        tSeguridad.Visible = true;

                        break;


                    case "Ver":
                        hdnEstado.Value = "View";
                        Session["IdDocumento"] = e.CommandArgument.ToString();
                        BloquearControles(false);
                        oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                        CargarControles(false);
                        //oDocumento = CapaNegocio.CNDocumento.Obtener(oDocumento);                                               
                        //RecuperarDatos(oDocumento);
                        HabilitarFormulario(true, 0);
                        pnlLimpiar.Visible = false;
                        pnlGrabar2.Visible = false;
                        pnlBusOrden.Visible = false;
                        pnlEliminar.Visible = true;
                        pnlRestaurar.Visible = true;
                        tSeguridad.Visible = true;
                        //lblliminarEmpresa.Text = "Eliminar";

                        break;
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

        }

        protected void gvwEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwEmpleado.PageIndex > -1)
                {
                    gvwEmpleado.PageIndex = e.NewPageIndex;
                    gvwEmpleado.DataSource = Session["Documentos"];
                    gvwEmpleado.DataBind();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPagina(sender as DropDownList);

        }

        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {
            //btnGrabar2.Visible = false;
            AgregarDocumento();


            //CargarComboJefes(ddlJefeSearch, 0);
            ddlEmpresaSearch.SelectedIndex = 0;

            cbeEliminar.TargetControlID = "btnEliminar";
            LimpiarSesion();
            //System.Threading.Thread.Sleep(5000);
           // btnGrabar2.Visible = true;
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                if (hdnEstado.Value == "Edit")
                    ActualizarEstado();
                else
                {
                    cbeEliminar.ConfirmText = "¿Está seguro que desea eliminar definitivamente la empresa?";
                    EliminarFisico();
                }
                LimpiarControles();
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }

        }

        protected void btnlimpiar_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarControles();
            ddlEmpresaBusOrden.SelectedIndex = 0;
        
        }

        protected void btnRestaurar_Click(object sender, ImageClickEventArgs e)
        {
            ActualizarEstado();
        
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                hdnEstado.Value = "F";
                HabilitarFormulario(false, 0);
                LimpiarControles();
                txtNrOrdenBusOrden.Text = string.Empty;
                //CargarDocumentos();
                BloquearControles(true);
                cbeEliminar.TargetControlID = "btnEliminar";
                LimpiarSesion();
            }
            catch (Exception ex)
            {
                Utilitario.MostrarMensaje(ex.Message.ToString());
            }
        }

        protected void ddlEmpresaBusOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            this.txtNrOrdenBusOrden.Text = string.Empty;
            //ddlTipoBusSap.SelectedValue = "0";
            txtNrOrdenBusOrden.Focus();
        }

        protected void ddlTipoBusSap_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            this.txtNrOrdenBusOrden.Text = string.Empty;
            txtNrOrdenBusOrden.Focus();
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNrOrden.Focus();
        }

        protected void ddlTDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFechaRecepcion.Focus();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonIni.Focus();
        }

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {

            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Documentos"];
            gvwEmpleado.DataBind();

        }
  
        protected void ibNuevoEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            hdnEstado.Value = "New";
            HabilitarFormulario(true, 0);
            pnlGrabar2.Visible = true;
            pnlLimpiar.Visible = true;
            //CargarCombosFormulario();
            //this.txtNrOrdenBusOrden.Text = string.Empty;
            //this.txtContraseña.Attributes.Add("value", string.Empty);
            //this.txtContraseña.Attributes.Add("value", this.txtContraseña.Text);
        }

        protected void chkEliminados_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (chkEliminados.Checked)
                {
                    CargarDocumentos();
                    HabilitarBusqueda(false);
                }
                else
                {
                    CargarDocumentos();
                    HabilitarBusqueda(true);
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();        
        }
        protected void btnTipoBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            Funciones_btnSearch();
        }

        protected void btnBuscarOrden_Click(object sender, ImageClickEventArgs e)
        {

            if (ddlTipoBusSap.SelectedValue == "0") 
            {
                CargarDocumentosxOrden();
                HabilitarFormulario(true, 0);
                txtNrDocumento.Focus();            
            }
            else if (ddlTipoBusSap.SelectedValue == "1")
            {
                CargarDocumentosxRuc();
                HabilitarFormulario(true, 0);
                txtNrDocumento.Focus();  

            }



        
        
        }

        protected void ddlEmpresaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Funciones_ddlEmpresaSearch();
            txtSearch.Focus();
        
        }

        protected void txtFechaRecepcion_DateChanged(object sender, EventArgs e)
        {
            int dias = 0;

            string input = txtFrPago.Text;

            if (input.Contains("%") || input.Length < 1)
            {
                txtFechaVen.Text = txtFechaRecepcion.Text;
            }

            else
            {
                string result = Regex.Replace(input, @"[^\d]", "");
                if (result.Length > 0)
                {
                    txtFechaVen.Text = txtFechaRecepcion.Text;

                    dias = Convert.ToInt32(result);



                    DateTime fecha = Convert.ToDateTime(txtFechaRecepcion.Text);

                    fecha = fecha.AddDays(dias);

                    string resultado = fecha.ToString("dd/MM/yyyy");

                    txtFechaVen.Text = resultado;

                }
                else
                {
                    txtFechaVen.Text = txtFechaRecepcion.Text;


                }
            }


            txtFechaDoc.Focus();

        }

    }
}