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

    public class CDPagos : Intellisoft.Project.Comun.Entidad.Base
    {

        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        //public Entity.CEPagos MovListar(Entity.CEPagos oeEntity)
        public Entity.CEPagos MovListar(Entity.CEPagos oeEntity, String planilla)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("SP_ASISTENTE_DE_PAGOS") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@PAGO", SqlDbType.NVarChar, planilla);

                Entity.CEPagos oEntityTemporal = null;
                List<Entity.CEPagos> lstEntidad = new List<Entity.CEPagos>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEntityTemporal = new Entity.CEPagos();
                        oEntityTemporal.CargarEntidad(dataReader);

                        lstEntidad.Add(oEntityTemporal);
                    }
                }

                oeEntity.LstPago = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        public DataSet MovListarCrystal(String planilla)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("SP_ASISTENTE_DE_PAGOS") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@PAGO", SqlDbType.NVarChar, planilla);

                DataSet ds = db.ExecuteDataSet(cmd);

                return ds;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        //public Entity.CEDocumento VistaPlanillas()
        //{
        //    try
        //    {
        //        EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
        //        SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Documento_VistaAdjuntosListar") as SqlCommand;

        //        //InParameter
        //        db.AddInParameter(cmd, "@IdDocumento", SqlDbType.Int, oeEntity.IdDocumento);

        //        Entity.CEDocumento oEmpresa = null;
        //        List<Entity.CEDocumento> lstEntidad = new List<Entity.CEDocumento>();
        //        using (IDataReader dataReader = db.ExecuteReader(cmd))
        //        {
        //            while (dataReader.Read())
        //            {
        //                oEmpresa = new Entity.CEDocumento();
        //                oEmpresa.CargarEntidad(dataReader);

        //                lstEntidad.Add(oEmpresa);
        //            }
        //        }

        //        oeEntity.LstDocumento = lstEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        oeEntity.CargarExcepcion(ex);
        //    }

        //    return oeEntity;
        //}

        public List<string> VistaPlanillas(String F_Inicio, String F_Fin)
        {
            List<string> listaResultados = new List<string>();

            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("SP_MOSTRAR_PLANILLAS") as SqlCommand;
                db.AddInParameter(cmd, "@F_Inicio", SqlDbType.NVarChar, F_Inicio);
                db.AddInParameter(cmd, "@F_Fin", SqlDbType.NVarChar, F_Fin);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {

                        string nombreArchivo = dataReader["WizardName"].ToString();
                        listaResultados.Add(nombreArchivo);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return listaResultados;
        }

        public String EstadoPlanilla(String Planilla)
        {
            String rsptEstado = "";
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("SP_ESTADO_PLANILLA") as SqlCommand;
                db.AddInParameter(cmd, "@Planilla", SqlDbType.NVarChar, Planilla);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        rsptEstado = dataReader["Estado"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rsptEstado;
        }

        public String TotalesPlanilla(String Planilla)
        {
            String rsptEstado = "";
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("SP_ASISTENTE_DE_PAGOS_TOTALES") as SqlCommand;
                db.AddInParameter(cmd, "@Planilla", SqlDbType.NVarChar, Planilla);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        rsptEstado = dataReader["Totales"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rsptEstado;
        }

        public String SP_ConsultarSemanaPLL(String Planilla)
        {
            String rsptEstado = "";
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;

                SqlCommand cmd = db.GetStoredProcCommand("SP_ConsultarSemanaPLL") as SqlCommand;
                db.AddInParameter(cmd, "@Planilla", SqlDbType.NVarChar, Planilla);

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    if (dataReader.Read())
                    {
                        rsptEstado = dataReader["Semana"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return rsptEstado;
        }

        public Int32 InsertarEstadoPlanilla(String Planilla, String Estado)
        {
            Int32 insercionExitosa = 0;
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("ISOFT") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = new SqlCommand("INSERT INTO PROCESOS_PLANILLAS (WizardName, Estado) VALUES (@Planilla, @Estado)");

                cmd.Parameters.Add(new SqlParameter("@Planilla", SqlDbType.NVarChar) { Value = Planilla });
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.NVarChar) { Value = Estado });

                int filasAfectadas = db.ExecuteNonQuery(cmd);
                if (filasAfectadas > 0)
                {
                    insercionExitosa = 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return insercionExitosa;
        }
    }
}
