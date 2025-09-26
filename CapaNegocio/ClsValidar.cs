using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocio
{
    public	class ClsValidar
	{
        public SqlConnection con = new SqlConnection("Server=192.168.1.2; DataBase=GMI_JCWEB_WTD; user id=sa; password=B1Admin");

        public void Abrir() { if (con.State == ConnectionState.Closed) { con.Open(); }
        }

        public void Cerrar() { if (con.State == ConnectionState.Open) { con.Close(); } }


        public DataTable Validar(String empresa,String ruc,String nrodocumento,String orden) {

            DataTable dt = new DataTable();
       
            try
            {                
                String Sql = "";
                Sql += "Select * ";
                Sql += "from Documento WITH(NOLOCK) ";
                Sql += "where Empresa=RTRIM(@empresa) and ";
                //Sql += "Proveedor=RTRIM(@proveedor) and ";
                Sql += "Ruc=RTRIM(@ruc) and ";
                Sql += "NroDoc=RTRIM(@documento) and ";
                Sql += "NOrden=RTRIM(@orden)";

                Abrir();               
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@documento", nrodocumento);
                cmd.Parameters.AddWithValue("@orden", orden);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception)
            {
                
            }
            Cerrar();
            return dt;

        }

        public DataTable ValidarFR(String empresa, String ruc, String nrodocumento, String orden)
        {

            DataTable dt = new DataTable();

            try
            {
                String Sql = "";
                Sql += "Select * ";
                Sql += "from Documento WITH(NOLOCK) ";
                Sql += "where Empresa=RTRIM(@empresa) and ";
                //Sql += "Proveedor=RTRIM(@proveedor) and ";
                Sql += "Ruc=RTRIM(@ruc) and ";
                Sql += "DocNumReserva=RTRIM(@documento) and ";
                Sql += "NOrden=RTRIM(@orden)";

                Abrir();
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@documento", nrodocumento);
                cmd.Parameters.AddWithValue("@orden", orden);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception)
            {

            }
            Cerrar();
            return dt;

        }

        /*

        /*
                public static DataTable Buscar(string nombre)
                {
                    DataTable dt = new DataTable();


                    string consulta = "SELECT id,apellido,edad FROM PERSONA WHERE nombre=@nombre"; //consulta

                    SqlCommand comando = new SqlCommand(consulta, con);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    SqlDataAdapter adap = new SqlDataAdapter(comando);
                    adap.Fill(dt);

                    return dt;
                }*/

    }
}
