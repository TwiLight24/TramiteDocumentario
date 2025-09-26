using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos = CapaDatos.Seguridad;
using Entity = CapaEntidad.Seguridad;
namespace CapaNegocio.Seguridad
{

    /// <summary>
    /// Objeto que representa los metodos de operaciones asociados a la Entidad Funcionalidad
    /// </summary>
    public static class Funcionalidad
    {

        #region Metodos Publicos
        /// <summary>
        /// Listar en un GridView todos los Parametros
        /// </summary>
        public static Entity.Funcionalidad ListarMenus(Entity.Funcionalidad clsFuncionalidad)
        {
            try
            {
                Datos.Funcionalidad objDAO = new Datos.Funcionalidad();
                clsFuncionalidad = objDAO.ListarMenus(clsFuncionalidad);
                objDAO.Dispose();
            }
            catch (Exception ex)
            {
                clsFuncionalidad.CargarExcepcion(ex);
            }

            return clsFuncionalidad;
        }

        #endregion
    }
}
