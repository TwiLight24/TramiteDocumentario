namespace CapaDatos
{
    using CapaEntidad;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CDUsuarios
    {
        private SqlConnection cn = new SqlConnection(CDConexion.conecta2());

        public static bool ActualizarUsuario(CEUsuarios entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_USUARIO", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", entity.id);
                command.Parameters.AddWithValue("@Ape_pat", entity.Ape_pat);
                command.Parameters.AddWithValue("@Ape_mat", entity.Ape_mat);
                command.Parameters.AddWithValue("@Prim_nom", entity.prim_nom);
                command.Parameters.AddWithValue("@Seg_nom", entity.seg_nom);
                command.Parameters.AddWithValue("@Empresa", entity.Empresa);
                command.Parameters.AddWithValue("@Correo", entity.Correo);
                command.Parameters.AddWithValue("@Dni", entity.Dni);
                command.Parameters.AddWithValue("@Observac", entity.Observac);
                connection.Open();
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
                return flag;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public CEUsuarios CDobtenerUsuarioxCodigo(string Codigo)
        {
            CEUsuarios usuarios2 = new CEUsuarios();
            SqlCommand command = new SqlCommand(Convert.ToString("Select * from usuarios where Ape_pat='") + Codigo + "' ", this.cn);
            this.cn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                usuarios2.Ape_pat = (string) reader["Ape_pat"];
                usuarios2.prim_nom = (string) reader["prim_nom"];
                usuarios2.Dni = (string) reader["Dni"];
                usuarios2.id = (int) reader["id"];
            }
            return usuarios2;
        }

        public string CDvalidaUsuario(CEUsuarios ceusu)
        {
            string str2 = "";
            SqlCommand command = new SqlCommand("select Ape_pat,Dni,* from usuarios where Ape_pat='" + ceusu.Ape_pat + "' and Dni='" + ceusu.Dni + "' ", this.cn);
            this.cn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str2 = (string) reader["Ape_pat"];
            }
            else
            {
                str2 = "";
            }
            reader.Close();
            this.cn.Close();
            return str2;
        }

        public static bool GuardarUsuario(CEUsuarios entity)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            try
            {
                SqlCommand command = new SqlCommand("USP_GUARDAR_USUARIO", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Ape_pat", entity.Ape_pat);
                command.Parameters.AddWithValue("@Ape_mat", entity.Ape_mat);
                command.Parameters.AddWithValue("@Prim_nom", entity.prim_nom);
                command.Parameters.AddWithValue("@Seg_nom", entity.seg_nom);
                command.Parameters.AddWithValue("@Empresa", entity.Empresa);
                command.Parameters.AddWithValue("@Correo", entity.Correo);
                command.Parameters.AddWithValue("@Dni", entity.Dni);
                command.Parameters.AddWithValue("@Observac", entity.Observac);
                connection.Open();
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                flag = false;
                ProjectData.ClearProjectError();
                return flag;
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static DataTable ListarEmpleado()
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_EMP", connection) {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarUsuarioById(int cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_ID_USUARIO", connection) {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = cod;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable ListarUsuariosByCriterio(string cod)
        {
            SqlConnection connection = new SqlConnection(CDConexion.conecta2());
            SqlCommand selectCommand = new SqlCommand("USP_BUSCAR_USUARIO", connection) {
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

