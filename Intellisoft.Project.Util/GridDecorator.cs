using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Intellisoft.Project.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class GridDecorator
    {
        public enum Vista
        {
            HorasProyectos,
            HorasActividad,
            HorasEmpleado,
            HorasEmpresaPeriodo,
            HorasActividadPeriodo,
            DetalleHoras,
            TotalizadoHoras
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="obj_vista"></param>
        public static void MergeRows(GridView gridView, Vista obj_vista)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                {
                    if (Continuar(obj_vista, cellIndex))
                    {
                        if (row.Cells[cellIndex].Text == previousRow.Cells[cellIndex].Text)
                        {
                            row.Cells[cellIndex].RowSpan = previousRow.Cells[cellIndex].RowSpan < 2 ? 2 : previousRow.Cells[cellIndex].RowSpan + 1;
                            previousRow.Cells[cellIndex].Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj_vista"></param>
        /// <param name="int_index_cell"></param>
        /// <returns></returns>
        private static bool Continuar(Vista obj_vista, int int_index_cell)
        {
            bool bln_continuar = true;

            if (obj_vista == Vista.DetalleHoras)
                bln_continuar = (int_index_cell < 1);
            else if (obj_vista == Vista.TotalizadoHoras)
                bln_continuar = (int_index_cell == 2);
            else if ((obj_vista == Vista.HorasProyectos) || (obj_vista == Vista.HorasActividadPeriodo))
                bln_continuar = (int_index_cell < 2);
            else
                bln_continuar = (int_index_cell < 7);

            return bln_continuar;
        }
    }
}
