namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;

    public class CEDocumento : Intellisoft.Project.Comun.Entidad.Base
    {
        #region Variables Privadas

        private Int32 _idDocumento = 0;
        private Int32 _idCargo = 0;
        private string _proveedor = string.Empty;
        private string _ubicacion = string.Empty;


        private string anu;
        private string clien;
        private string empr;
        private DateTime fact;
        private DateTime fdoc;
        private string fpago;
        private DateTime frec;
        private DateTime fven;
        private int key;
        private string mon;
        private decimal monact;
        private decimal monini;
        private decimal mont;
        private string ndoc;
        private string observ;
        private string oc;
        private string ru;
        private string tip;
        private string tipdoc;
        private string _comentario;
        private int _docNumFactReserva;
        private String _vencimiento;

        private int usu;
        private string er;
        private DateTime fepago;
        private string docAdjuntos;
        private string prioridad;
        private int canComPago;

        private List<CEDocumento> _lstDocumento = null;

        #endregion

        /// <summary>
        /// Código del Empleado dado por la Empresa
        /// </summary>
        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        public string anulado
        {
            get
            {
                return this.anu;
            }
            set
            {
                this.anu = value;
            }
        }

        public string cliente
        {
            get
            {
                return this.clien;
            }
            set
            {
                this.clien = value;
            }
        }

        public string empresa
        {
            get
            {
                return this.empr;
            }
            set
            {
                this.empr = value;
            }
        }

        public DateTime fechaact
        {
            get
            {
                return this.fact;
            }
            set
            {
                this.fact = value;
            }
        }

        public DateTime fechadoc
        {
            get
            {
                return this.fdoc;
            }
            set
            {
                this.fdoc = value;
            }
        }

        public DateTime fecharec
        {
            get
            {
                return this.frec;
            }
            set
            {
                this.frec = value;
            }
        }

        public DateTime fechaven
        {
            get
            {
                return this.fven;
            }
            set
            {
                this.fven = value;
            }
        }


        public string formpago
        {
            get
            {
                return this.fpago;
            }
            set
            {
                this.fpago = value;
            }
        }

        public string moneda
        {
            get
            {
                return this.mon;
            }
            set
            {
                this.mon = value;
            }
        }

        public decimal monto
        {
            get
            {
                return this.mont;
            }
            set
            {
                this.mont = value;
            }
        }

        public decimal montoact
        {
            get
            {
                return this.monact;
            }
            set
            {
                this.monact = value;
            }
        }

        public decimal montoini
        {
            get
            {
                return this.monini;
            }
            set
            {
                this.monini = value;
            }
        }

        public int nkey
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        public string norden
        {
            get
            {
                return this.oc;
            }
            set
            {
                this.oc = value;
            }
        }

        public string nrodoc
        {
            get
            {
                return this.ndoc;
            }
            set
            {
                this.ndoc = value;
            }
        }

        public string observac
        {
            get
            {
                return this.observ;
            }
            set
            {
                this.observ = value;
            }
        }

        public string ruc
        {
            get
            {
                return this.ru;
            }
            set
            {
                this.ru = value;
            }
        }

        public String Vencimiento
        {
            get {return this._vencimiento;}
            set { this._vencimiento = value; }
        }

        public string tipo
        {
            get
            {
                return this.tip;
            }
            set
            {
                this.tip = value;
            }
        }

        public string tipodoc
        {
            get
            {
                return this.tipdoc;
            }
            set
            {
                this.tipdoc = value;
            }
        }

        public int usuario
        {
            get
            {
                return this.usu;
            }
            set
            {
                this.usu = value;
            }
        }

        public string ER
        {
            get
            {
                return this.er;
            }
            set
            {
                this.er = value;
            }
        }

        public Int32 CanComPago
        {
            get
            {
                return this.canComPago;
            }
            set
            {
                this.canComPago = value;
            }
        }

        public DateTime Fepago
        {
            get
            {
                return this.fepago;
            }
            set
            {
                this.fepago = value;
            }
        }
        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<CEDocumento> LstDocumento
        {
            get { return _lstDocumento; }
            set { _lstDocumento = value; }
        }

        /// <summary>
        /// Código del Dcoumento
        /// </summary>
        public Int32 IdDocumento
        {
            get { return _idDocumento; }
            set { _idDocumento = value; }
        }
        /// <summary>
        /// Código del Cargo
        /// </summary>
        public Int32 IdCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }
        /// <summary>
        /// Código del Empleado dado por la Empresa
        /// </summary>
        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        /// <summary>
        /// Código del Empleado dado por la Empresa
        /// </summary>
        public string Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        /// <summary>
        /// Código del Factura de Reserva
        /// </summary>
        public Int32 DocNumFactReserva
        {
            get { return _docNumFactReserva; }
            set { _docNumFactReserva = value; }
        }

        public string DocAdjuntos 
        {
            get { return docAdjuntos; }
            set { docAdjuntos = value; }
        }

        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }


        #region Metodos Publicos

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdDocumento", out _idDocumento);
            CargarVariable(dr, "NOrden", out oc);
            CargarVariable(dr, "NCargo", out _idCargo);
            CargarVariable(dr, "Proveedor", out _proveedor);
            CargarVariable(dr, "moneda", out mon);
            CargarVariable(dr, "Ruc", out ru);
            CargarVariable(dr, "formpago", out fpago);
            CargarVariable(dr, "Empresa", out empr);
            CargarVariable(dr, "tipodoc", out tipdoc);
            CargarVariable(dr, "tipo", out tip);
            CargarVariable(dr, "montoini", out monini);
            CargarVariable(dr, "montoact", out monact);
            CargarVariable(dr, "Vencimiento", out _vencimiento);

            CargarVariable(dr, "NroDoc", out ndoc);
            CargarVariable(dr, "Monto", out mont);
            CargarVariable(dr, "Ubicacion", out _ubicacion);


            CargarVariable(dr, "fechadoc", out fdoc);
            CargarVariable(dr, "fechaact", out fact);
            CargarVariable(dr, "fechaven", out fven);
            CargarVariable(dr, "fecharec", out frec);
            CargarVariable(dr, "Comentario", out _comentario);
            CargarVariable(dr, "DocNumFactReserva", out _docNumFactReserva);

            CargarVariable(dr, "NroER", out er);
            CargarVariable(dr, "Fepago", out fepago);
            CargarVariable(dr, "CantComprobantePago", out canComPago);
            CargarVariable(dr, "DocAdjuntos", out docAdjuntos);


        }

        #endregion
    }
}

