using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using Intellisoft.Project.Comun.Entidad;

using Entity = CapaEntidad.Seguridad;
using Negocio = CapaNegocio.Seguridad;


namespace Intellisoft.Project.Util
{
    /// <summary>
    /// Utilidades de Seguridad para Aplicaciones Web
    /// </summary>
    public class Seguridad
    {

        /// <summary>
        /// Valida si la informacion de Usuario esta activa, sino redirecciona a la pagina de Timeout
        /// </summary>
        public static void ValidarSesionActiva()
        {
            if (HttpContext.Current.Session["UsuarioActual"] == null)
            {
                HttpContext.Current.Response.Redirect("~/pages/util/Timeout.aspx");
            }
        }

        /// <summary>
        /// Valida si la informacion de Usuario esta activa, sino redirecciona a la pagina de Timeout
        /// </summary>
        public static void ValidarSesionActivaAdmin()
        {
            if (HttpContext.Current.Session["UsuarioAdmin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/util/Timeout.aspx");
            }
        }

        /// <summary>
        /// Cierra la Sesion Actual y se redirige al Inicio de la Aplicacion
        /// </summary>
        public static void CerrarSesion(bool blnReiniciar)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();

            if (blnReiniciar)
            {
                HttpContext.Current.Response.Redirect("~/Index.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("<script type='text/javascript'> window.close(); </script>");
            }
        }

        /// <summary>
        /// Redirecciona a la Pagina por Defecto
        /// </summary>
        public static void RedireccionarPaginaDefecto()
        {
            ValidarSesionActiva();

            HttpContext.Current.Session["OpcionActual"] = HttpContext.Current.Session["OpcionDefecto"];
            HttpContext.Current.Response.Redirect(HttpContext.Current.Session["PaginaDefecto"].ToString());
        }

        /// <summary>
        /// Reemplaza los caracteres de acuerdo a como interpreta el servidor un texto
        /// </summary>
        private static string LecturaServidor(string strTexto)
        {
            string CodServer = string.Empty;

            #region Interpretación del Servidor

            CodServer = strTexto.Replace("%20", " ").Replace("%21", "!").
                                 Replace("%23", "#").Replace("%24", "$").
                                 Replace("%25", "%").Replace("%26", "&").
                                 Replace("%27", "'").Replace("%28", "(").
                                 Replace("%29", ")").Replace("%40", "@").
                                 Replace("%82", "‚").Replace("%93", "“").
                                 Replace("%94", "”").Replace("%96", "–").
                                 Replace("%2A", "*").Replace("%2a", "*").
                                 Replace("%2B", "+").Replace("%2b", "+").
                                 Replace("%2C", ",").Replace("%2c", ",").
                                 Replace("%2D", "-").Replace("%2d", "-").
                                 Replace("%2E", ".").Replace("%2e", ".").
                                 Replace("%2F", "/").Replace("%2f", "/").
                                 Replace("%3A", ":").Replace("%3a", ":").
                                 Replace("%3B", ";").Replace("%3b", ";").
                                 Replace("%3C", "<").Replace("%3c", "<").
                                 Replace("%3D", "=").Replace("%3d", "=").
                                 Replace("%3E", ">").Replace("%3e", ">").
                                 Replace("%3F", "?").Replace("%3f", "?").
                                 Replace("%5B", "[").Replace("%5b", "[").
                                 Replace("%5C", "\\").Replace("%5c", "\\").
                                 Replace("%5D", "]").Replace("%5d", "]").
                                 Replace("%5E", "^").Replace("%5e", "^").
                                 Replace("%5F", "_").Replace("%5f", "_").
                                 Replace("%7B", "{").Replace("%7b", "{").
                                 Replace("%7C", "|").Replace("%7c", "|").
                                 Replace("%7D", "}").Replace("%7d", "}").
                                 Replace("%7E", "~").Replace("%7e", "~").
                                 Replace("%A1", "¡").Replace("%a1", "¡").
                                 Replace("%C1", "Á").Replace("%c1", "Á").
                                 Replace("%C9", "É").Replace("%c9", "É").
                                 Replace("%CD", "Í").Replace("%cd", "Í").
                                 Replace("%D3", "Ó").Replace("%d3", "Ó").
                                 Replace("%DA", "Ú").Replace("%da", "Ú").
                                 Replace("%E1", "á").Replace("%e1", "á").
                                 Replace("%E9", "é").Replace("%e9", "é").
                                 Replace("%ED", "í").Replace("%ed", "í").
                                 Replace("%F3", "ó").Replace("%f3", "ó").
                                 Replace("%FA", "ú").Replace("%fa", "ú").
                                 Replace("%BF", "¿").Replace("%bf", "¿");

            #endregion

            return CodServer;
        }

