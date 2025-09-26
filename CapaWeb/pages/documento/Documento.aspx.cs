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
using System.Net.Mail;

namespace CapaWeb.pages.documento
{
    public partial class Documento : System.Web.UI.Page
    {
        private DataTable dtld;
        Negocio.CNDistribucion objCNDIST;
        int NrCorre = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //dgvDocAdjuntos.DataSource = null;
            //dgvDocAdjuntos.DataBind();

            if (!this.IsPostBack)
            {
                HabilitarFormulario(false, 0);
                CargarDocumentos();
                gvwEmpleado.Columns[1].Visible = true;

                List<string> listAdjuntos = Session["listAdjuntos"] as List<string>;
                if (listAdjuntos != null)
                {
                    string destinationFolder = Server.MapPath("~/adjuntos");
                    //****Reemplazar solo de manera visual la ruta que se muestra en la tabla****//
                    List<string> listAdjuntos_Ruta = new List<string>();
                    if (listAdjuntos.Count > 0)
                    {
                        for (int i = 0; i < listAdjuntos.Count; i++)
                        {
                            String archivo = listAdjuntos[i].ToString().Replace(destinationFolder + "\\", "");
                            listAdjuntos_Ruta.Add(archivo);
                        }
                    }
                    //***************************************************************************//

                    dgvDocAdjuntos.DataSource = listAdjuntos_Ruta;
                    dgvDocAdjuntos.DataBind();
                }

                int IdUsuario = Utilitario.ObtenerUsuarioActual().IdUsuario;
                if ( (IdUsuario == 179) || (IdUsuario == 184) || (IdUsuario == 151))
                {
                    pnlAdjuntar.Visible = true;
                    FileUpload1.Visible = true;
                    dgvDocAdjuntos.Visible = true;
                }

            }
        }

        private void LimpiarControles()
        {
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
            TxtFePago.Text = string.Empty;

            ddlTDocumento.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            ddlTMoneda.SelectedIndex = 0;
            txtMonIni.Text = string.Empty;
            txtSaldAct.Text = string.Empty;
            txtMonFac.Text = string.Empty;
            txtComentario.Text = string.Empty;
            txtNroEr.Text = string.Empty;

            txtCanComPago.Text = string.Empty;
            txtFactReserva.Text = string.Empty;
            Session["listAdjuntos"] = null;
            dgvDocAdjuntos.DataSource = null;
            dgvDocAdjuntos.DataBind();
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
            gvwEmpleado.Columns[1].Visible = activo;
            gvwEmpleado.Columns[0].Visible = activo;
            ddlEmpresaSearch.SelectedIndex = 0;
        }

