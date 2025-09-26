namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Data;

    using Entity = CapaEntidad;

    public class CNDistribucion
    {
        public bool ActualizarDistribucion(CEDistribucion entity)
        {
            return CDDistribucion.ActualizarDistribucion(entity);
        }

        public bool GuardarDistribucion(CEDistribucion entity)
        {
            return CDDistribucion.GuardarDistribucion(entity);
        }

        public DataTable ListarDistribucion(string cod)
        {
            return CDDistribucion.ListarDistribucion(cod);
        }

        public DataTable ListarDocumentos()
        {
            return CDDistribucion.ListarDocumentos();
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CEDistribucion Listar(Entity.CEDistribucion oeDistribucion)
        {
            try
            {
                CapaDatos.CDDistribucion oDaoEntidad = new CapaDatos.CDDistribucion();
                oeDistribucion = oDaoEntidad.Listar(oeDistribucion);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeDistribucion.CargarExcepcion(ex);
            }

            return oeDistribucion;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el país seleccionado.
        /// </summary>
        public static Entity.CEDistribucion ListarByPais(Entity.CEDistribucion oeEntity)
        {
            try
            {
                CapaDatos.CDDistribucion oDaoEntidad = new CapaDatos.CDDistribucion();
                oeEntity = oDaoEntidad.ListarByPais(oeEntity);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.CEDistribucion Registrar(Entity.CEDistribucion oeDocumento)
        {
            try
            {
                CapaDatos.CDDistribucion oDaoEntidad = new CapaDatos.CDDistribucion();
                oeDocumento = oDaoEntidad.Registrar(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }

    }
}

