using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class CargaMasiva : Intellisoft.Project.Comun.Entidad.Base
	{
        private int _Origen = 0;
        private int _Destino = 0;
        private string _Observacion;
        private Int32 _IdMovimiento = 0;
        private Int32 _IdDocumento = 0;
        private Int32 _IdCargo = 0;
        private string _Proveedor = string.Empty;
        private string _Empresa = string.Empty;
        private string _tipodoc = string.Empty;
        private string _nroDoc = string.Empty;
        private string _NroOrden = string.Empty;
        private decimal _monto = 0;
        private string _estado;
        private string _situacion;
        private Int32 _idCarga = 0;
        private Int32 _numero = 0;
        private string _concepto = string.Empty;
        private string _ruc = string.Empty;
        private string _nrDocumento = string.Empty;


        private DateTime _FechaIni;


        private List<CargaMasiva> _lstCargaMasiva = null;




        /// <summary>
        /// Lista de datos de la Entidad
        /// </summary>
        public List<CargaMasiva> LstCargaMasiva
        {
            get { return _lstCargaMasiva; }
            set { _lstCargaMasiva = value; }
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
        public string Concepto
        {
            get
            {
                return this._concepto;
            }
            set
            {
                this._concepto = value;
            }
        }

        /// <summary>
        /// Código del Moviemiento
        /// </summary>
        public string NrDocumento
        {
            get
            {
                return this._nrDocumento;
            }
            set
            {
                this._nrDocumento = value;
            }
        }

                /// <summary>
        /// Código del Moviemiento
        /// </summary>
        public string Ruc
        {
            get
            {
                return this._ruc;
            }
            set
            {
                this._ruc = value;
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
        /// Código del Moviemiento
        /// </summary>
        public Int32 IdCarga
        {
            get
            {
                return this._idCarga ;
            }
            set
            {
                this._idCarga = value;
            }
        }

        /// <summary>
        /// Código del Moviemiento
        /// </summary>
        public Int32 Numero
        {
            get
            {
                return this._numero;
            }
            set
            {
                this._numero = value;
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


        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

            CargarVariable(dr, "IdDocumento", out _IdDocumento);
            CargarVariable(dr, "IdMovimiento", out _IdMovimiento);
            CargarVariable(dr, "NOrden", out _NroOrden);
            CargarVariable(dr, "Proveedor", out _Proveedor);
            //CargarVariable(dr, "Origen", out _origen);
            CargarVariable(dr, "Estado", out _estado);
          
            CargarVariable(dr, "Tipodoc", out _tipodoc);
            CargarVariable(dr, "NroDoc", out _nroDoc);
            CargarVariable(dr, "Monto", out _monto);
            //CargarVariable(dr, "NombreUsuarioOrigen", out _nombreUsuarioOrigen);
            //CargarVariable(dr, "NombreUsuarioDestino", out _nombreUsuarioDestino);
            CargarVariable(dr, "FechaIni", out _FechaIni);
            CargarVariable(dr, "IdCarga", out _idCarga);
            CargarVariable(dr, "Numero", out _numero);
            CargarVariable(dr, "Empresa", out _Empresa);
            CargarVariable(dr, "Ruc", out _ruc);
            CargarVariable(dr, "Concepto", out _concepto);
            CargarVariable(dr, "NrDocumento", out _nrDocumento);

        }

    }
}
