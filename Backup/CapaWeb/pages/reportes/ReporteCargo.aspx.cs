using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;

namespace CapaWeb.pages.reportes
{
    public partial class ReporteCargo : System.Web.UI.Page
    {

        #region Variables

        DataSet dsResultado = null;
        private string tituloForm = string.Empty;
        private string reporte = string.Empty;
        private string orientation = string.Empty;
        private bool exportar = false;
        private string rangoFechas = string.Empty;

        #endregion


        #region Propiedades

        public DataSet DsResultado
        {
            get { return dsResultado; }
            set { dsResultado = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                CapaEntidad.CECargos objAsistencia = new CapaEntidad.CECargos();
                objAsistencia.idCargo = Convert.ToInt32(txtBuscar.Text);

                objAsistencia = CapaNegocio.CNCargos.ListarCargoByIdReporte(objAsistencia);

                if (objAsistencia.UltimoResultado.UltimoDataSet == null || objAsistencia.UltimoResultado.UltimoDataSet.Tables[0].Rows.Count == 0)
                {
                    //MessageBox.Show("No hay datos para la emisión del reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //ReporteCargo vsReporte = new ReporteCargo();
                    //vsReporte.TituloForm = "Vista Previa: Reporte de Inasistencia Empleados";
                    //vsReporte.Orientation = "V";
                    //vsReporte.Exportar = exportar;
                    //vsReporte.RangoFechas = "Desde " + Util.Utilitario.GetFormatDateTime(this.dtpDesde.Value.ToString("dd/MM/yyyy")
                    //                + " 00:00").ToString("dd/MM/yyyy HH:mm") + " hasta " + Util.Utilitario.GetFormatDateTime(this.dtpHasta.Value.ToString("dd/MM/yyyy")
                    //                + " 23:59").ToString("dd/MM/yyyy HH:mm");
                    //vsReporte.Reporte = "rptInasistenciaEmpleados.rpt";
                    DsResultado = objAsistencia.UltimoResultado.UltimoDataSet;
                    //vsReporte.ShowDialog();
                

                //Propiedades título
                //this.Text = this.TituloForm;
                //this.Width = (Orientation.ToLower().Equals("v")) ? 900 : 1200;

                //Emitir Reporte
                ReportDocument oRep = new ReportDocument();
                string pat = Path.GetFullPath("reports/ReportCargo.rpt");
                oRep.Load(Path.GetFullPath("reports/ReportCargo.rpt"));
                //oRep.DataDefinition.FormulaFields["RangoFechas"].Text = "'" + RangoFechas + "'";
                oRep.SetDataSource(this.DsResultado.Tables[0]);
                this.rvVistaReporte.ReportSource = oRep;

                //this.rvVistaReporte.ShowExportButton = Exportar;
                
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}