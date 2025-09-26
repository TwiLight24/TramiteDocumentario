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
    public class Articulo : Intellisoft.Project.Comun.Entidad.Base
	{


        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public Entity.Articulo Listar(Entity.Articulo oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Articulos_List") as SqlCommand;

                //InParameter
                //db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.IdArticulo);

                Entity.Articulo oEmpresa = null;
                List<Entity.Articulo> lstEntidad = new List<Entity.Articulo>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Articulo();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstArticulo = lstEntidad;
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
        public Entity.Articulo ListarByPlantilla(Entity.Articulo oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Articulos_ListByPlantilla") as SqlCommand;

                //InParameter
                if (oeEntity.IdUsuario > 0)
                db.AddInParameter(cmd, "@IdUsuario", SqlDbType.Int, oeEntity.IdUsuario);
                db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oeEntity.Activo);

                Entity.Articulo oEmpresa = null;
                List<Entity.Articulo> lstEntidad = new List<Entity.Articulo>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Articulo();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstArticulo = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

	}
}
