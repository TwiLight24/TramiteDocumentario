namespace Intellisoft.Project.Util
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Ehab = Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Variables = Intellisoft.Project.Comun.Entidad.VariablesGlobales;

    public class Log
    {

        /// <summary>
        /// Registra la incidencia utilizando la libreria de registro de Incidencias
        /// </summary>
        public static void RegistrarIncidencia(Exception ex)
        {
            Exception outEx;
            if (!Ehab.ExceptionPolicy.HandleException(ex, "GlobalPolicy", out outEx))
            {
                throw outEx ?? ex;
            }
        }

        /// <summary>
        /// Graba el log de eventos.
        /// </summary>
        public static void SaveLog(string strMessage)
        {
            if (!string.IsNullOrEmpty(strMessage))
            {
                string strPath = string.Empty;
                string strFile = string.Empty;
                strPath = GetPath();

                if (string.IsNullOrEmpty(strPath))
                {
                    try
                    {
                        strPath = @"C:\Urion_Trafigura\Logs_Eventos";
                        if (!Directory.Exists(strPath))
                            Directory.CreateDirectory(strPath);
                    }
                    catch
                    {
                        strPath = @"C:\Urion_Trafigura\Logs_Eventos";
                        if (!Directory.Exists(strPath))
                            Directory.CreateDirectory(strPath);
                    }
                }
                else
                {
                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);
                }

                strFile = strPath + @"\Logs_Eventos_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " | Formulario: " + HttpContext.Current.Request.FilePath + " | Mensaje: " + strMessage;

                using (StreamWriter oWriter = File.AppendText(strFile))
                {
                    oWriter.WriteLine(strMessage);
                }
            }
        }

        /// <summary>
        /// Obtiene el Path donde se guarda los logs
        /// </summary>
        private static string GetPath()
        {
            string strPath = string.Empty;

            try
            {
                //Intellisoft.Project.Entidad.ParametroDetalle objParametroDetalle = new Entidad.ParametroDetalle();
                //objParametroDetalle.IdDetalle = Variables.Rutas.Logs.ToString();
                //strPath = Intellisoft.Project.Control.ParametroDetalle.Obtener(objParametroDetalle).Col_UltimaLista[0].ValorCadena;
            }
            catch { }

            return strPath;
        }


    }
}
