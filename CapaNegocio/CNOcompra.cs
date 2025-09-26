namespace CapaNegocio
{
    using CapaDatos;
    using System;
    using System.Data;

    public class CNOcompra
    {
        private CDOcompra objCDOC = new CDOcompra();

        public DataTable ListarOCAbiertas_DET_ByID(string cod)
        {
            return CDOcompra.ListarOCAbiertas_Det_ByID(cod);
        }

        public DataTable ListarOCAbiertas_DET_ByID_IZ(string cod)
        {
            return CDOcompra.ListarOCAbiertas_Det_ByID_IZ(cod);
        }

        public DataTable ListarOCAbiertas_DET_ByID_ME(string cod)
        {
            return CDOcompra.ListarOCAbiertas_Det_ByID_ME(cod);
        }

        public DataTable ListarOCAbiertas_DET_ByID_PE(string cod)
        {
            return CDOcompra.ListarOCAbiertas_Det_ByID_PE(cod);
        }

        public DataTable ListarOCAbiertas_DET_ByID_RI(string cod)
        {
            return CDOcompra.ListarOCAbiertas_Det_ByID_RI(cod);
        }

        public DataTable ListarOCAbiertasByID(string cod)
        {
            return CDOcompra.ListarOCAbiertasByID(cod);
        }

        public DataTable ListarOCAbiertasByID_IZ(string cod)
        {
            return CDOcompra.ListarOCAbiertasByID_IZ(cod);
        }

        public DataTable ListarOCAbiertasByID_ME(string cod)
        {
            return CDOcompra.ListarOCAbiertasByID_ME(cod);
        }

        public DataTable ListarOCAbiertasByID_PE(string cod)
        {
            return CDOcompra.ListarOCAbiertasByID_PE(cod);
        }

        public DataTable ListarOCAbiertasByID_RI(string cod)
        {
            return CDOcompra.ListarOCAbiertasByID_RI(cod);
        }
    }
}

