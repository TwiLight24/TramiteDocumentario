using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaEntidad;
using System.Data;

using Entity = CapaEntidad;

namespace CapaNegocio
{
	public class Bandeja
	{
        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.Bandeja Registrar(Entity.Bandeja oeBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {


            try
            {
                CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
                oeBandeja = oDaoEntidad.Enviar(oeBandeja, arrayIdDocumento, arrayIdMovimiento);
                oDaoEntidad.Dispose();

            }
            catch (Exception ex)
            {
                oeBandeja.CargarExcepcion(ex);
            }

            return oeBandeja;
        }

        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.Bandeja Recibir(Entity.Bandeja oeBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {


            try
            {
                CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
                oeBandeja = oDaoEntidad.Recibir(oeBandeja, arrayIdDocumento, arrayIdMovimiento);
                oDaoEntidad.Dispose();

            }
            catch (Exception ex)
            {
                oeBandeja.CargarExcepcion(ex);
            }

            return oeBandeja;
        }


        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.Bandeja Rechazar(Entity.Bandeja oeBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {


            try
            {
                CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
                oeBandeja = oDaoEntidad.Rechazar(oeBandeja, arrayIdDocumento, arrayIdMovimiento);
                oDaoEntidad.Dispose();

            }
            catch (Exception ex)
            {
                oeBandeja.CargarExcepcion(ex);
            }

            return oeBandeja;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.Bandeja ListarByIdCocumentoMasivo(Entity.Bandeja oeEntity, string TipoBusqueda)
        {
            try
            {
                CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
                oeEntity = oDaoEntidad.ListarByIdDocumentoMasivo(oeEntity, TipoBusqueda);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        public static string EliminarDocs(string arrDocs, int intUsr)
        {
            CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
            return oDaoEntidad.EliminarDocs(arrDocs,  intUsr);
        }

        public static string AdjuntarDocs(int idDocumento, string docAdjunto, int intUsr)
        {
            CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
            return oDaoEntidad.AdjuntarDocs(idDocumento, docAdjunto, intUsr);
        }

        public static string ActualizarDocs(string arrDocs,string fecha, int intUsr)
        {
            CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
            return oDaoEntidad.ActualizarDocs(arrDocs, fecha, intUsr);
        }

        public static string BuscarUsuFechaPago(int intUsr)
        {
            CapaDatos.Bandeja oDaoEntidad = new CapaDatos.Bandeja();
            return oDaoEntidad.BuscarUsuFechaPago(intUsr);
        }

    }
}
