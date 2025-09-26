using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ClosedXML.Excel;

namespace CapaWeb.pages.mantenimiento
{
    public partial class Descargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String NombreArchivo = "Reporte_" + DateTime.Now;
            string Conexion = ConfigurationManager.ConnectionStrings["ISOFT"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ExportarExcelCz"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "RCTemporal");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=" + NombreArchivo + ".xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}