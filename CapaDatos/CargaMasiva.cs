using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad;
using System.Data.SqlClient;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data;

namespace CapaDatos
{
    public class CargaMasiva : Intellisoft.Project.Comun.Entidad.Base
	{
        /// <summary>
        /// Listar en una grilla todas las empresas ACTIVAS según el texto ingresado.
        /// </summary>
        public Entity.CargaMasiva ListarCargaMasiva(Entity.CargaMasiva oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Carga_List") as SqlCommand;

                // InParameter
                if (oeEntity.Destino > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.Destino);


                Entity.CargaMasiva oEmpresa = null;
                List<Entity.CargaMasiva> lstEntidad = new List<Entity.CargaMasiva>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CargaMasiva();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstCargaMasiva = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }


        /// <summary>
        /// Registrar los Movimientos del Documento y cargo.
        /// </summary>
        public Entity.CargaMasiva Enviar(Entity.CargaMasiva oEBandeja, string arrayIdDocumento, string arrayIdMovimiento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Bandeja_MovimientoPaid") as SqlCommand;

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
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.CargaMasiva Listar(Entity.CargaMasiva oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_CargaMasiva_List") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@Situacion", SqlDbType.VarChar, oeEntity.Situacion);
                if (oeEntity.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.UsuarioCreador);

                Entity.CargaMasiva oEmpresa = null;
                List<Entity.CargaMasiva> lstEntidad = new List<Entity.CargaMasiva>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.CargaMasiva();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstCargaMasiva = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

	}
}
