namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;

    public class CEMovimientos : Intellisoft.Project.Comun.Entidad.Base
    {
        private Int32 _idMovimiento = 0;
        private Int32 _idDocumento = 0;
        private string _proveedor = string.Empty;
        private string _empresa;
        private string _tipodoc;
        private int _destino;
        private string _estado;
        private DateTime _fechaFin;
        private DateTime _fechaIni;
        private string _nroDoc;
        private string _nOrden;
        private decimal _monto;
        private int _docNumFactReserva;
        private string _FechaVen;
        private string _FePagoR;

        private string _nombreUsuarioOrigen;
        private string _nombreUsuarioDestino;
        private string _NCargo;
        private string _motivo;


        //private int key;
        //private int nlin;
        private string _observac;
        private int _origen;
        private string _situacion;


        private List<CEMovimientos> _lstMovimiento = null;


        public string NombreUsuarioOrigen
        {
            get
            {
                return this._nombreUsuarioOrigen;
            }
            set
            {
                this._nombreUsuarioOrigen = value;
            }
        }

        public string FechaVen
        {
            get { return this._FechaVen; }
            set { this._FechaVen = value; }
        }
        public string FePagoR
        {
            get { return this._FePagoR; }
            set { this._FePagoR = value; }
        }

        public string NombreUsuarioDestino
        {
            get
            {
                return this._nombreUsuarioDestino;
            }
            set
            {
                this._nombreUsuarioDestino = value;
            }
        }

        public string Motivo
        {
            get
            {
                return this._motivo;
            }
            set
            {
                this._motivo = value;
            }
        }

        public decimal monto
        {
            get
            {
                return this._monto;
            }
            set
            {
                this._monto = value;
            }
        }
        public string nrodoc
        {
            get
            {
                return this._nroDoc;
            }
            set
            {
                this._nroDoc = value;
            }
        }

        public string NOrden
        {
            get
            {
                return this._nOrden;
            }
            set
            {
                this._nOrden = value;
            }
        }

        public string NCargo
        {
            get { return this._NCargo; }
            set { this._NCargo = value; }
        }

        public string tipodoc
        {
            get
            {
                return this._tipodoc;
            }
            set
            {
                this._tipodoc = value;
            }
        }

        public string empresa
        {
            get
            {
                return this._empresa;
            }
            set
            {
                this._empresa = value;
            }
        }

        public int Destino
        {
            get
            {
                return this._destino;
            }
            set
            {
                this._destino = value;
            }
        }

        public string Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
            }
        }

        public DateTime Fechafin
        {
            get
            {
                return this._fechaFin;
            }
            set
            {
                this._fechaFin = value;
            }
        }

        public DateTime Fechaini
        {
            get
            {
                return this._fechaIni;
            }
            set
            {
                this._fechaIni = value;
            }
        }

        /// <summary>
        /// Código del Moviemiento
        /// </summary>
        public Int32 IdMovimiento
        {
            get
            {
                return this._idMovimiento;
            }
            set
            {
                this._idMovimiento = value;
            }
        }

        /// <summary>
        /// Código del Dcoumento
        /// </summary>
        public Int32 IdDocumento
        {
            get { return _idDocumento; }
            set { _idDocumento = value; }
        }

        public string Observac
        {
            get
            {
                return this._observac;
            }
            set
            {
                this._observac = value;
            }
        }

        public int Origen
        {
            get
            {
                return this._origen;
            }
            set
            {
                this._origen = value;
            }
        }

        public string Situacion
        {
            get
            {
                return this._situacion;
            }
            set
            {
                this._situacion = value;
            }
        }

        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<CEMovimientos> LstMovimiento
        {
            get { return _lstMovimiento; }
            set { _lstMovimiento = value; }
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
        /// Código del Factura de Reserva
        /// </summary>
        public Int32 DocNumFactReserva
        {
            get { return _docNumFactReserva; }
            set { _docNumFactReserva = value; }
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
            CargarVariable(dr, "IdMovimiento", out _idMovimiento);
            CargarVariable(dr, "NOrden", out _nOrden);
            CargarVariable(dr, "NCargo", out _NCargo);
            CargarVariable(dr, "Proveedor", out _proveedor);
            CargarVariable(dr, "Origen", out _origen);
            CargarVariable(dr, "Estado", out _estado);
            CargarVariable(dr, "Empresa", out _empresa);
            CargarVariable(dr, "Tipodoc", out _tipodoc);
            CargarVariable(dr, "NroDoc", out _nroDoc);
            CargarVariable(dr, "Monto", out _monto);
            CargarVariable(dr, "NombreUsuarioOrigen", out _nombreUsuarioOrigen);
            CargarVariable(dr, "NombreUsuarioDestino", out _nombreUsuarioDestino);
            CargarVariable(dr, "FechaIni", out _fechaIni);
            CargarVariable(dr, "DocNumReserva", out _docNumFactReserva);
            CargarVariable(dr, "FechaVen", out _FechaVen);
            CargarVariable(dr, "FePagoR", out _FePagoR);
            CargarVariable(dr, "Motivo", out _motivo);

            //CargarVariable(dr, "ruc", out ru);
            //CargarVariable(dr, "formpago", out fpago);
            //CargarVariable(dr, "Empresa", out empr);
            //CargarVariable(dr, "tipodoc", out tipdoc);
            //CargarVariable(dr, "tipo", out tip);
            //CargarVariable(dr, "montoini", out monini);
            //CargarVariable(dr, "montoact", out monact);

            //CargarVariable(dr, "NroDoc", out ndoc);
            //CargarVariable(dr, "Monto", out mont);
            //CargarVariable(dr, "Ubicacion", out _ubicacion);


            //CargarVariable(dr, "fechadoc", out fdoc);
            //CargarVariable(dr, "fechaact", out fact);
            //CargarVariable(dr, "fechaven", out fven);
            //CargarVariable(dr, "fecharec", out frec);



        }

        #endregion
    }
}

