using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    /// <summary>
    /// Objeto que representa a la entidad Usuario
    /// </summary>
    public class Usuario : Intellisoft.Project.Comun.Entidad.Base
    {

        #region Variables Privadas

        private int _idUsuario = 0;
        private int _idRol = 0;
        private int _destino;
        private string _descripcion = string.Empty;
        private string _CorreoElectronico = string.Empty;
        private int _idEmpleado = 0;
        private int _idEmpleadoJefe = 0;
        private string _codigoEmpleado = string.Empty;
        private string _nombreUsuario = string.Empty;
        private string _nombreEmpleado = string.Empty;
        private string _contrasena = string.Empty;
        private string _credencialWindows = string.Empty;
        private string _tipoAutenticacion = string.Empty;
        private string _descripcionAutenticacion = string.Empty;
        private string _nuevaContrasena = string.Empty;
        private string _contrasenaCifrada = string.Empty;
        private string _idUsuarioCifrado = string.Empty;
        private string _fechaCaducidad = string.Empty;
        private bool _caducado = false;
        private bool _autenticado = false;
        private bool _creado = false;
        private int _idPeriodo = 0;
        private int _jornadaTrabajo = 0;
        private string _tipoTrabajador = string.Empty;
        private string _estadoPeriodoEmpleado = string.Empty;
        private string _estadoConsolidado = string.Empty;
        private DateTime _fechaInicio = DateTime.Now;
        private DateTime _fechaFin = DateTime.Now;
        private string _fechaCese = string.Empty;
        private int _idAplicativo = 0;
        private bool _permisoPorAplicativo = false;
        private string _rutaDefecto = string.Empty;

        private List<Usuario> _lstUsuario = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Codigo del Usuario
        /// </summary>
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        /// <summary>
        /// Codigo del Destino
        /// </summary>
        public int Destino
        {
            get
            {
                return this._destino;
            }
            set
            {
                this._destino = value;
            }
        }

        /// <summary>
        /// Codigo del Rol
        /// </summary>
        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        /// <summary>
        /// Descripcion del Rol
        /// </summary>
        public string DescripcionRol
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Descripcion del Rol
        /// </summary>
        public string CorreoElectronico
        {
            get { return _CorreoElectronico; }
            set { _CorreoElectronico = value; }
        }
        /// <summary>
        /// Id del Empleado
        /// </summary>
        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }

        /// <summary>
        /// Id del Empleado Jefe
        /// </summary>
        public int IdEmpleadoJefe
        {
            get { return _idEmpleadoJefe; }
            set { _idEmpleadoJefe = value; }
        }

        /// <summary>
        /// Codigo del Empleado que le asigna la empresa.
        /// </summary>
        public string CodigoEmpleado
        {
            get { return _codigoEmpleado; }
            set { _codigoEmpleado = value; }
        }

        /// <summary>
        /// Nombres Usuario para el inicio de sesión
        /// </summary>
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        /// <summary>
        /// Nombre del Empleado para el inicio de sesión
        /// </summary>
        public string NombreEmpleado
        {
            get { return _nombreEmpleado; }
            set { _nombreEmpleado = value; }
        }

        /// <summary>
        /// Contraseña plana del Usuario
        /// </summary>
        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        /// <summary>
        /// Nueva Contraseña
        /// </summary>
        public string NuevaContrasena
        {
            get { return _nuevaContrasena; }
            set { _nuevaContrasena = value; }
        }

        /// <summary>
        /// Nombre de Usuario de Windows
        /// </summary>
        public string CredencialWindows
        {
            get { return _credencialWindows; }
            set { _credencialWindows = value; }
        }

        /// <summary>
        /// Tipo de Autenticacion: Login y/o Active Directory
        /// </summary>
        public string TipoAutenticacion
        {
            get { return _tipoAutenticacion; }
            set { _tipoAutenticacion = value; }
        }

        /// <summary>
        /// Descripción del Tipo de Autenticación
        /// </summary>
        public string DescripcionAutenticacion
        {
            get { return _descripcionAutenticacion; }
            set { _descripcionAutenticacion = value; }
        }

        /// <summary>
        /// Contraseña cifrada del Usuario
        /// </summary>
        public string ContrasenaCifrada
        {
            get { return _contrasenaCifrada; }
            set { _contrasenaCifrada = value; }
        }

        /// <summary>
        /// Codigo cifrado del Usuario
        /// </summary>
        public string IdUsuarioCifrado
        {
            get { return _idUsuarioCifrado; }
            set { _idUsuarioCifrado = value; }
        }

        /// <summary>
        /// Fecha de Caducidad
        /// </summary>
        public string FechaCaducidad
        {
            get { return _fechaCaducidad; }
            set { _fechaCaducidad = value; }
        }

        /// <summary>
        /// Indica si el Usuario a Caducado
        /// </summary>
        public bool EstaCaducado
        {
            get { return _caducado; }
            set { _caducado = value; }
        }

        /// <summary>
        /// Indica si el Usuario ha sido autenticado
        /// </summary>
        public bool Autenticado
        {
            get { return _autenticado; }
            set { _autenticado = value; }
        }

        /// <summary>
        /// Indica si el Usuario ha sido credo
        /// </summary>
        public bool Creado
        {
            get { return _creado; }
            set { _creado = value; }
        }

        /// <summary>
        /// Id Periodo Empleado
        /// </summary>
        public int IdPeriodo
        {
            get { return _idPeriodo; }
            set { _idPeriodo = value; }
        }

        /// <summary>
        /// Jornada de Trabajo (cantidad de horas)
        /// </summary>
        public int JornadaTrabajo
        {
            get { return _jornadaTrabajo; }
            set { _jornadaTrabajo = value; }
        }

        /// <summary>
        /// Tipo de Trabajor de acuerdo a su contrato
        /// </summary>
        public string TipoTrabajador
        {
            get { return _tipoTrabajador; }
            set { _tipoTrabajador = value; }
        }

        /// <summary>
        /// Estado del Periodo del Empleado para el Registro de Horas
        /// </summary>
        public string EstadoPeriodoEmpleado
        {
            get { return _estadoPeriodoEmpleado; }
            set { _estadoPeriodoEmpleado = value; }
        }

        /// <summary>
        /// Estado del Consolidado del Periodo del Empleado para el Registro de Horas
        /// </summary>
        public string EstadoConsolidado
        {
            get { return _estadoConsolidado; }
            set { _estadoConsolidado = value; }
        }


        /// <summary>
        /// Fecha Inicio del Periodo
        /// </summary>
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        /// <summary>
        /// Fecha Fin del Periodo
        /// </summary>
        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }

        /// <summary>
        /// Fecha de Cese de labores del Empleado
        /// </summary>
        public string FechaCese
        {
            get { return _fechaCese; }
            set { _fechaCese = value; }
        }

        /// <summary>
        /// Lista de datos del Usuario
        /// </summary>
        public List<Usuario> LstUsuario
        {
            get { return _lstUsuario; }
            set { _lstUsuario = value; }
        }

        /// <summary>
        /// Codigo del Aplicativo
        /// </summary>
        public int IdAplicativo
        {
            get { return _idAplicativo; }
            set { _idAplicativo = value; }
        }

        /// <summary>
        /// Ruta del Aplicativo
        /// </summary>
        public string RutaDefecto
        {
            get { return _rutaDefecto; }
            set { _rutaDefecto = value; }
        }

        /// <summary>
        /// Indica si el Usuario Tiene Acceso a ese Aplicativo
        /// </summary>
        public bool PermisoPorAplicativo
        {
            get { return _permisoPorAplicativo; }
            set { _permisoPorAplicativo = value; }
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdUsuario", out _idUsuario);
            CargarVariable(dr, "IdRol", out _idRol);
            CargarVariable(dr, "DescripcionRol", out _descripcion);
            CargarVariable(dr, "IdEmpleado", out _idEmpleado);
            CargarVariable(dr, "IdEmpleadoJefe", out _idEmpleadoJefe);
            CargarVariable(dr, "CodigoEmpleado", out _codigoEmpleado);
            CargarVariable(dr, "NombreUsuario", out _nombreUsuario);
            CargarVariable(dr, "NombreEmpleado", out _nombreEmpleado);
            CargarVariable(dr, "Contrasena", out _contrasena);
            CargarVariable(dr, "NuevaContrasena", out _nuevaContrasena);
            CargarVariable(dr, "CredencialWindows", out _credencialWindows);
            CargarVariable(dr, "TipoAutenticacion", out _tipoAutenticacion);
            CargarVariable(dr, "DescripcionAutenticacion", out _descripcionAutenticacion);
            CargarVariable(dr, "FechaCaducidad", out _fechaCaducidad);
            CargarVariable(dr, "Caducado", out _caducado);
            CargarVariable(dr, "IdPeriodo", out _idPeriodo);
            CargarVariable(dr, "JornadaTrabajo", out _jornadaTrabajo);
            CargarVariable(dr, "TipoTrabajador", out _tipoTrabajador);
            CargarVariable(dr, "FechaInicio", out _fechaInicio);
            CargarVariable(dr, "FechaFin", out _fechaFin);
            CargarVariable(dr, "FechaCese", out _fechaCese);
            CargarVariable(dr, "EstadoPeriodo", out _estadoPeriodoEmpleado);
            CargarVariable(dr, "EstadoConsolidado", out _estadoConsolidado);
            CargarVariable(dr, "CorreoElectronico", out _CorreoElectronico);
            CargarVariable(dr, "IdAplicativo", out _idAplicativo);
            CargarVariable(dr, "PermisoPorAplicativo", out _permisoPorAplicativo);
            CargarVariable(dr, "RutaDefecto", out _rutaDefecto);
        }

        #endregion

    }
}
