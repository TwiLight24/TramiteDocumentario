namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Data;

    using Entity = CapaEntidad;

    public class CNMovimientos
    {
        public bool ActualizarMovimiento(CEMovimientos entity)
        {
            return CDMovimientos.ActualizarMovimiento(entity);
        }

        public bool CNGuardarMovimiento(CEMovimientos entity)
        {
            return CDMovimientos.CDGuardarMovimiento(entity);
        }

        public DataTable ReporteMovimientos(string cod)
        {
            return CDMovimientos.ReporteMovimientos(cod);
        }

        public DataTable ReportePromedios(DateTime fecha1, DateTime fecha2)
        {
            return CDMovimientos.ReportePromedios(fecha1, fecha2);
        }

        public DataTable ReporteVencimientos(string cod)
        {
            return CDMovimientos.ReporteVencimientos(cod);
        }

        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.CEMovimientos Registrar(Entity.CEMovimientos oeDocumento)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeDocumento = oDaoEntidad.Registrar(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CEMovimientos Listar(Entity.CEMovimientos oeMovimientos)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeMovimientos = oDaoEntidad.Listar(oeMovimientos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeMovimientos.CargarExcepcion(ex);
            }

            return oeMovimientos;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CEMovimientos MovListar(Entity.CEMovimientos oeMovimientos)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeMovimientos = oDaoEntidad.MovListar(oeMovimientos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeMovimientos.CargarExcepcion(ex);
            }

            return oeMovimientos;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el país seleccionado.
        /// </summary>
        public static Entity.CEMovimientos MovListarByPais(Entity.CEMovimientos oeEntity)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.MovListarByPais(oeEntity);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }
        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CEMovimientos MovListarByTexto(Entity.CEMovimientos oeEntity, string texto)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.MovListarByTexto(oeEntity, texto);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CEMovimientos ListarByTipoBusqueda(Entity.CEMovimientos oeEntity, string TipoBusqueda)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.ListarByTipoBusqueda(oeEntity, TipoBusqueda);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CEMovimientos MovListarByTipoBusqueda(Entity.CEMovimientos oeEntity, string TipoBusqueda)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.MovListarByTipoBusqueda(oeEntity, TipoBusqueda);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CEMovimientos VistaMovListar(Entity.CEMovimientos oeMovimientos)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeMovimientos = oDaoEntidad.VistaMovListar(oeMovimientos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeMovimientos.CargarExcepcion(ex);
            }

            return oeMovimientos;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el país seleccionado.
        /// </summary>
        public static Entity.CEMovimientos ListarByPais(Entity.CEMovimientos oeEntity)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
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
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CEMovimientos ListarByTexto(Entity.CEMovimientos oeEntity, string texto)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.ListarByTexto(oeEntity, texto);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Actualiza el Estado del Movimientos
        /// </summary>
        public static Entity.CEMovimientos Actualizar(Entity.CEMovimientos oeDocumento)
        {

            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeDocumento = oDaoEntidad.Actualizar(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CEMovimientos AsistenteDePagos(Entity.CEMovimientos oeEntity, string planilla)
        {
            try
            {
                CapaDatos.CDMovimientos oDaoEntidad = new CapaDatos.CDMovimientos();
                oeEntity = oDaoEntidad.AsistenteDePagos(oeEntity, planilla);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }
    }
}

