using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.Seguridad;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.Seguridad
{
    public class RolFuncionalidad : Intellisoft.Project.Comun.Dao.Base
    {

        #region Metodos Publicos


        /// <summary>
        /// Actualiza un registro en la tabla Rol Funcionalidad
        /// </summary>
        public Entity.RolFuncionalidad Actualizar(Entity.RolFuncionalidad clsRolFuncionalidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_RolFuncionalidad_Update") as SqlCommand;

                // InParameter
                if (clsRolFuncionalidad.IdRol > 0)
                    db.AddInParameter(cmd, "@IdRol", SqlDbType.Int, clsRolFuncionalidad.IdRol);
                if (clsRolFuncionalidad.IdFuncionalidad > 0)
                    db.AddInParameter(cmd, "@IdFuncionalidad", SqlDbType.Int, clsRolFuncionalidad.IdFuncionalidad);
                db.AddInParameter(cmd, "@FlgAsigna", SqlDbType.Int, clsRolFuncionalidad.Permiso);
                if (clsRolFuncionalidad.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@IdUsuarioModifica", SqlDbType.Int, clsRolFuncionalidad.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@num_resultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@dsc_mensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                clsRolFuncionalidad.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@num_resultado"].Value);
                clsRolFuncionalidad.UltimoResultado.Mensaje = cmd.Parameters["@dsc_mensaje"].Value.ToString();
                clsRolFuncionalidad.UltimoResultado.EsValido = (clsRolFuncionalidad.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                clsRolFuncionalidad.CargarExcepcion(ex);
            }

            return clsRolFuncionalidad;

        }


        /// <summary>
        /// Obtiene la relación de Menus y Funcionalidades de un Rol
        /// </summary>
        public Entity.RolFuncionalidad ObtenerFuncionalidadPorRol(Entity.RolFuncionalidad oeEntity)
        {
            Entity.RolFuncionalidad oRolFuncionalidad = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_RolFuncionalidad_GetByRol") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@idRol", SqlDbType.Int, oeEntity.IdRol);

                List<Entity.RolFuncionalidad> lstRolFuncionalidad = new List<Entity.RolFuncionalidad>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oRolFuncionalidad = new Entity.RolFuncionalidad();
                        oRolFuncionalidad.CargarEntidad(dataReader);

                        lstRolFuncionalidad.Add(oRolFuncionalidad);
                    }
                }

                oRolFuncionalidad.LstRolFuncionalidad = lstRolFuncionalidad;
            }
            catch (Exception ex)
            {
                oRolFuncionalidad.CargarExcepcion(ex);
            }

            return oRolFuncionalidad;
        }


        /// <summary>
        /// Listar en un GridView todos los Parámetros Detalle tras la búsqueda por Texto ingresado
        /// </summary>
        public Entity.Permiso ObtenerPermisosPorMenuRol(Entity.Permiso clsPermiso)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_RolFuncionalidad_GetPermisos") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@id_menu", SqlDbType.VarChar, clsPermiso.IdMenu);
                db.AddInParameter(cmd, "@id_rol", SqlDbType.Int, clsPermiso.IdRol);

                Entity.Permiso objPermiso = null;
                List<Entity.Permiso> lstPermiso = new List<Entity.Permiso>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        objPermiso = new Entity.Permiso();
                        objPermiso.CargarEntidad(dataReader);

                        lstPermiso.Add(objPermiso);
                    }
                }
                clsPermiso.LstPermiso = lstPermiso;
                //clsRolFuncionalidad.Col_UltimaLista = lstParamDet;
            }
            catch (Exception ex)
            {
                clsPermiso.CargarExcepcion(ex);
            }

            return clsPermiso;
        }

        #endregion

    }
}
