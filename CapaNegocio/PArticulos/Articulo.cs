using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;

namespace CapaNegocio.PArticulos
{
	public class Articulo
	{

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.Articulo Listar(Entity.Articulo oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Articulo oDaoEntidad = new CapaDatos.PArticulos.Articulo();
                oeArticulos = oDaoEntidad.Listar(oeArticulos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeArticulos.CargarExcepcion(ex);
            }

            return oeArticulos;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.Articulo ListarByPlantilla(Entity.Articulo oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Articulo oDaoEntidad = new CapaDatos.PArticulos.Articulo();
                oeArticulos = oDaoEntidad.ListarByPlantilla(oeArticulos);
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
