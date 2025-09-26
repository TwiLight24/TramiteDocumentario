using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

using Entity = CapaEntidad;


namespace CapaNegocio
{
    /// <summary>
    /// Objeto que representa los metodos de operaciones asociados a la Entidad Parametro Detalle
    /// </summary>
    public static class ParametroDetalle
    {

        #region Metodos Publicos


        /// <summary>
        /// Listar en un GridView todos los Párametros Detalle
        /// </summary>
        public static Entity.ParametroDetalle ListarParamDet(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.ListarParamDet(clsDetalle);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }

        /// <summary>
        /// Obtener el detalle de un Parámetro
        /// </summary>
        public static Entity.ParametroDetalle Seleccionar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.Seleccionar(clsDetalle);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Listar en un GridView todos los Parámetros Detalle tras la búsqueda por Texto ingresado
        /// </summary>
        public static Entity.ParametroDetalle Buscar(Entity.ParametroDetalle clsDetalle, string strTexto)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.Buscar(clsDetalle, strTexto);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Actualiza el estado de un Parametro Detalle (Activo)
        /// </summary>
        public static Entity.ParametroDetalle ActualizarEstado(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.ActualizarEstado(clsDetalle);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Parametro Detalle
        /// </summary>
        public static Entity.ParametroDetalle Actualizar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.Actualizar(clsDetalle);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }

        /// <summary>
        /// Inserta un nuevo Parametro Detalle
        /// </summary>
        public static Entity.ParametroDetalle Insertar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle objCapaDatos = new CapaDatos.ParametroDetalle();
                clsDetalle = objCapaDatos.Insertar(clsDetalle);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Actualiza Cliente
        /// </summary>
        /// <param name="entidad">Entidad Cliente: Todos</param>
        /// <returns>Indica si la operacion se ha completado correctamente</returns>
        public static Entity.ParametroDetalle DatosFileUpload()
        {
            Entity.ParametroDetalle entidad = null;

            try
            {
                if (HttpContext.Current.Session["RutasApp"] == null)
                {
                    entidad = new Entity.ParametroDetalle();
                    CapaDatos.ParametroDetalle CapaDatos = new CapaDatos.ParametroDetalle();
                    entidad = CapaDatos.DatosFileUpload();

                    HttpContext.Current.Session["RutasApp"] = entidad;
                    CapaDatos.Dispose();
                }
                else
                {
                    entidad = HttpContext.Current.Session["RutasApp"] as Entity.ParametroDetalle;
                }
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Obtener el detalle de un Parámetro
        /// </summary>
        /// <param name="sIdDetalle">Id Detalle</param>
        /// <returns>Detalle Parámetro</returns>
        public static Entity.ParametroDetalle Obtener(Entity.ParametroDetalle oEDetalle)
        {
            try
            {
                CapaDatos.ParametroDetalle oCapaDatosDetalle = new CapaDatos.ParametroDetalle();
                oEDetalle = oCapaDatosDetalle.Obtener(oEDetalle);
                oCapaDatosDetalle.Dispose();
            }
            catch (Exception ex)
            {
                oEDetalle.CargarExcepcion(ex);
            }

            return oEDetalle;
        }


        #endregion

    }
}