        private void LimpiarListas()
        {

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
            pnlCancelar2.Visible = activo;
            pnlGrabar2.Visible =  activo;
            pnlAdjuntar.Visible = activo;
            pnlRestaurar.Visible = (accion == 2 && activo);
            pnlEliminar.Visible = (accion == 1 && activo);
            tSeguridad.Visible = (accion != 0 && activo);

            if (Utilitario.ObtenerUsuarioActual().IdUsuario == 30 || Utilitario.ObtenerUsuarioActual().IdUsuario == 17)
            {
                TxtFePago.Enabled = true;
            }
            else
            {
                TxtFePago.Enabled = false;
            }
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
                }
                else if (emp.Equals("China Bolts"))
                {
                    oEDocumentos.empresa = "SBO_BB";
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
                ddlTMoneda.SelectedValue = oEDocumentos.moneda;
                txtMonIni.Text = Convert.ToString(oEDocumentos.montoini);
                txtSaldAct.Text = Convert.ToString(oEDocumentos.montoact);
                txtFechaVen.Text = oEDocumentos.Vencimiento;
                txtNroEr.Text = oEDocumentos.ER;
                    
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

                if (emp.Equals("China Bolts"))
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
                    else if (emp.Equals("Steel Form"))
                    {
                        oEDocumentos.empresa = "SBO_SF";
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
                ddlTMoneda.SelectedValue = oEDocumentos.moneda;              
                txtMonIni.Text = Convert.ToString(oEDocumentos.montoini);
                txtSaldAct.Text = Convert.ToString(oEDocumentos.montoact);
                txtMonFac.Text = Convert.ToString(oEDocumentos.monto);

                txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");
                txtFactReserva.Text = Convert.ToString(oEDocumentos.DocNumFactReserva);
                txtNroEr.Text= Convert.ToString(oEDocumentos.ER);
                TxtFePago.Text = Convert.ToDateTime(oEDocumentos.Fepago).ToString("dd/MM/yyyy");

                lblUserReg.Text = oEDocumentos.NombreUsuarioCreador + " / " + oEDocumentos.FechaRegistro;
                lblUserCambio.Text = oEDocumentos.NombreUsuarioCambio + " / " + oEDocumentos.FechaCambio;

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
                    ddlTMoneda.SelectedValue = oEDocumentos.moneda;
                    txtMonIni.Text = Convert.ToString(oEDocumentos.montoini);
                    txtSaldAct.Text = Convert.ToString(oEDocumentos.montoact);
                    txtMonFac.Text = Convert.ToString(oEDocumentos.monto);
                    txtComentario.Text = oEDocumentos.Comentario;

                    txtFechaDoc.Text = Convert.ToDateTime(oEDocumentos.fechadoc).ToString("dd/MM/yyyy");
                    txtFechaRecepcion.Text = Convert.ToDateTime(oEDocumentos.fecharec).ToString("dd/MM/yyyy");
                    txtFechaVen.Text = Convert.ToDateTime(oEDocumentos.fechaven).ToString("dd/MM/yyyy");
                    txtFactReserva.Text = Convert.ToString(oEDocumentos.DocNumFactReserva);
                    txtNroEr.Text= Convert.ToString(oEDocumentos.ER);
                    TxtFePago.Text= Convert.ToDateTime(oEDocumentos.Fepago).ToString("dd/MM/yyyy");
                    txtCanComPago.Text = oEDocumentos.CanComPago.ToString();

                    String[] cantDocAd = oEDocumentos.DocAdjuntos.ToString().Split('/');
                    
                    List<string> listAdjuntos = new List<string>();

                    for (int x = 0;  x < cantDocAd.Length-1; x++)
                    {
                        listAdjuntos.Add(cantDocAd[x]);
                    }
                    Session["listAdjuntos"] = listAdjuntos;
                    dgvDocAdjuntos.DataSource = listAdjuntos;
                    dgvDocAdjuntos.DataBind();


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
                string destinationFolder = Server.MapPath("~/adjuntos");

                List<string> listAdjuntos = Session["listAdjuntos"] as List<string>;
                if (listAdjuntos != null && listAdjuntos.Count > 0)
                {
                    String adjuntos = "";
                    for (int i = 0; i < listAdjuntos.Count; i++)
                    {
                        adjuntos = adjuntos + listAdjuntos[i].ToString().Replace(destinationFolder + "\\", "") + '/';
                    }
                    oeDocumento.DocAdjuntos = adjuntos;
                }
                oeDocumento.Prioridad = ddlTipoPrioridad.SelectedValue;

                oeDocumento.empresa = ddlEmpresa.SelectedValue;
                oeDocumento.norden = txtNrOrden.Text;
                oeDocumento.Proveedor = txtProveedor.Text;
                oeDocumento.ruc = txtRuc.Text;
                oeDocumento.nrodoc = txtNrDocumento.Text;
                oeDocumento.formpago = txtFrPago.Text;
                oeDocumento.tipodoc = ddlTDocumento.SelectedValue;
                oeDocumento.tipo = ddlTipo.SelectedValue;
                oeDocumento.moneda = ddlTMoneda.SelectedValue;
                oeDocumento.montoini = (txtMonIni.Text == "")? Convert.ToDecimal("0.00") : Convert.ToDecimal(txtMonIni.Text); // Convert.ToDecimal(txtMonIni.Text);
                oeDocumento.fecharec = Convert.ToDateTime(txtFechaRecepcion.Text);
                oeDocumento.montoact = (txtSaldAct.Text == "") ? Convert.ToDecimal("0.00") : Convert.ToDecimal(txtSaldAct.Text); //Convert.ToDecimal(txtSaldAct.Text);
                oeDocumento.monto = (txtMonFac.Text == "") ? Convert.ToDecimal("0.00") : Convert.ToDecimal(txtMonFac.Text); //Convert.ToDecimal(txtMonFac.Text);
                oeDocumento.fechaven = Convert.ToDateTime(txtFechaVen.Text);
                oeDocumento.fechaact = DateTime.Today;
                oeDocumento.Comentario = txtComentario.Text;
                oeDocumento.DocNumFactReserva = (txtFactReserva.Text == "") ? Convert.ToInt32("0") : Convert.ToInt32(txtFactReserva.Text); //Convert.ToInt32(txtFactReserva.Text);
                oeDocumento.ER = Convert.ToString(txtNroEr.Text);
                oeDocumento.CanComPago = (txtCanComPago.Text == "") ? Convert.ToInt32("0") : Convert.ToInt32(txtCanComPago.Text); //Convert.ToInt32(txtCanComPago.Text);

                oeDocumento.fechadoc = Convert.ToDateTime(txtFechaDoc.Text);
                oeDocumento.Fepago = Convert.ToDateTime(TxtFePago.Text);

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

            try
            {
                oeMovimiento.Fechaini = DateTime.Today;
                oeMovimiento.Fechafin = DateTime.Today;
                oeMovimiento.Estado = "INGRESADO";
                oeMovimiento.Origen = 1;
                oeMovimiento.Destino = 1;
                oeMovimiento.Observac = "";
                oeMovimiento.Situacion = "O";
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
            ddlTMoneda.Enabled = aviso;
            txtMonIni.Enabled = aviso;
            txtSaldAct.Enabled = aviso;
            txtMonFac.Enabled = aviso;
            txtComentario.Enabled = aviso;
            btnBuscarOrden.Enabled = aviso;
            ddlEmpresaBusOrden.Enabled = aviso;
            ddlEmpresa.Enabled = aviso;
            txtNroEr.Enabled = aviso;
            TxtFePago.Enabled = aviso;
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
        /// Agregar Documentos y Movimiento
        /// </summary>
        private void AgregarDocumento()
        {
            try
            {
                Entity.CEDocumento oeDocumento = new Entity.CEDocumento();
                Entity.CEMovimientos oeMovimiento = new Entity.CEMovimientos();
                oeDocumento = this.ObtenerDatos();

                string TDO = ddlTDocumento.SelectedValue;
                string NER = txtNroEr.Text;
                if (TDO == "ER" && NER.ToString() == "")
                {
                    Utilitario.MostrarMensaje("Debe ingresar el número de Entrega a Rendir");
                }
                else
                {
                    Negocio.ClsValidar x = new Negocio.ClsValidar();
                    DataTable dt;

                    if (TDO != "Lote de Importacion")
                    {
                         dt= x.Validar(ddlEmpresa.SelectedItem.ToString(), txtRuc.Text.Trim(), txtNrDocumento.Text.Trim(), txtNrOrden.Text.Trim());
                    }
                    else
                    {
                         dt = x.ValidarFR(ddlEmpresa.SelectedItem.ToString(), txtRuc.Text.Trim(), txtFactReserva.Text.Trim(), txtNrOrden.Text.Trim());
                    }
                    

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

                                if (dt.Rows.Count >0)
                                {

                                    Utilitario.MostrarMensaje("Documento que está registrando ya existe en la web documentaria.");
                                }
                                else
                                {

                                    int IdUsuario = Utilitario.ObtenerUsuarioActual().IdUsuario;

                                    oeMovimiento = this.ObtenerMovimientos();
                                    GenerarCorrelativo(); 
                                    oeDocumento.IdDocumento = NrCorre;
                                    oeDocumento.UsuarioCreador = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;
                                    oeDocumento.UsuarioModificador = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;
                                    oeDocumento.ER = txtNroEr.Text;
                                    oeDocumento = CapaNegocio.CNDocumento.Registrar(oeDocumento); 

                                    oeMovimiento.IdDocumento = NrCorre;
                                    oeMovimiento.Origen = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;
                                    oeMovimiento.Destino = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;
                                    oeMovimiento.UsuarioCreador = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;
                                    oeMovimiento.UsuarioModificador = IdUsuario; //Utilitario.ObtenerUsuarioActual().IdUsuario;

                                    Utilitario.MostrarMensaje(oeDocumento.UltimoResultado.Mensaje);

                                    oeMovimiento = CapaNegocio.CNMovimientos.Registrar(oeMovimiento);

                                    if ((oeDocumento.Prioridad == "Urgente" && oeDocumento.tipodoc == "Factura" && oeDocumento.UsuarioCreador == 179) ||
                                        (oeDocumento.Prioridad == "Urgente" && oeDocumento.tipodoc == "Factura" && oeDocumento.UsuarioCreador == 184)
                                        ) 

                                    {
                                        enviarCorreoPrioridad(oeDocumento.IdDocumento, oeDocumento.empresa, oeDocumento.Proveedor, oeDocumento.ruc, oeDocumento.nrodoc, oeDocumento.tipodoc, oeDocumento.monto, oeDocumento.norden, oeDocumento.moneda);
                                        //enviarCorreoPrioridad(oeDocumento.IdDocumento, oeDocumento.empresa, oeDocumento.tipodoc, oeDocumento.nrodoc, oeDocumento.Proveedor, oeDocumento.monto);
                                    }

                                    Utilitario.LimpiarControles(this.Controls);
                                    hdnEstado.Value = "New";

                                    Session["listAdjuntos"] = null;

                                    dgvDocAdjuntos.DataSource = null;
                                    dgvDocAdjuntos.DataBind();
                                    //}
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
                        oeDocumento.ER = txtNroEr.Text;
                        oeDocumento = CapaNegocio.CNDocumento.Actualizar(oeDocumento);
                        Utilitario.MostrarMensaje(oeDocumento.UltimoResultado.Mensaje);
                    }

                    if (oeDocumento.UltimoResultado.ResultadoOperacion == 1)
                    {
                        gvwEmpleado.Columns[1].Visible = true;// false;
                    }
                    else
                        Utilitario.MostrarMensaje("Ingrese correctamente el orden de las fechas del Proyecto.");
                }
            }
            catch (Exception ex)
            { Log.RegistrarIncidencia(ex); }
        }

        protected void enviarCorreoPrioridad(int IdDocumento, string Empresa, string Proveedor, string Ruc, string NroDocumento, string TipoDocumento, decimal Monto, string NroOrden, string Moneda)
        {
            MailMessage miCorreo = new MailMessage();
            miCorreo.IsBodyHtml = true;

            miCorreo.From = new System.Net.Mail.MailAddress("AlertasGMI@metalindustrias.com.pe");
            miCorreo.To.Add("rhernandez@metalindustrias.com.pe"); //PARA
            miCorreo.To.Add("garismendiz@metalindustrias.com.pe"); //PARA           
            miCorreo.CC.Add("sarias@metalindustrias.com.pe"); //CON COPIA
            miCorreo.CC.Add("lespinoza@metalindustrias.com.pe"); //CON COPIA
            miCorreo.CC.Add("rsalas@metalindustrias.com.pe"); //CON COPIA
            miCorreo.CC.Add("jestela@metalindustrias.com.pe"); //CON COPIA
            miCorreo.CC.Add("ycaycho@metalindustrias.com.pe"); //CON COPIA
            miCorreo.Bcc.Add("aplicaciones@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("squispe@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("kgalvez@metalindustrias.com.pe"); //CON COPIA OCULTA
            miCorreo.Bcc.Add("scastillo@metalindustrias.com.pe"); //CON COPIA OCULTA

            miCorreo.CC.Add("CPMENDOZA@MEGAESTRUCTURAS.PE"); // CON COPIA Catherine
            miCorreo.CC.Add("gchagua@megaestructuras.pe"); // CON COPIA Guisela
            miCorreo.Bcc.Add("blopez@metalindustrias.com.pe"); // CON COPIA Bryan

            miCorreo.Subject = "MONTALVO - DOCUMENTO REGISTRADO CON ESTADO URGENTE";

            miCorreo.Body = "Estimados, buen día.<br><br>" +
                        //"Se creo un documento en la web documentaria con estado Urgente con las siguientes caracteristicas:<br><br>" +
                        "Se creó un documento en la web documentaria con estado " +
                        "<span style='color:red; font-weight:bold;'>Urgente</span> con los siguientes datos:<br><br>" +   
                        "Id Documento: " + IdDocumento.ToString() + "<br>" +
                        "Empresa: " + Empresa + "<br><br>" +

                        "Nro Orden: " + NroOrden + "<br>" +
                        "Proveedor: " + Proveedor + "<br>" +
                        "Ruc: " + Ruc + "<br>" +
                        "Tipo Doc.: " + TipoDocumento + "<br>" +
                        "Nro Doc.: " + NroDocumento + "<br>" +
                        "Moneda: " + Moneda + "<br>" +
                        "Monto Total: " + Monto + "<br>";

            miCorreo.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "mail.metalindustrias.com.pe";
            smtp.Credentials = new System.Net.NetworkCredential("AlertasGMI@metalindustrias.com.pe", "{8fXUTLcdHA@");
            smtp.Timeout = 9999999;
            smtp.Send(miCorreo);
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
                        HabilitarFormulario(true, 0);
                        pnlEliminar.Visible = true;
                        pnlLimpiar.Visible = false;
                        tSeguridad.Visible = true;

                        OcultarCamposLoteImportacion();

                        break;


                    case "Ver":
                        hdnEstado.Value = "View";
                        Session["IdDocumento"] = e.CommandArgument.ToString();
                        BloquearControles(false);
                        oDocumento.IdDocumento = Convert.ToInt32(Session["IdDocumento"]);
                        CargarControles(false);
                        HabilitarFormulario(true, 0);
                        pnlLimpiar.Visible = false;
                        pnlGrabar2.Visible = false;
                        pnlBusOrden.Visible = false;
                        pnlAdjuntar.Visible = false;
                        pnlEliminar.Visible = true;
                        pnlRestaurar.Visible = true;
                        tSeguridad.Visible = true;
                        
                        break;

                    case "Delete":

                        string destinationFolder = Server.MapPath("~/adjuntos");

                        List<string> listAdjuntos = Session["listAdjuntos"] as List<string>;
                        if (listAdjuntos == null)
                        {
                            listAdjuntos = new List<string>();
                        }

                        int indice = Convert.ToInt32(e.CommandArgument);
                        listAdjuntos.RemoveAt(indice);
                        Session["listAdjuntos"] = listAdjuntos;


                        //****Reemplazar solo de manera visual la ruta que se muestra en la tabla****//
                        List<string> listAdjuntos_Ruta = new List<string>();
                        if (listAdjuntos.Count > 0)
                        {
                            for (int i = 0; i < listAdjuntos.Count; i++)
                            {
                                //String archivo = listAdjuntos[i].ToString().Replace("C:\\Users\\practicanteti\\Downloads\\Web Documentaria\\TramiteDocumentario_v1.5\\CapaWeb\\adjuntos\\", "");
                                String archivo = listAdjuntos[i].ToString().Replace(destinationFolder + "\\", "");
                                listAdjuntos_Ruta.Add(archivo);
                            }
                        }
                        //***************************************************************************//

                        dgvDocAdjuntos.DataSource = listAdjuntos_Ruta;
                        dgvDocAdjuntos.DataBind();

                        break;

                    case "VerAdjuntos":
                        GridViewRow obj_row_consol = null;
                        HiddenField hdnIdDocumento = null;
                        string str_para_encr_1 = string.Empty;
                        obj_row_consol = this.gvwEmpleado.Rows[Convert.ToInt32(e.CommandArgument)];
                        hdnIdDocumento = (obj_row_consol.FindControl("hdnIdDocumento") as HiddenField);

                        str_para_encr_1 = hdnIdDocumento.Value;

                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../../pages/herramientas/VistaAdjuntosDoc.aspx?var1=" + str_para_encr_1 + "', null, 'height=600, width=900, status=no, toolbar=no, scrollbars=no, menubar=no, location=no, top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void OcultarCamposLoteImportacion(){
            if (ddlTDocumento.SelectedItem.Value == "Lote de Importacion")
            {
                ddlTDocumento.Text = "Lote de Importacion";
                txtProveedor.Enabled = false;
                txtNrOrden.Enabled = false;
                txtRuc.Enabled = false;
                ddlTMoneda.Enabled = false;
                txtNrDocumento.Enabled = false;
                txtFrPago.Enabled = false;
                ddlTipo.Enabled = false;
                txtFechaVen.Enabled = false;
                txtFechaDoc.Enabled = false;
                txtMonIni.Enabled = false;
                txtMonFac.Enabled = false;
                txtSaldAct.Enabled = false;
                txtComentario.Enabled = false;
                txtNroEr.Enabled = false;
            }
        }
        
        protected void dgvDocAdjuntos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
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

            int valorEntero;
            if(txtFactReserva.Text == "") {
                txtFactReserva.Text = "0";
            }
            if (txtCanComPago.Text == "")
            {
                txtCanComPago.Text = "0";
            }
            bool esEntero = int.TryParse(txtFactReserva.Text, out valorEntero);

            if (esEntero == false)
            {
                Utilitario.MostrarMensaje("El campo Fac. Reserva SAP solo puede contener números enteros.");
                return;
            }

            esEntero = int.TryParse(txtCanComPago.Text, out valorEntero);
            if (esEntero == false)
            {
                Utilitario.MostrarMensaje("El campo Cant. Comprobantes de Pago solo puede contener números enteros.");
                return;
            }

            int IdUsuario = Utilitario.ObtenerUsuarioActual().IdUsuario;
            if ((dgvDocAdjuntos.Rows.Count == 0 && ddlTDocumento.Text == "Factura" && IdUsuario == 179) ||
                (dgvDocAdjuntos.Rows.Count == 0 && ddlTDocumento.Text == "Factura" && IdUsuario == 184) ||
                (dgvDocAdjuntos.Rows.Count == 0 && ddlTDocumento.Text == "Factura" && IdUsuario == 151)
                )
            {
                Utilitario.MostrarMensaje("Debe de adjuntar los documentos de la Factura!");
                return;
            }


            if (ddlTDocumento.SelectedItem.Value != "Lote de Importacion") {
                string rspt = validacionesDeCampo();
                if (rspt != "0") {
                    Utilitario.MostrarMensaje(rspt);
                    return;
                }
            }

            if (ddlTDocumento.SelectedItem.Value == "Lote de Importacion" && (ddlEmpresa.SelectedValue == "-1" || txtFechaRecepcion.Text == "" || txtFactReserva.Text == "" || txtCanComPago.Text == ""))
            {
                Utilitario.MostrarMensaje("Si el 'Tipo de Documento' es Lote de Importacion debe de llenar los campo: Empresa, Fecha de Recepcion, Fac. Reserva SAP, Cantidad de Comprobantes de Pago");
                return;
            }

            AgregarDocumento();
            ddlEmpresaSearch.SelectedIndex = 0;

            cbeEliminar.TargetControlID = "btnEliminar";
            LimpiarSesion();
        }

        protected string validacionesDeCampo()
        {
            int acum = 0;
            string rsptMsg = "Se encontraron los siguientes inconveniente:";
            List<string> lista = new List<string>();
            lista.Add(txtProveedor.Text + "@" + "Proveedor");
            lista.Add(txtNrOrden.Text + "@" + "Nr. Orden");
            lista.Add(txtRuc.Text + "@" + "RUC");
            lista.Add(ddlTMoneda.Text + "@" + "Moneda");
            lista.Add(txtNrDocumento.Text + "@" + "Nr. Documento");
            lista.Add(txtFrPago.Text + "@" + "Forma de Pago");
            lista.Add(ddlTDocumento.Text + "@" + "Tipo Documento");
            lista.Add(ddlTipo.Text + "@" + "Seleccione Tipo");
            lista.Add(txtFechaDoc.Text + "@" + "Fecha Documento");
            lista.Add(txtMonIni.Text + "@" + "Monto Inicial");
            lista.Add(txtMonFac.Text + "@" + "Monto Facturado");
            lista.Add(txtSaldAct.Text + "@" + "Saldo Actual");


            int IdUsuario = Utilitario.ObtenerUsuarioActual().IdUsuario;
            if ((ddlTDocumento.Text == "Factura" && IdUsuario == 179) || (ddlTDocumento.Text == "Factura" &&  IdUsuario == 184) || (ddlTDocumento.Text == "Factura" && IdUsuario == 151))
            {
                lista.Add(ddlTipoPrioridad.Text + "@" + "Tipo Prioridad");
            }


            for (int i = 0; i < lista.Count; i++)
            {
                string cadena = lista[i];
                string[] lista2 = cadena.Split('@');

                if (lista2.GetValue(0).ToString() == "-1" || lista2.GetValue(0).ToString() == "") {
                    acum = acum + 1;
                    rsptMsg = rsptMsg + " - " + lista2.GetValue(1).ToString();
                }

            }

            if (acum > 0) {
                //Utilitario.MostrarMensaje(rsptMsg);
                return rsptMsg;
            }
            return "0";
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

        protected void FileUpload1_Changed(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();

                try
                {
                    DateTime ahora = DateTime.Now;
                    string formatoPersonal = ahora.ToString("yyyyMMdd HHmmss");

                    string destinationFolder = Server.MapPath("~/adjuntos");
                    if (!Directory.Exists(destinationFolder))
                        Directory.CreateDirectory(destinationFolder);

                    string fileName = Path.GetFileName(FileUpload1.FileName);

                    if(fileName.Contains("%") || fileName.Contains("/"))
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "El nombre del Archivo no puede contener los caracteres '%' ni '/'.";
                    }
                    else
                    {
                        string destinationFilePath = Path.Combine(destinationFolder, fileName.Replace(ext, "") + " " + formatoPersonal.Trim() + ext);
                        FileUpload1.SaveAs(destinationFilePath);

                        List<string> listAdjuntos = Session["listAdjuntos"] as List<string>;
                        if (listAdjuntos == null)
                        {
                            listAdjuntos = new List<string>();
                        }

                        listAdjuntos.Add(destinationFilePath);
                        Session["listAdjuntos"] = listAdjuntos;

                        //****Reemplazar solo de manera visual la ruta que se muestra en la tabla****//
                        List<string> listAdjuntos_Ruta = new List<string>();
                        if (listAdjuntos.Count > 0)
                        {
                            for (int i = 0; i < listAdjuntos.Count; i++)
                            {
                                //String archivo = listAdjuntos[i].ToString().Replace("C:\\Users\\practicanteti\\Downloads\\Web Documentaria\\TramiteDocumentario_v1.5\\CapaWeb\\adjuntos\\", "");
                                String archivo = listAdjuntos[i].ToString().Replace(destinationFolder + "\\", "");
                                listAdjuntos_Ruta.Add(archivo);
                            }
                        }
                        //***************************************************************************//

                        dgvDocAdjuntos.DataSource = listAdjuntos_Ruta; //listAdjuntos;
                        dgvDocAdjuntos.DataBind();

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Archivo cargado.";
                    }                   
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Por favor selecciona un archivo.";
            }
        }

        protected void Selection_Change(object sender, EventArgs e)
        {
            
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

            if (ddlTDocumento.SelectedItem.Value == "Lote de Importacion")
            {
                LimpiarControles();
                ddlTDocumento.Text = "Lote de Importacion";
                txtProveedor.Enabled = false;
                txtNrOrden.Enabled = false;
                txtRuc.Enabled = false;
                ddlTMoneda.Enabled = false;
                txtNrDocumento.Enabled = false;
                txtFrPago.Enabled = false;
                ddlTipo.Enabled = false;
                txtFechaVen.Enabled = false;
                txtFechaDoc.Enabled = false;
                txtMonIni.Enabled = false;
                txtMonFac.Enabled = false;
                txtSaldAct.Enabled = false;
                txtComentario.Enabled = false;
                txtNroEr.Enabled = false;
            }
            else
            {
                txtProveedor.Enabled = true;
                txtNrOrden.Enabled = true;
                txtRuc.Enabled = true;
                ddlTMoneda.Enabled = true;
                txtNrDocumento.Enabled = true;
                txtFrPago.Enabled = true;
                ddlTipo.Enabled = true;
                txtFechaVen.Enabled = true;
                txtFechaDoc.Enabled = true;
                txtMonIni.Enabled = true;
                txtMonFac.Enabled = true;
                txtSaldAct.Enabled = true;
                txtComentario.Enabled = true;
                txtNroEr.Enabled = true;
            }

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonIni.Focus();
        }

        protected void ddlPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ConfigurarTamañoPagina(DropDownList ddlControl)
        {
            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwEmpleado.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            gvwEmpleado.DataSource = Session["Documentos"];
            gvwEmpleado.DataBind();
        }
        
        protected void ibNuevoEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            hdnEstado.Value = "New";
            HabilitarFormulario(true, 0);
            pnlGrabar2.Visible = true;
            pnlLimpiar.Visible = true;
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

        protected void gvwEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvwDocAdjuntos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}