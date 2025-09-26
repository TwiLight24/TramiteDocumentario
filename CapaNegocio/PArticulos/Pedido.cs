using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using Datos = CapaDatos.PArticulos;
using System.Data;

namespace CapaNegocio.PArticulos
{
	public class Pedido
	{

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.Pedido Registrar(Entity.Pedido oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Pedido oDaoEntidad = new CapaDatos.PArticulos.Pedido();
                oeArticulos = oDaoEntidad.Registrar(oeArticulos);
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
        public static Entity.Pedido RegistrarDetalle(Entity.Pedido oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Pedido oDaoEntidad = new CapaDatos.PArticulos.Pedido();
                oeArticulos = oDaoEntidad.RegistrarDetalle(oeArticulos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeArticulos.CargarExcepcion(ex);
            }

            return oeArticulos;
        }


        /// <summary>
        /// Listar en una grilla todos los Pedidos.
        /// </summary>
        public static Entity.Pedido Listar(Entity.Pedido oeMovimientos)
        {
            try
            {
                Datos.Pedido oDaoEntidad = new Datos.Pedido();
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
        /// Listar en una grilla todos los Pedidos.
        /// </summary>
        public static Entity.Pedido ListarByUsuario(Entity.Pedido oeMovimientos)
        {
            try
            {
                Datos.Pedido oDaoEntidad = new Datos.Pedido();
                oeMovimientos = oDaoEntidad.ListarByUsuario(oeMovimientos);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeMovimientos.CargarExcepcion(ex);
            }

            return oeMovimientos;
        }


        /// <summary>
        /// Obtiene los datos de un Pedido
        /// </summary>
        /// <param name="iDocumento">Id del Perdido</param>
        /// <returns>Datos del Pedido</returns>
        public static Entity.Pedido Obtener(Entity.Pedido oeDocumento)
        {
            Entity.Pedido entidad = null;

            try
            {
                Datos.Pedido oDaoEntidad = new Datos.Pedido();
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
        /// Actualiza una Empresa seleccionada
        /// </summary>
        public static Entity.Pedido Actualizar(Entity.Pedido oeDocumento)
        {

            try
            {
               Datos.Pedido oDaoEntidad = new Datos.Pedido();
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
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.Pedido Agregar(Entity.Pedido oeArticulos)
        {
            try
            {
                CapaDatos.PArticulos.Pedido oDaoEntidad = new CapaDatos.PArticulos.Pedido();
                oeArticulos = oDaoEntidad.Agregar(oeArticulos);
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
