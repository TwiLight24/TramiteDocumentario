using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.Seguridad
{
    /// <summary>
    /// Objeto que representa a la entidad Rol Funcionalidad
    /// </summary>
    public class RolFuncionalidad : Intellisoft.Project.Comun.Entidad.Base
    {

        #region Variables Privadas

        private int _idRol = 0;
        private string _idMenu = string.Empty;
        private int _idFuncionalidad = 0;
        private bool _permiso = false;

        private List<RolFuncionalidad> _lstRolFuncionalidad = null;

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
        /// Indica si la relación tiene el permiso configurado
        /// </summary>
        public bool Permiso
        {
            get { return _permiso; }
            set { _permiso = value; }
        }

        /// <summary>
        /// Lista de datos del Rol Funcionalidad
        /// </summary>
        public List<RolFuncionalidad> LstRolFuncionalidad
        {
            get { return _lstRolFuncionalidad; }
            set { _lstRolFuncionalidad = value; }
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
        }


        #endregion

    }
}
