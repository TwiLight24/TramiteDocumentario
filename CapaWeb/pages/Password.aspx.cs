using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Intellisoft.Project.Util;

namespace CapaWeb.pages
{
    public partial class Password : System.Web.UI.Page
    {
        public string nombreSistema = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            nombreSistema = ConfigurationManager.AppSettings["NombreSistema"];
            if (!IsPostBack)
            {
                LimpiarControles();
            }

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            CambiarPassword();
        }

        private void LimpiarControles()
        {
            txtNewPassword.Text = string.Empty;
            txtOldPassword.Text = string.Empty;
            txtRepeatPassword.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }

        private void CambiarPassword()
        {
            string ActualPass = string.Empty;
            string NewPwd = string.Empty;
            string pwdUsuario = string.Empty;
            bool rpta = false;

            try
            {
                CapaEntidad.Usuario entidad = Session["UsuarioActual"] as CapaEntidad.Usuario;

                pwdUsuario = Intellisoft.Project.Util.Seguridad.DesencriptarBd(entidad.Contrasena);

                ActualPass = txtOldPassword.Text;
                NewPwd = txtNewPassword.Text;

                if (ActualPass == pwdUsuario)
                {
                    if (NewPwd == pwdUsuario)
                    {
                        lblMensaje.Text = "La nueva contraseña no debe ser igual a la actual.";
                    }
                    else
                    {
                        if (NewPwd == txtRepeatPassword.Text)
                        {
                            CapaEntidad.Usuario objUsuario = new CapaEntidad.Usuario();

                            objUsuario.Contrasena = entidad.Contrasena;
                            objUsuario.NuevaContrasena = Intellisoft.Project.Util.Seguridad.EncriptarBd(NewPwd);
                            objUsuario.IdUsuario = entidad.IdUsuario;
                            objUsuario = CapaNegocio.Usuario.ActualizarPassword(objUsuario);

                            if (objUsuario.UltimoResultado.ResultadoOperacion == 1) // Cambio de Contraseña exitoso.
                            {
                                Intellisoft.Project.Util.Utilitario.MostrarMensaje(objUsuario.UltimoResultado.Mensaje + " Deberá volver a iniciar sesión para acceder al sistema.");
                                rpta = true;
                                LogOut(rpta);
                            }
                            else
                            {
                                lblMensaje.Text = objUsuario.UltimoResultado.Mensaje;
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Las contraseñas ingresadas no son iguales.";
                        }
                    }
                }
                else
                {
                    lblMensaje.Text = "La contraseña actual ingresada es incorrecta.";

                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
                Log.SaveLog(ex.Message);
            }


        }

        private void LogOut(bool rpta)
        {
            if (rpta == true)
            {
                Session.Clear();
                Session.Abandon();
                ScriptManager.RegisterStartupScript(this, typeof(string), "CLOSE_WINDOW", "opener.location.href = '../Inicio.aspx'; window.close();", true);
            }
        }

    }
}