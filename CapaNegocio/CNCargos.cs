namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Data;

    using Entity = CapaEntidad;
    public class CNCargos
    {
        private CDCargos objCDCAR = new CDCargos();

        public int CNGuardarCargoCab(CECargos entity)
        {
            return CDCargos.CDGuardarCargoCab(entity);
        }

        public string CNGuardarCargoDet(CECargos entity)
        {
            return CDCargos.CDGuardarCargoDet(entity);
        }

        public DataTable ListarCargosById(int cod)
        {
            return CDCargos.ListarCargoById(cod);
        }

        /// <summary>
        /// Obtiene los datos del Documento para Generar el Correlativo
        /// </summary>
        public static Entity.CECargos GenerarCorrelativo(Entity.CECargos oeDocumento)
        {
            Entity.CECargos entidad = null;

            try
            {
                CapaDatos.CDCargos oDaoEntidad = new CapaDatos.CDCargos();
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
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.CECargos Registrar(Entity.CECargos oeDocumento)
        {
            try
            {
                CapaDatos.CDCargos oDaoEntidad = new CapaDatos.CDCargos();
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
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.CECargos RegistrarCargoDetalle(Entity.CECargos oeDocumento)
        {
            try
            {
                CapaDatos.CDCargos oDaoEntidad = new CapaDatos.CDCargos();
                oeDocumento = oDaoEntidad.RegistrarCargoDetalle(oeDocumento);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }
        /// <summary>
        /// Listar el detalle de los cierre de turnos.
        /// </summary>
        public static Entity.CECargos ListarCargoByIdReporte(Entity.CECargos objAplicacion)
        {
            try
            {
                CDCargos objDao = new CDCargos();
                objAplicacion = objDao.ListarCargoByIdReporte(objAplicacion);
                objDao.Dispose();
            }
            catch (Exception ex)
            {
                objAplicacion.CargarExcepcion(ex);
            }

            return objAplicacion;
        }
    }
}

