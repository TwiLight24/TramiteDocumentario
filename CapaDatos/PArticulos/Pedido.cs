using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity = CapaEntidad.PArticulos;
using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Data;
using System.IO;

namespace CapaDatos.PArticulos
{
    public class Pedido : Intellisoft.Project.Comun.Dao.Base
	{
        /// <summary>
        /// Registrar los Pedido.
        /// </summary>
        public Entity.Pedido Registrar(Entity.Pedido oEPedido)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_Insert") as SqlCommand;

                // InParameter

                if (oEPedido.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEPedido.UsuarioCreador);
                if (oEPedido.UsuarioModificador > 0)
                    db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEPedido.UsuarioModificador);
                db.AddInParameter(cmd, "@TotalPedido", SqlDbType.Money, oEPedido.TotalPedido);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);
                db.AddOutParameter(cmd, "@gIdPedido", SqlDbType.Int, 99999);

                db.ExecuteNonQuery(cmd);

                oEPedido.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEPedido.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEPedido.UltimoResultado.EsValido = (oEPedido.UltimoResultado.ResultadoOperacion > -1);

                oEPedido.IdPedido = Convert.ToInt32(cmd.Parameters["@gIdPedido"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEPedido.CargarExcepcion(ex);
            }

            return oEPedido;
        }



        /// <summary>
        /// Registrar los Detalle Pedido.
        /// </summary>
        public Entity.Pedido RegistrarDetalle(Entity.Pedido oEPedido)
        {
            try
            {
                



            }
            catch (Exception ex)
            {
                oEPedido.CargarExcepcion(ex);
            }

            return oEPedido;
        }


        /// <summary>
        /// Listar en una grilla todas los pedidos segun el estado seleccionado.
        /// </summary>
        public Entity.Pedido Listar(Entity.Pedido oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_List") as SqlCommand;

                //InParameter
                

                Entity.Pedido oEmpresa = null;
                List<Entity.Pedido> lstEntidad = new List<Entity.Pedido>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Pedido();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstPedido = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Listar en una grilla todas los pedidos segun el estado seleccionado.
        /// </summary>
        public Entity.Pedido ListarByUsuario(Entity.Pedido oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_ListByUsuario") as SqlCommand;

                //InParameter
                db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oeEntity.UsuarioCreador);

                Entity.Pedido oEmpresa = null;
                List<Entity.Pedido> lstEntidad = new List<Entity.Pedido>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oEmpresa = new Entity.Pedido();
                        oEmpresa.CargarEntidad(dataReader);

                        lstEntidad.Add(oEmpresa);
                    }
                }

                oeEntity.LstPedido = lstEntidad;
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;
        }

        /// <summary>
        /// Devuelve todos los datos de una Empresa
        /// </summary>
        public Entity.Pedido ObtenerDocumento(Entity.Pedido oeEntity)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_GetByID") as SqlCommand;

                // InParameter
                db.AddInParameter(cmd, "@IdPedido", SqlDbType.Int, oeEntity.IdPedido);
                //db.AddInParameter(cmd, "@Activo", SqlDbType.Bit, oEDocumento.Activo);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);


                Entity.Pedido oPedido = null;
                List<Entity.Pedido> lstEntidad = new List<Entity.Pedido>();
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oPedido = new Entity.Pedido();
                        oPedido.CargarEntidad(dataReader);

                        lstEntidad.Add(oPedido);
                    }
                }

                oeEntity.LstPedido = lstEntidad;

                oeEntity.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oeEntity.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oeEntity.UltimoResultado.EsValido = (oeEntity.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oeEntity.CargarExcepcion(ex);
            }

            return oeEntity;

        }


        /// <summary>
        /// Actualiza una Empresa seleccionada
        /// </summary>
        public Entity.Pedido Actualizar(Entity.Pedido oEDocumento)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_Update") as SqlCommand;

                // InParameter
                if (oEDocumento.IdPedido > 0)
                    db.AddInParameter(cmd, "@IdPedido", SqlDbType.Int, oEDocumento.IdPedido);
                if (oEDocumento.IdArticulo > 0)
                    db.AddInParameter(cmd, "@IdArticulo", SqlDbType.Int, oEDocumento.IdArticulo);
                db.AddInParameter(cmd, "@Cantidad", SqlDbType.VarChar, oEDocumento.Cantidad);

                //if (!string.IsNullOrEmpty(oEEmpresa.Nombre))
                //db.AddInParameter(cmd, "@Nombre", SqlDbType.VarChar, oEEmpresa.Nombre);
                //if (oEEmpresa.IdPais > 0)
                //db.AddInParameter(cmd, "@IdPais", SqlDbType.Int, oEEmpresa.IdPais);
                //if (oEEmpresa.UsuarioModificador > 0)
                db.AddInParameter(cmd, "@UsuarioModificacion", SqlDbType.Int, oEDocumento.UsuarioModificador);

                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);

                db.ExecuteNonQuery(cmd);

                oEDocumento.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEDocumento.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEDocumento.UltimoResultado.EsValido = (oEDocumento.UltimoResultado.ResultadoOperacion > -1);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEDocumento.CargarExcepcion(ex);
            }

            return oEDocumento;
        }


        /// <summary>
        /// Registrar los Pedido.
        /// </summary>
        public Entity.Pedido Agregar(Entity.Pedido oEPedido)
        {
            try
            {
                EntLib.Data.Sql.SqlDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("PEDIDOS") as EntLib.Data.Sql.SqlDatabase;
                SqlCommand cmd = db.GetStoredProcCommand("USP_JC_Pedidos_Add") as SqlCommand;

                // InParameter
                if (oEPedido.IdPedido > 0)
                    db.AddInParameter(cmd, "@IdPedido", SqlDbType.Int, oEPedido.IdPedido);
                if (oEPedido.IdArticulo > 0)
                    db.AddInParameter(cmd, "@IdArticulo", SqlDbType.Int, oEPedido.IdArticulo);
                db.AddInParameter(cmd, "@Cantidad", SqlDbType.VarChar, oEPedido.Cantidad);
                if (oEPedido.UsuarioCreador > 0)
                    db.AddInParameter(cmd, "@UsuarioRegistro", SqlDbType.Int, oEPedido.UsuarioCreador);


                // OutParameter
                db.AddOutParameter(cmd, "@cResultado", SqlDbType.SmallInt, 4);
                db.AddOutParameter(cmd, "@aMensaje", SqlDbType.VarChar, 1000);
                

                db.ExecuteNonQuery(cmd);

                oEPedido.UltimoResultado.ResultadoOperacion = Convert.ToInt16(cmd.Parameters["@cResultado"].Value);
                oEPedido.UltimoResultado.Mensaje = cmd.Parameters["@aMensaje"].Value.ToString();
                oEPedido.UltimoResultado.EsValido = (oEPedido.UltimoResultado.ResultadoOperacion > -1);
                

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                oEPedido.CargarExcepcion(ex);
            }

            return oEPedido;
        }

	}
}
