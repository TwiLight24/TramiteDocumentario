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

    public class CDMovimientos : Intellisoft.Project.Comun.Entidad.Base
    {
        public static bool ActualizarMovimiento(CEMovimientos entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_MOVIMIENTO", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@nkey", entity.nkey);
                //command.Parameters.AddWithValue("@fechafin", entity.fechafin);
                //command.Parameters.AddWithValue("@nlinea", entity.nlinea);
                //command.Parameters.AddWithValue("@situacion", entity.situacion);
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
                //ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static bool CDGuardarMovimiento(CEMovimientos entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_GUARDAR_MOVIMIENTO", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@nkey", entity.nkey);
                //command.Parameters.AddWithValue("@fechaini", entity.fechaini);
                //command.Parameters.AddWithValue("@fechafin", entity.fechafin);
                //command.Parameters.AddWithValue("@estado", entity.estado);
                //command.Parameters.AddWithValue("@origen", entity.origen);
                //command.Parameters.AddWithValue("@destino", entity.destino);
                //command.Parameters.AddWithValue("@observac", entity.observac);
                //command.Parameters.AddWithValue("@situacion", entity.situacion);
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
                //ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static DataTable ReporteMovimientos(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_JC_REPORTE_MOVIMIENTOS", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.NVarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ReportePromedios(DateTime fecha1, DateTime fecha2)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("SELECT distinct Prim_nom +' '+ Ape_pat as Nombre,(select count(distinct nrodoc) from v_promedios p where p.id=u.id) nrodoc,(select SUM(dias) from v_promedios p where p.id=u.id) dias,(select SUM(dias) from v_promedios p where p.id=u.id)/(select count(distinct nrodoc) from v_promedios p where p.id=u.id) promedio FROM usuarios u left join v_promedios v on v.id=u.id where v.fechaini between @fecha1 and @fecha2", connection);
            selectCommand.Parameters.Add("@fecha1", SqlDbType.Date).Value = fecha1;
            selectCommand.Parameters.Add("@fecha2", SqlDbType.Date).Value = fecha2;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ReporteVencimientos(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_JC_Reporte_Vencimientos", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.NVarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Registra El Moviemiento del Documento
        /// </summary>
        public Entity.CEMovimientos Registrar(Entity.CEMovimientos oEMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                //SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_MovInsert") as SqlCommand;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_MovInsert_v4") as SqlCommand;

                // InParameter
                if (oEMovimiento.IdDocumento > 0)
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEMovimiento.IdDocumento);
                db.AddInParameter(cmd, "@Estado", SqlDbType.VarChar, oEMovimiento.Estado);
                db.AddInParameter(cmd, "@Origen", SqlDbType.VarChar, oEMovimiento.Origen);
                db.AddInParameter(cmd, "@Destino", SqlDbType.VarChar, oEMovimiento.Destino);
                db.AddInParameter(cmd, "@Observac", SqlDbType.VarChar, oEMovimiento.Observac);

                if (oEMovimiento.UsuarioCreador > 0)
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEMovimiento.UsuarioCreador);
                if (oEMovimiento.UsuarioModificador > 0)
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEMovimiento.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEMovimiento.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEMovimiento.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEMovimiento.UltimoResultado.EsValido = (oEMovimiento.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEMovimiento.CargarExcepcion(ex);
            }

            return oEMovimiento;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEMovimientos Listar(Entity.CEMovimientos oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_LISTAR_BANDEJA") as SqlCommand;

                 //InParameter
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEMovimientos MovListar(Entity.CEMovimientos oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_MovListar") as SqlCommand;

                //InParameter
                //db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oeEntity.IdDocumento);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
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
        public Entity.CEMovimientos MovListarByPais(Entity.CEMovimientos oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_MovListByEmpresa") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CEMovimientos MovListarByTexto(Entity.CEMovimientos oeEntity, string texto)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_MovListByTexto") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@Texto", SqlDbType.VarChar, texto);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEMovimientos VistaMovListar(Entity.CEMovimientos oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_VistaMovListar") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oeEntity.IdDocumento);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
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
        public Entity.CEMovimientos ListarByPais(Entity.CEMovimientos oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_ListByEmpresa") as SqlCommand;

                // InParameter
                if (oeEntity.Destino > 0)
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CEMovimientos ListarByTexto(Entity.CEMovimientos oeEntity, string texto)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_ListByTexto") as SqlCommand;

                // InParameter
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@Texto", SqlDbType.VarChar, texto);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CEMovimientos ListarByTipoBusqueda(Entity.CEMovimientos oeEntity, string TipoBusqueda)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_ListByTipoBusqueda") as SqlCommand;

                // InParameter
                if (oeEntity.Destino > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@TipoBusqueda", SqlDbType.NVarChar, TipoBusqueda);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CEMovimientos MovListarByTipoBusqueda(Entity.CEMovimientos oeEntity, string TipoBusqueda)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Movimientos_MovListByTipoBusqueda") as SqlCommand;

                // InParameter
                //if (oeEntity.Destino > 0)
                //    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@TipoBusqueda", SqlDbType.NVarChar, TipoBusqueda);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Actualiza una ElEstado Del Movimiento
        /// </summary>
        public Entity.CEMovimientos Actualizar(Entity.CEMovimientos oEEmpresa)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_JC_Movimientos_Update") as SqlCommand;

                // InParameter
                if (oEEmpresa.IdDocumento > 0)
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEEmpresa.IdDocumento);
                if (oEEmpresa.IdMovimiento > 0)
                    db.AddInParameter(cmd, "@IdMovimiento", SqlDbType.Int, oEEmpresa.IdMovimiento);
 


                //if (!string.IsNullOrEmpty(oEEmpresa.Nombre))
                //db.AddInParameter(cmd, "@Nombre", SqlDbType.VarChar, oEEmpresa.Nombre);
                //if (oEEmpresa.IdPais > 0)
                //db.AddInParameter(cmd, "@IdPais", SqlDbType.Int, oEEmpresa.IdPais);
                //if (oEEmpresa.UsuarioModificador > 0)
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEEmpresa.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEEmpresa.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEEmpresa.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEEmpresa.UltimoResultado.EsValido = (oEEmpresa.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEEmpresa.CargarExcepcion(ex);
            }

            return oEEmpresa;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CEMovimientos AsistenteDePagos(Entity.CEMovimientos oeEntity, string TipoBusqueda)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("SP_ASISTENTE_DE_PAGOS") as SqlCommand;

                db.AddInParameter(cmd, "@PAGO", SqlDbType.NVarChar, TipoBusqueda);

                Entity.CEMovimientos oEmpresa = null;
                List<Entity.CEMovimientos> lstEntidad = new List<Entity.CEMovimientos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEMovimientos();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstMovimiento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }
    }
}

