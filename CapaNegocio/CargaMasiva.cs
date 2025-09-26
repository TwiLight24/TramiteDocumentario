using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Entity = CapaEntidad;

namespace CapaNegocio
{
	public class CargaMasiva
	{
        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public static Entity.CargaMasiva ListarCargaMasiva(Entity.CargaMasiva oeEntity)
        {
            try
            {
                CapaDatos.CargaMasiva oDaoEntidad = new CapaDatos.CargaMasiva();
                oeEntity = oDaoEntidad.ListarCargaMasiva(oeEntity);
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
        public static Entity.CargaMasiva Registrar(Entity.CargaMasiva oeBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {


            try
            {
                CapaDatos.CargaMasiva oDaoEntidad = new CapaDatos.CargaMasiva();
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
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CargaMasiva Listar(Entity.CargaMasiva oeDocumento)
        {
            try
            {
                CapaDatos.CargaMasiva oDaoEntidad = new CapaDatos.CargaMasiva();
                oeDocumento = oDaoEntidad.Listar(oeDocumento);
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
