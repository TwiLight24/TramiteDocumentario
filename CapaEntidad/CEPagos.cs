namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;

    public class CEPagos : Intellisoft.Project.Comun.Entidad.Base
    {

        private Int32 _id;
        private Int32 _Invtype;
        private Int32 _Docentry;
        private string _Referencia;
        private string _Mediodepago;
        private string _Proveedor;
        private string _TipoDoc;
        private string _NumeroDoc;
        private string _Moneda;
        private DateTime _FechaDoc;
        private DateTime _FechaVen;
        private decimal _TotalDocumento;
        private decimal _MontoPagado;
        private decimal _Retencion;
        private decimal _Detraccion;
        private string _Desc;
        private String _IdDoc;

        private List<CEPagos> _lstPago = null;

        private List<String> _lstPlanilla = null;

        public int Id { get => _id; set => _id = value; }
        public int Invtype { get => _Invtype; set => _Invtype = value; }
        public int Docentry { get => _Docentry; set => _Docentry = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string Mediodepago { get => _Mediodepago; set => _Mediodepago = value; }
        public string Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public string TipoDoc { get => _TipoDoc; set => _TipoDoc = value; }
        public string NumeroDoc { get => _NumeroDoc; set => _NumeroDoc = value; }
        public string Moneda { get => _Moneda; set => _Moneda = value; }
        public DateTime FechaDoc { get => _FechaDoc; set => _FechaDoc = value; }
        public DateTime FechaVen { get => _FechaVen; set => _FechaVen = value; }
        public decimal TotalDocumento { get => _TotalDocumento; set => _TotalDocumento = value; }
        public decimal MontoPagado { get => _MontoPagado; set => _MontoPagado = value; }
        public decimal Retencion { get => _Retencion; set => _Retencion = value; }
        public decimal Detraccion { get => _Detraccion; set => _Detraccion = value; }
        public string Desc { get => _Desc; set => _Desc = value; }

        public string IdDoc { get => _IdDoc; set => _IdDoc = value; }
        public List<CEPagos> LstPago { get => _lstPago; set => _lstPago = value; }

        public List<String> lstPlanilla { get => _lstPlanilla; set => _lstPlanilla = value; }

        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "Id", out _id);
            CargarVariable(dr, "Invtype", out _Invtype);
            CargarVariable(dr, "DocEntry", out _Docentry);
            CargarVariable(dr, "Referencia", out _Referencia);
            CargarVariable(dr, "Mediodepago", out _Mediodepago);
            CargarVariable(dr, "Proveedor", out _Proveedor);
            CargarVariable(dr, "TipoDoc", out _TipoDoc);
            CargarVariable(dr, "NumeroDoc", out _NumeroDoc);
            CargarVariable(dr, "Moneda", out _Moneda);
            CargarVariable(dr, "FechaDoc", out _FechaDoc);
            CargarVariable(dr, "FechaVen", out _FechaVen);
            CargarVariable(dr, "TotalDocumento", out _TotalDocumento);
            CargarVariable(dr, "MontoPagado", out _MontoPagado);
            CargarVariable(dr, "Retencion", out _Retencion);
            CargarVariable(dr, "Detraccion", out _Detraccion);
            CargarVariable(dr, "Desc", out _Desc);
            CargarVariable(dr, "IdDoc", out _IdDoc);          
        }
    }
}
