using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad;
using System.Data.SqlClient;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace CapaDatos
{
    public class Bandeja : Intellisoft.Project.Comun.Entidad.Base
	{

        /// <summary>
        /// Registrar los Movimientos del Documento y cargo.
        /// </summary>
        public Entity.Bandeja Enviar(Entity.Bandeja oEBandeja, string arrayIdDocumento,string arrayIdMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Bandeja_MoviUpdateInsert") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@ArrayIdDocumento", SqlDbType.VarChar, arrayIdDocumento);
                db.AddInParameter(cmd, "@ArrayIdMovimiento", SqlDbType.VarChar, arrayIdMovimiento);
                db.AddInParameter(cmd, "@Origen", SqlDbType.VarChar, oEBandeja.Origen);
                db.AddInParameter(cmd, "@Destino", SqlDbType.VarChar, oEBandeja.Destino);
                db.AddInParameter(cmd, "@Observac", SqlDbType.VarChar, oEBandeja.Observacion);

                if (oEBandeja.UsuarioCreador > 0)
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEBandeja.UsuarioCreador);
                if (oEBandeja.UsuarioModificador > 0)
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEBandeja.UsuarioModificador);
                db.AddInParameter(cmd, "@Motivo", SqlDbType.VarChar, "");

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);
                db.AddOutParameter(cmd, "@gIdCargo", SqlDbType.Int, 99999);

                db.ExecuteNonQuery(cmd);

                oEBandeja.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEBandeja.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEBandeja.UltimoResultado.EsValido = (oEBandeja.UltimoResultado.ResultadoOperacion > -1);

                oEBandeja.IdCargo = Convert.ToInt32(cmd.Parameters["@gIdCargo"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEBandeja.CargarExcepcion(ex);
            }

            return oEBandeja;
        }


        /// <summary>
        /// Registrar los Movimientos del Documento y cargo.
        /// </summary>
        public Entity.Bandeja Recibir(Entity.Bandeja oEBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Bandeja_MovimientoSend") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@ArrayIdDocumento", SqlDbType.VarChar, arrayIdDocumento);
                db.AddInParameter(cmd, "@ArrayIdMovimiento", SqlDbType.VarChar, arrayIdMovimiento);
                db.AddInParameter(cmd, "@Origen", SqlDbType.VarChar, oEBandeja.Origen);
                db.AddInParameter(cmd, "@Destino", SqlDbType.VarChar, oEBandeja.Destino);
                db.AddInParameter(cmd, "@Observac", SqlDbType.VarChar, oEBandeja.Observacion);

                if (oEBandeja.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEBandeja.UsuarioCreador);
                if (oEBandeja.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEBandeja.UsuarioModificador);

                db.AddInParameter(cmd, "@Motivo", SqlDbType.VarChar, "");

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);               

                db.ExecuteNonQuery(cmd);

                oEBandeja.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEBandeja.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEBandeja.UltimoResultado.EsValido = (oEBandeja.UltimoResultado.ResultadoOperacion > -1);               

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEBandeja.CargarExcepcion(ex);
            }

            return oEBandeja;
        }


        /// <summary>
        /// Registrar los Movimientos del Documento y cargo.
        /// </summary>
        public Entity.Bandeja Rechazar(Entity.Bandeja oEBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Bandeja_MovimientoRejected") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@ArrayIdDocumento", SqlDbType.VarChar, arrayIdDocumento);
                db.AddInParameter(cmd, "@ArrayIdMovimiento", SqlDbType.VarChar, arrayIdMovimiento);
                db.AddInParameter(cmd, "@Origen", SqlDbType.VarChar, oEBandeja.Origen);
                db.AddInParameter(cmd, "@Destino", SqlDbType.VarChar, oEBandeja.Destino);
                db.AddInParameter(cmd, "@Observac", SqlDbType.VarChar, oEBandeja.Observacion);
                

                if (oEBandeja.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEBandeja.UsuarioCreador);
                if (oEBandeja.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEBandeja.UsuarioModificador);
                db.AddInParameter(cmd, "@Motivo", SqlDbType.VarChar, oEBandeja.motivo);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);
                db.AddOutParameter(cmd, "@gIdCargo", SqlDbType.Int, 99999);

                db.ExecuteNonQuery(cmd);

                oEBandeja.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEBandeja.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEBandeja.UltimoResultado.EsValido = (oEBandeja.UltimoResultado.ResultadoOperacion > -1);

                oEBandeja.IdCargo = Convert.ToInt32(cmd.Parameters["@gIdCargo"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEBandeja.CargarExcepcion(ex);
            }

            return oEBandeja;
        }


        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.Bandeja ListarByIdDocumentoMasivo(Entity.Bandeja oeEntity, string arrayIdDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Bandeja_ListByIdDocumentoMasivo") as SqlCommand;

                // InParameter
                if (oeEntity.Destino > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);
                db.AddInParameter(cmd, "@ArrayIdDocumento", SqlDbType.NVarChar, arrayIdDocumento);

                Entity.Bandeja oEmpresa = null;
                List<Entity.Bandeja> lstEntidad = new List<Entity.Bandeja>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Bandeja();
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

        public string EliminarDocs(string arrDocs,int intUsr)
        {
            DataTable dt = new DataTable();
            string rs = "";
            try
            {
                SqlConnection connection = new SqlConnection(CDConexion.conecta2());
                SqlDataAdapter da = new SqlDataAdapter("SWD_RESPALDO '" + arrDocs + "'," + intUsr, connection);
                da.Fill(dt);
                rs = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                rs = ex.Message.ToString();
            }
            return rs;

        }

        public string AdjuntarDocs(int idDocumento, string docAdjunto, int intUsr)
        {
            DataTable dt = new DataTable();
            string rs = "";
            try
            {
                SqlConnection connection = new SqlConnection(CDConexion.conecta2());
                SqlDataAdapter da = new SqlDataAdapter("SP_AGREGAR_DOC_ADJUNTOS " + idDocumento + ", '" + docAdjunto + "', '" + intUsr + "'", connection);
                da.Fill(dt);
                rs = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                rs = ex.Message.ToString();
            }
            return rs;

        }

        public string ActualizarDocs(string arrDocs, string fecha, int intUsr)
        {
            DataTable dt = new DataTable();
            string rs = "";
            try
            {
                SqlConnection connection = new SqlConnection(CDConexion.conecta2());
                SqlDataAdapter da = new SqlDataAdapter("SP_ActualizarFP '" + arrDocs + "','"+fecha + "'," + intUsr, connection);
                da.Fill(dt);
                rs = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                rs = ex.Message.ToString();
            }
            return rs;

        }
        //BuscarUsuFechaPago
        public string BuscarUsuFechaPago(int intUsr)
        {
            DataTable dt = new DataTable();
            string rs = "";
            try
            {
                SqlConnection connection = new SqlConnection(CDConexion.conecta2());
                SqlDataAdapter da = new SqlDataAdapter("SP_BuscarUsuFechaPago '" + intUsr+ "'", connection);
                da.Fill(dt);
                rs = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                rs = ex.Message.ToString();
            }
            return rs;

        }
    }
}
