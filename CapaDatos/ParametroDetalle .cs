using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entity = CapaEntidad;

using EntLib = Microsoft.Practices.EnterpriseLibrary;

using System.Data;


namespace CapaDatos
{
    public class ParametroDetalle : Intellisoft.Project.Comun.Dao.Base
    {

        #region Metodos Publicos



        /// <summary>
        /// Listar en un GridView todos los Parámetros Detalle
        /// </summary>
        public Entity.ParametroDetalle ListarParamDet(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_List") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@flg_activo", SqlDbType.Bit, clsDetalle.Activo);


                Entity.ParametroDetalle clsParamDet = null;
                List<Entity.ParametroDetalle> listParamDet = new List<Entity.ParametroDetalle>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        clsParamDet = new Entity.ParametroDetalle();
                        clsParamDet.CargarEntidad(dataReader);

                        listParamDet.Add(clsParamDet);
                    }
                }

                clsDetalle.Col_UltimaLista = listParamDet;
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Obtener el detalle de un Parámetro
        /// </summary>
        public Entity.ParametroDetalle Seleccionar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_Sel") as SqlCommand;

                if (!string.IsNullOrEmpty(clsDetalle.IdDetalle))
                    db.AddInParameter(cmd, "@id_detalle", SqlDbType.VarChar, clsDetalle.IdDetalle);
                if (clsDetalle.IdParametro != 0)
                { db.AddInParameter(cmd, "@id_parametro", SqlDbType.SmallInt, clsDetalle.IdParametro); }
                db.AddInParameter(cmd, "@flg_activo", SqlDbType.Bit, clsDetalle.Activo);

                Entity.ParametroDetalle clsParamDet = null;
                List<Entity.ParametroDetalle> lstParamDet = new List<Entity.ParametroDetalle>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        clsParamDet = new Entity.ParametroDetalle();
                        clsParamDet.CargarEntidad(dataReader);

                        lstParamDet.Add(clsParamDet);
                    }
                }

                clsDetalle.Col_UltimaLista = lstParamDet;
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Listar en un GridView todos los Parámetros Detalle tras la búsqueda por Texto ingresado
        /// </summary>
        public Entity.ParametroDetalle Buscar(Entity.ParametroDetalle clsDetalle, string strTexto)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_Search") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@flg_activo", SqlDbType.Bit, clsDetalle.Activo);
                db.AddInParameter(cmd, "@dsc_Texto", SqlDbType.VarChar, strTexto);
                db.AddInParameter(cmd, "@IdParametro", SqlDbType.Int, clsDetalle.IdParametro);

                Entity.ParametroDetalle clsParamDet = null;
                List<Entity.ParametroDetalle> lstParamDet = new List<Entity.ParametroDetalle>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        clsParamDet = new Entity.ParametroDetalle();
                        clsParamDet.CargarEntidad(dataReader);

                        lstParamDet.Add(clsParamDet);
                    }
                }

                clsDetalle.Col_UltimaLista = lstParamDet;
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }


        /// <summary>
        /// Actualiza el estado de un Parametro Detalle (Activo)
        /// </summary>
        public Entity.ParametroDetalle ActualizarEstado(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalleEstado_Update") as SqlCommand;

                // InParameter
                if (!string.IsNullOrEmpty(clsDetalle.IdDetalle))
                    db.AddInParameter(cmd, "@id_detalle", SqlDbType.VarChar, clsDetalle.IdDetalle);
                if (clsDetalle.IdParametro != 0)
                { db.AddInParameter(cmd, "@id_parametro", SqlDbType.SmallInt, clsDetalle.IdParametro); }
                db.AddInParameter(cmd, "@flg_activo", SqlDbType.Bit, clsDetalle.Activo);
                if (clsDetalle.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@usr_mod", SqlDbType.BigInt, clsDetalle.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@num_resultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@dsc_mensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                clsDetalle.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@num_resultado"].Value);
                clsDetalle.UltimoResultado.Mensaje = cmd.Parameters["@dsc_mensaje"].Value.ToString();
                clsDetalle.UltimoResultado.EsValido = (clsDetalle.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Parametro Detalle
        /// </summary>
        public Entity.ParametroDetalle Actualizar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_Update") as SqlCommand;

                // InParameter
                if (!string.IsNullOrEmpty(clsDetalle.IdDetalle))
                    db.AddInParameter(cmd, "@id_detalle", SqlDbType.VarChar, clsDetalle.IdDetalle);
                if (clsDetalle.IdParametro > 0)
                    db.AddInParameter(cmd, "@id_parametro", SqlDbType.SmallInt, clsDetalle.IdParametro);

                db.AddInParameter(cmd, "@dsc_detalle", SqlDbType.VarChar, clsDetalle.Descripcion);
                db.AddInParameter(cmd, "@valor_entero", SqlDbType.Int, clsDetalle.ValorEntero);
                db.AddInParameter(cmd, "@valor_decimal", SqlDbType.Money, clsDetalle.ValorDecimal);
                db.AddInParameter(cmd, "@valor_cadena", SqlDbType.VarChar, clsDetalle.ValorCadena);
                string FechaFormat = (clsDetalle.ValorFecha == DateTime.MinValue) ? string.Empty : clsDetalle.ValorFecha.ToString("yyyyMMdd HH:mm");
                db.AddInParameter(cmd, "@valor_fecha", SqlDbType.VarChar, FechaFormat);

                if (clsDetalle.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@usr_mod", SqlDbType.Int, clsDetalle.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@num_resultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@dsc_mensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                clsDetalle.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@num_resultado"].Value);
                clsDetalle.UltimoResultado.Mensaje = cmd.Parameters["@dsc_mensaje"].Value.ToString();
                clsDetalle.UltimoResultado.EsValido = (clsDetalle.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;

        }

        /// <summary>
        /// Inserta un nuevo Parametro Detalle
        /// </summary>
        public Entity.ParametroDetalle Insertar(Entity.ParametroDetalle clsDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_Insert") as SqlCommand;

                // InParameter
                if (!string.IsNullOrEmpty(clsDetalle.IdDetalle))
                    db.AddInParameter(cmd, "@id_detalle", SqlDbType.VarChar, clsDetalle.IdDetalle);
                if (clsDetalle.IdParametro > 0)
                    db.AddInParameter(cmd, "@id_parametro", SqlDbType.SmallInt, clsDetalle.IdParametro);

                db.AddInParameter(cmd, "@dsc_detalle", SqlDbType.VarChar, clsDetalle.Descripcion);
                db.AddInParameter(cmd, "@valor_entero", SqlDbType.Int, clsDetalle.ValorEntero);
                db.AddInParameter(cmd, "@valor_decimal", SqlDbType.Money, clsDetalle.ValorDecimal);
                db.AddInParameter(cmd, "@valor_cadena", SqlDbType.VarChar, clsDetalle.ValorCadena);
                string FechaFormat = (clsDetalle.ValorFecha == DateTime.MinValue) ? string.Empty : clsDetalle.ValorFecha.ToString("yyyyMMdd HH:mm");
                db.AddInParameter(cmd, "@valor_fecha", SqlDbType.VarChar, FechaFormat);

                if (clsDetalle.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@usr_cre", SqlDbType.BigInt, clsDetalle.UsuarioCreador);

                // OutParameter
                db.AddOutParameter(cmd, "@num_resultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@dsc_mensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                clsDetalle.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@num_resultado"].Value);
                clsDetalle.UltimoResultado.Mensaje = cmd.Parameters["@dsc_mensaje"].Value.ToString();
                clsDetalle.UltimoResultado.EsValido = (clsDetalle.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                clsDetalle.CargarExcepcion(ex);
            }

            return clsDetalle;
        }



        public Entity.ParametroDetalle DatosFileUpload()
        {
            Entity.ParametroDetalle entidad = new Entity.ParametroDetalle();

            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_SelectUpLoadFiles") as SqlCommand;

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                int nOrdinal = 0;
                using (IDataReader oReader = db.ExecuteReader(cmd))
                {
                    while (oReader.Read())
                    {
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlServidor")) > -1) entidad.UrlServidor = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "CarpetaBase")) > -1) entidad.CarpetaBase = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlBase")) > -1) entidad.UrlBase = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "CarpetaArchivos")) > -1) entidad.CarpetaArchivos = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlArchivos")) > -1) entidad.UrlArchivos = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "CarpetaImagenes")) > -1) entidad.CarpetaImagenes = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlImagenes")) > -1) entidad.UrlImagenes = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "CarpetaArchivosLogs")) > -1) entidad.CarpetaArchivosLogs = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "CarpetaArchivosTemporales")) > -1) entidad.CarpetaArchivosTemporales = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlArchivosTemporales")) > -1) entidad.UrlArchivosTemporales = oReader.GetString(nOrdinal);
                        if ((nOrdinal = ObtenerOrdinal(oReader, "UrlServidorArchivos")) > -1) entidad.UrlServidorArchivos = oReader.GetString(nOrdinal);
                    }
                }

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
        /// Obtener el detalle de un Parámetro - Utilizando Listas
        /// </summary>
        /// <param name="sIdDetalle">Id Detalle</param>
        /// <returns>Detalle Parámetro</returns>
        public Entity.ParametroDetalle Obtener(Entity.ParametroDetalle oEDetalle)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_ParametroDetalle_get") as SqlCommand;

                if (!string.IsNullOrEmpty(oEDetalle.IdDetalle))
                    db.AddInParameter(cmd, "@IdDetalle", SqlDbType.VarChar, oEDetalle.IdDetalle);
                if (oEDetalle.IdParametro != 0)
                    db.AddInParameter(cmd, "@IdParametro", SqlDbType.SmallInt, oEDetalle.IdParametro);

                Entity.ParametroDetalle oEntidad = null;
                List<Entity.ParametroDetalle> lstEntidad = new List<Entity.ParametroDetalle>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEntidad = new Entity.ParametroDetalle();
                        oEntidad.CargarEntidad(dataReader);

                        lstEntidad.Add(oEntidad);
                    }
                }

                oEDetalle.LstParametroDetalle = lstEntidad;
            }
            catch (Exception ex)
            {
                oEDetalle.CargarExcepcion(ex);
            }

            return oEDetalle;
        }

        #endregion

    }
}
