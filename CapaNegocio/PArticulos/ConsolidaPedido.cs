using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using Dao = CapaDatos.PArticulos;
using System.Collections;

namespace CapaNegocio.PArticulos
{
	public class ConsolidaPedido
	{
                /// <summary>
        /// Lista la informacion del consolidado de un empleado
        /// </summary>
        public static Entity.ConsolidaPedido ListarConsolidado(Entity.ConsolidaPedido entidad)
        {
            try
            {
                Dao.ConsolidaPedido objDAO = new Dao.ConsolidaPedido();
                entidad = objDAO.ListarConsolidado(entidad);
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
        public static Entity.ConsolidaPedido ListarConsolidadoByEmpresa(Entity.ConsolidaPedido entidad)
        {
            try
            {
                Dao.ConsolidaPedido objDAO = new Dao.ConsolidaPedido();
                entidad = objDAO.ListarConsolidadoByEmpresa(entidad);
                objDAO.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;

        }

	}
}
