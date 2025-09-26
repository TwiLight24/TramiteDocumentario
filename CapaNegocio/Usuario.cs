using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad;

namespace CapaNegocio
{
    /// <summary>
    /// Objeto que representa los metodos de operaciones asociados a la Entidad Usuario
    /// </summary>
    public static class Usuario
    {

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static CapaEntidad.Usuario Listar(Entity.Usuario oeEmpresa)
        {
            try
            {
                CapaDatos.Usuario oDaoEntidad = new CapaDatos.Usuario();
                oeEmpresa = oDaoEntidad.Listar(oeEmpresa);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oeEmpresa.CargarExcepcion(ex);
            }

            return oeEmpresa;
        }

        /// <summary>
        /// Agrega un registro en la tabla de Usuario
        /// </summary>
        public static Entity.Usuario Agregar(Entity.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.Agregar(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Validad Usuario y Obtiene Password
        /// </summary>
        /// <param name="entidad">Entidad Usuario: NombreUsuario, Contrasena</param>
        /// <returns>Entidad Usuario Autenticado</returns>
        public static CapaEntidad.Usuario ValidaUsuarioSistema(CapaEntidad.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.ValidaUsuarioSistema(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Valida el Nombre de Usuario de Windows
        /// </summary>
        /// <param name="entidad">Entidad Usuario: CredencialWindows</param>
        /// <returns>Entidad Usuario Autenticado</returns>
        public static CapaEntidad.Usuario ValidaUsuarioWindows(CapaEntidad.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.ValidaUsuarioWindows(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Selecciona Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario: Codigo</param>
        /// <returns>Entidad Usuario Seleccionado</returns>
        public static CapaEntidad.Usuario Seleccionar(CapaEntidad.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.Seleccionar(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Selecciona Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario: IdUsuario</param>
        /// /// <param name="entidad">Entidad Usuario: IdPeriodo</param>
        /// <returns>Entidad Usuario Seleccinado</returns>
        public static CapaEntidad.Usuario Seleccionar2(CapaEntidad.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.Seleccionar2(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Obtiene los datos de un Usuario
        /// </summary>
        /// <param name="iCliente">Id del Empleado</param>
        /// <returns>Datos del Empleado</returns>
        public static Entity.Usuario Obtener(Entity.Usuario oUsuario)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                oUsuario = objCapaDatos.Obtener(oUsuario);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                oUsuario.CargarExcepcion(ex);
            }

            return oUsuario;
        }

        /// <summary>
        /// Actualiza un registro en la tabla de Usuario
        /// </summary>
        public static Entity.Usuario Actualizar(Entity.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.Actualizar(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Actualizar el estado de caducidad de un Usuario
        /// </summary>
        public static Entity.Usuario ActualizarCaducidad(Entity.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.ActualizarCaducidad(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Verificar si un nombre de usuario es repetido o no
        /// </summary>
        public static Int32 VerificarNombreUsuario(Entity.Usuario oUsuario)
        {
            Int32 verificador = 0;
            try
            {
                CapaDatos.Usuario CapaDatos = new CapaDatos.Usuario();
                verificador = CapaDatos.VerificarNombreUsuario(oUsuario);
                CapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                oUsuario.CargarExcepcion(ex);
            }

            return verificador;
        }

        /// <summary>
        /// Verificar si una credencial windows es repetida o no
        /// </summary>
        public static Int32 VerificarCredencialWindows(Entity.Usuario oUsuario)
        {
            Int32 verificador = 0;
            try
            {
                CapaDatos.Usuario CapaDatos = new CapaDatos.Usuario();
                verificador = CapaDatos.VerificarCredencialWindows(oUsuario);
                CapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                oUsuario.CargarExcepcion(ex);
            }

            return verificador;
        }

        /// <summary>
        /// Actualiza la contraseña de un Usuario
        /// </summary>
        public static Entity.Usuario ActualizarPassword(Entity.Usuario entidad)
        {
            try
            {
                CapaDatos.Usuario objCapaDatos = new CapaDatos.Usuario();
                entidad = objCapaDatos.ActualizarPassword(entidad);
                objCapaDatos.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }


    }
}
