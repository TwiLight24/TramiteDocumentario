using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing;
using System.Globalization;


namespace Intellisoft.Project.Util
{
    public class Utilitario : System.Web.UI.Page
    {

        /// <summary>
        /// Carga con datos un control DropDownList (Combo)
        /// </summary>
        /// <typeparam name="T">Objeto que representa la lista</typeparam>
        /// <param name="lstDatos">Lista de datos</param>
        /// <param name="oCombo">Objeto DropDownList</param>
        /// <param name="sColVal">Valor</param>
        /// <param name="sColDes">Descripción</param>
        /// <param name="sMsgInicial">Opcional: Mensaje que se visualizará antes de escoger un item del combo</param>
        public static void CargaCombo<T>(List<T> lstDatos, DropDownList oCombo, string sColVal, string sColDes, string sMsgInicial)
        {

            oCombo.DataSource = lstDatos;
            oCombo.DataValueField = sColVal;
            oCombo.DataTextField = sColDes;
            oCombo.DataBind();
            if (!string.IsNullOrEmpty(sMsgInicial))
                oCombo.Items.Insert(0, new ListItem(sMsgInicial, "-1"));
        }

        /// <summary>
        /// Carga con datos un control DropDownList (Combo)
        /// </summary>
        /// <param name="oDtDatos">Lista de datos</param>
        /// <param name="oCombo">Objeto DropDownList</param>
        /// <param name="sColVal">Valor</param>
        /// <param name="sColDes">Descripción</param>
        /// <param name="sMsgInicial">Opcional: Mensaje que se visualizará antes de escoger un item del combo</param>
        public static void CargaCombo(DataTable oDtDatos, DropDownList oCombo, string sColVal, string sColDes, string sMsgInicial)
        {
            oCombo.DataSource = oDtDatos;
            oCombo.DataValueField = sColVal;
            oCombo.DataTextField = sColDes;
            oCombo.DataBind();
            if (!string.IsNullOrEmpty(sMsgInicial))
                oCombo.Items.Insert(0, new ListItem(sMsgInicial, "-1"));
        }

        /// <summary>
        /// Carga con datos un control DropDownList (Combo)
        /// </summary>
        /// <param name="oDsDatos">Lista de datos</param>
        /// <param name="oCombo">Objeto DropDownList</param>
        /// <param name="sColVal">Valor</param>
        /// <param name="sColDes">Descripción</param>
        /// <param name="sMsgInicial">Opcional: Mensaje que se visualizará antes de escoger un item del combo</param>
        public static void CargaCombo(DataSet oDsDatos, DropDownList oCombo, string sColVal, string sColDes, string sMsgInicial)
        {
            oCombo.DataSource = oDsDatos;
            oCombo.DataValueField = sColVal;
            oCombo.DataTextField = sColDes;
            oCombo.DataBind();
            if (!string.IsNullOrEmpty(sMsgInicial))
                oCombo.Items.Insert(0, new ListItem(sMsgInicial, "-1"));
        }

        /// <summary>
        /// Devuelve el tamaño de las paginas a mostrar
        /// </summary>
        /// <returns>Tamaño de las paginas a mostrar</returns>
        public static int ObtenerTamañoPagina()
        {
            int filas = 10;

            if (HttpContext.Current.Session["page"] != null) filas = Convert.ToInt32(HttpContext.Current.Session["page"]);

            return filas;
        }

        /// <summary>
        /// Registra el tamaño de las paginas a mostrar
        /// </summary>
        /// <param name="filas">Filas a mostrar</param>
        public static void RegistrarTamañoPagina(int filas)
        {
            HttpContext.Current.Session["page"] = filas.ToString();
        }

        /// <summary>
        /// Muestra un mensaje mediante de un alert
        /// </summary>
        public static void MostrarMensaje(string message)
        {
            // Cleans the message to allow single quotation marks 
            string cleanMessage = message.Replace("'", "\\'");
            string script = "alert('" + cleanMessage + "');";

            // Gets the executing web page 
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page 
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                ScriptManager.RegisterClientScriptBlock(page, typeof(Page), page.ClientID, script, true);
            }
        }

