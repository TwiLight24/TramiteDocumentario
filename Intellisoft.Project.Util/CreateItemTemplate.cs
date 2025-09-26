using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intellisoft.Project.Util
{
    public class CreateItemTemplate : ITemplate
    {
        public delegate void ejecutar_evento();

        public event ejecutar_evento horas_detalle_click;        
        public event ejecutar_evento horas_empresa_click;

        //Field to store the ListItemType value
        private ListItemType _obj_item_type;

        public CreateItemTemplate()
        {
            //
            // TODO: Add default constructor logic here
            //
        }

        //Parameterrised constructor
        public CreateItemTemplate(ListItemType obj_item_type)
        {
            _obj_item_type = obj_item_type;
        }

        //Overwrite the InstantiateIn() function of the ITemplate interface.
        public void InstantiateIn(System.Web.UI.Control obj_ctrl_container)
        {
            //Code to create the ItemTemplate and its field.
            if (_obj_item_type == ListItemType.Item)
            {
                LinkButton lkb_horas = new LinkButton();
                // lkb_horas.ID = "lkb_horas";
                lkb_horas.CssClass = "a";
                lkb_horas.Click += new EventHandler(lkb_horas_Click);
                // lkb_horas.Attributes.Add("OnClientClick", "");

                obj_ctrl_container.Controls.Add(lkb_horas);
            }
            else if (_obj_item_type == ListItemType.Footer)
            {
                LinkButton lkb_sum_hora_empr = new LinkButton();
                // lkb_sum_hora_empr.ID = "ltl_sum_hora_empr";
                lkb_sum_hora_empr.CssClass = "a";
                lkb_sum_hora_empr.Click += new EventHandler(lkb_sum_hora_empr_Click);
                // lkb_sum_hora_empr.Attributes.Add("OnClientClick", "");

                obj_ctrl_container.Controls.Add(lkb_sum_hora_empr);
            }
        }

        void lkb_horas_Click(object sender, EventArgs e)
        {
            this.horas_detalle_click();
            // HiddenField hdnIdEmpleado = (((sender as LinkButton).Parent.Parent as GridViewRow).FindControl("hdnIdEmpleado") as HiddenField);
            // Seguridad.EncriptarUrl(IdRegActividad.Value)
            // ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../../pages/administracion/VistaEmpleado.aspx?var1=" + IdRegAct + "&var2=" + Index + "&var3=" + filaVisual + "&var4=" + Indicador + "', null, 'height=450, width=700, status=no, toolbar=no, scrollbars=no, menubar=no, location=no, top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }

        void lkb_sum_hora_empr_Click(object sender, EventArgs e)
        {
            this.horas_empresa_click();
            // HiddenField hdnIdPeriodo = (((sender as LinkButton).Parent.Parent as GridViewRow).FindControl("hdnIdPeriodo") as HiddenField);
            // HiddenField hdnIdEmpresa = (((sender as LinkButton).Parent.Parent as GridViewRow).FindControl("hdnIdEmpresa") as HiddenField);
            // ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../../pages/administracion/VistaEmpresa.aspx?var1=" + hdnIdPeriodo.Value + "&var2=" + hdnIdEmpresa.Value + "&var3=" + "" + "&var4=" + "" + "', null, 'height=450, width=700, status=no, toolbar=no, scrollbars=no, menubar=no, location=no, top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
    }
}
