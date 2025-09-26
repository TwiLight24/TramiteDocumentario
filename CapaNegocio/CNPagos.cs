namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidad;
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Entity = CapaEntidad;

    public class CNPagos
    {
        /// <summary>
        /// Listar en una grilla todas las empresas segun el estado seleccionado.
        /// </summary>
        public static Entity.CEPagos MovListar(Entity.CEPagos oePagos, String planilla)
        {
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                oePagos = oDaoEntidad.MovListar(oePagos, planilla);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
                oePagos.CargarExcepcion(ex);
            }

            return oePagos;
        }

        public static DataSet MovListarCrystal(String planilla)
        {
            DataSet dt = new DataSet();
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                dt = oDaoEntidad.MovListarCrystal(planilla);

            }
            catch (Exception ex)
            {
            }

            return dt;
        }
        public static List<string> VistaPlanillas(String F_Inicio, String F_Fin)
        {
            List<string> ListaPlanillas = new List<string>();
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                ListaPlanillas = oDaoEntidad.VistaPlanillas(F_Inicio, F_Fin);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return ListaPlanillas;
        }

        public static string EstadoPlanilla(String Planilla)
        {
            String estado = "";
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                estado = oDaoEntidad.EstadoPlanilla(Planilla);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }

        public static string TotalesPlanilla(String Planilla)
        {
            String estado = "";
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                estado = oDaoEntidad.TotalesPlanilla(Planilla);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }

        public static string SP_ConsultarSemanaPLL(String Planilla)
        {
            String estado = "";
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                estado = oDaoEntidad.SP_ConsultarSemanaPLL(Planilla);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }

        public static int InsertarEstadoPlanilla(String Planilla, String Estado)
        {
            int estado = 0;
            try
            {
                CapaDatos.CDPagos oDaoEntidad = new CapaDatos.CDPagos();
                estado = oDaoEntidad.InsertarEstadoPlanilla(Planilla, Estado);
                oDaoEntidad.Dispose();
            }
            catch (Exception ex)
            {
            }

            return estado;
        }
    }
}
