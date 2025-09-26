using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.Seguridad;
using Datos = CapaDatos.Seguridad;

namespace CapaNegocio.Seguridad
{
    /// <summary>
    /// Objeto que representa los metodos de operaciones asociados a la Entidad RolFuncionalidad
    /// </summary>
    public static class RolFuncionalidad
    {
        #region Metodos Publicos

        /// <summary>
        /// Obtiene los Menus y Funcionalidades de un determinado Rol
        /// </summary>
        public static Entity.RolFuncionalidad ObtenerFuncionalidadPorRol(Entity.RolFuncionalidad oeEntity)
        {
            try
            {
                Datos.RolFuncionalidad oDaoEntidad = new Datos.RolFuncionalidad();
                oeEntity = oDaoEntidad.ObtenerFuncionalidadPorRol(oeEntity);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Obtiene los Permisos de RolFuncionalidad de acuerdo a menú y rol
        /// </summary>
        public static Entity.Permiso ObtenerPermisosPorMenuRol(Entity.Permiso oeEntity)
        {
            try
            {
                Datos.RolFuncionalidad oDaoEntidad = new Datos.RolFuncionalidad();
                oeEntity = oDaoEntidad.ObtenerPermisosPorMenuRol(oeEntity);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Actualiza un registro en la tabla RolFuncionalidad
        /// </summary>
        public static Entity.RolFuncionalidad Actualizar(Entity.RolFuncionalidad oeEntity)
        {
            try
            {
                Datos.RolFuncionalidad objDAO = new Datos.RolFuncionalidad();
                oeEntity = objDAO.Actualizar(oeEntity);
                objDAO.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        #endregion
    }
}
