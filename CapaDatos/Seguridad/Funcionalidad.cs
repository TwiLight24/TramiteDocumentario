using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.Seguridad;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.Seguridad
{
    public class Funcionalidad : Intellisoft.Project.Comun.Dao.Base
    {
        /// <summary>
        /// Listar en un GridView todos los Parámetros
        /// </summary>
        public Entity.Funcionalidad ListarMenus(Entity.Funcionalidad clsFuncionalidad)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("Seguridad") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("usp_app_Funcionalidad_MenuList") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@flg_activo", SqlDbType.Bit, clsFuncionalidad.Activo);


                Entity.Funcionalidad clsFun = null;
                List<Entity.Funcionalidad> listFuncionalidad = new List<Entity.Funcionalidad>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        clsFun = new Entity.Funcionalidad();
                        clsFun.CargarEntidad(dataReader);

                        listFuncionalidad.Add(clsFun);
                    }
                }

                clsFuncionalidad.LstFuncionalidad = listFuncionalidad;
            }
            catch (Exception ex)
            {
                clsFuncionalidad.CargarExcepcion(ex);
            }

            return clsFuncionalidad;
        }
    }
}
