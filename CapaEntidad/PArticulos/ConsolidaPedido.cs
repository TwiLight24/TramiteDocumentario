using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad.PArticulos
{
    public class ConsolidaPedido : Intellisoft.Project.Comun.Entidad.Base
    {
        #region Variables Privadas

        private int _idPeriodo = 0;
        private int _idEmpresa = 0;
        private int _idArticulo = 0;
        private string _nombreArticulo = string.Empty;
        private string _unidadMedida = string.Empty;
        private string _empresa = string.Empty;
        private string _area = string.Empty;
        private decimal _precio = 0;
        private int _cantidad = 0;
        private decimal _total = 0;

        List<ConsolidaPedido> _listConsolidaPedido = null; 

        #endregion

        #region Propiedades Públicas

        public int IdPeriodo
        {
            get { return _idPeriodo; }
            set { _idPeriodo = value; }
        }

        public int IdEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        public List<ConsolidaPedido> ListConsolidaPedido
        {
            get { return _listConsolidaPedido; }
            set { _listConsolidaPedido = value; }
        }

        public string NombreArticulo
        {
            get { return _nombreArticulo; }
            set { _nombreArticulo = value; }
        }


        public string UnidadMedida
        {
            get { return _unidadMedida; }
            set { _unidadMedida = value; }
        }


        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }


        //public string Area
        //{
        //    get { return _area; }
        //    set { _area = value; }
        //}


        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }



        public int IdArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }


        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }


        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        #endregion

        /// <summary>
        /// Carga los datos del DataRow en la Entidad
        /// </summary>
        /// <param name="dr">Datos a cargar en la Entidad</param>
        public override void CargarEntidad(System.Data.IDataReader dr)
        {
            base.CargarEntidad(dr);

          
            CargarVariable(dr, "IdPeriodo", out _idPeriodo);
            CargarVariable(dr, "IdEmpresa", out _idEmpresa);
            CargarVariable(dr, "IdArticulo", out _idArticulo);
            CargarVariable(dr, "NombreArticulo", out _nombreArticulo);
            CargarVariable(dr, "UnidadMedida", out _unidadMedida);
            CargarVariable(dr, "Precio", out _precio);
            CargarVariable(dr, "Cantidad", out _cantidad);
            CargarVariable(dr, "Total", out _total);
            CargarVariable(dr, "Empresa", out _empresa);
            CargarVariable(dr, "Area", out _area);
           
        }

    }
}
