using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.Seguridad
{

    /// <summary>
    /// Objeto que representa a la entidad Funcionalidad
    /// </summary>

    public class Funcionalidad : Intellisoft.Project.Comun.Entidad.Base
	{
        #region Variables Privadas

        private int _idFuncionalidad = 0;
        private string _idMenu = string.Empty;
        private string _nombre = string.Empty;
        private string _descripcion = string.Empty;
        private string _pagina = string.Empty;
        private bool _funcionalidadEmpleado = false;

        private List<Funcionalidad> _lstFuncionalidad = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Código de la Funcionalidad
        /// </summary>
        public int IdFuncionalidad
        {
            get { return _idFuncionalidad; }
            set { _idFuncionalidad = value; }
        }

        /// <summary>
        /// Código del Menu
        /// </summary>
        public string IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }

        /// <summary>
        /// Nombre de la Funcionalidad
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Descripcion de la Funcionalidad
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Pagina de la Funcionalidad
        /// </summary>
        public string Pagina
        {
            get { return _pagina; }
            set { _pagina = value; }
        }

        /// <summary>
        /// Funcionalidad del Empleado
        /// </summary>
        public bool FuncionalidadEmpleado
        {
            get { return _funcionalidadEmpleado; }
            set { _funcionalidadEmpleado = value; }
        }

        /// <summary>
        /// Lista de datos de la Funcionalidad
        /// </summary>
        public List<Funcionalidad> LstFuncionalidad
        {
            get { return _lstFuncionalidad; }
            set { _lstFuncionalidad = value; }
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

            CargarVariable(dr, "IdFuncionalidad", out _idFuncionalidad);
            CargarVariable(dr, "IdMenu", out _idMenu);
            CargarVariable(dr, "Nombre", out _nombre);
            CargarVariable(dr, "Descripcion", out _descripcion);
            CargarVariable(dr, "Pagina", out _pagina);
            CargarVariable(dr, "FuncionalidadEmpleado", out _funcionalidadEmpleado);
        }

        #endregion
    }
}
