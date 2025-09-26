namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;

    public class CECargos : Intellisoft.Project.Comun.Entidad.Base
    {
        private int _destino;
        //private DateTime fact;
        private int _idDocumento;
        private int _idCargo;
        private string _observacion;
        private string _tipo;
        private int _usuario;

        public int destino
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

        //public DateTime fecha
        //{
        //    get
        //    {
        //        return this.fact;
        //    }
        //    set
        //    {
        //        this.fact = value;
        //    }
        //}

        public int idCargo
        {
            get
            {
                return this._idCargo;
            }
            set
            {
                this._idCargo = value;
            }
        }

        public int idDocumento
        {
            get
            {
                return this._idDocumento;
            }
            set
            {
                this._idDocumento = value;
            }
        }

        public string observacion
        {
            get
            {
                return this._observacion;
            }
            set
            {
                this._observacion = value;
            }
        }

        public string tipo
        {
            get
            {
                return this._tipo;
            }
            set
            {
                this._tipo = value;
            }
        }

        public int usuario
        {
            get
            {
                return this._usuario;
            }
            set
            {
                this._usuario = value;
            }
        }


        #region Metodos Publicos

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>

                public override void CargarEntidad(System.Data.IDataReader dr)
        {
            //base.CargarEntidad(dr);

            CargarVariable(dr, "IdDocumento", out _idDocumento);
            CargarVariable(dr, "IdCargo", out _idCargo);
            //CargarVariable(dr, "NOrden", out oc);
            //CargarVariable(dr, "NCargo", out _idCargo);
            //CargarVariable(dr, "Proveedor", out _proveedor);
            //CargarVariable(dr, "Estado", out _estado);
            //CargarVariable(dr, "Empresa", out _empresa);
            //CargarVariable(dr, "Tipodoc", out _tipodoc);
            //CargarVariable(dr, "NroDoc", out _nroDoc);
            //CargarVariable(dr, "Monto", out _monto);

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

