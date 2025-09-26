using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Text;

namespace Intellisoft.Project.Comun.Entidad
{
    /// <summary>
    /// Objeto que representa a las propiedades y metodos comunes de una Entidad
    /// </summary>
    [Serializable]
    public class Base : IDisposable
    {
        #region Variables Privadas

        private bool _activo = true;
        private int _cregistro = 0;
        private string _nombreUsuarioRegistro = string.Empty;
        private string _nombreUsuarioCreador = string.Empty;
        private string _fregistro = string.Empty;
        private int _ccambio = 0;
        private string _nombreUsuarioCambio = string.Empty;
        private string _nombreUsuarioModificacion = string.Empty;
        private string _fcambio = string.Empty;
        private string _criterio_busqueda = string.Empty;
        private int _opcion = 0;

        private string _area = string.Empty;


        private Resultado _resultado = new Resultado();

        #endregion

        #region Propiedades

        /// <summary>
        /// Indica si el registro se encuentra activo
        /// </summary>
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        /// <summary>
        /// Indica el codigo del Usuario que creó el registro
        /// </summary>
        public int UsuarioCreador
        {
            get { return _cregistro; }
            set { _cregistro = value; }
        }

        /// <summary>
        /// Nombre del Usuario que creó el registro
        /// </summary>
        public string NombreUsuarioCreador 
        {
            get { return _nombreUsuarioCreador; }
            set { _nombreUsuarioCreador = value; }
        }

        /// <summary>
        /// Nombre del Usuario que creó el registro
        /// </summary>
        public string NombreUsuarioRegistro
        {
            get { return _nombreUsuarioRegistro; }
            set { _nombreUsuarioRegistro = value; }
        }

        /// <summary>
        /// Indica la Fecha de Registro
        /// </summary>
        public string FechaRegistro
        {
            get { return _fregistro; }
            set { _fregistro = value; }
        }

        /// <summary>
        /// Indica el codigo del Usuario que modificó el registro por última vez
        /// </summary>
        public int UsuarioModificador
        {
            get { return _ccambio; }
            set { _ccambio = value; }
        }

        /// <summary>
        /// Nombre del Usuario que modificó el registro por última vez
        /// </summary>
        public string NombreUsuarioCambio
        {
            get { return _nombreUsuarioCambio; }
            set { _nombreUsuarioCambio = value; }
        }

        /// <summary>
        /// Nombre del Usuario que modificó el registro por última vez
        /// </summary>
        public string NombreUsuarioModificacion
        {
            get { return _nombreUsuarioModificacion; }
            set { _nombreUsuarioModificacion = value; }
        }

        /// <summary>
        /// Indica la fecha del último cambio del registro
        /// </summary>
        public string FechaCambio
        {
            get { return _fcambio; }
            set { _fcambio = value; }
        }

        /// <summary>
        /// Criterio de busqueda
        /// </summary>
        public string Criterio_busqueda
        {
            get { return _criterio_busqueda; }
            set { _criterio_busqueda = value; }
        }

        /// <summary>
        /// Opción
        /// </summary>
        public int Opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        /// <summary>
        /// Nombre del Area
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        #endregion

        #region Propiedades Adicionales

        /// <summary>
        /// Indica el ultimo resultado asociado al ultimo proceso relacionado a la Entidad actual
        /// </summary>
        public Resultado UltimoResultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public virtual void CargarEntidad(IDataReader dr)
        {
            CargarVariable(dr, "Activo", out _activo);
            CargarVariable(dr, "UsuarioCreador", out _cregistro);
            CargarVariable(dr, "NombreUsuarioCreador", out _nombreUsuarioCreador);
            CargarVariable(dr, "NombreUsuarioRegistro", out _nombreUsuarioRegistro);
            CargarVariable(dr, "FechaRegistro", out _fregistro);
            CargarVariable(dr, "UsuarioModificador", out _ccambio);
            CargarVariable(dr, "NombreUsuarioCambio", out _nombreUsuarioCambio);
            CargarVariable(dr, "NombreUsuarioModificacion", out _nombreUsuarioModificacion);
            CargarVariable(dr, "FechaCambio", out _fcambio);
            CargarVariable(dr, "Opcion", out _opcion);
            CargarVariable(dr, "Area", out _area);
        }

        /// <summary>
        /// Carga los datos de la Entidad en el DataRow
        /// </summary>
        /// <param name="dr">Donde se cargará los datos de la Entidad</param>
        public virtual void CargarDataRow(DataRow dr)
        {
            dr["Activo"] = _activo;
            dr["UsuarioCreador"] = _cregistro;
            dr["FechaRegistro"] = _fregistro;
            dr["UsuarioModificador"] = _ccambio;
            dr["FechaCambio"] = _fcambio;
        }

        /// <summary>
        /// Valida el valor de la fecha, en caso sea igual a DateTime.MinValue devolverá null
        /// </summary>
        /// <param name="fecha">Fecha a Validar</param>
        /// <returns>Retorna el valor de la fecha validado</returns>
        public object ValidarFecha(DateTime fecha)
        {
            object valor = null;

            if (fecha != DateTime.MinValue) valor = fecha;

