namespace CapaDatos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CDOcompra
    {
        public static DataTable ListarOCAbiertas_Det_ByID(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_DET_ID", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertas_Det_ByID_IZ(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_DET_ID_IZ", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertas_Det_ByID_ME(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_DET_ID_ME", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertas_Det_ByID_PE(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_DET_ID_PE", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertas_Det_ByID_RI(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_DET_ID_RI", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertasByID(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_ID", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertasByID_IZ(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_ID_IZ", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertasByID_ME(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_ID_ME", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertasByID_PE(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_ID_PE", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarOCAbiertasByID_RI(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_OC_ID_RI", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@FILTRO", SqlDbType.VarChar, 50).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}

