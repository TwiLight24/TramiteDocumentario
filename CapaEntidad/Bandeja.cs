using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad 
{
    public class Bandeja : Intellisoft.Project.Comun.Entidad.Base
	{
        private int _Origen = 0;
        private int _Destino = 0;
        private string _Observacion;
        private Int32 _IdMovimiento = 0;
        private Int32 _IdDocumento = 0;
        private Int32 _IdCargo = 0;
        private string _Proveedor = string.Empty;
        private string _Empresa  = string.Empty;
        private string _tipodoc = string.Empty;
        private string _nroDoc = string.Empty;
        private string _NroOrden = string.Empty;
        private decimal _monto = 0;
        private string _estado;
        private DateTime _FechaIni;
        private int _docNumFactReserva;
        private string _motivo = string.Empty;


        private List<Bandeja> _lstBandeja = null;




        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<Bandeja> LstMovimiento
        {
            get { return _lstBandeja; }
            set { _lstBandeja = value; }
        }


        public int Destino
        {
            get
            {
                return this._Destino;
            }
            set
            {
                this._Destino = value;
            }
        }


        public int Origen
        {
            get
            {
                return this._Origen;
            }
            set
            {
                this._Origen = value;
            }
        }

        public string Observacion
        {
            get
            {
                return this._Observacion;
            }
            set
            {
                this._Observacion = value;
            }
        }

        public string Proveedor
        {
            get
            {
                return this._Proveedor;
            }
            set
            {
                this._Proveedor = value;
            }
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



        public string NroDoc
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

        public string Empresa
        {
            get
            {
                return this._Empresa;
            }
            set
            {
                this._Empresa = value;
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

        public decimal Monto
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


        /// <summary>
        /// Código del Moviemiento
        /// </summary>
        public Int32 IdMovimiento
        {
            get
            {
                return this._IdMovimiento;
            }
            set
            {
                this._IdMovimiento = value;
            }
        }

        /// <summary>
        /// Código del Dcoumento
        /// </summary>
        public Int32 IdDocumento
        {
            get { return _IdDocumento; }
            set { _IdDocumento = value; }
        }



        /// <summary>
        /// Código del CArgo
        /// </summary>
        public Int32 IdCargo
        {
            get { return _IdCargo; }
            set { _IdCargo = value; }
        }


        /// <summary>
        /// Código del Factura de Reserva
        /// </summary>
        public Int32 DocNumFactReserva
        {
            get { return _docNumFactReserva; }
            set { _docNumFactReserva = value; }
        }

        public string motivo
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



        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdDocumento", out _IdDocumento);
            CargarVariable(dr, "IdMovimiento", out _IdMovimiento);
            CargarVariable(dr, "NOrden", out _NroOrden);
            CargarVariable(dr, "Proveedor", out _Proveedor);
            //CargarVariable(dr, "Origen", out _origen);
            CargarVariable(dr, "Estado", out _estado);
            CargarVariable(dr, "Empresa", out _Empresa);
            CargarVariable(dr, "Tipodoc", out _tipodoc);
            CargarVariable(dr, "NroDoc", out _nroDoc);
            CargarVariable(dr, "Monto", out _monto);
            //CargarVariable(dr, "NombreUsuarioOrigen", out _nombreUsuarioOrigen);
            //CargarVariable(dr, "NombreUsuarioDestino", out _nombreUsuarioDestino);
            CargarVariable(dr, "FechaIni", out _FechaIni);
            CargarVariable(dr, "DocNumReserva", out _docNumFactReserva);
        }

	}
}
