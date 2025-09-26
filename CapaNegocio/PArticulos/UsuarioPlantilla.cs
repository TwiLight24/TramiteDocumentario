using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using Dao = CapaDatos.PArticulos;

namespace CapaNegocio.PArticulos
{
	public class UsuarioPlantilla
	{
        /// <summary>
        /// Lista la informacion del consolidado de un empleado
        /// </summary>
        public static Entity.UsuarioPlantilla Listar(Entity.UsuarioPlantilla entidad)
        {
            try
            {
                Dao.UsuarioPlantilla objDAO = new Dao.UsuarioPlantilla();
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
        /// Registra una nueva Empresa
        /// </summary>
        public static Entity.UsuarioPlantilla Registrar(Entity.UsuarioPlantilla oeBandeja, string arrayIdPlanilla, string arrayIdUsuario)
        {


            try
            {
                Dao.UsuarioPlantilla oDaoEntidad = new Dao.UsuarioPlantilla();
                oeBandeja = oDaoEntidad.Registrar(oeBandeja, arrayIdPlanilla, arrayIdUsuario);
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
