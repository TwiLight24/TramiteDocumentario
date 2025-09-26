using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.PArticulos
{
    public class Plantilla : Intellisoft.Project.Comun.Dao.Base
	{
        /// <summary>
        /// Listar en un GridView todos los Proyectos de acuerdo a su Indicador
        /// </summary>
        public Entity.Plantilla Listar(Entity.Plantilla oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Plantilla_List") as SqlCommand;

                // InParameter
                //db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, oEntidad.IdEmpresa);


                Entity.Plantilla entidad = null;
                List<Entity.Plantilla> listProyecto = new List<Entity.Plantilla>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.Plantilla();
                        entidad.CargarEntidad(dataReader);

                        listProyecto.Add(entidad);
                    }
                }

                oEntidad.ListPlantilla = listProyecto;
            }
            catch (Exception ex)
            {
                oEntidad.CargarExcepcion(ex);
            }

            return oEntidad;
        }


        /// <summary>
        /// Listar en un GridView todos los Proyectos de acuerdo a su Indicador
        /// </summary>
        public Entity.Plantilla ListarArticulosPorPlanilla(Entity.Plantilla oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Plantilla_GetByID") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@IdPlantilla", SqlDbType.Int, oEntidad.IdPlantilla);


                Entity.Plantilla entidad = null;
                List<Entity.Plantilla> listProyecto = new List<Entity.Plantilla>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.Plantilla();
                        entidad.CargarEntidad(dataReader);

                        listProyecto.Add(entidad);
                    }
                }

                oEntidad.ListPlantilla = listProyecto;
            }
            catch (Exception ex)
            {
                oEntidad.CargarExcepcion(ex);
            }

            return oEntidad;
        }


        /// <summary>
        /// Listar en un GridView todos los Proyectos de acuerdo a su Indicador
        /// </summary>
        public Entity.Plantilla ListarArticulos(Entity.Plantilla oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Articulos_List") as SqlCommand;

                // InParameter
                //db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, oEntidad.IdEmpresa);


                Entity.Plantilla entidad = null;
                List<Entity.Plantilla> listProyecto = new List<Entity.Plantilla>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.Plantilla();
                        entidad.CargarEntidad(dataReader);

                        listProyecto.Add(entidad);
                    }
                }

                oEntidad.ListPlantilla = listProyecto;
            }
            catch (Exception ex)
            {
                oEntidad.CargarExcepcion(ex);
            }

            return oEntidad;
        }


        /// <summary>
        /// Registrar los Movimientos del Documento y cargo.
        /// </summary>
        public Entity.Plantilla Registrar(Entity.Plantilla oEBandeja, string arrayIdPlanilla)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Planilla_AgregarGlobal") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@ArrayIdArticulo", SqlDbType.VarChar, arrayIdPlanilla);
                db.AddInParameter(cmd, "@Descripcion", SqlDbType.VarChar, oEBandeja.Descripcion);

                if (oEBandeja.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEBandeja.UsuarioCreador);
                if (oEBandeja.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEBandeja.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);
                db.AddOutParameter(cmd, "@gIdPlanilla", SqlDbType.Int, 99999);

                db.ExecuteNonQuery(cmd);

                oEBandeja.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEBandeja.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEBandeja.UltimoResultado.EsValido = (oEBandeja.UltimoResultado.ResultadoOperacion > -1);

                oEBandeja.IdPlantilla = Convert.ToInt32(cmd.Parameters["@gIdPlanilla"].Value);

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
        public Entity.Plantilla Actualizar(Entity.Plantilla oEBandeja, string arrayIdPlanilla)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Plantilla_ActualizarGlobal") as SqlCommand;

                // InParameter
                if (oEBandeja.IdPlantilla > 0)
                db.AddInParameter(cmd, "@IdPlantilla", SqlDbType.Int, oEBandeja.IdPlantilla);
                db.AddInParameter(cmd, "@ArrayIdArticulo", SqlDbType.VarChar, arrayIdPlanilla);
                db.AddInParameter(cmd, "@Descripcion", SqlDbType.VarChar, oEBandeja.Descripcion);

                if (oEBandeja.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEBandeja.UsuarioCreador);
                if (oEBandeja.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEBandeja.UsuarioModificador);

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
	}
}
