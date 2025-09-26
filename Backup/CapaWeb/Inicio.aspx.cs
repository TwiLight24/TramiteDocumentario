using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Intellisoft.Project.Comun.Entidad;

namespace CapaWeb
{
    public partial class Inicio : System.Web.UI.Page
    {
        public string nombreSistema = string.Empty;
        public string nombreSistema2 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Label7.Text = Intellisoft.Project.Util.Seguridad.DesencriptarBd("C/9FUoHxXWo=");
            nombreSistema = ConfigurationManager.AppSettings["NombreSistema"];
            nombreSistema2 = ConfigurationManager.AppSettings["NombreSistema2"];

            if (!IsPostBack)
            {
                if (this.ddlAutenticacion.Items.Count > 0)
                    this.ddlAutenticacion.Items[1].Text = nombreSistema;
                    this.ddlAutenticacion.Items[2].Text = nombreSistema2;
            }
        }

        #region Metodos Privados

        /// <summary>
        /// Indica si el Usuario Timesheet ha sido autenticado
        /// </summary>
        /// <returns>Indica si el Usuario Timesheet ha sido autenticado</returns>
        private bool AutenticarUsuarioSistema()
        {
            bool blnRpta = false;
            bool blnAutenticado = false;
            string sContrasena;
            string strRutaDefecto = string.Empty;
            Session["MsjeLogin"] = null;

            try
            {

               
                CapaEntidad.Usuario objUsuario = new CapaEntidad.Usuario();

                objUsuario.NombreUsuario = txtUsuario.Text.ToLower().TrimEnd();
                objUsuario.Contrasena = txtContrasena.Text;
                sContrasena = Intellisoft.Project.Util.Seguridad.EncriptarBd(txtContrasena.Text);
                objUsuario.IdAplicativo = Convert.ToInt32(ddlAutenticacion.SelectedValue);

                objUsuario = CapaNegocio.Usuario.ValidaUsuarioSistema(objUsuario);

              
                if (objUsuario.UltimoResultado.EsValido)
                {
                    if (objUsuario.PermisoPorAplicativo)
                    {
                        if (sContrasena == objUsuario.Contrasena) /*== Intellisoft.Project.Util.Seguridad.DesencriptarBd(objUsuario.Contrasena)*/
                        {
                            blnAutenticado = Intellisoft.Project.Util.Seguridad.AutenticarUsuario(objUsuario, VariablesGlobales.TipoAutenticacionConst.Documentario, out strRutaDefecto);
                            if (blnAutenticado)
                            {
                                ////objUsuario.IdRol = 1;
                                //if (objUsuario.IdRol == 2 || objUsuario.IdRol == 3) //Roles Empleado (2) ó Supervisor (3), Obligatorio Periodo Asignado
                                //{
                                //    if (objUsuario.IdPeriodo != 0)
                                //    {
                                //        Session["EliminarSustentoTemporales"] = true;
                                //        Response.Redirect(strRutaDefecto, false);
                                //    }
                                //    else
                                //        Intellisoft.Project.Util.Utilitario.MostrarMensaje("No tiene asignado un periodo de trabajo activo. Comuníquese con el Administrador del Sistema.");
                                //}
                                //else //Roles Administradores: 1, 4 y 5 Ingresan sin tener Periodo Asignado 
                                //{
                                Session["EliminarSustentoTemporales"] = (objUsuario.IdRol != 1);
                                Response.Redirect(strRutaDefecto, false);
                                //}
                            }
                            else
                            {
                                if (Session["MsjeLogin"] != null && Session["MsjeLogin"].ToString().Length > 0)
                                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(Session["MsjeLogin"].ToString());
                                else
                                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("No se pudo autenticar el usuario");
                            }
                        }
                        else
                            Intellisoft.Project.Util.Utilitario.MostrarMensaje("El usuario o contraseña ingresado es incorrecto");
                    }
                    else
                        Intellisoft.Project.Util.Utilitario.MostrarMensaje("El usuario no cuenta con los Permisos para Ingresar a esta Aplicación.");
                }
                else
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje("No se pudo iniciar sesión con los datos ingresados.");
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

            return blnRpta;
        }


        /// <summary>
        /// Indica si el Usuario Windows ha sido autenticado
        /// </summary>
        /// <returns>Indica si el Usuario Windows ha sido autenticado</returns>
        private bool AutenticarUsuarioWindows()
        {
            bool blnRpta = false;
            bool blnAutenticado = false;
            string strRutaDefecto = string.Empty;
            try
            {
                CapaEntidad.Usuario objUsuario = new CapaEntidad.Usuario();
                objUsuario.CredencialWindows = this.txtUsuario.Text.Trim();
                objUsuario.Contrasena = Intellisoft.Project.Util.Seguridad.EncriptarBd(this.txtContrasena.Text.Trim());

                /*objUsuario.CredencialWindows = string.Empty;
                string[] CadCredencial = User.Identity.Name.Split(new string[] { @"\" }, StringSplitOptions.None);

                objUsuario.CredencialWindows = CadCredencial[1];*/

                objUsuario = Intellisoft.Project.Util.Seguridad.ValidarUsrDominio(objUsuario); // Intellisoft.Project.Control.Usuario.ValidaUsuarioWindows(objUsuario);
                if (objUsuario.UltimoResultado.EsValido)
                {
                    blnAutenticado = Intellisoft.Project.Util.Seguridad.AutenticarUsuario(objUsuario, VariablesGlobales.TipoAutenticacionConst.Windows, out strRutaDefecto);
                    if (blnAutenticado)
                        Response.Redirect(strRutaDefecto, false);
                    else
                    {
                        if (Session["MsjeLogin"] != null && Session["MsjeLogin"].ToString().Length > 0)
                            Intellisoft.Project.Util.Utilitario.MostrarMensaje(Session["MsjeLogin"].ToString());
                        else
                            Intellisoft.Project.Util.Utilitario.MostrarMensaje("No se pudo autenticar las credenciales del usuario.");
                    }
                }
                else
                {
                    // Intellisoft.Project.Util.Utilitario.MostrarMensaje(objUsuario.UltimoResultado.Mensaje); // "Las Credenciales del Usuario '" + objUsuario.CredencialWindows + "' no son válidas para iniciar sesión.");
                    if (objUsuario.UltimoResultado.Mensaje.Trim() == "Logon failure: unknown user name or bad password.")
                        Intellisoft.Project.Util.CustomValidation.AddError("Usuario o contraseña incorrectos", "Login", this);
                    else
                        Intellisoft.Project.Util.CustomValidation.AddError(objUsuario.UltimoResultado.Mensaje, "Login", this);

                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(objUsuario.UltimoResultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }

            return blnRpta;
        }

        #endregion

        #region Metodos de Controles

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ddlAutenticacion.SelectedValue == "1") //Sistema Tramite Documentario
                this.AutenticarUsuarioSistema();
            else if (ddlAutenticacion.SelectedValue == "2") //Sistema Pedido de Utiles
                this.AutenticarUsuarioSistema();
            else if (ddlAutenticacion.SelectedValue == "3") //Windows
                this.AutenticarUsuarioWindows();
            else
                Intellisoft.Project.Util.Utilitario.MostrarMensaje("Seleccione una opción para el inicio de sesión.");
        }

        protected void ddlAutenticacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAutenticacion.SelectedValue == "0") //Seleccionar
                this.pnlLoginSistema.Visible = false;