            return valor;
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out short data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? (short)0 : Convert.ToInt16(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out byte[] data)
        {
            object rpta = DevolverData(dr, campo);

            data = (rpta == null) ? new byte[0] : rpta as byte[];
        }


        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out int data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToInt32(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out long data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToInt64(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out decimal data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? 0 : Convert.ToDecimal(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out bool data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? false : Convert.ToBoolean(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out string data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? string.Empty : Convert.ToString(rpta);
        }

        /// <summary>
        /// Carga la variable con la data encontrada
        /// </summary>
        /// <param name="dr">Contiene la data a transferir</param>
        /// <param name="campo">Nombre del campo a transferir</param>
        /// <param name="data">Receptor del valor</param>
        protected void CargarVariable(IDataReader dr, string campo, out DateTime data)
        {
            object rpta = DevolverData(dr, campo);

            data = rpta == null ? DateTime.MinValue : Convert.ToDateTime(rpta);
        }

        /// <summary>
        /// Carga en el objeto Resultado la información de la Excepcion indicada
        /// </summary>
        /// <param name="ex">Excepcion a cargar</param>
        public void CargarExcepcion(Exception ex)
        {
            _resultado.CargarExcepcion(ex);
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Devuelve el valor del campo encontrado, sino encuentra el campo o el campo es nulo, devuelve null
        /// </summary>
        /// <param name="dr">Contiene el dato a cargar</param>
        /// <param name="campo">Nombre del campo a buscar</param>
        /// <returns></returns>
        private object DevolverData(IDataReader dr, string campo)
        {
            object rpta = null;

            for (int iReader = 0; iReader < dr.FieldCount; iReader++)
            {
                if (string.Compare(dr.GetName(iReader), campo, true) == 0)
                {
                    if (!dr.IsDBNull(iReader))
                    {
                        rpta = dr.GetValue(iReader);
                        break;
                    }
                }
            }

            return rpta;
        }

        #endregion

        #region Liberacion de Recursos

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        /// <param name="disposing">Indica si omite en el proceso la llamada al finalizador</param>
        private void Dispose(bool disposing)
        {
            if (_resultado != null) _resultado.Dispose();

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Finalizador del objeto
        /// </summary>
        ~Base()
        {
            this.Dispose(false);
        }

        #endregion
    }

    /// <summary>
    /// Objeto que representa los resultados obtenidos durante el procesamiento de Entidades
    /// </summary>
    [Serializable]
    public class Resultado : IDisposable
    {
        #region Variables Privadas

        private bool esValido = true;
        //private string mensajeError = string.Empty;
        //private string pilaError = string.Empty;
        private Exception excepcion = null;
        private short resultadoOperacion = 0;
        private string mensaje = string.Empty;
        private string cadenaConexion = string.Empty;
        private DataSet ds = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Indica si el resultado del ultimo proceso es válido
        /// </summary>
        public bool EsValido
        {
            get { return esValido; }
            set { esValido = value; }
        }

        /// <summary>
        /// Indica si el valor del resultado del proceso 
        /// (1: Exitoso, 0: No proceso, -1: Error)
        /// </summary>
        public short ResultadoOperacion
        {
            get { return resultadoOperacion; }
            set { resultadoOperacion = value; }
        }

        /// <summary>
        /// Indica el mensaje final de la operación.
        /// </summary>
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        /// <summary>
        /// Indica la cadena de conexion utilizada en el ultimo proceso válido
        /// </summary>
        public string CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        /// <summary>
        /// Indica el ultimo DataSet asociado al ultimo proceso válido
        /// </summary>
        public DataSet UltimoDataSet
        {
            get { return ds; }
            set { ds = value; }
        }

        /// <summary>
        /// Indica la ultima Excepcion asociada a la Entidad
        /// </summary>
        public Exception UltimaExcepcion
        {
            get { return excepcion; }
        }

        #endregion

        #region Meotodos Publicos

        /// <summary>
        /// Carga en el objeto Resultado la informacion de la Excepcion indicada
        /// </summary>
        /// <param name="ex">Excepcion a cargar</param>
        public void CargarExcepcion(Exception ex)
        {
            esValido = false;
            mensaje = ex.Message;
            resultadoOperacion = -1;
            excepcion = ex;
            excepcion = new Exception(ex.Message, ex);
        }

        #endregion

        #region Liberacion de Recursos

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        /// <param name="disposing">Indica si omite en el proceso la llamada al finalizador</param>
        private void Dispose(bool disposing)
        {
            if (ds != null) ds.Dispose();

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el objeto
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Finalizador del objeto
        /// </summary>
        ~Resultado()
        {
            this.Dispose(false);
        }

        #endregion
    }

    /// <summary>
    /// Objeto que representa las operaciones de copia y clonacion de objetos
    /// </summary>
    public static class ObjectClone
    {
        /// <summary>
        /// Obtiene una copia de un objeto
        /// </summary>
        /// <typeparam name="T">El tipo del Objeto</typeparam>
        /// <param name="objToClone">Objeto a clonar</param>
        /// <returns>Devuelve la copia exacta de un objeto</returns>
        public static T Clone<T>(T objToClone)
        {
            using (Stream oStream = new MemoryStream())
            {
                IFormatter oFormatter = new BinaryFormatter();
                oFormatter.Serialize(oStream, objToClone);
                oStream.Seek(0, SeekOrigin.Begin);
                T oCloned = (T)oFormatter.Deserialize(oStream);
                oStream.Dispose();
                return oCloned; // (T)formatter.Deserialize(objectStream);
            }
        }
    } 
}
