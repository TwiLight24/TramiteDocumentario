using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using System.Data.SqlClient;
using System.Data;
using EntLib = Microsoft.Practices.EnterpriseLibrary;

namespace CapaDatos.PArticulos
{
    public class ConsolidaPedido : Intellisoft.Project.Comun.Dao.Base
	{


        /// <summary>
        /// Listar en un GridView todos los Proyectos de acuerdo a su Indicador
        /// </summary>
        public Entity.ConsolidaPedido ListarConsolidado(Entity.ConsolidaPedido oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Consolidado_List") as SqlCommand;

                // InParameter
                //db.AddInParameter(cmd, "@IdEmpleado", SqlDbType.Int, oEntidad.IdEmpresa);


                Entity.ConsolidaPedido entidad = null;
                List<Entity.ConsolidaPedido> listProyecto = new List<Entity.ConsolidaPedido>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.ConsolidaPedido();
                        entidad.CargarEntidad(dataReader);

                        listProyecto.Add(entidad);
                    }
                }

                oEntidad.ListConsolidaPedido = listProyecto;
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
        public Entity.ConsolidaPedido ListarConsolidadoByEmpresa(Entity.ConsolidaPedido oEntidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Consolidado_ListByEmpresa") as SqlCommand;

                // InParameter
                if (oEntidad.IdPeriodo > 0)
                db.AddInParameter(cmd, "@IdPeriodo", SqlDbType.VarChar, oEntidad.IdPeriodo);
                db.AddInParameter(cmd, "@Empresa", SqlDbType.VarChar, oEntidad.Empresa);


                Entity.ConsolidaPedido entidad = null;
                List<Entity.ConsolidaPedido> listProyecto = new List<Entity.ConsolidaPedido>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        entidad = new Entity.ConsolidaPedido();
                        entidad.CargarEntidad(dataReader);

                        listProyecto.Add(entidad);
                    }
                }

                oEntidad.ListConsolidaPedido = listProyecto;
            }
            catch (Exception ex)
            {
                oEntidad.CargarExcepcion(ex);
            }

            return oEntidad;
        }
	}
}