            //else if (ddlAutenticacion.SelectedValue == "1") //Sistema
            //{
            //    this.pnlLoginSistema.Visible = true;
            //    this.txtUsuario.Text = string.Empty;
            //    this.txtUsuario.Focus();
            //    this.txtUsuario.Enabled = true;
            //}
            //else if (ddlAutenticacion.SelectedValue == "2") //Sistema
            //{
            //    this.pnlLoginSistema.Visible = true;
            //    this.txtUsuario.Text = string.Empty;
            //    this.txtUsuario.Focus();
            //    this.txtUsuario.Enabled = true;
            //}

            else if (rdbTipoAuten.SelectedValue == "1") {

                this.pnlLoginSistema.Visible = true;
                this.txtUsuario.Text = string.Empty;
                this.txtUsuario.Focus();
                this.txtUsuario.Enabled = true;
            
            }


            else if (rdbTipoAuten.SelectedValue == "2")
            {
                this.vsLogin.ShowMessageBox = true;
                this.pnlLoginSistema.Visible = true; // false;  
                string Usuario = HttpContext.Current.User.Identity.Name.ToString().ToUpper();
                //string[] CadCredencial = User.Identity.Name.Split(new string[] { @"\" }, StringSplitOptions.None);
                //if (CadCredencial.Length > 0)
                if (Usuario.Length > 0)
                {
                    //this.txtUsuario.Text = CadCredencial[1];
                    this.txtUsuario.Text = Usuario;
                    this.txtUsuario.Enabled = true;
                    this.txtContrasena.Focus();
                }

            }

            //else if (ddlAutenticacion.SelectedValue == "3") //Windows
            //{
            //    this.vsLogin.ShowMessageBox = true;
            //    this.pnlLoginSistema.Visible = true; // false;  
            //    string Usuario = HttpContext.Current.User.Identity.Name.ToString().ToUpper();
            //    string[] CadCredencial = User.Identity.Name.Split(new string[] { @"\" }, StringSplitOptions.None);
            //    if (CadCredencial.Length > 0)
            //    {
            //        this.txtUsuario.Text = CadCredencial[1];
            //        this.txtUsuario.Enabled = true;
            //        this.txtContrasena.Focus();
            //    }
            //}
        }

        #endregion

    }
}