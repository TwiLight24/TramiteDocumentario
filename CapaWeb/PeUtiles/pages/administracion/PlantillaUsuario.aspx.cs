using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = CapaEntidad.PArticulos;
using Negocio = CapaNegocio.PArticulos;
using Intellisoft.Project.Util;

namespace CapaWeb.PeUtiles.pages.administracion
{
    public partial class PlantillaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //HabilitarFormulario(true);
                CargarUsuarioPorPlantillas();
                CargarComboPlantillas();
            }

        }


        /// <summary>
        /// Muestra las lista de Documentos
        /// </summary>
        private void CargarUsuarioPorPlantillas()
        {
            try
            {
                Entity.UsuarioPlantilla oEPlantilla = null;
                oEPlantilla = new Entity.UsuarioPlantilla();        
                oEPlantilla = Negocio.UsuarioPlantilla.Listar(oEPlantilla);
                Session["UsuarioPorPlantillas"] = oEPlantilla.ListPlantilla;
                gvwPlantilla.DataSource = Session["UsuarioPorPlantillas"];
                gvwPlantilla.PageIndex = 0;
                gvwPlantilla.DataBind();


            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }



        /// <summary>
        /// Cargar en el ComboBox todos las empresas
        /// </summary>
        private void CargarComboPlantillas()
        {
            try
            {
                DropDownList drp = gvwPlantilla.FindControl("ddlPlantilla") as DropDownList;
                //gvwEmpleado.Columns[2].Visible = false;
            if (drp != null)
            {
                Entity.Plantilla oEmpresa = new Entity.Plantilla();
                oEmpresa.Activo = true;
                oEmpresa = Negocio.Plantilla.Listar(oEmpresa);
                Intellisoft.Project.Util.Utilitario.CargaCombo(oEmpresa.ListPlantilla, drp, "IdUsuario", "NombreUsuario", " ---- Ninguno ---- ");
        }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        private void ConfigurarTamañoPaginaPlantilla(DropDownList ddlControl)
        {

            Utilitario.RegistrarTamañoPagina(Convert.ToInt32(ddlControl.SelectedValue));
            gvwPlantilla.PageSize = Convert.ToInt32(HttpContext.Current.Session["page"]);
            //(gvwDetalleHoras.FooterRow.FindControl("ddlPage") as DropDownList).SelectedValue = Convert.ToString(HttpContext.Current.Session["page"]);
            gvwPlantilla.DataSource = Session["UsuarioPorPlantillas"];
            gvwPlantilla.DataBind();

        }


        /// <summary>
        /// Enviar Documentos.
        /// </summary>
        private void RegistrarPlantilla(int usuarioActual)
        {
            Entity.UsuarioPlantilla oPlantilla = null;

            try
            {
                CheckBox chkSelect = null;
                HiddenField hdnEstado = null;
                string str_msj = string.Empty;
                string arrayIdPlantilla = "";
                string arrayIdUsuario = "";

                foreach (GridViewRow row in gvwPlantilla.Rows)
                {
                    chkSelect = (row.FindControl("chkSelect") as CheckBox);
                    hdnEstado = (row.FindControl("hdnEstado") as HiddenField);

                    if (chkSelect != null && chkSelect.Checked)
                    {
                        //if (hdnEstado.Value.Equals("False")) // if (!hdnEstado.Value.Equals(str_estado))
                        //{

                        arrayIdPlantilla = arrayIdPlantilla + (row.FindControl("ddlPlantilla") as DropDownList).SelectedIndex + ",";
                        //DropDownList drp = e.Row.FindControl("ddlPlantilla") as DropDownList;
                            arrayIdUsuario = arrayIdUsuario + (row.FindControl("hdnIdUsuario") as HiddenField).Value + ",";

                        //}
                        //else
                        //    str_msj += "\\n- " + (row.FindControl("hdnIdArticulo") as HiddenField).Value;
                    }

                }

                if (string.IsNullOrEmpty(str_msj))
                {
                    arrayIdPlantilla = arrayIdPlantilla.Substring(0, arrayIdPlantilla.Length - 1);
                    arrayIdUsuario = arrayIdUsuario.Substring(0, arrayIdUsuario.Length - 1);
                    //arrayIdMovimiento = arrayIdMovimiento.Substring(0, arrayIdMovimiento.Length - 1);

                    oPlantilla = new Entity.UsuarioPlantilla();
                    oPlantilla.UsuarioCreador = usuarioActual;
                    oPlantilla.UsuarioModificador = usuarioActual;
                    oPlantilla = Negocio.UsuarioPlantilla.Registrar(oPlantilla, arrayIdPlantilla, arrayIdUsuario);

                    //dMensaje = CapaNegocio.Bandeja.Registrar(arrayRowIdPick);

                    //int id = 0;
                    //oUsuario = new Entity.Usuario();

                    //id = oBandeja.Destino;
                    //oUsuario.IdUsuario = id;
                    //oUsuario = CapaNegocio.Usuario.Obtener(oUsuario);
                    //Session["Cargo"] = oBandeja.IdCargo;
                    //Response.Redirect("~/reportes/ReporteCargo.aspx", false);
                    //Intellisoft.Project.Util.Correo.EnviarCorreo(oUsuario.CorreoElectronico, "Tiene Documentos Asignados en Su Bandeja");


                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(oPlantilla.UltimoResultado.Mensaje);
                    return;
                }
                else
                {
                    str_msj = "Aviso\\nLos siguientes Articulos No se Pueden Enviar y no seran tomados en cuenta:" + str_msj;
                    Intellisoft.Project.Util.Utilitario.MostrarMensaje(str_msj);
                    return;
                }
            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Seguridad.RegistrarExcepcion(ex);
                Intellisoft.Project.Util.Utilitario.MostrarMensaje(ex.Message);
            }

        }

        protected void gvwPlantilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (this.gvwPlantilla.PageIndex > -1)
                {
                    gvwPlantilla.PageIndex = e.NewPageIndex;
                    gvwPlantilla.DataSource = Session["UsuarioPorPlantillas"];
                    gvwPlantilla.DataBind();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarIncidencia(ex);
            }
        }

        protected void gvwPlantilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvwPlantilla_DataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList drp = e.Row.FindControl("ddlPlantilla") as DropDownList;
                string dato =  e.Row.Cells[9].Text;

                if (drp != null)
                {
                    Entity.Plantilla oEmpresa = new Entity.Plantilla();
                    oEmpresa.Activo = true;
                    oEmpresa = Negocio.Plantilla.Listar(oEmpresa);
                    Intellisoft.Project.Util.Utilitario.CargaCombo(oEmpresa.ListPlantilla, drp, "IdPlantilla", "Descripcion", " ---- Ninguno ---- ");
                    drp.SelectedValue = dato;
                }
               

            }
            catch (Exception ex)
            {
                Intellisoft.Project.Util.Log.RegistrarIncidencia(ex);
            }
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurarTamañoPaginaPlantilla(sender as DropDownList);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int IdUser = 0;

            IdUser = Intellisoft.Project.Util.Utilitario.ObtenerUsuarioActual().IdUsuario;
            RegistrarPlantilla(IdUser);
        }

        protected void chkAllPlantillas_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ddlPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
        //foreach (GridViewRow row in gvwPlantilla.Rows)
        //{

        //    string valor = ((DropDownList)row.FindControl("ddlPlantilla")).SelectedItem.Value;
        //    row.Cells[8].Text = "10";
    
        //}

        }

        protected void gvwPlantilla_Load(object sender, EventArgs e)
        {
           
        }

    }
}