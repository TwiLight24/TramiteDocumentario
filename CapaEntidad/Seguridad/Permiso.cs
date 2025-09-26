using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.Seguridad
{
    /// <summary>
    /// Objeto que representa a las propiedades de permisos
    /// </summary>
    public class Permiso : Intellisoft.Project.Comun.Entidad.Base
    {

        #region Variables Privadas

        private int _idRol = 0;
        private string _idMenu = string.Empty;
        private int _idFuncionalidad = 0;
        private string _nombre = string.Empty;
        private string _descripcion = string.Empty;
        private bool _asignado = false;

        private List<Permiso> _lstPermiso = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Codigo del Rol
        /// </summary>
        public int IdRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        /// <summary>
        /// Grupo de Menu de la funcionalidad
        /// </summary>
        public string IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }

        /// <summary>
        /// Codigo de la Funcionalidad
        /// </summary>
        public int IdFuncionalidad
        {
            get { return _idFuncionalidad; }
            set { _idFuncionalidad = value; }
        }

        /// <summary>
        /// Nombre de la funcionalidad
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Descripcion de la funcionalidad
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        /// <summary>
        /// Indica si la relación tiene el permiso configurado
        /// </summary>
        public bool Asignado
        {
            get { return _asignado; }
            set { _asignado = value; }
        }

        /// <summary>
        /// Lista de datos del Rol Funcionalidad
        /// </summary>
        public List<Permiso> LstPermiso
        {
            get { return _lstPermiso; }
            set { _lstPermiso = value; }
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

            CargarVariable(dr, "IdRol", out _idRol);
            CargarVariable(dr, "IdMenu", out _idMenu);
            CargarVariable(dr, "IdFuncionalidad", out _idFuncionalidad);
            CargarVariable(dr, "Nombre", out _nombre);
            CargarVariable(dr, "Descripcion", out _descripcion);
            CargarVariable(dr, "Asignado", out _asignado);
        }


        #endregion

    }
}
