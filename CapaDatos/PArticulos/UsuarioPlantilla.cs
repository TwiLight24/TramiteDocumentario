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
    public class UsuarioPlantilla : Intellisoft.Project.Comun.Entidad.Base
	{

        /// <summary>
        /// Listar en un GridView todos los Proyectos de acuerdo a su Indicador
        /// </summary>
        public Entity.UsuarioPlantilla Listar(Entity.UsuarioPlantilla oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_UsuarioPlantilla_List") as SqlCommand;

                // InParameter
                //db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, oEntidad.IdEmpresa);


                Entity.UsuarioPlantilla entidad = null;
                List<Entity.UsuarioPlantilla> listProyecto = new List<Entity.UsuarioPlantilla>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.UsuarioPlantilla();
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
        public Entity.UsuarioPlantilla Registrar(Entity.UsuarioPlantilla oEBandeja, string arrayIdPlanilla, string arrayIdUsuario)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_UsuarioPlantilla_AgregarGlobal") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@ArrayIdUsuario", SqlDbType.VarChar, arrayIdUsuario);
                db.AddInParameter(cmd, "@ArrayIdPlantilla", SqlDbType.VarChar, arrayIdPlanilla);

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
