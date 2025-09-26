namespace CapaDatos
{
    using CapaEntidad;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Entity = CapaEntidad;
    using EntLib = Microsoft.Practices.EnterpriseLibrary;
    using System.Collections.Generic;

    public class CDDistribucion : Intellisoft.Project.Comun.Entidad.Base
    {
        public static bool ActualizarDistribucion(CEDistribucion entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_DISTRIBUCION", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@nkey", entity.nkey);
                //command.Parameters.AddWithValue("@fechaini", entity.fechaini);
                //command.Parameters.AddWithValue("@id", entity.id);
                connection.Open();
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
                return flag;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static bool GuardarDistribucion(CEDistribucion entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_GUARDAR_DISTRIBUCION", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@nkey", entity.nkey);
                //command.Parameters.AddWithValue("@fechaini", entity.fechaini);
                //command.Parameters.AddWithValue("@id", entity.id);
                connection.Open();
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
                return flag;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static DataTable ListarDistribucion(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_LISTAR_DISTRIBUCION", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarDocumentos()
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_LISTAR_DOCUMENTO2", connection) {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEDistribucion Listar(Entity.CEDistribucion oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_LISTAR_DISTRIBUCION") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);

                Entity.CEDistribucion oDistribucion = null;
                List<Entity.CEDistribucion> lstEntidad = new List<Entity.CEDistribucion>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oDistribucion = new Entity.CEDistribucion();
                        oDistribucion.CargarEntidad(dataReader);

                        lstEntidad.Add(oDistribucion);
                    }
                }

                oeEntity.LstDistribucion = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el país seleccionado.
        /// </summary>
        public Entity.CEDistribucion ListarByPais(Entity.CEDistribucion oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Distribucion_ListByEmpresa") as SqlCommand;

                // InParameter
                if (oeEntity.Destino > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.Empresa);

                Entity.CEDistribucion oEmpresa = null;
                List<Entity.CEDistribucion> lstEntidad = new List<Entity.CEDistribucion>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDistribucion();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDistribucion = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Registra El Moviemiento del Documento
        /// </summary>
        public Entity.CEDistribucion Registrar(Entity.CEDistribucion oEDistribucion)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Distribucion_Guardar") as SqlCommand;

                // InParameter
                if (oEDistribucion.IdDocumento > 0)
                    db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEDistribucion.IdDocumento);
                db.AddInParameter(cmd, "@UsuarioAsignado", SqlDbType.Int, oEDistribucion.UsuarioAsignado);
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEDistribucion.UsuarioCreador);
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEDistribucion.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEDistribucion.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEDistribucion.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEDistribucion.UltimoResultado.EsValido = (oEDistribucion.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDistribucion.CargarExcepcion(ex);
            }

            return oEDistribucion;
        }



    }
}

