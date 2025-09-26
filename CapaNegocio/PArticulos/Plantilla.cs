using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using Dao = CapaDatos.PArticulos;

namespace CapaNegocio.PArticulos
{
	public class Plantilla
	{
        /// <summary>
        /// Lista la informacion del consolidado de un empleado
        /// </summary>
        public static Entity.Plantilla Listar(Entity.Plantilla entidad)
        {
            try
            {
                Dao.Plantilla objDAO = new Dao.Plantilla();
                entidad = objDAO.Listar(entidad);
                objDAO.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;

        }

        /// <summary>
        /// Lista la informacion del consolidado de un empleado
        /// </summary>
        public static Entity.Plantilla ListarArticulosPorPlanilla(Entity.Plantilla entidad)
        {
            try
            {
                Dao.Plantilla objDAO = new Dao.Plantilla();
                entidad = objDAO.ListarArticulosPorPlanilla(entidad);
                objDAO.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;

        }

        /// <summary>
        /// Lista la informacion del consolidado de un empleado
        /// </summary>
        public static Entity.Plantilla ListarArticulos(Entity.Plantilla entidad)
        {
            try
            {
                Dao.Plantilla objDAO = new Dao.Plantilla();
                entidad = objDAO.ListarArticulos(entidad);
                objDAO.Dispose();
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
        public static Entity.Plantilla Registrar(Entity.Plantilla oeBandeja, string arrayIdPlanilla)
        {


            try
            {
                Dao.Plantilla oDaoEntidad = new Dao.Plantilla();
                oeBandeja = oDaoEntidad.Registrar(oeBandeja, arrayIdPlanilla);
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
        public static Entity.Plantilla Actualizar(Entity.Plantilla oeBandeja, string arrayIdPlanilla)
        {


            try
            {
                Dao.Plantilla oDaoEntidad = new Dao.Plantilla();
                oeBandeja = oDaoEntidad.Actualizar(oeBandeja, arrayIdPlanilla);
                oDaoEntidad.Dispose();

            }
            catch (Exception ex)
            {
                oeBandeja.CargarExcepcion(ex);
            }

            return oeBandeja;
        }


	}
}