        /// <summary>
        /// Muestra un mensaje mediante de un confirm
        /// </summary>
        public static void MostrarMensajeConfirmacion(string message)
        {
            // Cleans the message to allow single quotation marks 
            string cleanMessage = message.Replace("'", "\\'");
            string script = "confirm('" + cleanMessage + "');";

            // Gets the executing web page 
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page 
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("confirm"))
            {
                ScriptManager.RegisterClientScriptBlock(page, typeof(Page), page.ClientID, script, true);
            }
        }

        /// <summary>
        /// Devuelve el Usuario actualmente autenticado
        /// </summary>
        public static CapaEntidad.Usuario ObtenerUsuarioActual()
        {
            return HttpContext.Current.Session["UsuarioActual"] as CapaEntidad.Usuario;
        }

        /// <summary>
        /// Función que permite limpiar todos los controles de una página Web recursivamente. 
        /// </summary>
        public static void LimpiarControles(ControlCollection controles)
        {
            foreach (System.Web.UI.Control control in controles)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                    ((TextBox)control).Enabled = true;
                }
                else if (control is DropDownList)
                {
                    ((DropDownList)control).ClearSelection();
                    ((DropDownList)control).Enabled = true;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                    ((RadioButton)control).Enabled = true;
                }
                else if (control is RadioButtonList)
                {
                    ((RadioButtonList)control).ClearSelection();
                    ((RadioButtonList)control).Enabled = true;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                    ((CheckBox)control).Enabled = true;
                }
                else if (control.HasControls())
                    //Aquí se detécta un Control que contenga otros Controles, así ningún control se quedará sin ser limpiado.
                    LimpiarControles(control.Controls);
            }
        }

        public static void FocusControl(string ClientID, System.Web.UI.Page page)
        {
            page.RegisterClientScriptBlock("CtrlFocus",
            @"<script> 
              function ScrollView()
              {
                 var el = document.getElementById('" + ClientID + @"')

                 if (el != null)

                 {        
                    el.scrollIntoView();
                    el.focus();
                 }
              }
              window.onload = ScrollView;
            </script>");
        }

        /// <summary>
        /// Se obtiene la fecha formateada con el CultureInfo es-PE
        /// </summary>
        public static DateTime GetFormatDateTime(string strFecha)
        {
            DateTime dFecha;

            if (string.IsNullOrEmpty(strFecha))
                dFecha = DateTime.Parse(DateTime.Now.ToShortDateString() + " 00:00", new CultureInfo("es-PE", false));
            else
                dFecha = DateTime.Parse(strFecha, new CultureInfo("es-PE", false));

            return dFecha;
        }

        /// <summary>
        /// Valida si el usuario tiene permiso para editar el TimeSheet
        /// </summary>
        /// <returns></returns>
        //public static bool ValidarUsrEditarTs()
        //{
        //    bool EsValido = true;

        //    if (HttpContext.Current.Session["ValidUsrEditTs"] == null)
        //    {
        //        Entidad.Usuario UsrEditTs = (HttpContext.Current.Session["UsuarioActual"] as Entidad.Usuario);

        //        Entidad.ParametroDetalle UsrNoEditTs = new Entidad.ParametroDetalle();
        //        UsrNoEditTs.IdParametro = Comun.Entidad.VariablesGlobales.ParametroConst.Sistema;
        //        UsrNoEditTs.IdDetalle = "USRNOTS";

        //        UsrNoEditTs = Control.ParametroDetalle.Obtener(UsrNoEditTs);

        //        string[] CadUsrNoEditTs = UsrNoEditTs.LstParametroDetalle[0].ValorCadena.Split(',');

        //        foreach (string User in CadUsrNoEditTs)
        //        {
        //            if (UsrEditTs.NombreUsuario == User)
        //            {
        //                EsValido = false;
        //                break;
        //            }
        //        }

        //        HttpContext.Current.Session["ValidUsrEditTs"] = EsValido;
        //    }
        //    else
        //        EsValido = Convert.ToBoolean(HttpContext.Current.Session["ValidUsrEditTs"]);

        //    return EsValido;
        //}
    }
}
