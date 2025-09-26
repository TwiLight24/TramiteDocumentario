namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Data;

    using Entity = CapaEntidad;

    public class CNDocumento
    {
        private CDDocumento objCDDOC = new CDDocumento();

        public int CNActualizarDocumento(CEDocumento entity)
        {
            return CDDocumento.CDActualizarDocumento(entity);
        }

        public int CNGuardarDocumento(CEDocumento entity)
        {
            return CDDocumento.CDGuardarDocumento(entity);
        }

        public DataTable ListarDocumentos(string cod)
        {
            return CDDocumento.ListarDocumentos(cod);
        }

        /// <summary>
        /// Listar todos los documentos adjuntos.
        /// </summary>
        public static Entity.CEDocumento VistaDocAdjuntos(Entity.CEDocumento oeDocumento)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oeDocumento = oDaoEntidad.VistaAdjuntosListar(oeDocumento);
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
        public static Entity.CEDocumento Listar(Entity.CEDocumento oeDocumento)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oeDocumento = oDaoEntidad.Listar(oeDocumento);
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
        public static Entity.CEDocumento ListarByTexto(Entity.CEDocumento oeEntity, string texto)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
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
        /// Listar en una grilla todas las empresas ACTIVAS según el país seleccionado.
        /// </summary>
        public static Entity.CEDocumento ListarByEmpresa(Entity.CEDocumento oeEntity)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oeEntity = oDaoEntidad.ListarByEmpresa(oeEntity);
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
        public static Entity.CEDocumento ListarByTipoBusqueda(Entity.CEDocumento oeEntity, string TipoBusqueda)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oeEntity = oDaoEntidad.ListarByTipoBusqueda(oeEntity, TipoBusqueda);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        public static Entity.CEDocumento ListarByTipoBusquedaFin(Entity.CEDocumento oeEntity, string TipoBusqueda)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oeEntity = oDaoEntidad.ListarByTipoBusquedaFIN(oeEntity, TipoBusqueda);
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
        public static Entity.CEDocumento Registrar(Entity.CEDocumento oeDocumento)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
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
        /// Actualiza una Empresa seleccionada
        /// </summary>
        public static Entity.CEDocumento Actualizar(Entity.CEDocumento oeDocumento)
        {

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
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
        /// Obtiene los datos del Documento desde SAP
        /// </summary>
        /// <param name="nrOrden">DocNum</param>
        /// <returns>Datos del Documento</returns>
        public static Entity.CEDocumento CargarDatosxOrden(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.CargarDatosxOrden(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Obtiene los datos del Documento desde SAP
        /// </summary>
        /// <param name="nrOrden">DocNum</param>
        /// <returns>Datos del Documento</returns>
        public static Entity.CEDocumento CargarDatosxRuc(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.CargarDatosxRuc(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }
        /// <summary>
        /// Obtiene los datos del Documento desde SAP
        /// </summary>
        /// <param name="nrOrden">DocNum</param>
        /// <returns>Datos del Documento</returns>
        public static Entity.CEDocumento CargarDatosxRucSteel(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.CargarDatosxRucSteel(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }
        /// <summary>
        /// Obtiene los datos del Documento desde SAP
        /// </summary>
        /// <param name="nrOrden">DocNum</param>
        /// <returns>Datos del Documento</returns>
        public static Entity.CEDocumento CargarDatosxOrdenSteel(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.CargarDatosxOrdenSteel(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }



        /// <summary>
        /// Obtiene los datos de un Documento
        /// </summary>
        /// <param name="iDocumento">Id del Documento</param>
        /// <returns>Datos del Documento</returns>
        public static Entity.CEDocumento Obtener(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.ObtenerDocumento(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Obtiene los datos del Documento para Generar el Correlativo
        /// </summary>
        public static Entity.CEDocumento GenerarCorrelativo(Entity.CEDocumento oeDocumento)
        {
            Entity.CEDocumento entidad = null;

            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                entidad = oDaoEntidad.GenerarCorrelativo(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }


        /// <summary>
        /// Actualiza el estado de un Documento (Activo)
        /// </summary>
        public static Entity.CEDocumento ActualizarEstado(Entity.CEDocumento oEDocumento)
        {
            try
            {
                CDDocumento oDaoEntidad = new CDDocumento();
                oEDocumento = oDaoEntidad.ActualizarEstado(oEDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;
        }

        /// <summary>
        /// Elimina fisicamente un Documento
        /// </summary>
        public static Entity.CEDocumento EliminadoFisico(Entity.CEDocumento oEEmpresa)
        {
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                oEEmpresa = oDaoEntidad.EliminadoFisico(oEEmpresa);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oEEmpresa.CargarExcepcion(ex);
            }

            return oEEmpresa;
        }

        public static string UsuarioRegistroMontalvo(String iddocumento)
        {
            String estado = "";
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                estado = oDaoEntidad.UsuarioRegistroMontalvo(iddocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }

        public static string UsuarioRegistroMontalvoxIdDocumento(int IdDocumento)
        {
            String estado = "";
            try
            {
                CapaDatos.CDDocumento oDaoEntidad = new CapaDatos.CDDocumento();
                estado = oDaoEntidad.UsuarioRegistroMontalvoxIdDocumento(IdDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }

    }
}

