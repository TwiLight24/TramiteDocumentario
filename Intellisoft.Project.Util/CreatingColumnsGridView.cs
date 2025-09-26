using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace Intellisoft.Project.Util
{
    /// <summary>
    /// Clase que crea las columnas, y sus propiedades, de un control GridView 
    /// según la clase que va a ejecutar un mantenimiento.
    /// </summary>
    public class CreatingColumnsGridView : System.Web.UI.Page
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase CreatingColumnsGridView
        /// </summary>
        /// <param name="Grid">GridView donde se agregara las columnas</param>
        public CreatingColumnsGridView()
        {
        }

        /// <summary>
        /// Carga las columnas en el GridView para la bandeja de entrada
        /// </summary>
        public void LoadColumns_BandejaSup(GridView gridData, DataTable table)
        {
            ImageField imagen = null;
            BoundField bound = null;
            DataControlField colField = null;
            for (int i = 4; i < table.Columns.Count - 1; i++)
            {
                if (!table.Columns[i].ColumnName.Equals("Estado") && !table.Columns[i].ColumnName.Equals("ImgEstado"))
                {
                    bound = new BoundField();
                    bound.DataField = table.Columns[i].ColumnName;
                    bound.HeaderText = table.Columns[i].ColumnName.Replace('_', ' ');
                    bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bound.ItemStyle.Wrap = true;
                    bound.HeaderStyle.Wrap = true;
                    gridData.Columns.Add(bound);
                }
            }

            bound = new BoundField();
            bound.DataField = table.Columns[table.Columns.Count - 1].ColumnName;
            bound.HeaderText = "Total";
            bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bound.ItemStyle.Wrap = true;
            bound.HeaderStyle.Wrap = true;
            gridData.Columns.Add(bound);

            bound = new BoundField();
            bound.DataField = table.Columns[1].ColumnName;
            bound.HeaderText = "Periodo";
            bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bound.ItemStyle.Wrap = true;
            bound.HeaderStyle.Wrap = true;
            gridData.Columns.Add(bound);

            //gridData.DataBind();  
            imagen = new ImageField();
            imagen.DataImageUrlField = "ImgEstado"; // "Estado";
            // imagen.DataImageUrlFormatString = "'<%# \"../../images/\" + DataBinder.Eval(Container.DataItem,\"ImgEstado\") + \"\" %>'"; // "../../images/Bind(" +  //circle_orange1.png";
            imagen.HeaderText = "Estado";
            imagen.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            colField = imagen;
            gridData.Columns.Add(colField);
        }

        /// <summary>
        /// Carga las columnas en el GridView para el reporte de la bandeja de entrada
        /// </summary>
        public void LoadColumns_BandejaSupervisorReporte(GridView gridData, DataTable table)
        {
            ImageField imagen = null;
            BoundField bound = null;
            DataControlField colField = null;
            for (int i = 0; i < table.Columns.Count - 1; i++)
            {
                if (!table.Columns[i].ColumnName.Equals("Estado") && !table.Columns[i].ColumnName.Equals("ImgEstado"))
                {
                    bound = new BoundField();
                    bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bound.DataField = table.Columns[i].ColumnName;
                    bound.HeaderText = table.Columns[i].ColumnName.Replace('_', ' ');

                    if (bound.HeaderText.ToLower() == "empleado")
                    {
                        bound.HeaderStyle.Width = Unit.Pixel(160);
                        bound.ItemStyle.Width = Unit.Pixel(160);
                        bound.ItemStyle.Height = Unit.Pixel(20);
                        bound.ItemStyle.Wrap = true;
                        bound.HeaderStyle.Wrap = true;
                    }
                    if (bound.HeaderText.ToLower() == "dia" )
                    {
                        bound.HeaderStyle.Width = Unit.Pixel(80);
                        bound.ItemStyle.Width = Unit.Pixel(80);
                        bound.ItemStyle.Height = Unit.Pixel(20);
                        bound.ItemStyle.Wrap = true;
                        bound.HeaderStyle.Wrap = true;
                    }
                    if (bound.HeaderText.ToLower() == "fecha")
                    {
                        bound.HeaderStyle.Width = Unit.Pixel(80);
                        bound.ItemStyle.Width = Unit.Pixel(80);
                        bound.ItemStyle.Height = Unit.Pixel(20);
                        bound.ItemStyle.Wrap = true;
                        bound.HeaderStyle.Wrap = true;
                    }

                    gridData.Columns.Add(bound);
                }
            }

            /*bound = new BoundField();
            bound.DataField = table.Columns[table.Columns.Count - 1].ColumnName;
            bound.HeaderText = "Actual";
            bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gridData.Columns.Add(bound);*/

            bound = new BoundField();
            bound.DataField = table.Columns[table.Columns.Count - 1].ColumnName;
            bound.HeaderText = "Total";
            bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bound.ItemStyle.Wrap = true;
            bound.HeaderStyle.Wrap = true;
            gridData.Columns.Add(bound);

            //gridData.DataBind();  
            imagen = new ImageField();
            imagen.DataImageUrlField = "ImgEstado"; // "Estado";
            // imagen.DataImageUrlFormatString = "'<%# \"../../images/\" + DataBinder.Eval(Container.DataItem,\"ImgEstado\") + \"\" %>'"; // "../../images/Bind(" +  //circle_orange1.png";
            imagen.HeaderText = "Estado";
            imagen.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            imagen.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            bound.ItemStyle.Wrap = true;
            bound.HeaderStyle.Wrap = true;
            colField = imagen;
            gridData.Columns.Add(colField);
        }

        /// <summary>
        /// Carga las columnas en el GridView para el consolidado
        /// </summary>
        public void LoadColumns_Consolidado(GridView gridData, DataTable table)
        {
            ImageField obj_img_field = null;
            // TemplateField obj_col_temp = null;
            ButtonField obj_col_btn = null;
            BoundField obj_col_bound = null;
            DataControlField obj_col_field = null;

            for (int i = 4; i < table.Columns.Count - 1; i++)
            {
                if (!table.Columns[i].ColumnName.Equals("Estado") && !table.Columns[i].ColumnName.Equals("ImgEstado"))
                {
                    obj_col_btn = new ButtonField();

                    obj_col_btn.DataTextField = table.Columns[i].ColumnName;
                    obj_col_btn.HeaderText = table.Columns[i].ColumnName.Replace('_', ' ');
                    obj_col_btn.ButtonType = ButtonType.Link;
                    obj_col_btn.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    obj_col_btn.CommandName = (i - 1).ToString(); // "DetalleVistaEmpProyecto"; // +i.ToString();

                    gridData.Columns.Add(obj_col_btn);
                }
            }

            obj_col_btn = new ButtonField();
            obj_col_btn.DataTextField = table.Columns[table.Columns.Count - 1].ColumnName;
            obj_col_btn.HeaderText = "Total";
            obj_col_btn.ButtonType = ButtonType.Link;
            obj_col_btn.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            obj_col_btn.CommandName = "DetalleVistaEmpleado";

            gridData.Columns.Add(obj_col_btn);

            obj_col_bound = new BoundField();
            obj_col_bound.DataField = table.Columns[1].ColumnName;
            obj_col_bound.HeaderText = "Periodo";
            obj_col_bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gridData.Columns.Add(obj_col_bound);

            //gridData.DataBind();  
            obj_img_field = new ImageField();
            obj_img_field.DataImageUrlField = "ImgEstado";
            obj_img_field.HeaderText = "Estado";
            obj_img_field.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            obj_img_field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            obj_col_field = obj_img_field;
            gridData.Columns.Add(obj_col_field);
        }

        /// <summary>
        /// Carga las columnas en el GridView para el consolidado
        /// </summary>
        public void LoadColumns_ConsolidadoReporte(GridView gridData, DataTable table)
        {
            ImageField obj_img_field = null;
            // TemplateField obj_col_temp = null;
            // ButtonField obj_col_btn = null;
            BoundField obj_col_bound = null;
            DataControlField obj_col_field = null;

            for (int i = 4; i < table.Columns.Count - 1; i++)
            {
                if (!table.Columns[i].ColumnName.Equals("Estado") && !table.Columns[i].ColumnName.Equals("ImgEstado"))
                {
                    obj_col_bound = new BoundField();

                    obj_col_bound.DataField = table.Columns[i].ColumnName;
                    obj_col_bound.HeaderText = table.Columns[i].ColumnName.Replace('_', ' ');
                    obj_col_bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                    gridData.Columns.Add(obj_col_bound);
                }
            }

            obj_col_bound = new BoundField();
            obj_col_bound.DataField = table.Columns[table.Columns.Count - 1].ColumnName;
            obj_col_bound.HeaderText = "Total";
            obj_col_bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            gridData.Columns.Add(obj_col_bound);

            obj_col_bound = new BoundField();
            obj_col_bound.DataField = table.Columns[1].ColumnName;
            obj_col_bound.HeaderText = "Periodo";
            obj_col_bound.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gridData.Columns.Add(obj_col_bound);

            obj_img_field = new ImageField();
            obj_img_field.DataImageUrlField = "ImgEstado";
            obj_img_field.HeaderText = "Estado";
            obj_img_field.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            obj_img_field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            obj_col_field = obj_img_field;
            gridData.Columns.Add(obj_col_field);
        }

        protected void horas_detalle_click()
        {

        }
    }
}