        /// <summary>
        /// Encripta la cadena indicada.
        /// </summary>
        /// <param name="texto">cadena de caracteres que se va a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public static string EncriptarUrl(string cadenaUrl)
        {
            string keyUrl = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz1234567890";

            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(LecturaServidor(cadenaUrl));

            //se utilizan las clases de encriptacion proveidas por el Framework
            //Algritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyUrl));
            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformaion de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        /// <summary>
        /// Desencripta la cadena. Regresa una cadena desencriptada. 
        /// </summary>
        /// <param name="cipherString">Cadena encriptada</param>
        /// <returns>Cadena desencriptada</returns>
        public static string DesencriptarUrl(string cadenaUrlEncriptada)
        {
            string keyUrl = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz1234567890";
            byte[] keyArray;

            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(LecturaServidor(cadenaUrlEncriptada));

            //se llama a las clases ke tienen los algoritmos de encriptacion
            //se le aplica hashing
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyUrl));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            string res = UTF8Encoding.UTF8.GetString(resultArray);
            return res;
        }

        /// <summary>
        /// Encripta la cadena indicada.
        /// </summary>
        /// <param name="texto">cadena de caracteres que se va a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public static string EncriptarBd(string cadenaBd)
        {
            string keyBd = "9876543210zyxwvutsrqpoñnmlkjihgfedcbaZYXWVUTSRQPOÑNMLKJIHGFEDCBA";

            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(LecturaServidor(cadenaBd));

            //se utilizan las clases de encriptacion proveidas por el Framework
            //Algritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyBd));
            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformaion de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        /// <summary>
        /// Desencripta la cadena. Regresa una cadena desencriptada. 
        /// </summary>
        /// <param name="cipherString">Cadena encriptada</param>
        /// <returns>Cadena desencriptada</returns>
        public static string DesencriptarBd(string cadenaBdEncriptada)
        {
            string keyBd = "9876543210zyxwvutsrqpoñnmlkjihgfedcbaZYXWVUTSRQPOÑNMLKJIHGFEDCBA";

            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(LecturaServidor(cadenaBdEncriptada));

            //se llama a las clases ke tienen los algoritmos de encriptacion
            //se le aplica hashing
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(keyBd));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            string res = UTF8Encoding.UTF8.GetString(resultArray);
            return res;
        }

