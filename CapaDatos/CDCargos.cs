namespace CapaDatos
{
    using CapaEntidad;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Data.SqlClient;


    using Entity = CapaEntidad;
    using EntLib = Microsoft.Practices.EnterpriseLibrary;

    public class CDCargos : Intellisoft.Project.Comun.Entidad.Base
    {
        public static int CDGuardarCargoCab(CECargos entity)
        {
            int num;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("usp_guardar_cargo_cab", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@ncar", entity.ncar);
                //command.Parameters.AddWithValue("@tipo", entity.tipo);
                //command.Parameters.AddWithValue("@destino", entity.destino);
                //command.Parameters.AddWithValue("@observac", entity.observac);
                //command.Parameters.AddWithValue("@usuario", entity.usuario);
                //command.Parameters.AddWithValue("@fecha", entity.fecha);
                command.Parameters["@ncar"].Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                num = int.Parse(command.Parameters["@ncar"].Value.ToString()) + 1;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                num = 0;
                ProjectData.ClearProjectError();
                return num;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public static string CDGuardarCargoDet(CECargos entity)
        {
            string str;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("usp_guardar_cargo_det", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                //command.Parameters.AddWithValue("@ncar", entity.ncar);
                //command.Parameters.AddWithValue("@nkey", entity.nkey);
                //command.Parameters.AddWithValue("@usuario", entity.usuario);
                //command.Parameters.AddWithValue("@fecha", entity.fecha);
                connection.Open();
                command.ExecuteNonQuery();
                str = Conversions.ToString(true);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                str = exception.Message.ToString();
                ProjectData.ClearProjectError();
                return str;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return str;
        }

        public static DataTable ListarCargoById(int cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_JC_REPORTE_CARGO", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@IdCargo", SqlDbType.Int).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Obtener Correlativo.
        /// </summary>
        public Entity.CECargos GenerarCorrelativo(Entity.CECargos oDocumento)
        {
            Entity.CECargos oeDocumento = null;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Obetener_Correlativo_Cargo") as SqlCommand;

                //InParameter
                //db.AddInParameter(cmd, "@IdDocumento", SqlDbType.VarChar, oDocumento.IdDocumento);

                //Entity.CEDocumento oDocumento = null;
                //List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oeDocumento = new Entity.CECargos();
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
        /// Registra El Moviemiento del Documento
        /// </summary>
        public Entity.CECargos Registrar(Entity.CECargos oEMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_CARGO_INSERT") as SqlCommand;

                // InParameter
                if (oEMovimiento.idCargo > 0)
                    db.AddInParameter(cmd, "@IdCargo", SqlDbType.Int, oEMovimiento.idCargo);
                db.AddInParameter(cmd, "@Tipo", SqlDbType.VarChar, oEMovimiento.tipo);
                db.AddInParameter(cmd, "@Destino", SqlDbType.Int, oEMovimiento.destino);
                db.AddInParameter(cmd, "@Observac", SqlDbType.VarChar, oEMovimiento.observacion);
                //db.AddInParameter(cmd, "@Situacion", SqlDbType.VarChar, oEMovimiento.Situacion);

                //if (oEEmpresa.UsuarioCreador > 0)
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEMovimiento.UsuarioCreador);
                //if (oEEmpresa.UsuarioModificador > 0)
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
        /// Registra El Moviemiento del Documento
        /// </summary>
        public Entity.CECargos RegistrarCargoDetalle(Entity.CECargos oEMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_CARGO_DETALLE_INSERT") as SqlCommand;

                // InParameter
                if (oEMovimiento.idDocumento > 0)
                    db.AddInParameter(cmd, "@IdCargo", SqlDbType.Int, oEMovimiento.idCargo);
                if (oEMovimiento.idDocumento > 0)
                    db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oEMovimiento.idDocumento);
                //db.AddInParameter(cmd, "@Situacion", SqlDbType.VarChar, oEMovimiento.Situacion);

                //if (oEEmpresa.UsuarioCreador > 0)
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEMovimiento.UsuarioCreador);
                //if (oEEmpresa.UsuarioModificador > 0)
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
        /// Listar el detalle de los cierre de turnos.
        /// </summary>
        public Entity.CECargos ListarCargoByIdReporte(Entity.CECargos objTurno)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_REPORTE_CARGO") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@IdCargo", SqlDbType.Int, objTurno.idCargo);
                //db.AddInParameter(cmd, "@IdTurno", SqlDbType.Int, objTurno.IdTurno);
                //db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, objTurno.Activo);

                DataSet ds = db.ExecuteDataSet(cmd);
                objTurno.UltimoResultado.UltimoDataSet = ds.Copy();
                cmd.Dispose();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                objTurno.CargarExcepcion(ex);
            }

            return objTurno;
        }
    }
}

