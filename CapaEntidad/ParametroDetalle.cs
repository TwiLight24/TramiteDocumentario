using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intellisoft.Project.Comun.Entidad;

namespace CapaEntidad
{
    /// <summary>
    /// Objeto que representa a la entidad Parametro Detalle
    /// </summary>
    [Serializable]
    public class ParametroDetalle : Base
    {

        #region Variables Privadas

        private short _idParametro = 0;
        private string _idDetalle = string.Empty;
        private string _descripcion = string.Empty;
        private string _descParametro = string.Empty;
        private int _valorEntero = 0;
        private decimal _valordecimal = 0;
        private string _valorCadena = string.Empty;
        private DateTime _valorfecha = DateTime.Now;

        /* FILEUPLOAD */
        private string _fileServer = string.Empty;
        private string _serverArchivos = string.Empty;
        private string _mainFolder = string.Empty;
        private string _urlBase = string.Empty;
        private string _dataFiles = string.Empty;
        private string _urlArchivos = string.Empty;
        private string _imageFiles = string.Empty;
        private string _urlImagenes = string.Empty;
        private string _tempfiles = string.Empty;
        private string _logfiles = string.Empty;
        private string _urlArchivosTemporales = string.Empty;

        private List<ParametroDetalle> _lstDetalle = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Codigo del Parámetro
        /// </summary>
        public short IdParametro
        {
            get { return _idParametro; }
            set { _idParametro = value; }
        }

        /// <summary>
        /// Codigo del detalle de Parámetro
        /// </summary>
        public string IdDetalle
        {
            get { return _idDetalle; }
            set { _idDetalle = value; }
        }

        /// <summary>
        /// Descripción del detalle de Parámetro
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string DescParametro
        {
            get { return _descParametro; }
            set { _descParametro = value; }
        }

        /// <summary>
        /// Valor entero parámetro
        /// </summary>
        public int ValorEntero
        {
            get { return _valorEntero; }
            set { _valorEntero = value; }
        }

        /// <summary>
        /// Valor decimal parámetro
        /// </summary>
        public decimal ValorDecimal
        {
            get { return _valordecimal; }
            set { _valordecimal = value; }
        }

        /// <summary>
        /// Valor cadena parámetro
        /// </summary>
        public string ValorCadena
        {
            get { return _valorCadena; }
            set { _valorCadena = value; }
        }

        /// <summary>
        /// Valor fecha parametro
        /// </summary>
        public DateTime ValorFecha
        {
            get { return _valorfecha; }
            set { _valorfecha = value; }
        }

        /* FILEUPLOAD */
        /// <summary>
        /// URL del Servidor IIS
        /// </summary>
        public string UrlServidor
        {
            get { return _fileServer; }
            set { _fileServer = value; }
        }

        /// <summary>
        /// URL del Servidor de Archivos
        /// </summary>
        public string UrlServidorArchivos
        {
            get { return _serverArchivos; }
            set { _serverArchivos = value; }
        }

        /// <summary>
        /// Nombre de la Carpeta Base
        /// </summary>
        public string CarpetaBase
        {
            get { return _mainFolder; }
            set { _mainFolder = value; }
        }

        /// <summary>
        /// URL de la Carpeta Base
        /// </summary>
        public string UrlBase
        {
            get { return _urlBase; }
            set { _urlBase = value; }
        }

        /// <summary>
        /// Nombre de la Carpeta de Archivos
        /// </summary>
        public string CarpetaArchivos
        {
            get { return _dataFiles; }
            set { _dataFiles = value; }
        }

        /// <summary>
        /// URL de la Carpeta de Archivos
        /// </summary>
        public string UrlArchivos
        {
            get { return _urlArchivos; }
            set { _urlArchivos = value; }
        }

        /// <summary>
        /// Nombre de la Carpeta de Imagenes
        /// </summary>
        public string CarpetaImagenes
        {
            get { return _imageFiles; }
            set { _imageFiles = value; }
        }

        /// <summary>
        /// URL de la Carpeta de Imagenes
        /// </summary>
        public string UrlImagenes
        {
            get { return _urlImagenes; }
            set { _urlImagenes = value; }
        }

        /// <summary>
        /// Nombre de la Carpeta de Archivos Temporales
        /// </summary>
        public string CarpetaArchivosTemporales
        {
            get { return _tempfiles; }
            set { _tempfiles = value; }
        }

        /// <summary>
        /// Nombre de la Carpeta de los Logs de Eventos
        /// </summary>
        public string CarpetaArchivosLogs
        {
            get { return _logfiles; }
            set { _logfiles = value; }
        }

        /// <summary>
        /// URL de la Carpeta de Archivos Temporales
        /// </summary>
        public string UrlArchivosTemporales
        {
            get { return _urlArchivosTemporales; }
            set { _urlArchivosTemporales = value; }
        }


        /// <summary>
        /// Lista de datos del parametro detalle
        /// </summary>
        public List<ParametroDetalle> LstParametroDetalle
        {
            get { return _lstDetalle; }
            set { _lstDetalle = value; }
        }

        /// <summary>
        /// Colección de datos
        /// </summary>
        public List<ParametroDetalle> Col_UltimaLista
        {
            get { return _lstDetalle; }
            set { _lstDetalle = ObjectClone.Clone<List<ParametroDetalle>>(value); }
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdParametro", out _idParametro);
            CargarVariable(dr, "IdDetalle", out _idDetalle);
            CargarVariable(dr, "Descripcion", out _descripcion);
            CargarVariable(dr, "DescParametro", out _descParametro);
            CargarVariable(dr, "ValorEntero", out _valorEntero);
            CargarVariable(dr, "ValorCadena", out _valorCadena);
            CargarVariable(dr, "ValorFecha", out _valorfecha);
            CargarVariable(dr, "ValorDecimal", out _valordecimal);

            /* FILEUPLOAD */
            CargarVariable(dr, "UrlServidor", out _fileServer);
            CargarVariable(dr, "UrlServidorArchivos", out _serverArchivos);
            CargarVariable(dr, "CarpetaBase", out _mainFolder);
            CargarVariable(dr, "UrlBase", out _urlBase);
            CargarVariable(dr, "CarpetaArchivos", out _dataFiles);
            CargarVariable(dr, "UrlArchivos", out _urlArchivos);
            CargarVariable(dr, "CarpetaImagenes", out _imageFiles);
            CargarVariable(dr, "UrlImagenes", out _urlImagenes);
            CargarVariable(dr, "CarpetaArchivosTemporales", out _tempfiles);
            CargarVariable(dr, "CarpetaArchivosLogs", out _logfiles);
            CargarVariable(dr, "UrlArchivosTemporales", out _urlArchivosTemporales);

        }

        #endregion

    }
}