        /// <summary>
        /// Autentica las credenciales ingresadas por el Usuario
        /// </summary>
        /// <param name="objUsuario">Entidad Usuario: AAUS_LOGIN, AAUS_PASSWORD</param>
        /// <param name="strRutaDefecto">Indica la ruta a la que se debe redireccionar despues de autenticar</param>
        /// <returns>Indica si el Usuario ha sido autenticado</returns>
        /// 
        public static bool AutenticarUsuario(CapaEntidad.Usuario objUsuario, string strTipoAutenticacion, out string strRutaDefecto)
        {
            bool blnRpta = false;
            strRutaDefecto = string.Empty;
            //Entidad.Periodo objPeriodo = null;
            HttpContext.Current.Session["MsjeLogin"] = null;
            bool expire = false;

            try
            {
                objUsuario = CapaNegocio.Usuario.Seleccionar(objUsuario);

                //objPeriodo = new Entidad.Periodo();
                //objPeriodo.IdUsuario = objUsuario.IdUsuario;

                //objPeriodo = Intellisoft.Project.Control.Periodo.ObtenerPeriodoUsuario(objPeriodo);
                //objUsuario.IdPeriodo = objPeriodo.IdPeriodo;
                //objUsuario.FechaInicio = objPeriodo.FechaInicio;
                //objUsuario.FechaFin = objPeriodo.FechaFin;
                //objUsuario.EstadoConsolidado = objPeriodo.EstadoConsolidacion;
                //objUsuario.EstadoPeriodoEmpleado = objPeriodo.EstadoPeriodoEmpleado;

                if (objUsuario.UltimoResultado.EsValido)
                {
                    DateTime FechaActual = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00");
                    HttpContext.Current.Session["UsuarioActual"] = objUsuario;

                    if (objUsuario.EstaCaducado)
                    {
                        HttpContext.Current.Session["MsjeLogin"] = "Su cuenta ha caducado, comuníquese con el Administrador del Sistema para habilitarla.";
                        blnRpta = false;
                    }
                    else
                    {
                        if (objUsuario.FechaCese != null && objUsuario.FechaCese.ToString().Length > 0)
                        {
                            if (FechaActual > Convert.ToDateTime(objUsuario.FechaCese))
                            {
                                HttpContext.Current.Session["MsjeLogin"] = "No cuenta con permisos para acceder al sistema debido al cese en sus labores.";
                                blnRpta = false;
                                expire = true;
                            }
                        }
                        if (!expire)
                        {
                            if (objUsuario.FechaCaducidad != null && objUsuario.FechaCaducidad.ToString().Length > 0)
                            {
                                if (FechaActual > Convert.ToDateTime(objUsuario.FechaCaducidad))
                                {
                                    // Si la fecha de caducidad expiró y el estado aún no esta como caducado debe actualizarse.
                                    if (!objUsuario.EstaCaducado)
                                    {
                                        CapaEntidad.Usuario obj = new CapaEntidad.Usuario();
                                        obj.IdUsuario = objUsuario.IdUsuario;
                                        obj.IdEmpleado = objUsuario.IdEmpleado;
                                        obj.EstaCaducado = true;
                                        obj = CapaNegocio.Usuario.ActualizarCaducidad(obj);
                                    }

                                    HttpContext.Current.Session["MsjeLogin"] = "Su cuenta ha caducado, comuníquese con el Administrador del Sistema para habilitarla.";
                                    blnRpta = false;
                                    expire = true;
                                }
                            }
                            if (!expire)
                            {
                                if (objUsuario.TipoAutenticacion == strTipoAutenticacion || objUsuario.TipoAutenticacion == VariablesGlobales.TipoAutenticacionConst.Ambas)
                                {

                                    strRutaDefecto = objUsuario.RutaDefecto;

                                    Entity.RolFuncionalidad objERolFuncionalidad = new Entity.RolFuncionalidad();
                                    //objUsuario.IdRol = 1;
                                    objERolFuncionalidad.IdRol = objUsuario.IdRol;
                                    objERolFuncionalidad = Negocio.RolFuncionalidad.ObtenerFuncionalidadPorRol(objERolFuncionalidad);
                                    HttpContext.Current.Session["FuncionalidadActual"] = objERolFuncionalidad.LstRolFuncionalidad;

                                    HttpContext.Current.Session["MsjeLogin"] = null;

                                    //if (objUsuario.FechaCaducidad != null && objUsuario.FechaCaducidad.ToString().Length > 0)
                                    //{
                                    //    if (Convert.ToDateTime(objUsuario.FechaCaducidad).Subtract(FechaActual).Days <= ObtenerDiasAlertas())
                                    //        HttpContext.Current.Session["MsjeLogin"] = "Aviso: Su cuenta caducará el " + Convert.ToDateTime(objUsuario.FechaCaducidad).ToString("dd/MM/yyyy") + ".";
                                    //}

                                    //if (objUsuario.FechaCese != null && objUsuario.FechaCese.ToString().Length > 0)
                                    //{
                                    //    if (Convert.ToDateTime(objUsuario.FechaCese).Subtract(FechaActual).Days <= ObtenerDiasAlertas())
                                    //        HttpContext.Current.Session["MsjeLogin"] = "Aviso: Su cuenta será desactivada el " + Convert.ToDateTime(objUsuario.FechaCese).ToString("dd/MM/yyyy") + " por motivos de cese de labores.";
                                    //}

                                    blnRpta = true;
                                }
                                else
                                {
                                    HttpContext.Current.Session["MsjeLogin"] = "No cuenta con permisos para iniciar sesión con el tipo de autenticación seleccionado.";
                                    blnRpta = false;
                                }
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return blnRpta;
        }

        //public static int ObtenerDiasAlertas()
        //{
            //Entidad.ParametroDetalle objParam = null;
            //int dias = 0;

            //try
            //{
            //    objParam = new CapaEntidad.ParametroDetalle();
            //    objParam.IdParametro = Intellisoft.Project.Comun.Entidad.VariablesGlobales.ParametroConst.AlertasTimesheet;
            //    objParam.IdDetalle = Intellisoft.Project.Comun.Entidad.VariablesGlobales.AlertasTimesheet.SesionExpire;
            //    objParam = CapaNegocio.ParametroDetalle.Seleccionar(objParam);

            //    dias = objParam.Col_UltimaLista.Find(delegate(CapaEntidad.ParametroDetalle oEntidad)
            //    { return oEntidad.IdDetalle == Intellisoft.Project.Comun.Entidad.VariablesGlobales.AlertasTimesheet.SesionExpire; }).ValorEntero;

            //    if (dias.ToString().Length == 0)
            //    {
            //        dias = 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Util.Log.RegistrarIncidencia(ex);
            //    Intellisoft.Project.Util.Log.SaveLog(ex.Message);
            //}

        //    return dias;
        //}


        /// <summary>
        /// Autentica las credenciales ingresadas por el Usuario
        /// </summary>
        public static bool CargarDatosUsuario(int idUsuario, int idPeriodo)
        {
            bool ok = false;

            try
            {
                CapaEntidad.Usuario objUsuario = null;
                objUsuario = new CapaEntidad.Usuario();

                objUsuario.IdUsuario = idUsuario;
                objUsuario.IdPeriodo = idPeriodo;
                objUsuario = CapaNegocio.Usuario.Seleccionar2(objUsuario);
                if (objUsuario.UltimoResultado.EsValido)
                {
                    HttpContext.Current.Session["UsuarioActual"] = objUsuario;

                    //CapaEntidad.RolFuncionalidad objERolFuncionalidad = new CapaEntidad.RolFuncionalidad();
                    //objERolFuncionalidad.IdRol = objUsuario.IdRol;
                    //objERolFuncionalidad = Control.RolFuncionalidad.ObtenerFuncionalidadPorRol(objERolFuncionalidad);

                    //HttpContext.Current.Session["FuncionalidadActual"] = objERolFuncionalidad.LstRolFuncionalidad;

                    ok = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ok;
        }

        public static void ErrorPage()
        {
            // Obtenemos el último error principal
            Exception objErr = HttpContext.Current.Server.GetLastError().GetBaseException();
            string detalleError = string.Empty;
            System.Diagnostics.StackTrace objStTrace = new System.Diagnostics.StackTrace(objErr, true);
            //for (int i = 0; i < objStTrace.FrameCount; i++)
            //{
            System.Diagnostics.StackFrame objErrLine = objStTrace.GetFrame(0);
            detalleError += "<br><b>Método: </b>" + objErrLine.GetMethod() + ", <b>Línea: </b>" + objErrLine.GetFileLineNumber();
            // break;
            //}

            // Construimos el mensaje de error
            string err = "<b>Error en el Modulo: </b>" + HttpContext.Current.Request.Url.ToString() +
                    "<br><b>Mensaje de Error: </b>" + objErr.Message.ToString() +
                    "<br><b>Detalle: </b> " + detalleError;
            HttpContext.Current.Session["Error"] = err.ToString();
            // Redireccionamos a la página de error
            HttpContext.Current.Response.Redirect("~/Util/ErrorPage.aspx");

        }

        /// <summary>
        /// Registra la incidencia en el registro de la aplicacion
        /// </summary>
        /// <param name="ex">Excepcion a registrar</param>
        /// <returns>Mensaje devuelto al usuario</returns>
        public static string RegistrarExcepcion(Exception ex)
        {
            return ex.Message + "<br>" + ex.StackTrace;
        }

        /// <summary>
        /// Usando los directorios del LDAP, se valida la sesion de usuario
        /// </summary>
        /// <param name="UsuarioWA">Nombre usuario y password</param>
        /// <returns>Usuario valido</returns>
        public static CapaEntidad.Usuario ValidarUsrDominio(CapaEntidad.Usuario UsuarioWA)
        {
            try
            {
                string PathDominio = string.Empty;
                string Dominio = string.Empty;
                string UsrDominio = string.Empty;
                string Password = string.Empty;

                UsuarioWA = CapaNegocio.Usuario.ValidaUsuarioWindows(UsuarioWA);

                if (UsuarioWA.Autenticado)
                {
                    CapaEntidad.ParametroDetalle DatosLDAP = new CapaEntidad.ParametroDetalle();
                    DatosLDAP.IdParametro = Comun.Entidad.VariablesGlobales.ParametroConst.ParaLDAP;

                    DatosLDAP = CapaNegocio.ParametroDetalle.Obtener(DatosLDAP);

                    PathDominio = DatosLDAP.LstParametroDetalle.Find(delegate(CapaEntidad.ParametroDetalle Registro) { return Registro.IdDetalle == "PathDominio"; }).ValorCadena;
                    Dominio = DatosLDAP.LstParametroDetalle.Find(delegate(CapaEntidad.ParametroDetalle Registro) { return Registro.IdDetalle == "Dominio"; }).ValorCadena;
                    UsrDominio = Dominio + @"\" + UsuarioWA.CredencialWindows;
                    Password = DesencriptarBd(UsuarioWA.Contrasena);

                    DirectoryEntry AccesoDirectorio = new DirectoryEntry(PathDominio, UsrDominio, Password);
                    DirectorySearcher BuscarDirectorio = new DirectorySearcher(AccesoDirectorio);

                    BuscarDirectorio.Filter = "SAMAccountName=" + UsuarioWA.CredencialWindows;

                    SearchResultCollection ResultadoBusqueda = BuscarDirectorio.FindAll();

                    UsuarioWA.UltimoResultado.EsValido = (ResultadoBusqueda.Count > 0);
                    if (UsuarioWA.UltimoResultado.EsValido)
                        UsuarioWA.UltimoResultado.Mensaje = "Validación con LDAP correcta.";
                    else
                        UsuarioWA.UltimoResultado.Mensaje = "Usuario o Contraseña no válidos.";
                }
                else
                    UsuarioWA.UltimoResultado.Mensaje = "Las Credenciales del Usuario '" + UsuarioWA.CredencialWindows + "' no son válidas para iniciar sesión.";
            }
            catch (Exception ex)
            {
                UsuarioWA.UltimoResultado.CargarExcepcion(ex);
            }

            return UsuarioWA;
        }
    }
}