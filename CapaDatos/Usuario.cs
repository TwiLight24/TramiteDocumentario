using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entity = CapaEntidad;

using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    /// <summary>
    /// Objeto que representa los metodos de manejo de datos relacionados a la Entidad Usuario
    /// </summary>
    public class Usuario : Intellisoft.Project.Comun.Dao.Base
    {
        #region Metodos Públicos

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.Usuario Listar(Entity.Usuario oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_LISTAR_USUARIO") as SqlCommand;

                // InParameter
                //db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oeEntity.Activo);

                Entity.Usuario oEmpresa = null;
                List<Entity.Usuario> lstEntidad = new List<Entity.Usuario>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Usuario();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstUsuario = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Agrega un registro en la tabla de Usuario
        /// </summary>
        public Entity.Usuario Agregar(Entity.Usuario entidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_Insert") as SqlCommand;

                // InParameter
                if (entidad.IdRol != 0)
                    db.AddInParameter(cmd, "@IdRol", SqlDbType.Int, entidad.IdRol);
                if (entidad.IdEmpleado != 0)
                    db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, entidad.IdEmpleado);
                if (!string.IsNullOrEmpty(entidad.NombreUsuario))
                    db.AddInParameter(cmd, "@NombreUsuario", SqlDbType.VarChar, entidad.NombreUsuario);
                if (!string.IsNullOrEmpty(entidad.Contrasena))
                    db.AddInParameter(cmd, "@Contraseña", SqlDbType.VarChar, entidad.Contrasena);
                db.AddInParameter(cmd, "@CredencialWindows", SqlDbType.VarChar, entidad.CredencialWindows);
                if (!string.IsNullOrEmpty(entidad.TipoAutenticacion))
                    db.AddInParameter(cmd, "@TipoAutenticacion", SqlDbType.Char, entidad.TipoAutenticacion);
                db.AddInParameter(cmd, "@vFechaCaducidad", SqlDbType.VarChar, (entidad.FechaCaducidad.Length != 0) ? Convert.ToDateTime(entidad.FechaCaducidad).ToString("yyyyMMdd HH:mm:ss") : entidad.FechaCaducidad);
                if (entidad.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, entidad.UsuarioCreador);
                if (entidad.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, entidad.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                entidad.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                entidad.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                entidad.UltimoResultado.EsValido = (entidad.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                entidad.CargarExcepcion(ex);
            }

            return entidad;
        }

        /// <summary>
        /// Valida Nombre de Usuario y Obtiene Password
        /// </summary>
        /// <param name="entidad">Entidad Usuario: NombreUsuario, Contrasena</param>
        /// <returns>Entidad Usuario Autenticado</returns>
        public CapaEntidad.Usuario ValidaUsuarioSistema(CapaEntidad.Usuario entidad)
        {
            try
            {

                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_ValidarSistema") as SqlCommand;
                DataSet ds = new DataSet();

                db.AddInParameter(cmd, "@nombre_Usuario", SqlDbType.VarChar, entidad.NombreUsuario);
                db.AddInParameter(cmd, "@IdAplicativo", SqlDbType.Int, entidad.IdAplicativo);
                db.AddOutParameter(cmd, "@exito", SqlDbType.Bit, 1);

                ds = db.ExecuteDataSet(cmd);

                entidad.Autenticado = Convert.ToBoolean(cmd.Parameters[1].Value);

                if (entidad.Autenticado)
                {
                    entidad.IdUsuario = Convert.ToInt32(ds.Tables[0].Rows[0]["IdUsuario"].ToString());
                    entidad.Contrasena = ds.Tables[0].Rows[0]["Contrasena"].ToString();
                    entidad.PermisoPorAplicativo = Convert.ToBoolean(ds.Tables[0].Rows[0]["PermisoPorAplicativo"].ToString());
                }
                cmd.Dispose();
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
        public CapaEntidad.Usuario ValidaUsuarioWindows(CapaEntidad.Usuario entidad)
        {
            try
            {

                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_ValidarWindows") as SqlCommand;
                DataSet ds = new DataSet();

                db.AddInParameter(cmd, "@usuario_windows", SqlDbType.VarChar, entidad.CredencialWindows);
                db.AddOutParameter(cmd, "@exito", SqlDbType.Bit, 1);

                ds = db.ExecuteDataSet(cmd);

                entidad.Autenticado = Convert.ToBoolean(cmd.Parameters[1].Value);

                if (entidad.Autenticado)
                {
                    entidad.IdUsuario = Convert.ToInt32(ds.Tables[0].Rows[0]["IdUsuario"].ToString());
                }
                cmd.Dispose();
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
        /// <returns>Entidad Usuario Seleccinado</returns>
        public CapaEntidad.Usuario Seleccionar(CapaEntidad.Usuario entidad)
        {
            try
            {

                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_Select") as SqlCommand;
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, entidad.IdUsuario);
                db.AddInParameter(cmd, "@IdAplicativo", SqlDbType.Int, entidad.IdAplicativo);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                        entidad.CargarEntidad(dataReader);
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entidad;
        }

        /// <summary>
        /// Selecciona Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario: IdUsuario</param>
        /// /// <param name="entidad">Entidad Usuario: IdPeriodo</param>
        /// <returns>Entidad Usuario Seleccinado</returns>
        public CapaEntidad.Usuario Seleccionar2(CapaEntidad.Usuario entidad)
        {
            try
            {

                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_Select2") as SqlCommand;
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, entidad.IdUsuario);
                db.AddInParameter(cmd, "@IdPeriodo", SqlDbType.Int, entidad.IdPeriodo);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                        entidad.CargarEntidad(dataReader);
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entidad;
        }

        /// <summary>
        /// Obtiene los datos de un Usuario
        /// </summary>
        /// <param name="iCliente">Id del Empleado</param>
        /// <returns>Datos del Empleado</returns>
        public Entity.Usuario Obtener(Entity.Usuario oUsuario)
        {
            CapaEntidad.Usuario oeUsuario = null;

            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_Get") as SqlCommand;

                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oUsuario.IdUsuario);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeUsuario = new CapaEntidad.Usuario();
                        oeUsuario.CargarEntidad(dataReader);
                    }
                }

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oeUsuario.CargarExcepcion(ex);
            }

            return oeUsuario;
        }

        /// <summary>
        /// Actualiza un registro en la tabla de Usuario
        /// </summary>
        public Entity.Usuario Actualizar(Entity.Usuario entidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_Update") as SqlCommand;

                // InParameter
                if (entidad.IdRol != 0)
                    db.AddInParameter(cmd, "@IdRol", SqlDbType.Int, entidad.IdRol);
                if (entidad.IdEmpleado != 0)
                    db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, entidad.IdEmpleado);
                if (!string.IsNullOrEmpty(entidad.NombreUsuario))
                    db.AddInParameter(cmd, "@NombreUsuario", SqlDbType.VarChar, entidad.NombreUsuario);
                if (!string.IsNullOrEmpty(entidad.Contrasena))
                    db.AddInParameter(cmd, "@Contraseña", SqlDbType.VarChar, entidad.Contrasena);
                db.AddInParameter(cmd, "@CredencialWindows", SqlDbType.VarChar, entidad.CredencialWindows);
                if (!string.IsNullOrEmpty(entidad.TipoAutenticacion))
                    db.AddInParameter(cmd, "@TipoAutenticacion", SqlDbType.Char, entidad.TipoAutenticacion);
                db.AddInParameter(cmd, "@vFechaCaducidad", SqlDbType.VarChar, (entidad.FechaCaducidad.Length != 0) ? Convert.ToDateTime(entidad.FechaCaducidad).ToString("yyyyMMdd HH:mm:ss") : entidad.FechaCaducidad);
                if (entidad.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, entidad.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                entidad.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                entidad.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                entidad.UltimoResultado.EsValido = (entidad.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
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
        public Entity.Usuario ActualizarCaducidad(Entity.Usuario entidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_UsuarioCaducidad_Update") as SqlCommand;

                // InParameter
                if (entidad.IdUsuario != 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, entidad.IdUsuario);
                if (entidad.IdEmpleado != 0)
                { db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, entidad.IdEmpleado); }
                db.AddInParameter(cmd, "@Caducado", SqlDbType.Bit, entidad.EstaCaducado);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                entidad.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                entidad.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                entidad.UltimoResultado.EsValido = (entidad.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
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
        public Int32 VerificarNombreUsuario(Entity.Usuario oUsuario)
        {
            Int32 verificador = 0;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_ValidarNombreUsuario") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@NombreUsuario", SqlDbType.VarChar, oUsuario.NombreUsuario);
                //OutParameter
                db.AddOutParameter(cmd, "@Verificador", SqlDbType.Int, 4);


                db.ExecuteReader(cmd);
                verificador = Convert.ToInt32(cmd.Parameters["@Verificador"].Value);
                cmd.Dispose();
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
        public Int32 VerificarCredencialWindows(Entity.Usuario oUsuario)
        {
            Int32 verificador = 0;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_ValidarCredencialWindows") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@CredencialWindows", SqlDbType.VarChar, oUsuario.CredencialWindows);
                //OutParameter
                db.AddOutParameter(cmd, "@Verificador", SqlDbType.Int, 4);


                db.ExecuteReader(cmd);
                verificador = Convert.ToInt32(cmd.Parameters["@Verificador"].Value);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oUsuario.CargarExcepcion(ex);
            }

            return verificador;
        }


        public Entity.Usuario ActualizarPassword(Entity.Usuario oUsuario)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Usuario_UpdatePassword") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@PassActual", SqlDbType.VarChar, oUsuario.Contrasena);
                db.AddInParameter(cmd, "@PassNueva", SqlDbType.VarChar, oUsuario.NuevaContrasena);
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oUsuario.IdUsuario);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oUsuario.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oUsuario.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oUsuario.UltimoResultado.EsValido = (oUsuario.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oUsuario.CargarExcepcion(ex); ;
            }

            return oUsuario;
        }


        #endregion
    }
}
