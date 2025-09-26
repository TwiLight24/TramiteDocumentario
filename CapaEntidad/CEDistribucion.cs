namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;

    public class CEDistribucion : Intellisoft.Project.Comun.Entidad.Base
    {
        private int _idDocumento;
        private int _idMovimiento;
        private string _proveedor = string.Empty;
        private string _empresa;
        private string _tipodoc;
        private string _nroDoc;
        private decimal _monto;
        private string _estado;
        private int _destino;
        private int _usuarioAsignado;
        private string _nombreUsuarioAsignado;
        private string _distribuido = string.Empty;

        private DateTime _fechafin;
        private DateTime _fechaini;


        private List<CEDistribucion> _lstDistribucion = null;



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
        /// <summary>
        /// Monto
        /// </summary>
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
        /// Código del Empleado dado por la Empresa
        /// </summary>
        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        /// <summary>
        /// N° de Dococumento
        /// </summary>
        public string Nrodoc
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
        /// <summary>
        /// Tipo del Dcoumento
        /// </summary>
        public string Tipodoc
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

        /// <summary>
        /// Empresa
        /// </summary>
        public string Empresa
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
        /// <summary>
        /// Estado
        /// </summary>
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

        /// <summary>
        ///Fecha Fin
        /// </summary>
        public DateTime Fechafin
        {
            get
            {
                return this._fechafin;
            }
            set
            {
                this._fechafin = value;
            }
        }

        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime Fechaini
        {
            get
            {
                return this._fechaini;
            }
            set
            {
                this._fechaini = value;
            }
        }

        /// <summary>
        /// Usuario Destino
        /// </summary>
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

        /// <summary>
        /// Usuario Destino
        /// </summary>
        public int UsuarioAsignado
        {
            get
            {
                return this._usuarioAsignado;
            }
            set
            {
                this._usuarioAsignado = value;
            }
        }


                /// <summary>
        /// Usuario Destino
        /// </summary>
        public string _NombreUsuarioAsignado
        {
            get
            {
                return this._nombreUsuarioAsignado;
            }
            set
            {
                this._nombreUsuarioAsignado = value;
            }
        }


        

        /// Lista de datos de la Entidad
        /// </summary>
        public List<CEDistribucion> LstDistribucion
        {
            get { return _lstDistribucion; }
            set { _lstDistribucion = value; }
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
            CargarVariable(dr, "Proveedor", out _proveedor);
            CargarVariable(dr, "Estado", out _estado);
            CargarVariable(dr, "Empresa", out _empresa);
            CargarVariable(dr, "Tipodoc", out _tipodoc);
            CargarVariable(dr, "NroDoc", out _nroDoc);
            CargarVariable(dr, "Monto", out _monto);
            CargarVariable(dr, "NombreUsuarioAsignado", out _nombreUsuarioAsignado);
            

            //CargarVariable(dr, "fechadoc", out fdoc);
            //CargarVariable(dr, "fechaact", out fact);
            //CargarVariable(dr, "fechaven", out fven);
            //CargarVariable(dr, "fecharec", out frec);



        }

        #endregion


    }
}

