using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;

namespace CapaNegocio.PArticulos
{
	public class Periodo
	{

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.Periodo Listar(Entity.Periodo oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Periodo oDaoEntidad = new CapaDatos.PArticulos.Periodo();
                oeArticulos = oDaoEntidad.Listar(oeArticulos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeArticulos.CargarExcepcion(ex);
            }

            return oeArticulos;
        }



	}
}
