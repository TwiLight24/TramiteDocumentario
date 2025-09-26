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

    public class CDDocumento : Intellisoft.Project.Comun.Entidad.Base
    {
        public static int CDActualizarDocumento(CEDocumento entity)
        {
            int num;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_DOCUMENTO", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@nkey", entity.nkey);
                command.Parameters.AddWithValue("@anulado", entity.anulado);
                connection.Open();
                command.ExecuteNonQuery();
                num = -1;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                num = 0;
                ProjectData.ClearProjectError();
                return num;
                //ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEDocumento VistaAdjuntosListar(Entity.CEDocumento oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_VistaAdjuntosListar") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oeEntity.IdDocumento);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento  = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        public static int CDGuardarDocumento(CEDocumento entity)
        {
            int num;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("usp_guardar_documento", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@nkey", entity.nkey);
                command.Parameters.AddWithValue("@empresa", entity.empresa);
                command.Parameters.AddWithValue("@norden", entity.norden);
                command.Parameters.AddWithValue("@cliente", entity.cliente);
                command.Parameters.AddWithValue("@ruc", entity.ruc);
                command.Parameters.AddWithValue("@tipodoc", entity.tipodoc);
                command.Parameters.AddWithValue("@moneda", entity.moneda);
                command.Parameters.AddWithValue("@montoini", entity.montoini);
                command.Parameters.AddWithValue("@montoact", entity.montoact);
                command.Parameters.AddWithValue("@monto", entity.monto);
                command.Parameters.AddWithValue("@nrodoc", entity.nrodoc);
                command.Parameters.AddWithValue("@formpago", entity.formpago);
                command.Parameters.AddWithValue("@fechadoc", entity.fechadoc);
                command.Parameters.AddWithValue("@fechaven", entity.fechaven);
                command.Parameters.AddWithValue("@fecharec", entity.fecharec);
                command.Parameters.AddWithValue("@tipo", entity.tipo);
                command.Parameters.AddWithValue("@observac", entity.observac);
                command.Parameters.AddWithValue("@usuario", entity.usuario);
                command.Parameters.AddWithValue("@fechaact", entity.fechaact);
                command.Parameters.AddWithValue("@anulado", entity.anulado);
                command.Parameters["@nkey"].Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                num = int.Parse(command.Parameters["@nkey"].Value.ToString()) + 1;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                num = 0;
                ProjectData.ClearProjectError();
                return num;
                //ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public static DataTable ListarDocumentos(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_LISTAR_DOCUMENTO", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEDocumento Listar(Entity.CEDocumento oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_Listar") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oeEntity.Activo);
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento = lstEntidad;
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
        public Entity.CEDocumento ListarByTexto(Entity.CEDocumento oeEntity, string texto)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_ListByTexto") as SqlCommand;

                // InParameter
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);
                db.AddInParameter(cmd, "@Texto", SqlDbType.VarChar, texto);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento = lstEntidad;
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
        public Entity.CEDocumento ListarByEmpresa(Entity.CEDocumento oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_ListByEmpresa") as SqlCommand;

                // InParameter
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento = lstEntidad;
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
        public Entity.CEDocumento ListarByTipoBusqueda(Entity.CEDocumento oeEntity, string TipoBusqueda)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_ListByTipoBusqueda") as SqlCommand;

                // InParameter
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@TipoBusqueda", SqlDbType.NVarChar, TipoBusqueda);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        public Entity.CEDocumento ListarByTipoBusquedaFIN(Entity.CEDocumento oeEntity, string TipoBusqueda)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_ListByTipoBusqueda_FIN") as SqlCommand;

                // InParameter
                if (oeEntity.UsuarioCreador > 0)
                    //db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oeEntity.empresa);
                db.AddInParameter(cmd, "@TipoBusqueda", SqlDbType.NVarChar, TipoBusqueda);

                Entity.CEDocumento oEmpresa = null;
                List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CEDocumento();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstDocumento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Registra una nueva Empresa
        /// </summary>
        public Entity.CEDocumento Registrar(Entity.CEDocumento oEDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                //SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_Insert_v1") as SqlCommand;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_Insert_v4") as SqlCommand;

                // InParameter
                if (oEDocumento.IdDocumento > 0)
                    db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEDocumento.IdDocumento);
                db.AddInParameter(cmd, "@empresa", SqlDbType.VarChar, oEDocumento.empresa);
                db.AddInParameter(cmd, "@norden", SqlDbType.VarChar, oEDocumento.norden);
                db.AddInParameter(cmd, "@Proveedor", SqlDbType.VarChar, oEDocumento.Proveedor);
                db.AddInParameter(cmd, "@ruc", SqlDbType.VarChar, oEDocumento.ruc);
                db.AddInParameter(cmd, "@tipodoc", SqlDbType.VarChar, oEDocumento.tipodoc);
                db.AddInParameter(cmd, "@moneda", SqlDbType.VarChar, oEDocumento.moneda);
                db.AddInParameter(cmd, "@montoini", SqlDbType.Decimal, oEDocumento.montoini);
                db.AddInParameter(cmd, "@montoact", SqlDbType.Decimal, oEDocumento.montoact);
                db.AddInParameter(cmd, "@monto", SqlDbType.Decimal, oEDocumento.monto);
                db.AddInParameter(cmd, "@nrodoc", SqlDbType.VarChar, oEDocumento.nrodoc);
                db.AddInParameter(cmd, "@formpago", SqlDbType.VarChar, oEDocumento.formpago);
                db.AddInParameter(cmd, "@fechadoc", SqlDbType.Date, oEDocumento.fechadoc);
                db.AddInParameter(cmd, "@fechaven", SqlDbType.Date, oEDocumento.fechaven);
                db.AddInParameter(cmd, "@fecharec", SqlDbType.Date, oEDocumento.fecharec);
                db.AddInParameter(cmd, "@tipo", SqlDbType.VarChar, oEDocumento.tipo);              
                db.AddInParameter(cmd, "@usuario", SqlDbType.VarChar, oEDocumento.usuario);
                db.AddInParameter(cmd, "@fechaact", SqlDbType.DateTime, oEDocumento.fechaact);
                db.AddInParameter(cmd, "@anulado", SqlDbType.VarChar, oEDocumento.anulado);
                db.AddInParameter(cmd, "@DocNumFactReserva", SqlDbType.Int, oEDocumento.DocNumFactReserva);
                db.AddInParameter(cmd, "@Comentario", SqlDbType.VarChar, oEDocumento.Comentario);
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEDocumento.UsuarioCreador);
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEDocumento.UsuarioModificador);
                db.AddInParameter(cmd, "@NroEr", SqlDbType.VarChar, oEDocumento.ER);
                db.AddInParameter(cmd, "@fepago", SqlDbType.Date, oEDocumento.Fepago);
                db.AddInParameter(cmd, "@adjuntos ", SqlDbType.VarChar, oEDocumento.DocAdjuntos);
                db.AddInParameter(cmd, "@cantComPago", SqlDbType.Decimal, oEDocumento.CanComPago);
                db.AddInParameter(cmd, "@prioridad ", SqlDbType.VarChar, oEDocumento.Prioridad);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEDocumento.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEDocumento.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEDocumento.UltimoResultado.EsValido = (oEDocumento.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;
        }

        /// <summary>
        /// Actualiza una Empresa seleccionada
        /// </summary>
        public Entity.CEDocumento Actualizar(Entity.CEDocumento oEDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documentos_Update") as SqlCommand;

                // InParameter
                if (oEDocumento.IdDocumento > 0)
                    db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEDocumento.IdDocumento);
                db.AddInParameter(cmd, "@empresa", SqlDbType.VarChar, oEDocumento.empresa);
                db.AddInParameter(cmd, "@norden", SqlDbType.VarChar, oEDocumento.norden);
                db.AddInParameter(cmd, "@Proveedor", SqlDbType.VarChar, oEDocumento.Proveedor);
                db.AddInParameter(cmd, "@ruc", SqlDbType.VarChar, oEDocumento.ruc);
                db.AddInParameter(cmd, "@tipodoc", SqlDbType.VarChar, oEDocumento.tipodoc);
                db.AddInParameter(cmd, "@moneda", SqlDbType.VarChar, oEDocumento.moneda);
                db.AddInParameter(cmd, "@montoini", SqlDbType.Decimal, oEDocumento.montoini);
                db.AddInParameter(cmd, "@montoact", SqlDbType.Decimal, oEDocumento.montoact);
                db.AddInParameter(cmd, "@monto", SqlDbType.Decimal, oEDocumento.monto);
                db.AddInParameter(cmd, "@nrodoc", SqlDbType.VarChar, oEDocumento.nrodoc);
                db.AddInParameter(cmd, "@formpago", SqlDbType.VarChar, oEDocumento.formpago);
                db.AddInParameter(cmd, "@fechadoc", SqlDbType.Date, oEDocumento.fechadoc);
                db.AddInParameter(cmd, "@fechaven", SqlDbType.Date, oEDocumento.fechaven);
                db.AddInParameter(cmd, "@fecharec", SqlDbType.Date, oEDocumento.fecharec);
                db.AddInParameter(cmd, "@tipo", SqlDbType.VarChar, oEDocumento.tipo);               
                db.AddInParameter(cmd, "@usuario", SqlDbType.VarChar, oEDocumento.usuario);
                db.AddInParameter(cmd, "@fechaact", SqlDbType.DateTime, oEDocumento.fechaact);
                db.AddInParameter(cmd, "@anulado", SqlDbType.VarChar, oEDocumento.anulado);
                db.AddInParameter(cmd, "@Comentario", SqlDbType.VarChar, oEDocumento.Comentario);
                db.AddInParameter(cmd, "@DocNumReserva",SqlDbType.VarChar, oEDocumento.DocNumFactReserva);
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEDocumento.UsuarioModificador);
                db.AddInParameter(cmd, "@NroER", SqlDbType.VarChar, oEDocumento.ER);
                db.AddInParameter(cmd, "@fepago", SqlDbType.Date, oEDocumento.Fepago);
                db.AddInParameter(cmd, "@adjuntos ", SqlDbType.VarChar, oEDocumento.DocAdjuntos);
                db.AddInParameter(cmd, "@cantComPago", SqlDbType.Decimal, oEDocumento.CanComPago);
                db.AddInParameter(cmd, "@prioridad ", SqlDbType.VarChar, oEDocumento.Prioridad);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEDocumento.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEDocumento.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEDocumento.UltimoResultado.EsValido = (oEDocumento.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;
        }

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CEDocumento CargarDatosxOrden(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_BUSCAR_DOC") as SqlCommand;

                 //InParameter
                db.AddInParameter(cmd, "@DocNum", SqlDbType.VarChar, oDocumento.norden);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oDocumento.empresa);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);
                    }
                }

                cmd.Dispose();
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
        public Entity.CEDocumento CargarDatosxRuc(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_ProveedorSap_SearchByRuc") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@Ruc", SqlDbType.VarChar, oDocumento.ruc);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oDocumento.empresa);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);
                    }
                }

                cmd.Dispose();
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
        public Entity.CEDocumento CargarDatosxRucSteel(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("STEEL") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("GMI_JCWEB_WTD_Documento_SearchByRuc") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@Ruc", SqlDbType.VarChar, oDocumento.ruc);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oDocumento.empresa);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);
                    }
                }

                cmd.Dispose();
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
        public Entity.CEDocumento CargarDatosxOrdenSteel(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("STEEL") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("GMI_JCWEB_WTD_Documento_Search_DocNum") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@DocNum", SqlDbType.VarChar, oDocumento.norden);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oDocumento.empresa);
                

                //Entity.CEDocumento oDocumento = null;
                //List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);

                        //lstEntidad.Add(oDocumento);
                    }
                }

                cmd.Dispose();
                //oeEntity.LstDocumento = lstEntidad;
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
        public Entity.CEDocumento Obtener(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_Obetener_DOC") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.VarChar, oDocumento.IdDocumento);

                //Entity.CEDocumento oDocumento = null;
                //List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);

                        //lstEntidad.Add(oDocumento);
                    }
                }

                cmd.Dispose();
                //oeEntity.LstDocumento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }
        
        /// <summary>
        /// Devuelve todos los datos de una Empresa
        /// </summary>
        public Entity.CEDocumento ObtenerDocumento(Entity.CEDocumento oEDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_GetByID") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "IdDocumento", SqlDbType.Int, oEDocumento.IdDocumento);
                db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oEDocumento.Activo);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEDocumento.CargarEntidad(dataReader);
                    }
                }

                oEDocumento.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEDocumento.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEDocumento.UltimoResultado.EsValido = (oEDocumento.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;

        }

        /// <summary>
        /// Obtener Correlativo.
        /// </summary>
        public Entity.CEDocumento GenerarCorrelativo(Entity.CEDocumento oDocumento)
        {
            Entity.CEDocumento oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Obetener_Correlativo") as SqlCommand;

                //InParameter
                //db.AddInParameter(cmd, "@IdDocumento", SqlDbType.VarChar, oDocumento.IdDocumento);

                //Entity.CEDocumento oDocumento = null;
                //List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CEDocumento();
                        oeDocumento.CargarEntidad(dataReader);

                        //lstEntidad.Add(oDocumento);
                    }
                }

                cmd.Dispose();
                //oeEntity.LstDocumento = lstEntidad;
            }
            catch (Exception ex)
            {
                oeDocumento.CargarExcepcion(ex);
            }

            return oeDocumento;
        }

        /// <summary>
        /// Actualiza el estado de un Documento (Activo)
        /// </summary>
        public Entity.CEDocumento ActualizarEstado(Entity.CEDocumento oEDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_Status") as SqlCommand;

                // InParameter
                if (oEDocumento.IdDocumento > 0)
                    db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEDocumento.IdDocumento);
                db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oEDocumento.Activo);
                if (oEDocumento.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEDocumento.UsuarioModificador);

                db.ExecuteNonQuery(cmd);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;
        }

        /// <summary>
        /// Elimina fisicamente una empresa
        /// </summary>
        public Entity.CEDocumento EliminadoFisico(Entity.CEDocumento oEEmpresa)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Empresa_Delete") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEEmpresa.IdDocumento);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEEmpresa.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEEmpresa.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEEmpresa.UltimoResultado.EsValido = (oEEmpresa.UltimoResultado.ResultadoOperacion == 1);

                //db.ExecuteNonQuery(cmd);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEEmpresa.CargarExcepcion(ex);
            }

            return oEEmpresa;

        }

        public String UsuarioRegistroMontalvo(String Planilla)
        {
            String rsptEstado = "";
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("UsuarioRegistroMontalvo") as SqlCommand;
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.NVarChar, Planilla);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        rsptEstado = dataReader["UsuarioRegistro"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rsptEstado;
        }

        public String UsuarioRegistroMontalvoxIdDocumento(int IdDocumento)
        {
            String rsptEstado = "";
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("UsuarioRegistroMontalvoxIdDocumento") as SqlCommand;
                db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, IdDocumento);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        rsptEstado = dataReader["UsuarioRegistro"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rsptEstado;
        }

    }
}

